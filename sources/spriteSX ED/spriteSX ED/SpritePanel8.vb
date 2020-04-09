Public Class SpritePanel8
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
        Me.Name = "SpritePanel8"
        Me.SpriteSize = mSXdevtools.spriteSXED.SpritePanelBase.SPRITESIZES.SPRITE8x8
        Me.SpriteMode2 = False

        Me.ResumeLayout(False)

    End Sub



    'Overrides Sub ClearSprite()

    '    AddUndo()

    '    _step = 0

    '    For i As Integer = 0 To _matrixdataSize
    '        pixelData(i) = False
    '    Next

    '    For Each aPic As PictureBox In colorPic
    '        aPic.BackColor = _PaletteData.getRGB(Me.inkColor)
    '        Me.colorValues(aPic.TabIndex) = Me.inkColor.id
    '        'orPic(aPic.TabIndex).TabStop = False
    '    Next

    '    SetORstate(False)

    '    ShowSprite()
    'End Sub



    Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)


        Dim TempValue As Byte = 0
        Dim contador As Integer = 0

        Me._WorkSprite = spriteData.clone()

        For y As Integer = 0 To _HIGH

            TempValue = 0
            For x As Integer = 0 To _WIDTH
                contador = y * 8 + (7 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)

                TempValue = spriteData.gfxData(y) And Me.bite_MASKs(x)

                If TempValue = Me.bite_MASKs(x) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next

        Next

        'Me.inkColor = Me.PaletteData.GetColor(spriteData.InkColor)
        'Me.bgColor = Me.PaletteData.GetColor(spriteData.BGcolor)


        MyBase.SetSprite(spriteData)

    End Sub


    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overrides Function GetSprite() As SpriteMSX

        Dim tmpData(7) As Byte
        'ReDim tmpData(31)

        Dim aBit As Byte
        Dim TempValue As Byte = 0
        Dim Counter As Integer = 0
        Dim byteCounter As Integer = 0

        For y As Integer = 0 To 7
            TempValue = 0
            For x As Integer = 0 To 7
                Counter = y * 8 + (7 - x)

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


        If Me._WorkSprite Is Nothing Then
            Me._WorkSprite = New SpriteMSX(Me.SpriteName, SpriteBitmap.Clone, SpriteMSX.SPRITE_SIZE.SIZE8, Me.inkColor.id, Me.bgColor.id, tmpData.Clone, Me.PaletteData)
        Else
            Me._WorkSprite.name = Me.SpriteName

            Me._WorkSprite.size = SpriteMSX.SPRITE_SIZE.SIZE8
            Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.MONO

            Me._WorkSprite.gfxData = tmpData.Clone
            Me._WorkSprite.aBitmap = SpriteBitmap.Clone

            Me._WorkSprite.InkColor = Me._inkColor.id
            Me._WorkSprite.BGcolor = Me._bgColor.id

            Me._WorkSprite.PaletteData = Me.PaletteData
        End If

        Return Me._WorkSprite

    End Function






End Class
