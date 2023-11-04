Public Class SpritePanel8mode2
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
        Me.Name = "SpritePanel8mode2"
        Me.SpriteSize = iVDP.SPRITE_SIZE.SIZE8
        Me.SpriteMode = iVDP.SPRITE_MODE.COLOR

        Me.ResumeLayout(False)

    End Sub



    Public Overrides Sub ShowSprite()
        'MyBase.ShowSprite()
        If Me.ENDinit And Not Me.ColorPalette Is Nothing Then
            ShowSpritePreview()
            'Application.DoEvents()
            ShowSpriteZoomPanel()
            'Application.DoEvents()
            ShowECstates()
            ShowCCstates()
            ShowICstates()
            ShowColorLines()
            'Application.DoEvents()
        End If
    End Sub



    Public Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

        ' colors
        ' default values for different sprite copy situations
        'For i As Integer = 0 To 15
        '    Me.colorValues(i) = spriteData.InkColor
        '    Me.CCvalues(i) = False
        'Next
        ''

        'If Not spriteData.ColorData Is Nothing Then
        '    Me.colorValues = spriteData.ColorData.Clone
        '    Me.CCvalues = spriteData.CCbitData.Clone
        'End If

        Me.ColorLines = spriteData.ColorData.Clone
        Me.ICLines = spriteData.ICbitData.Clone
        Me.CCLines = spriteData.CCbitData.Clone
        Me.ECLines = spriteData.ECbitData.Clone

        For nLine As Integer = 0 To 7
            Me.LineInkButtons(nLine).BackColor = Me.ColorPalette.GetRGBColor(Me.ColorLines(nLine))
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

        Dim patternValues(7) As Byte
        Dim tmpColor(15) As Byte
        Dim tmpvalue As Byte

        For y As Integer = 0 To 7
            tmpvalue = 0
            For x As Integer = 0 To 7
                If Me.PatternLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x)
                End If
            Next
            patternValues(y) = tmpvalue
        Next

        Me._WorkSprite.Size = iVDP.SPRITE_SIZE.SIZE8
        Me._WorkSprite.Mode = iVDP.SPRITE_MODE.COLOR

        Me._WorkSprite.patternData = patternValues.Clone
        Me._WorkSprite.ColorData = Me.ColorLines.Clone
        Me._WorkSprite.ICbitData = Me.ICLines.Clone
        Me._WorkSprite.CCbitData = Me.CCLines.Clone
        Me._WorkSprite.ECbitData = Me.ECLines.Clone

        Me._WorkSprite.InkColor = Me._inkColor
        Me._WorkSprite.BackgroundColor = Me._bgColor

        Me._WorkSprite.SetColorPalette(Me.ColorPalette)

        Me._WorkSprite.refresh()


        Return Me._WorkSprite

    End Function



End Class
