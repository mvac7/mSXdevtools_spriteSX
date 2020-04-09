Public Class SpritePixel

    Event PixelChanged(ByVal sender As SpritePixel)

    Public ID As String
    Public spriteX As Byte
    Public spriteY As Byte

    Private _inkColor As Color
    Private _bgColor As Color
    Private _value As Boolean


    Public Property inkColor() As Color
        Get
            Return _inkColor
        End Get
        Set(ByVal value As Color)
            _inkColor = value
            If _value Then Me.PixelBox.BackColor = _inkColor
        End Set
    End Property


    Public Property bgColor() As Color
        Get
            Return _bgColor
        End Get
        Set(ByVal value As Color)
            _bgColor = value
            If Not _value Then Me.PixelBox.BackColor = _bgColor
        End Set
    End Property


    Public Property value() As Boolean
        Get
            Return _value
        End Get
        Set(ByVal value As Boolean)
            _value = value
            If _value Then
                Me.PixelBox.BackColor = _inkColor
            Else
                Me.PixelBox.BackColor = _bgColor
            End If
            RaiseEvent PixelChanged(Me)
        End Set
    End Property


    'Private Sub PixelBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PixelBox.MouseDown

    '    If value Then
    '        value = False
    '        PixelBox.BackColor = bgColor
    '    Else
    '        value = True
    '        PixelBox.BackColor = inkColor
    '    End If

    'End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.inkColor = Color.White
        Me.bgColor = Color.Black

        Me._value = False
        Me.spriteX = 0
        Me.spriteY = 0

    End Sub



    Public Sub New(ByVal aID As String, ByVal posX As Byte, ByVal posY As Byte, ByVal aInkColor As Color, ByVal aBGColor As Color)
        Try

            ' Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.ID = aID

            Me.spriteX = posX
            Me.spriteY = posY

            Me.inkColor = aInkColor
            Me.bgColor = aBGColor

            Me._value = False

        Catch ex As Exception

        End Try
    End Sub



    'Private Sub PixelBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PixelBox.MouseClick

    'End Sub



    'Private Sub PixelBox_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PixelBox.MouseEnter
    '    If e.Button = MouseButtons.Left Then
    '        PixelBox.BackColor = Me.inkColor
    '    End If

    '    If e.Button = MouseButtons.Right Then
    '        PixelBox.BackColor = Me.bgColor
    '    End If
    'End Sub

    'Private Sub PixelBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PixelBox.MouseMove
    '    If e.Button = MouseButtons.Left Then
    '        PixelBox.BackColor = Me.inkColor
    '    End If

    '    If e.Button = MouseButtons.Right Then
    '        PixelBox.BackColor = Me.bgColor
    '    End If

    'End Sub


    'Private Sub PixelBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PixelBox.MouseClick
    '    If e.Button = MouseButtons.Left Then
    '        Me.value = True
    '        'sender.TabStop = True


    '    End If

    '    If e.Button = MouseButtons.Right Then
    '        Me.value = False
    '        'sender.BackColor = Me.bgColor.RGBColor
    '        'sender.TabStop = False

    '    End If
    'End Sub
End Class
