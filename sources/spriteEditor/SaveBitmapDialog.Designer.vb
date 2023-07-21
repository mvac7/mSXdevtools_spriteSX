<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveBitmapDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveBitmapDialog))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.BankComboBox = New System.Windows.Forms.ComboBox()
        Me.BankALabel = New System.Windows.Forms.Label()
        Me.PaletteComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BankBComboBox = New System.Windows.Forms.ComboBox()
        Me.BankCComboBox = New System.Windows.Forms.ComboBox()
        Me.BankBLabel = New System.Windows.Forms.Label()
        Me.BankCLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.Ok_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Cancel_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Title_Label = New mSXdevtools.GUI.Controls.piXelST_Label()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        Me.BottonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BankComboBox
        '
        Me.BankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BankComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BankComboBox.FormattingEnabled = True
        Me.BankComboBox.Items.AddRange(New Object() {"Bank A", "Bank B", "Bank C"})
        Me.BankComboBox.Location = New System.Drawing.Point(88, 48)
        Me.BankComboBox.Name = "BankComboBox"
        Me.BankComboBox.Size = New System.Drawing.Size(256, 26)
        Me.BankComboBox.TabIndex = 5
        '
        'BankALabel
        '
        Me.BankALabel.Location = New System.Drawing.Point(2, 48)
        Me.BankALabel.Name = "BankALabel"
        Me.BankALabel.Size = New System.Drawing.Size(80, 23)
        Me.BankALabel.TabIndex = 20
        Me.BankALabel.Text = "Bank A"
        Me.BankALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PaletteComboBox
        '
        Me.PaletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaletteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PaletteComboBox.FormattingEnabled = True
        Me.PaletteComboBox.Items.AddRange(New Object() {"Monocolor", "Multicolor"})
        Me.PaletteComboBox.Location = New System.Drawing.Point(88, 374)
        Me.PaletteComboBox.Name = "PaletteComboBox"
        Me.PaletteComboBox.Size = New System.Drawing.Size(256, 26)
        Me.PaletteComboBox.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(2, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Palette"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BankBComboBox
        '
        Me.BankBComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BankBComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BankBComboBox.FormattingEnabled = True
        Me.BankBComboBox.Items.AddRange(New Object() {"Bank A", "Bank B", "Bank C"})
        Me.BankBComboBox.Location = New System.Drawing.Point(88, 80)
        Me.BankBComboBox.Name = "BankBComboBox"
        Me.BankBComboBox.Size = New System.Drawing.Size(256, 26)
        Me.BankBComboBox.TabIndex = 6
        '
        'BankCComboBox
        '
        Me.BankCComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BankCComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BankCComboBox.FormattingEnabled = True
        Me.BankCComboBox.Items.AddRange(New Object() {"Bank A", "Bank B", "Bank C"})
        Me.BankCComboBox.Location = New System.Drawing.Point(88, 112)
        Me.BankCComboBox.Name = "BankCComboBox"
        Me.BankCComboBox.Size = New System.Drawing.Size(256, 26)
        Me.BankCComboBox.TabIndex = 7
        '
        'BankBLabel
        '
        Me.BankBLabel.Location = New System.Drawing.Point(2, 80)
        Me.BankBLabel.Name = "BankBLabel"
        Me.BankBLabel.Size = New System.Drawing.Size(80, 23)
        Me.BankBLabel.TabIndex = 27
        Me.BankBLabel.Text = "Bank B"
        Me.BankBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BankCLabel
        '
        Me.BankCLabel.Location = New System.Drawing.Point(2, 112)
        Me.BankCLabel.Name = "BankCLabel"
        Me.BankCLabel.Size = New System.Drawing.Size(80, 23)
        Me.BankCLabel.TabIndex = 28
        Me.BankCLabel.Text = "Bank C"
        Me.BankCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(88, 342)
        Me.NameTextBox.MaxLength = 128
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(256, 26)
        Me.NameTextBox.TabIndex = 36
        '
        'NameLabel
        '
        Me.NameLabel.Location = New System.Drawing.Point(2, 342)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(80, 23)
        Me.NameLabel.TabIndex = 37
        Me.NameLabel.Text = "Name"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BottonsPanel
        '
        Me.BottonsPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.BottonsPanel.Controls.Add(Me.Ok_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 430)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(414, 44)
        Me.BottonsPanel.TabIndex = 38
        '
        'Ok_Button
        '
        Me.Ok_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Ok_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Save
        Me.Ok_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ok_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Ok_Button.ForeColor = System.Drawing.Color.Black
        Me.Ok_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.icon_Save
        Me.Ok_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Ok_Button.Location = New System.Drawing.Point(170, 4)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Ok_Button.Size = New System.Drawing.Size(138, 36)
        Me.Ok_Button.TabIndex = 127
        Me.Ok_Button.TabStop = False
        Me.Ok_Button.Text = "Save"
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
        Me.Cancel_Button.Location = New System.Drawing.Point(308, 4)
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
        Me.Title_Label.Size = New System.Drawing.Size(414, 32)
        Me.Title_Label.TabIndex = 278
        Me.Title_Label.Text = "Save Bitmap"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TMS9918Aviewer
        '
        Me.TMS9918Aviewer.BackgroundColor = CType(4, Byte)
        Me.TMS9918Aviewer.BackgroundImage = CType(resources.GetObject("TMS9918Aviewer.BackgroundImage"), System.Drawing.Image)
        Me.TMS9918Aviewer.BorderColor = CType(4, Byte)
        Me.TMS9918Aviewer.ControlType = mSXdevtools.GUI.TMS9918A.TMS9918A.CONTROL_TYPE.VIEWER
        Me.TMS9918Aviewer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TMS9918Aviewer.InkColor = CType(15, Byte)
        Me.TMS9918Aviewer.IsShowSprites = False
        Me.TMS9918Aviewer.Location = New System.Drawing.Point(88, 145)
        Me.TMS9918Aviewer.Margin = New System.Windows.Forms.Padding(4)
        Me.TMS9918Aviewer.Name = "TMS9918Aviewer"
        Me.TMS9918Aviewer.ScreenMode = mSXdevtools.DataStructures.iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.Size = New System.Drawing.Size(256, 192)
        Me.TMS9918Aviewer.SpriteSize = mSXdevtools.DataStructures.SpriteMSX.SPRITE_SIZE.SIZE16
        Me.TMS9918Aviewer.SpriteZoom = mSXdevtools.DataStructures.iVDP.SPRITE_ZOOM.X1
        Me.TMS9918Aviewer.TabIndex = 0
        Me.TMS9918Aviewer.ViewMode = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_MODE.MAP
        Me.TMS9918Aviewer.ViewSize = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_SIZE.x1
        '
        'SaveBitmapDialog
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(414, 474)
        Me.ControlBox = False
        Me.Controls.Add(Me.Title_Label)
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.BankCLabel)
        Me.Controls.Add(Me.BankBLabel)
        Me.Controls.Add(Me.BankCComboBox)
        Me.Controls.Add(Me.BankBComboBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PaletteComboBox)
        Me.Controls.Add(Me.BankALabel)
        Me.Controls.Add(Me.BankComboBox)
        Me.Controls.Add(Me.TMS9918Aviewer)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveBitmapDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.BottonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TMS9918Aviewer As mSXdevtools.GUI.TMS9918A.TMS9918A
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BankComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BankALabel As System.Windows.Forms.Label
    Friend WithEvents PaletteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BankBComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BankCComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BankBLabel As System.Windows.Forms.Label
    Friend WithEvents BankCLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents BottonsPanel As Panel
    Friend WithEvents Ok_Button As piXelST_Button
    Friend WithEvents Cancel_Button As piXelST_Button
    Friend WithEvents Title_Label As piXelST_Label
End Class
