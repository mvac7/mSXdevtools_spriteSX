Public Class SpritePanel16mode2
    Inherits SpritePanelBase


    Public Sub New(ByVal aPaletteData As PaletteMSX)
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
        Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16
        Me.SpriteMode = SpriteMSX.SPRITE_MODE.COLOR

        Me.ResumeLayout(False)

    End Sub



    Public Overrides Sub ShowSprite()
        'MyBase.ShowSprite()
        If Me.ENDinit And Not Me.ColorPalette Is Nothing Then
            ShowSpritePreview()
            'Application.DoEvents()
            ShowSpriteZoomPanel()
            'Application.DoEvents()
            showORstates()
            ShowColorLines()
            'Application.DoEvents()
        End If

        'If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
        Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
        Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        'End If
    End Sub




    Public Overrides Sub ClearSprite()

        AddUndo()

        _step = 0

        'For i As Integer = 0 To _matrixdataSize
        '    pixelData(i) = False
        'Next


        For Each aPic As System.Windows.Forms.Button In colorPic
            aPic.BackColor = Me.ColorPalette.GetRGBColor(Me.InkColor)
            Me.colorValues(aPic.TabIndex) = Me.InkColor
        Next

        SetORstate(False)

        MyBase.ClearSprite()

        'ShowSprite()
    End Sub



    Public Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

        ' colors
        If spriteData.ColorData Is Nothing Then
            For i As Integer = 0 To 15
                Me.colorValues(i) = spriteData.InkColor
                Me.ORvalues(i) = False
            Next
        Else
            Me.colorValues = spriteData.ColorData.Clone
            Me.ORvalues = spriteData.ORbitData.Clone
        End If

        For i As Integer = 0 To 15
            Me.colorPic(i).BackColor = Me.ColorPalette.GetRGBColor(Me.colorValues(i))
        Next
        ' end colors


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

        'Dim aBit As Byte
        Dim tmpvalue As Byte = 0
        'Dim Counter As Integer = 0
        Dim byteCounter As Integer = 0

        'Dim aPixel As SpritePixel

        For y As Integer = 0 To 15
            tmpvalue = 0
            For x As Integer = 0 To 7
                'Counter = (y * 16) + x

                If Me.spriteLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x)
                End If
            Next
            tmpData(byteCounter) = tmpvalue
            byteCounter += 1
        Next


        For y As Integer = 0 To 15
            tmpvalue = 0
            For x As Integer = 8 To 15
                'Counter = (y * 16) + x

                If Me.spriteLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x - 8)
                End If
            Next
            tmpData(byteCounter) = tmpvalue
            byteCounter += 1
        Next

        

        'For y As Integer = 0 To 15
        '    tmpORData(y) = orPic(y).TabStop
        'Next

        'If Me._WorkSprite Is Nothing Then
        '    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO se esta usando un index fijo a 0
        '    Me._WorkSprite = New SpriteMSX(0, Me.SpriteName, SpriteBitmap.Clone, SpriteMSX.SPRITE_SIZE.SIZE16, Me.inkColor, Me.bgColor, tmpData.Clone(), colorValues.Clone(), ORvalues.Clone(), Me.Palette)
        'Else
        'Me._WorkSprite.name = Me.SpriteName

        Me._WorkSprite.size = SpriteMSX.SPRITE_SIZE.SIZE16
        Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.COLOR

        Me._WorkSprite.patternData = tmpData.Clone
        Me._WorkSprite.colorData = colorValues.Clone
        Me._WorkSprite.ORbitData = ORvalues.Clone

        'Me._WorkSprite.aBitmap = SpriteBitmap.Clone

        Me._WorkSprite.InkColor = Me.InkColor
        Me._WorkSprite.BackgroundColor = Me.BackgroundColor

        Me._WorkSprite.SetColorPalette(Me.ColorPalette)

        Me._WorkSprite.refresh()
        'End If

        Return Me._WorkSprite

    End Function



    Public Overrides Sub FlipVertical()

        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte
        'Dim tempPixelData(_matrixdataSize) As Boolean
        'Dim tempPixelData As ArrayList = Me.spriteLines.Clone
        'Dim tsize As Integer = _HIGH + 1

        AddUndo()

        'tempPixelData = pixelData.Clone
        tempColorData = Me.colorValues.Clone
        tempORdata = Me.ORvalues.Clone

        For i As Integer = 0 To _WIDTH
            Me.colorValues(i) = tempColorData(_WIDTH - i)
        Next

        For i As Integer = 0 To _HIGH
            Me.ORvalues(i) = tempORdata(_WIDTH - i)
        Next

        'For y As Integer = 0 To _HIGH
        '    For x As Integer = 0 To _WIDTH
        '        pixelData(y * tsize + x) = tempPixelData((_HIGH - y) * tsize + x)
        '    Next
        'Next

        'For y As Integer = 0 To _HIGH
        '    Me.spriteLines.Item(y) = tempPixelData(_HIGH - y)    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO no permite hacer un clone. Desconozco si al ser un Array realiza una copia automatica o pasa una referencia ???
        'Next

        'ShowSprite()

        MyBase.FlipVertical()

    End Sub



    Public Overrides Sub MoveUp(ByVal rotate As Boolean)

        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte

        Dim rotateColor As Byte
        Dim rotateOR As Boolean

        AddUndo()

        tempColorData = Me.colorValues.Clone
        tempORdata = Me.ORvalues.Clone

        rotateColor = tempColorData(0)
        rotateOR = tempORdata(0)

        For i As Integer = 0 To _HIGH - 1
            Me.colorValues(i) = tempColorData(i + 1)
        Next

        For i As Integer = 0 To _HIGH - 1
            Me.ORvalues(i) = tempORdata(i + 1)
        Next

        If rotate = True Then
            Me.colorValues(_HIGH) = rotateColor
            Me.ORvalues(_HIGH) = rotateOR
        Else
            Me.colorValues(_HIGH) = Me.InkColor
            Me.ORvalues(_HIGH) = Me._ORselected
        End If


        MyBase.MoveUp(rotate)

    End Sub



    Public Overrides Sub MoveDown(ByVal rotate As Boolean)

        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte

        Dim rotateColor As Byte
        Dim rotateOR As Boolean

        AddUndo()

        tempColorData = Me.colorValues.Clone
        tempORdata = Me.ORvalues.Clone

        rotateColor = tempColorData(_HIGH)
        rotateOR = tempORdata(_HIGH)

        For i As Integer = 1 To _HIGH
            Me.colorValues(i) = tempColorData(i - 1)
        Next

        For i As Integer = 1 To _HIGH
            Me.ORvalues(i) = tempORdata(i - 1)
        Next

        If rotate = True Then
            Me.colorValues(0) = rotateColor
            Me.ORvalues(0) = rotateOR
        Else
            Me.colorValues(0) = Me.InkColor
            Me.ORvalues(0) = Me._ORselected
        End If


        MyBase.MoveDown(rotate)

    End Sub


End Class
