<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpritesetDataControl
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GetPaletteButton = New System.Windows.Forms.Button()
        Me.BackgroundColorLabel = New System.Windows.Forms.Label()
        Me.InkColorLabel = New System.Windows.Forms.Label()
        Me.FGColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.BGColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteLabel = New System.Windows.Forms.Label()
        Me.SizeLabel = New System.Windows.Forms.Label()
        Me.PaletteComboBox = New System.Windows.Forms.ComboBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.SizeComboBox = New System.Windows.Forms.ComboBox()
        Me.ModeCombobox = New System.Windows.Forms.ComboBox()
        Me.ModeLabel = New System.Windows.Forms.Label()
        Me.ColorsPiXelGroupBox = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.ColorsPiXelGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GetPaletteButton
        '
        Me.GetPaletteButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.palette3_x24
        Me.GetPaletteButton.Location = New System.Drawing.Point(435, 101)
        Me.GetPaletteButton.Name = "GetPaletteButton"
        Me.GetPaletteButton.Size = New System.Drawing.Size(34, 27)
        Me.GetPaletteButton.TabIndex = 298
        Me.GetPaletteButton.UseVisualStyleBackColor = True
        '
        'BackgroundColorLabel
        '
        Me.BackgroundColorLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackgroundColorLabel.Location = New System.Drawing.Point(27, 54)
        Me.BackgroundColorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BackgroundColorLabel.Name = "BackgroundColorLabel"
        Me.BackgroundColorLabel.Size = New System.Drawing.Size(100, 24)
        Me.BackgroundColorLabel.TabIndex = 239
        Me.BackgroundColorLabel.Text = "Background"
        Me.BackgroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InkColorLabel
        '
        Me.InkColorLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InkColorLabel.Location = New System.Drawing.Point(27, 23)
        Me.InkColorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.InkColorLabel.Name = "InkColorLabel"
        Me.InkColorLabel.Size = New System.Drawing.Size(100, 24)
        Me.InkColorLabel.TabIndex = 237
        Me.InkColorLabel.Text = "Ink"
        Me.InkColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FGColorButton
        '
        Me.FGColorButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FGColorButton.Location = New System.Drawing.Point(135, 23)
        Me.FGColorButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.FGColorButton.Name = "FGColorButton"
        Me.FGColorButton.Size = New System.Drawing.Size(32, 24)
        Me.FGColorButton.TabIndex = 236
        '
        'BGColorButton
        '
        Me.BGColorButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGColorButton.Location = New System.Drawing.Point(135, 54)
        Me.BGColorButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BGColorButton.Name = "BGColorButton"
        Me.BGColorButton.Size = New System.Drawing.Size(32, 24)
        Me.BGColorButton.TabIndex = 238
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.Color.White
        Me.NameTextBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.ForeColor = System.Drawing.Color.Black
        Me.NameTextBox.Location = New System.Drawing.Point(106, 12)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NameTextBox.MaxLength = 64
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(363, 23)
        Me.NameTextBox.TabIndex = 289
        '
        'PaletteLabel
        '
        Me.PaletteLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteLabel.Location = New System.Drawing.Point(0, 103)
        Me.PaletteLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PaletteLabel.Name = "PaletteLabel"
        Me.PaletteLabel.Size = New System.Drawing.Size(100, 28)
        Me.PaletteLabel.TabIndex = 294
        Me.PaletteLabel.Text = "Palette"
        Me.PaletteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SizeLabel
        '
        Me.SizeLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SizeLabel.Location = New System.Drawing.Point(0, 41)
        Me.SizeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(100, 28)
        Me.SizeLabel.TabIndex = 296
        Me.SizeLabel.Text = "Size"
        Me.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PaletteComboBox
        '
        Me.PaletteComboBox.BackColor = System.Drawing.Color.White
        Me.PaletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaletteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PaletteComboBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteComboBox.ForeColor = System.Drawing.Color.Black
        Me.PaletteComboBox.FormattingEnabled = True
        Me.PaletteComboBox.Location = New System.Drawing.Point(106, 103)
        Me.PaletteComboBox.Name = "PaletteComboBox"
        Me.PaletteComboBox.Size = New System.Drawing.Size(323, 24)
        Me.PaletteComboBox.TabIndex = 293
        '
        'NameLabel
        '
        Me.NameLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(0, 8)
        Me.NameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(100, 28)
        Me.NameLabel.TabIndex = 292
        Me.NameLabel.Text = "Name"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SizeComboBox
        '
        Me.SizeComboBox.BackColor = System.Drawing.Color.White
        Me.SizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SizeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SizeComboBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SizeComboBox.ForeColor = System.Drawing.Color.Black
        Me.SizeComboBox.FormattingEnabled = True
        Me.SizeComboBox.Items.AddRange(New Object() {"8x8", "16x16"})
        Me.SizeComboBox.Location = New System.Drawing.Point(106, 43)
        Me.SizeComboBox.Name = "SizeComboBox"
        Me.SizeComboBox.Size = New System.Drawing.Size(200, 24)
        Me.SizeComboBox.TabIndex = 295
        '
        'ModeCombobox
        '
        Me.ModeCombobox.BackColor = System.Drawing.Color.White
        Me.ModeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModeCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ModeCombobox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeCombobox.ForeColor = System.Drawing.Color.Black
        Me.ModeCombobox.FormattingEnabled = True
        Me.ModeCombobox.Items.AddRange(New Object() {"Monocolor (TMS9918A)", "Multicolor (V9938)"})
        Me.ModeCombobox.Location = New System.Drawing.Point(106, 73)
        Me.ModeCombobox.Name = "ModeCombobox"
        Me.ModeCombobox.Size = New System.Drawing.Size(200, 24)
        Me.ModeCombobox.TabIndex = 290
        '
        'ModeLabel
        '
        Me.ModeLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeLabel.Location = New System.Drawing.Point(0, 71)
        Me.ModeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ModeLabel.Name = "ModeLabel"
        Me.ModeLabel.Size = New System.Drawing.Size(100, 28)
        Me.ModeLabel.TabIndex = 291
        Me.ModeLabel.Text = "Mode"
        Me.ModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColorsPiXelGroupBox
        '
        Me.ColorsPiXelGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.ColorsPiXelGroupBox.BGColor = System.Drawing.Color.LightGray
        Me.ColorsPiXelGroupBox.Controls.Add(Me.BackgroundColorLabel)
        Me.ColorsPiXelGroupBox.Controls.Add(Me.InkColorLabel)
        Me.ColorsPiXelGroupBox.Controls.Add(Me.BGColorButton)
        Me.ColorsPiXelGroupBox.Controls.Add(Me.FGColorButton)
        Me.ColorsPiXelGroupBox.LineColor = System.Drawing.Color.DimGray
        Me.ColorsPiXelGroupBox.Location = New System.Drawing.Point(106, 146)
        Me.ColorsPiXelGroupBox.Name = "ColorsPiXelGroupBox"
        Me.ColorsPiXelGroupBox.Padding = New System.Windows.Forms.Padding(0)
        Me.ColorsPiXelGroupBox.Size = New System.Drawing.Size(200, 94)
        Me.ColorsPiXelGroupBox.TabIndex = 299
        Me.ColorsPiXelGroupBox.TabStop = False
        Me.ColorsPiXelGroupBox.Text = "Colors"
        '
        'SpritesetDataControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.ColorsPiXelGroupBox)
        Me.Controls.Add(Me.GetPaletteButton)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.PaletteLabel)
        Me.Controls.Add(Me.SizeLabel)
        Me.Controls.Add(Me.PaletteComboBox)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.SizeComboBox)
        Me.Controls.Add(Me.ModeCombobox)
        Me.Controls.Add(Me.ModeLabel)
        Me.MaximumSize = New System.Drawing.Size(500, 260)
        Me.MinimumSize = New System.Drawing.Size(500, 260)
        Me.Name = "SpritesetDataControl"
        Me.Size = New System.Drawing.Size(500, 260)
        Me.ColorsPiXelGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GetPaletteButton As Button
    Friend WithEvents BackgroundColorLabel As Label
    Friend WithEvents InkColorLabel As Label
    Friend WithEvents FGColorButton As ColorButton
    Friend WithEvents BGColorButton As ColorButton
    Friend WithEvents NameTextBox As TextBox
    Private WithEvents PaletteLabel As Label
    Private WithEvents SizeLabel As Label
    Friend WithEvents PaletteComboBox As ComboBox
    Private WithEvents NameLabel As Label
    Friend WithEvents SizeComboBox As ComboBox
    Friend WithEvents ModeCombobox As ComboBox
    Private WithEvents ModeLabel As Label
    Friend WithEvents ColorsPiXelGroupBox As piXelST_GroupBox
End Class
