Public Class SpritePanel16mode2
    Inherits SpritePanelBase
    'Implements ISpriteContainer



    Public Sub New(ByVal aPaletteData As MSXpalette)
        MyBase.New(aPaletteData)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' **** put your code here **** '

    End Sub



    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ClassTTT1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "SpritePanel16mode2"
        Me.SpriteSize = mSXdevtools.spriteSXED.SpritePanelBase.SPRITESIZES.SPRITE16x16
        Me.SpriteMode2 = True

        Me.ResumeLayout(False)

    End Sub



    Public Overrides Sub ShowSprite()
        'MyBase.ShowSprite()
        If Me.ENDinit And Not Me.PaletteData Is Nothing Then
            GeneratePreview()
            Application.DoEvents()
            GenerateMatrix()
            Application.DoEvents()
            showORstates()
            showColorLines()
            Application.DoEvents()
        End If
    End Sub




    Public Overrides Sub ClearSprite()

        AddUndo()

        _step = 0

        For i As Integer = 0 To _matrixdataSize
            pixelData(i) = False
        Next

        For Each aPic As PictureBox In colorPic
            aPic.BackColor = _PaletteData.getRGB(Me.inkColor)
            Me.colorValues(aPic.TabIndex) = Me.inkColor.id
            'orPic(aPic.TabIndex).TabStop = False
        Next

        SetORstate(False)

        ShowSprite()
    End Sub



    Public Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

        Dim TempValue As Byte = 0
        Dim contador As Integer = 0

        Me._WorkSprite = spriteData.clone()

        For y As Integer = 0 To 15

            TempValue = 0
            For x As Integer = 0 To 7
                contador = (y * 16) + (15 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)

                TempValue = spriteData.gfxData(y + 16) And Me.bite_MASKs(x)

                If TempValue = Me.bite_MASKs(x) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next

            TempValue = 0
            For x As Integer = 8 To 15
                contador = (y * 16) + (15 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)


                TempValue = spriteData.gfxData(y) And Me.bite_MASKs(x - 8)

                If TempValue = Me.bite_MASKs(x - 8) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next


            'tmpData(y) = TempValue
        Next


        ' actualiza los colores
        'Me.inkColor = Me.PaletteData.GetColor(spriteData.InkColor)
        'Me.changeBGColor(Me.PaletteData.GetColor(spriteData.BGcolor))

        Me.colorValues = spriteData.colorData.Clone

        For i As Integer = 0 To 15
            Me.colorPic(i).BackColor = _PaletteData.getRGB(spriteData.colorData(i))
            ORvalues(i) = spriteData.ORbitData(i)
        Next
        ' end colores


        ' actualiza y visualiza los datos del campo OR de linea
        'If spriteData.ORbitData Is Nothing Then
        '    For i As Integer = 0 To 15
        '        orPic(i).TabStop = False
        '    Next
        'Else
        '    For i As Integer = 0 To 15
        '        orPic(i).TabStop = spriteData.ORbitData(i)
        '    Next
        'End If

        'Me.showORstates()

        'Me.SpriteName = spriteData.name
        'Me.PatternNumber = spriteData.order

        'Me.ShowSprite()

        MyBase.SetSprite(spriteData)

    End Sub



    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetSprite() As SpriteMSX

        Dim tmpData(31) As Byte
        'ReDim tmpData(31)

        'Dim tmpORData(15) As Boolean

        Dim aBit As Byte
        Dim TempValue As Byte = 0
        Dim Counter As Integer = 0
        Dim byteCounter As Integer = 0

        'Dim aPixel As SpritePixel

        For y As Integer = 0 To 15
            TempValue = 0
            For x As Integer = 8 To 15
                Counter = (y * 16) + (15 - x)

                If pixelData(Counter) Then
                    aBit = 1
                Else
                    aBit = 0
                End If

                TempValue = TempValue + aBit * 2 ^ (x - 8)
            Next
            tmpData(byteCounter) = TempValue
            byteCounter += 1
        Next

        For y As Integer = 0 To 15
            TempValue = 0
            For x As Integer = 0 To 7
                Counter = (y * 16) + (15 - x)

                If pixelData(Counter) Then
                    aBit = 1
                Else
                    aBit = 0
                End If

                TempValue = TempValue + aBit * 2 ^ x
            Next
            tmpData(byteCounter) = TempValue
            byteCounter += 1
        Next

        'For y As Integer = 0 To 15
        '    tmpORData(y) = orPic(y).TabStop
        'Next

        If Me._WorkSprite Is Nothing Then
            Me._WorkSprite = New SpriteMSX(Me.SpriteName, SpriteBitmap.Clone, SpriteMSX.SPRITE_SIZE.SIZE16, Me.inkColor.id, Me.bgColor.id, tmpData.Clone(), colorValues.Clone(), ORvalues.Clone(), Me.PaletteData)
        Else
            Me._WorkSprite.name = Me.SpriteName

            Me._WorkSprite.size = SpriteMSX.SPRITE_SIZE.SIZE16
            Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.COLOR

            Me._WorkSprite.gfxData = tmpData.Clone
            Me._WorkSprite.colorData = colorValues.Clone
            Me._WorkSprite.ORbitData = ORvalues.Clone

            Me._WorkSprite.aBitmap = SpriteBitmap.Clone

            Me._WorkSprite.InkColor = Me.inkColor.id
            Me._WorkSprite.BGcolor = Me.bgColor.id

            Me._WorkSprite.PaletteData = Me.PaletteData
        End If

        Return Me._WorkSprite

    End Function


    Public Overrides Sub FlipVerticalSprite()

        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte
        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _HIGH + 1

        AddUndo()

        tempPixelData = pixelData.Clone
        tempColorData = Me.colorValues.Clone
        tempORdata = Me.ORvalues.Clone

        For i As Integer = 0 To _WIDTH
            Me.colorValues(i) = tempColorData(_WIDTH - i)
        Next

        For i As Integer = 0 To _HIGH
            Me.ORvalues(i) = tempORdata(_WIDTH - i)
        Next

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                pixelData(y * tsize + x) = tempPixelData((_HIGH - y) * tsize + x)
            Next
        Next

        ShowSprite()
    End Sub


    Public Overrides Sub MoveUp()
        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte
        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone
        tempORdata = Me.ORvalues.Clone

        For i As Integer = 0 To _HIGH - 1
            Me.ORvalues(i) = tempORdata(i + 1)
        Next
        'Me.orPic(_HIGH).TabStop = Me._ORselected
        Me.ORvalues(_HIGH) = Me._ORselected

        tempColorData = Me.colorValues.Clone
        For i As Integer = 0 To _HIGH - 1
            Me.colorValues(i) = tempColorData(i + 1)
        Next
        Me.colorValues(_HIGH) = Me.inkColor.id

        For x As Integer = 0 To _WIDTH
            For y As Integer = 0 To _HIGH - 1
                pixelData(y * tsize + x) = tempPixelData((y + 1) * tsize + x)
            Next
            pixelData(_HIGH * tsize + x) = False
        Next

        ShowSprite()

    End Sub



    Public Overrides Sub MoveDown()
        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte
        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone
        tempORdata = Me.ORvalues.Clone

        For i As Integer = 1 To _HIGH
            Me.ORvalues(i) = tempORdata(i - 1)
        Next
        Me.ORvalues(0) = Me._ORselected

        tempColorData = Me.colorValues.Clone
        For i As Integer = 1 To _HIGH
            Me.colorValues(i) = tempColorData(i - 1)
        Next
        Me.colorValues(0) = Me.inkColor.id

        For x As Integer = 0 To _WIDTH
            For y As Integer = 0 To _HIGH - 1
                pixelData((y + 1) * tsize + x) = tempPixelData(y * tsize + x)
            Next
            pixelData(x) = False
        Next

        ShowSprite()
    End Sub


End Class
