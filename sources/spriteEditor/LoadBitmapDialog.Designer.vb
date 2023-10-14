<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadBitmapDialog
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BGColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.BGcolorLabel = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SizeLabel = New System.Windows.Forms.Label()
        Me.SizeComboBox = New System.Windows.Forms.ComboBox()
        Me.ModeComboBox = New System.Windows.Forms.ComboBox()
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.Ok_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Cancel_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Title_Label = New mSXdevtools.GUI.Controls.piXelST_Label()
        Me.SomeTilesets = New System.Windows.Forms.Panel()
        Me.BankComboBox = New System.Windows.Forms.ComboBox()
        Me.BankLabel = New System.Windows.Forms.Label()
        Me.BGinfo = New System.Windows.Forms.Button()
        Me.patternsPictureBox = New System.Windows.Forms.PictureBox()
        Me.BottonsPanel.SuspendLayout()
        Me.SomeTilesets.SuspendLayout()
        CType(Me.patternsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BGColorButton
        '
        Me.BGColorButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BGColorButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGColorButton.Location = New System.Drawing.Point(307, 151)
        Me.BGColorButton.Margin = New System.Windows.Forms.Padding(0)
        Me.BGColorButton.MinimumSize = New System.Drawing.Size(32, 22)
        Me.BGColorButton.Name = "BGColorButton"
        Me.BGColorButton.Size = New System.Drawing.Size(40, 26)
        Me.BGColorButton.TabIndex = 256
        Me.ToolTip1.SetToolTip(Me.BGColorButton, "Color priority to use as a background in the conversion.")
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(94, 194)
        Me.NameTextBox.MaxLength = 128
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(256, 26)
        Me.NameTextBox.TabIndex = 19
        '
        'BGcolorLabel
        '
        Me.BGcolorLabel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGcolorLabel.Location = New System.Drawing.Point(156, 152)
        Me.BGcolorLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.BGcolorLabel.Name = "BGcolorLabel"
        Me.BGcolorLabel.Size = New System.Drawing.Size(146, 22)
        Me.BGcolorLabel.TabIndex = 257
        Me.BGcolorLabel.Text = "Background Color:"
        Me.BGcolorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NameLabel
        '
        Me.NameLabel.Location = New System.Drawing.Point(18, 196)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(70, 21)
        Me.NameLabel.TabIndex = 268
        Me.NameLabel.Text = "Name"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 21)
        Me.Label3.TabIndex = 276
        Me.Label3.Text = "Mode"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SizeLabel
        '
        Me.SizeLabel.Location = New System.Drawing.Point(18, 228)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(70, 21)
        Me.SizeLabel.TabIndex = 275
        Me.SizeLabel.Text = "Size"
        Me.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SizeComboBox
        '
        Me.SizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SizeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SizeComboBox.FormattingEnabled = True
        Me.SizeComboBox.Items.AddRange(New Object() {"8x8", "16x16"})
        Me.SizeComboBox.Location = New System.Drawing.Point(94, 226)
        Me.SizeComboBox.Name = "SizeComboBox"
        Me.SizeComboBox.Size = New System.Drawing.Size(256, 26)
        Me.SizeComboBox.TabIndex = 273
        '
        'ModeComboBox
        '
        Me.ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModeComboBox.FormattingEnabled = True
        Me.ModeComboBox.Items.AddRange(New Object() {"Monocolor", "Multicolor"})
        Me.ModeComboBox.Location = New System.Drawing.Point(94, 258)
        Me.ModeComboBox.Name = "ModeComboBox"
        Me.ModeComboBox.Size = New System.Drawing.Size(256, 26)
        Me.ModeComboBox.TabIndex = 274
        '
        'BottonsPanel
        '
        Me.BottonsPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.BottonsPanel.Controls.Add(Me.Ok_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 320)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(434, 44)
        Me.BottonsPanel.TabIndex = 278
        '
        'Ok_Button
        '
        Me.Ok_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Ok_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.Ok_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Ok_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Ok_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Ok_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Ok_Button.Location = New System.Drawing.Point(126, 4)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Ok_Button.Size = New System.Drawing.Size(202, 36)
        Me.Ok_Button.TabIndex = 127
        Me.Ok_Button.TabStop = False
        Me.Ok_Button.Text = "Get Spriteset"
        Me.Ok_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Cancel_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Cancellation
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.Location = New System.Drawing.Point(328, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Size = New System.Drawing.Size(102, 36)
        Me.Cancel_Button.TabIndex = 128
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Title_Label
        '
        Me.Title_Label.BackColor = System.Drawing.Color.RoyalBlue
        Me.Title_Label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_Label.ForeColor = System.Drawing.Color.White
        Me.Title_Label.Location = New System.Drawing.Point(0, 0)
        Me.Title_Label.Name = "Title_Label"
        Me.Title_Label.Padding = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.Title_Label.Size = New System.Drawing.Size(434, 32)
        Me.Title_Label.TabIndex = 277
        Me.Title_Label.Text = "Load Bitmap"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SomeTilesets
        '
        Me.SomeTilesets.Controls.Add(Me.BankComboBox)
        Me.SomeTilesets.Controls.Add(Me.BankLabel)
        Me.SomeTilesets.Location = New System.Drawing.Point(16, 45)
        Me.SomeTilesets.Name = "SomeTilesets"
        Me.SomeTilesets.Size = New System.Drawing.Size(334, 30)
        Me.SomeTilesets.TabIndex = 293
        '
        'BankComboBox
        '
        Me.BankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BankComboBox.Enabled = False
        Me.BankComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BankComboBox.FormattingEnabled = True
        Me.BankComboBox.Items.AddRange(New Object() {"Bank A", "Bank B", "Bank C"})
        Me.BankComboBox.Location = New System.Drawing.Point(78, 2)
        Me.BankComboBox.Name = "BankComboBox"
        Me.BankComboBox.Size = New System.Drawing.Size(147, 26)
        Me.BankComboBox.TabIndex = 16
        '
        'BankLabel
        '
        Me.BankLabel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BankLabel.Location = New System.Drawing.Point(2, 2)
        Me.BankLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.BankLabel.Name = "BankLabel"
        Me.BankLabel.Size = New System.Drawing.Size(70, 26)
        Me.BankLabel.TabIndex = 267
        Me.BankLabel.Text = "Bank:"
        Me.BankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BGinfo
        '
        Me.BGinfo.FlatAppearance.BorderSize = 0
        Me.BGinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BGinfo.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_info_24px
        Me.BGinfo.Location = New System.Drawing.Point(350, 150)
        Me.BGinfo.Name = "BGinfo"
        Me.BGinfo.Size = New System.Drawing.Size(26, 26)
        Me.BGinfo.TabIndex = 294
        Me.ToolTip1.SetToolTip(Me.BGinfo, "For a good conversion it is necessary to select the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "background color used in th" &
        "e loaded image.")
        Me.BGinfo.UseVisualStyleBackColor = True
        '
        'patternsPictureBox
        '
        Me.patternsPictureBox.BackColor = System.Drawing.Color.RoyalBlue
        Me.patternsPictureBox.Location = New System.Drawing.Point(94, 81)
        Me.patternsPictureBox.Name = "patternsPictureBox"
        Me.patternsPictureBox.Size = New System.Drawing.Size(256, 64)
        Me.patternsPictureBox.TabIndex = 269
        Me.patternsPictureBox.TabStop = False
        '
        'LoadBitmapDialog
        '
        Me.AcceptButton = Me.Ok_Button
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(434, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.BGinfo)
        Me.Controls.Add(Me.SomeTilesets)
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.Title_Label)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SizeLabel)
        Me.Controls.Add(Me.SizeComboBox)
        Me.Controls.Add(Me.ModeComboBox)
        Me.Controls.Add(Me.patternsPictureBox)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.BGColorButton)
        Me.Controls.Add(Me.BGcolorLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoadBitmapDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.BottonsPanel.ResumeLayout(False)
        Me.SomeTilesets.ResumeLayout(False)
        CType(Me.patternsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BGColorButton As mSXdevtools.GUI.Controls.ColorButton
    Friend WithEvents BGcolorLabel As System.Windows.Forms.Label
    Friend WithEvents NameLabel As Label
    Friend WithEvents patternsPictureBox As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SizeLabel As Label
    Friend WithEvents SizeComboBox As ComboBox
    Friend WithEvents ModeComboBox As ComboBox
    Friend WithEvents Title_Label As piXelST_Label
    Friend WithEvents BottonsPanel As Panel
    Friend WithEvents Ok_Button As piXelST_Button
    Friend WithEvents Cancel_Button As piXelST_Button
    Friend WithEvents SomeTilesets As Panel
    Friend WithEvents BankComboBox As ComboBox
    Friend WithEvents BankLabel As Label
    Friend WithEvents BGinfo As Button
End Class
