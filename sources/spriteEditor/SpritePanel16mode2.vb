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
        Me.SpriteSize = iVDP.SPRITE_SIZE.SIZE16
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

        'If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
        Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
        Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        'End If
    End Sub



    Public Overrides Sub SetSprite(ByVal spriteData As SpriteMSX)

        Dim nLine As Integer

        ' colors
        If spriteData.ColorData Is Nothing Then
            For nLine = 0 To 15
                Me.ColorLines(nLine) = spriteData.InkColor
                Me.ICLines(nLine) = False
                Me.CCLines(nLine) = False
                Me.ECLines(nLine) = False
            Next
        Else
            Me.ColorLines = spriteData.ColorData.Clone
            Me.ICLines = spriteData.ICbitData.Clone
            Me.CCLines = spriteData.CCbitData.Clone
            Me.ECLines = spriteData.ECbitData.Clone
        End If

        For nLine = 0 To 15
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

        Dim patternValues(31) As Byte
        Dim tmpvalue As Byte
        Dim byteCounter As Integer = 0

        For y As Integer = 0 To 15
            tmpvalue = 0
            For x As Integer = 0 To 7
                If Me.PatternLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x)
                End If
            Next
            patternValues(byteCounter) = tmpvalue
            byteCounter += 1
        Next


        For y As Integer = 0 To 15
            tmpvalue = 0
            For x As Integer = 8 To 15
                If Me.PatternLines.Item(y)(x) Then
                    tmpvalue = tmpvalue Or Me.bitMASKi(x - 8)
                End If
            Next
            patternValues(byteCounter) = tmpvalue
            byteCounter += 1
        Next


        Me._WorkSprite.Size = iVDP.SPRITE_SIZE.SIZE16
        Me._WorkSprite.Mode = iVDP.SPRITE_MODE.COLOR

        Me._WorkSprite.patternData = patternValues.Clone
        Me._WorkSprite.ColorData = Me.ColorLines.Clone
        Me._WorkSprite.ICbitData = Me.ICLines.Clone
        Me._WorkSprite.CCbitData = Me.CCLines.Clone
        Me._WorkSprite.ECbitData = Me.ECLines.Clone

        Me._WorkSprite.InkColor = Me.InkColor
        Me._WorkSprite.BackgroundColor = Me.BackgroundColor

        Me._WorkSprite.SetColorPalette(Me.ColorPalette)

        Me._WorkSprite.Refresh()


        Return Me._WorkSprite

    End Function



End Class
