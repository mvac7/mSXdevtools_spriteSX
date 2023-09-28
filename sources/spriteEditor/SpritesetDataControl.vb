Public Class SpritesetDataControl



    Private _inkColor As Byte
    Private _backgroundColor As Byte

    Private AppConfig As Config

    Private Project As tMSgfXProject


    Public Event DataChanged()


    Public Overloads Property Name() As String
        Get
            Return Me.NameTextBox.Text
        End Get
        Set(value As String)
            If Not Me.NameTextBox Is Nothing Then
                Me.NameTextBox.Text = value
            End If
        End Set
    End Property



    Public ReadOnly Property SpriteSize() As SpriteMSX.SPRITE_SIZE
        Get
            Return Me.SizeComboBox.SelectedIndex + 1
        End Get
    End Property


    Public ReadOnly Property SpriteMode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me.ModeCombobox.SelectedIndex + 1
        End Get
    End Property


    Public ReadOnly Property PaletteID() As Integer
        Get
            Return Me.Project.Palettes.GetIDFromIndex(Me.PaletteComboBox.SelectedIndex)
        End Get
    End Property



    Public ReadOnly Property InkColor() As Byte
        Get
            Return Me.FGColorButton.SelectedColor
        End Get
    End Property



    Public ReadOnly Property BackgroundColor() As Byte
        Get
            Return Me.BGColorButton.SelectedColor
        End Get
    End Property



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub



    Public Sub Initialize(ByRef _config As Config, ByRef _project As tMSgfXProject, ByRef spriteset As SpritesetMSX, ByVal isUpdate As Boolean)

        'Dim _paletteID As Integer

        Me.AppConfig = _config
        Me.Project = _project

        RefreshPaletteSelector()

        If spriteset Is Nothing Then
            Me.Name = "SPRITESET00"
            Me.SizeComboBox.SelectedIndex = 1
            Me.ModeCombobox.SelectedIndex = 0
            Me.PaletteComboBox.SelectedIndex = 0
            Me._inkColor = 15
            Me._backgroundColor = 0
        Else
            'spriteset = Me.Project.SpriteSets.GetSpritesetByID(spritesetID)
            Me.Name = spriteset.Name
            Me.SizeComboBox.SelectedIndex = spriteset.Size - 1
            Me.ModeCombobox.SelectedIndex = spriteset.Mode - 1
            Me.PaletteComboBox.SelectedIndex = Me.Project.Palettes.GetIndexFromID(spriteset.ColorPalette.ID)
            Me._inkColor = spriteset.InkColor
            Me._backgroundColor = spriteset.BackgroundColor
        End If

        'Me.NameTextBox.Text = Me.Name

        RefreshColorSelectors()

        If isUpdate = True Then
            ColorsPiXelGroupBox.Visible = False
        End If

        AddHandler Me.PaletteComboBox.SelectedIndexChanged, AddressOf PaletteComboBox_SelectedIndexChanged
        AddHandler Me.SizeComboBox.SelectedIndexChanged, AddressOf SizeComboBox_SelectedIndexChanged
        AddHandler Me.ModeCombobox.SelectedIndexChanged, AddressOf ModeCombobox_SelectedIndexChanged
        AddHandler Me.FGColorButton.ColorChanged, AddressOf FGColorButton_ColorChanged
        AddHandler Me.BGColorButton.ColorChanged, AddressOf BGColorButton_ColorChanged

    End Sub




    Private Sub PaletteComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles PaletteComboBox.SelectedIndexChanged
        RefreshColorSelectors()
        RaiseEvent DataChanged()
    End Sub



    Private Sub SizeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles SizeComboBox.SelectedIndexChanged
        RaiseEvent DataChanged()
    End Sub

    Private Sub ModeCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles ModeCombobox.SelectedIndexChanged
        RaiseEvent DataChanged()
    End Sub

    Private Sub FGColorButton_ColorChanged(color As Byte) 'Handles FGColorButton.ColorChanged
        Me._inkColor = FGColorButton.SelectedColor
        RaiseEvent DataChanged()
    End Sub

    Private Sub BGColorButton_ColorChanged(color As Byte) 'Handles BGColorButton.ColorChanged
        Me._inkColor = BGColorButton.SelectedColor
        RaiseEvent DataChanged()
    End Sub



    Private Sub GetPaletteButton_Click(sender As Object, e As EventArgs) Handles GetPaletteButton.Click
        Dim PaletteDialog As Palette512Dialog

        PaletteDialog = New Palette512Dialog(Me.AppConfig, Me.Project, Me.PaletteID)

        If PaletteDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Me.Project.Palettes.Count > (Me.PaletteComboBox.Items.Count - 1) Then
                RefreshPaletteSelector()
            End If

            Me.PaletteComboBox.SelectedIndex = Me.Project.Palettes.GetIndexFromID(PaletteDialog.SelectedPaletteID)
        End If
    End Sub




    Private Sub RefreshPaletteSelector()
        Dim counter As Integer = 1
        Me.PaletteComboBox.Items.Clear()
        Me.PaletteComboBox.Items.Add("0 - " + Me.Project.Palettes.GetPaletteByID(0).Name)
        If Me.Project.Palettes.Count > 0 Then
            For Each aName As String In Me.Project.Palettes.GetNameList()
                Me.PaletteComboBox.Items.Add(CStr(counter) + " - " + aName)
                counter += 1
            Next
        End If
    End Sub



    Private Sub RefreshColorSelectors()
        Dim selectedPalette As PaletteMSX = Me.Project.Palettes.GetPalette(Me.PaletteComboBox.SelectedIndex)

        FGColorButton.Palette = selectedPalette
        FGColorButton.SetColor(Me._inkColor)
        BGColorButton.Palette = selectedPalette
        BGColorButton.SetColor(Me._backgroundColor)
    End Sub



End Class
