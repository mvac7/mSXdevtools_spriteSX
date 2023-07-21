Public Class SpritePanel16
    Inherits SpritePanelBase
    'Implements ISpriteContainer



    Public Sub New(ByVal aPaletteData As iPaletteMSX)
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
        Me.Name = "SpritePanel16"
        Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16
        Me.SpriteMode = SpriteMSX.SPRITE_MODE.MONO

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



    'Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

    '    'Dim TempValue As Byte = 0
    '    'Dim contador As Integer = 0

    '    'Me._WorkSprite = spriteData.Clone()
    '    Me._WorkSprite = New SpriteMSX


    '    'For y As Integer = 0 To 15

    '    '    TempValue = 0
    '    '    For x As Integer = 0 To 7
    '    '        'contador = (y * 16) + x

    '    '        TempValue = spriteData.patternData(y) And Me.bitMASKi(x)

    '    '        If TempValue = Me.bitMASKi(x) Then
    '    '            'pixelData(contador) = True
    '    '            Me.spriteLines.Item(y)(x) = True
    '    '        Else
    '    '            'pixelData(contador) = False
    '    '            Me.spriteLines.Item(y)(x) = False
    '    '        End If

    '    '    Next

    '    '    TempValue = 0
    '    '    For x As Integer = 8 To 15
    '    '        'contador = (y * 16) + x

    '    '        TempValue = spriteData.patternData(y + 16) And Me.bitMASKi(x - 8)

    '    '        If TempValue = Me.bitMASKi(x - 8) Then
    '    '            'pixelData(contador) = True
    '    '            spriteLines.Item(y)(x) = True
    '    '        Else
    '    '            'pixelData(contador) = False
    '    '            spriteLines.Item(y)(x) = False
    '    '        End If

    '    '    Next

    '    'Next


    '    'Me.spritePicture.Refresh()

    '    MyBase.SetSprite(spriteData)

    'End Sub



    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overrides Function GetSprite() As SpriteMSX

        Dim tmpData(31) As Byte

        Dim tmpvalue As Byte = 0
        Dim byteCounter As Integer = 0

        For y As Integer = 0 To 15
            tmpvalue = 0
            For x As Integer = 0 To 7
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
                If Me.spriteLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x - 8)
                End If
            Next
            tmpData(byteCounter) = tmpvalue
            byteCounter += 1
        Next


        'Me._WorkSprite.name = Me.SpriteName

        Me._WorkSprite.Size = SpriteMSX.SPRITE_SIZE.SIZE16
        Me._WorkSprite.Mode = SpriteMSX.SPRITE_MODE.MONO

        Me._WorkSprite.patternData = tmpData.Clone

        Me._WorkSprite.InkColor = Me._inkColor
        Me._WorkSprite.BackgroundColor = Me._bgColor

        Me._WorkSprite.Palette = Me.Palette

        Me._WorkSprite.refresh()
        'End If

        Return Me._WorkSprite

    End Function



    Public Overrides Sub ClearSprite()

        AddUndo()

        _step = 0

        MyBase.ClearSprite()

    End Sub



    Public Overrides Sub MoveUp()

        AddUndo()

        MyBase.MoveUp()

    End Sub



    Public Overrides Sub MoveDown()

        AddUndo()

        MyBase.MoveDown()

    End Sub



    Public Overrides Sub FlipVertical()

        AddUndo()

        MyBase.FlipVertical()

    End Sub



End Class
