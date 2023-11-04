Public Class SpritePanel8
    Inherits SpritePanelBase
    'Implements ISpriteContainer



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
        Me.Name = "SpritePanel8"
        Me.SpriteSize = iVDP.SPRITE_SIZE.SIZE8
        Me.SpriteMode = iVDP.SPRITE_MODE.MONO

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
                If Me.PatternLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x)
                End If
            Next
            tmpData(byteCounter) = tmpvalue
            byteCounter += 1
        Next

        Me._WorkSprite.Size = iVDP.SPRITE_SIZE.SIZE8
        Me._WorkSprite.Mode = iVDP.SPRITE_MODE.MONO

        Me._WorkSprite.patternData = tmpData.Clone

        Me._WorkSprite.InkColor = Me._inkColor
        Me._WorkSprite.BackgroundColor = Me._bgColor

        Me._WorkSprite.SetColorPalette(Me.ColorPalette)

        Me._WorkSprite.refresh()


        Return Me._WorkSprite

    End Function




End Class
