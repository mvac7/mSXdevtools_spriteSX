Public Class SpritePanel8mode2
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
        Me.Name = "SpritePanel8mode2"
        Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8
        Me.SpriteMode = SpriteMSX.SPRITE_MODE.COLOR

        Me.ResumeLayout(False)

    End Sub



    Public Overrides Sub ShowSprite()
        'MyBase.ShowSprite()
        If Me.ENDinit And Not Me.Palette Is Nothing Then
            ShowSpritePreview()
            'Application.DoEvents()
            ShowSpriteZoomPanel()
            'Application.DoEvents()
            showORstates()
            showColorLines()
            'Application.DoEvents()
        End If
    End Sub



    Public Overrides Sub ClearSprite()

        AddUndo()

        _step = 0

        'For i As Integer = 0 To _matrixdataSize
        '    pixelData(i) = False
        'Next

        For Each aPic As System.Windows.Forms.Button In colorPic
            aPic.BackColor = Me._Palette.GetRGBColor(Me.InkColor)
            Me.colorValues(aPic.TabIndex) = Me.InkColor
            'orPic(aPic.TabIndex).TabStop = False
        Next

        SetORstate(False)

        MyBase.ClearSprite()
        'ShowSprite()
    End Sub



    Public Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

        ' colors
        ' default values for different sprite copy situations
        For i As Integer = 0 To 15
            Me.colorValues(i) = spriteData.InkColor
            Me.ORvalues(i) = False
        Next
        '

        If Not spriteData.ColorData Is Nothing Then
            Me.colorValues = spriteData.ColorData.Clone
            Me.ORvalues = spriteData.ORbitData.Clone
        End If

        For i As Integer = 0 To 7
            Me.colorPic(i).BackColor = Me._Palette.GetRGBColor(Me.colorValues(i))
        Next
        ' end colors


        MyBase.SetSprite(spriteData)

    End Sub


    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overrides Function GetSprite() As SpriteMSX

        Dim tmpData(7) As Byte
        Dim tmpColor(15) As Byte

        Dim tmpvalue As Byte = 0
        Dim byteCounter As Integer = 0

        For y As Integer = 0 To 7
            tmpvalue = 0
            For x As Integer = 0 To 7
                If Me.spriteLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x)
                End If
            Next
            tmpData(byteCounter) = tmpvalue
            byteCounter += 1
        Next

        Me._WorkSprite.Size = SpriteMSX.SPRITE_SIZE.SIZE8
        Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.COLOR

        Me._WorkSprite.patternData = tmpData.Clone
        Me._WorkSprite.colorData = colorValues.Clone
        Me._WorkSprite.ORbitData = ORvalues.Clone

        'Me._WorkSprite.aBitmap = SpriteBitmap.Clone

        Me._WorkSprite.InkColor = Me._inkColor
        Me._WorkSprite.BackgroundColor = Me._bgColor

        Me._WorkSprite.Palette = Me._Palette

        Me._WorkSprite.refresh()


        Return Me._WorkSprite

    End Function



    Public Overrides Sub FlipVertical()

        Dim tempORdata(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte

        AddUndo()

        tempColorData = Me.colorValues.Clone
        tempORdata = Me.ORvalues.Clone

        For i As Integer = 0 To _WIDTH
            Me.colorValues(i) = tempColorData(_WIDTH - i)
        Next

        For i As Integer = 0 To _HIGH
            Me.ORvalues(i) = tempORdata(_WIDTH - i)
        Next

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
