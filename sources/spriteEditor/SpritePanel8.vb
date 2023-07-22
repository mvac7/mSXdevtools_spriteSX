Public Class SpritePanel8
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
        Me.Name = "SpritePanel8"
        Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8
        Me.SpriteMode = SpriteMSX.SPRITE_MODE.MONO

        Me._WorkSprite = New SpriteMSX

        Me.ResumeLayout(False)

    End Sub



    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overrides Function GetSprite() As SpriteMSX

        Dim tmpData(7) As Byte

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
        Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.MONO

        Me._WorkSprite.patternData = tmpData.Clone

        Me._WorkSprite.InkColor = Me._inkColor
        Me._WorkSprite.BackgroundColor = Me._bgColor

        Me._WorkSprite.Palette = Me.Palette

        Me._WorkSprite.refresh()


        Return Me._WorkSprite

    End Function



    Public Overrides Sub ClearSprite()

        AddUndo()

        _step = 0


        MyBase.ClearSprite()

    End Sub


    Public Overrides Sub MoveUp(ByVal rotate As Boolean)

        AddUndo()

        MyBase.MoveUp(rotate)

    End Sub


    Public Overrides Sub MoveDown(ByVal rotate As Boolean)

        AddUndo()

        MyBase.MoveDown(rotate)

    End Sub


    Public Overrides Sub FlipVertical()

        AddUndo()

        MyBase.FlipVertical()

    End Sub



End Class
