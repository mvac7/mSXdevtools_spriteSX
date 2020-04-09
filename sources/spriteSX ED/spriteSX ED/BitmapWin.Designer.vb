<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BitmapWin
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
        Me.components = New System.ComponentModel.Container
        Me.OkButton = New System.Windows.Forms.Button
        Me.ExitButton = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.emptySpritesCheckBox = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.setTMS9918paletteButton = New System.Windows.Forms.Button
        Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
        Me.sizeTextBox = New System.Windows.Forms.TextBox
        Me.colorTextBox = New System.Windows.Forms.TextBox
        Me.SaveSC2SPRsButton = New System.Windows.Forms.Button
        Me.LoadSC2SPRsButton = New System.Windows.Forms.Button
        Me.SaveSC2Button = New System.Windows.Forms.Button
        Me.SaveBitmapButton = New System.Windows.Forms.Button
        Me.LoadSC2Button = New System.Windows.Forms.Button
        Me.LoadBitmapButton = New System.Windows.Forms.Button
        Me.screen2 = New mSXdevtools.MSXLibrary.TMS9918
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.Color.PaleGreen
        Me.OkButton.Enabled = False
        Me.OkButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(8, 41)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(112, 34)
        Me.OkButton.TabIndex = 5
        Me.OkButton.Text = "Transfer!"
        Me.ToolTip1.SetToolTip(Me.OkButton, "Transfer graphic data to Editor.")
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.LightSalmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(228, 399)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(60, 26)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Exit"
        Me.ToolTip1.SetToolTip(Me.ExitButton, "Return to Editor.")
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'emptySpritesCheckBox
        '
        Me.emptySpritesCheckBox.AutoSize = True
        Me.emptySpritesCheckBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emptySpritesCheckBox.Location = New System.Drawing.Point(10, 17)
        Me.emptySpritesCheckBox.Name = "emptySpritesCheckBox"
        Me.emptySpritesCheckBox.Size = New System.Drawing.Size(112, 18)
        Me.emptySpritesCheckBox.TabIndex = 9
        Me.emptySpritesCheckBox.Text = "Empty sprites"
        Me.ToolTip1.SetToolTip(Me.emptySpritesCheckBox, "Include empty sprites " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in transfer.")
        Me.emptySpritesCheckBox.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.dragdrop_48_06Y
        Me.PictureBox1.Location = New System.Drawing.Point(4, 379)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Drag & Drop your picture files " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(PNG, GIF or SC2)")
        '
        'setTMS9918paletteButton
        '
        Me.setTMS9918paletteButton.BackColor = System.Drawing.Color.Gainsboro
        Me.setTMS9918paletteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setTMS9918paletteButton.Location = New System.Drawing.Point(228, 7)
        Me.setTMS9918paletteButton.Name = "setTMS9918paletteButton"
        Me.setTMS9918paletteButton.Size = New System.Drawing.Size(48, 22)
        Me.setTMS9918paletteButton.TabIndex = 16
        Me.setTMS9918paletteButton.Text = "9918"
        Me.ToolTip1.SetToolTip(Me.setTMS9918paletteButton, "Set palette TMS9918")
        Me.setTMS9918paletteButton.UseVisualStyleBackColor = False
        '
        'ProjectNameTextBox
        '
        Me.ProjectNameTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.ProjectNameTextBox.Location = New System.Drawing.Point(20, 8)
        Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
        Me.ProjectNameTextBox.ReadOnly = True
        Me.ProjectNameTextBox.Size = New System.Drawing.Size(119, 20)
        Me.ProjectNameTextBox.TabIndex = 11
        '
        'sizeTextBox
        '
        Me.sizeTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.sizeTextBox.Location = New System.Drawing.Point(142, 8)
        Me.sizeTextBox.Name = "sizeTextBox"
        Me.sizeTextBox.ReadOnly = True
        Me.sizeTextBox.Size = New System.Drawing.Size(40, 20)
        Me.sizeTextBox.TabIndex = 12
        '
        'colorTextBox
        '
        Me.colorTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.colorTextBox.Location = New System.Drawing.Point(185, 8)
        Me.colorTextBox.Name = "colorTextBox"
        Me.colorTextBox.ReadOnly = True
        Me.colorTextBox.Size = New System.Drawing.Size(40, 20)
        Me.colorTextBox.TabIndex = 13
        '
        'SaveSC2SPRsButton
        '
        Me.SaveSC2SPRsButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSC2SPRsButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSC2SPRsButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save_20x16
        Me.SaveSC2SPRsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSC2SPRsButton.Location = New System.Drawing.Point(149, 306)
        Me.SaveSC2SPRsButton.Name = "SaveSC2SPRsButton"
        Me.SaveSC2SPRsButton.Size = New System.Drawing.Size(126, 29)
        Me.SaveSC2SPRsButton.TabIndex = 8
        Me.SaveSC2SPRsButton.Text = "Save SC2 SPRs"
        Me.SaveSC2SPRsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSC2SPRsButton, "Save a sprite pattern table " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in a MSX BASIC binary file (SC2).")
        Me.SaveSC2SPRsButton.UseVisualStyleBackColor = False
        '
        'LoadSC2SPRsButton
        '
        Me.LoadSC2SPRsButton.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadSC2SPRsButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadSC2SPRsButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.load_20x16
        Me.LoadSC2SPRsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadSC2SPRsButton.Location = New System.Drawing.Point(18, 306)
        Me.LoadSC2SPRsButton.Name = "LoadSC2SPRsButton"
        Me.LoadSC2SPRsButton.Size = New System.Drawing.Size(126, 29)
        Me.LoadSC2SPRsButton.TabIndex = 7
        Me.LoadSC2SPRsButton.Text = "Load SC2 SPRs"
        Me.LoadSC2SPRsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadSC2SPRsButton, "Load sprites from Sprite pattern table " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in MSX BASIC binary file (SC2).")
        Me.LoadSC2SPRsButton.UseVisualStyleBackColor = False
        '
        'SaveSC2Button
        '
        Me.SaveSC2Button.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSC2Button.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSC2Button.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save_20x16
        Me.SaveSC2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSC2Button.Location = New System.Drawing.Point(150, 271)
        Me.SaveSC2Button.Name = "SaveSC2Button"
        Me.SaveSC2Button.Size = New System.Drawing.Size(126, 29)
        Me.SaveSC2Button.TabIndex = 4
        Me.SaveSC2Button.Text = "Save SC2 GFX"
        Me.SaveSC2Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSC2Button, "Save the graphic display of the sprites " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in a MSX Basic binary file (SC2).")
        Me.SaveSC2Button.UseVisualStyleBackColor = False
        '
        'SaveBitmapButton
        '
        Me.SaveBitmapButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveBitmapButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBitmapButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save_20x16
        Me.SaveBitmapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveBitmapButton.Location = New System.Drawing.Point(150, 236)
        Me.SaveBitmapButton.Name = "SaveBitmapButton"
        Me.SaveBitmapButton.Size = New System.Drawing.Size(126, 29)
        Me.SaveBitmapButton.TabIndex = 3
        Me.SaveBitmapButton.Text = "Save Bitmap"
        Me.SaveBitmapButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveBitmapButton, "Save the graphic display of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the sprites in a bitmap (PNG).")
        Me.SaveBitmapButton.UseVisualStyleBackColor = False
        '
        'LoadSC2Button
        '
        Me.LoadSC2Button.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadSC2Button.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadSC2Button.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.load_20x16
        Me.LoadSC2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadSC2Button.Location = New System.Drawing.Point(18, 271)
        Me.LoadSC2Button.Name = "LoadSC2Button"
        Me.LoadSC2Button.Size = New System.Drawing.Size(126, 29)
        Me.LoadSC2Button.TabIndex = 2
        Me.LoadSC2Button.Text = "Load SC2 GFX"
        Me.LoadSC2Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadSC2Button, "Convert to sprites an upper 1/3 from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "256x192 MSX BASIC binary file (SC2). ")
        Me.LoadSC2Button.UseVisualStyleBackColor = False
        '
        'LoadBitmapButton
        '
        Me.LoadBitmapButton.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadBitmapButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadBitmapButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.load_20x16
        Me.LoadBitmapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadBitmapButton.Location = New System.Drawing.Point(18, 236)
        Me.LoadBitmapButton.Name = "LoadBitmapButton"
        Me.LoadBitmapButton.Size = New System.Drawing.Size(126, 29)
        Me.LoadBitmapButton.TabIndex = 1
        Me.LoadBitmapButton.Text = "Load Bitmap"
        Me.LoadBitmapButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadBitmapButton, "Convert to sprites an upper 1/3 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from 256x192 bitmap." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.LoadBitmapButton.UseVisualStyleBackColor = False
        '
        'screen2
        '
        Me.screen2.Location = New System.Drawing.Point(20, 34)
        Me.screen2.MaximumSize = New System.Drawing.Size(260, 196)
        Me.screen2.MinimumSize = New System.Drawing.Size(260, 196)
        Me.screen2.Name = "screen2"
        Me.screen2.Size = New System.Drawing.Size(260, 196)
        Me.screen2.TabIndex = 0
        Me.screen2.VDPtype = mSXdevtools.MSXLibrary.MSXpalette.MSXVDP.[AUTO]
        Me.screen2.VisibleTileSets = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.emptySpritesCheckBox)
        Me.GroupBox1.Controls.Add(Me.OkButton)
        Me.GroupBox1.Location = New System.Drawing.Point(94, 350)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 79)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transfer"
        '
        'BitmapWin
        '
        Me.AcceptButton = Me.OkButton
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(294, 432)
        Me.Controls.Add(Me.setTMS9918paletteButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.colorTextBox)
        Me.Controls.Add(Me.sizeTextBox)
        Me.Controls.Add(Me.ProjectNameTextBox)
        Me.Controls.Add(Me.SaveSC2SPRsButton)
        Me.Controls.Add(Me.LoadSC2SPRsButton)
        Me.Controls.Add(Me.SaveSC2Button)
        Me.Controls.Add(Me.SaveBitmapButton)
        Me.Controls.Add(Me.LoadSC2Button)
        Me.Controls.Add(Me.LoadBitmapButton)
        Me.Controls.Add(Me.screen2)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 460)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 460)
        Me.Name = "BitmapWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Load/Save Bitmap"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents screen2 As mSXdevtools.MSXLibrary.TMS9918
    Friend WithEvents LoadBitmapButton As System.Windows.Forms.Button
    Friend WithEvents LoadSC2Button As System.Windows.Forms.Button
    Friend WithEvents SaveBitmapButton As System.Windows.Forms.Button
    Friend WithEvents SaveSC2Button As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LoadSC2SPRsButton As System.Windows.Forms.Button
    Friend WithEvents SaveSC2SPRsButton As System.Windows.Forms.Button
    Friend WithEvents emptySpritesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents sizeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents colorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents setTMS9918paletteButton As System.Windows.Forms.Button
    Private WithEvents ExitButton As System.Windows.Forms.Button
End Class
