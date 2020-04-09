<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.exitButton = New System.Windows.Forms.Button
        Me.versionLabel = New System.Windows.Forms.Label
        Me.AboutTextBox = New System.Windows.Forms.TextBox
        Me.licenseButton = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.copyleftLabel = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'exitButton
        '
        Me.exitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.exitButton.BackColor = System.Drawing.Color.PaleGreen
        Me.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exitButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitButton.ForeColor = System.Drawing.Color.Black
        Me.exitButton.Location = New System.Drawing.Point(460, 320)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(80, 32)
        Me.exitButton.TabIndex = 1
        Me.exitButton.Text = "Ok"
        Me.exitButton.UseVisualStyleBackColor = False
        '
        'versionLabel
        '
        Me.versionLabel.BackColor = System.Drawing.Color.Transparent
        Me.versionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionLabel.ForeColor = System.Drawing.Color.Black
        Me.versionLabel.Location = New System.Drawing.Point(152, 80)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(380, 18)
        Me.versionLabel.TabIndex = 3
        Me.versionLabel.Text = "version"
        Me.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AboutTextBox
        '
        Me.AboutTextBox.BackColor = System.Drawing.Color.LightGray
        Me.AboutTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AboutTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutTextBox.ForeColor = System.Drawing.Color.Black
        Me.AboutTextBox.Location = New System.Drawing.Point(154, 150)
        Me.AboutTextBox.Multiline = True
        Me.AboutTextBox.Name = "AboutTextBox"
        Me.AboutTextBox.ReadOnly = True
        Me.AboutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.AboutTextBox.Size = New System.Drawing.Size(400, 154)
        Me.AboutTextBox.TabIndex = 6
        Me.AboutTextBox.TabStop = False
        Me.AboutTextBox.Text = resources.GetString("AboutTextBox.Text")
        '
        'licenseButton
        '
        Me.licenseButton.BackColor = System.Drawing.Color.Transparent
        Me.licenseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.licenseButton.FlatAppearance.BorderSize = 0
        Me.licenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.licenseButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gplv3_88x31
        Me.licenseButton.Location = New System.Drawing.Point(144, 314)
        Me.licenseButton.Name = "licenseButton"
        Me.licenseButton.Size = New System.Drawing.Size(100, 40)
        Me.licenseButton.TabIndex = 7
        Me.licenseButton.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.spriteSX_logotxt
        Me.PictureBox2.Location = New System.Drawing.Point(154, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(390, 50)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox1.BackgroundImage = Global.mSXdevtools.spriteSXED.My.Resources.Resources.about_spriteSXcolumn
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 360)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'copyleftLabel
        '
        Me.copyleftLabel.BackColor = System.Drawing.Color.Transparent
        Me.copyleftLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyleftLabel.ForeColor = System.Drawing.Color.Black
        Me.copyleftLabel.Location = New System.Drawing.Point(152, 120)
        Me.copyleftLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.copyleftLabel.Name = "copyleftLabel"
        Me.copyleftLabel.Size = New System.Drawing.Size(380, 18)
        Me.copyleftLabel.TabIndex = 8
        Me.copyleftLabel.Text = "copyleft"
        Me.copyleftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(475, 369)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(71, 14)
        Me.PictureBox3.TabIndex = 10
        Me.PictureBox3.TabStop = False
        '
        'AboutForm
        '
        Me.AcceptButton = Me.exitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Plum
        Me.BackgroundImage = Global.mSXdevtools.spriteSXED.My.Resources.Resources.aboutwin_BGH
        Me.CancelButton = Me.exitButton
        Me.ClientSize = New System.Drawing.Size(558, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.copyleftLabel)
        Me.Controls.Add(Me.licenseButton)
        Me.Controls.Add(Me.AboutTextBox)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TransparencyKey = System.Drawing.Color.Plum
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AboutTextBox As System.Windows.Forms.TextBox
    Friend WithEvents licenseButton As System.Windows.Forms.Button
    Friend WithEvents copyleftLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
