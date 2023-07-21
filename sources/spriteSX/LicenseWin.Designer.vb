<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicenseWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicenseWin))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.LicenseTextBox = New System.Windows.Forms.TextBox()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.versionLabel = New System.Windows.Forms.Label()
        Me.copyleftLabel = New System.Windows.Forms.Label()
        Me.AppNameLabel = New System.Windows.Forms.Label()
        Me.GPLButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.Color.PaleGreen
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(313, 380)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(110, 36)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Accept"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.Salmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(432, 386)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(80, 30)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'LicenseTextBox
        '
        Me.LicenseTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LicenseTextBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LicenseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LicenseTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseTextBox.Location = New System.Drawing.Point(12, 163)
        Me.LicenseTextBox.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.LicenseTextBox.Multiline = True
        Me.LicenseTextBox.Name = "LicenseTextBox"
        Me.LicenseTextBox.ReadOnly = True
        Me.LicenseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LicenseTextBox.Size = New System.Drawing.Size(510, 190)
        Me.LicenseTextBox.TabIndex = 1
        Me.LicenseTextBox.TabStop = False
        Me.LicenseTextBox.Text = resources.GetString("LicenseTextBox.Text")
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.DescriptionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(5, 94)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(507, 43)
        Me.DescriptionLabel.TabIndex = 16
        Me.DescriptionLabel.Text = "description..."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Version:"
        '
        'versionLabel
        '
        Me.versionLabel.BackColor = System.Drawing.Color.Transparent
        Me.versionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionLabel.Location = New System.Drawing.Point(79, 41)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(334, 18)
        Me.versionLabel.TabIndex = 13
        Me.versionLabel.Text = "version"
        '
        'copyleftLabel
        '
        Me.copyleftLabel.BackColor = System.Drawing.Color.Transparent
        Me.copyleftLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyleftLabel.Location = New System.Drawing.Point(5, 63)
        Me.copyleftLabel.Name = "copyleftLabel"
        Me.copyleftLabel.Size = New System.Drawing.Size(507, 18)
        Me.copyleftLabel.TabIndex = 12
        Me.copyleftLabel.Text = "copyleft"
        '
        'AppNameLabel
        '
        Me.AppNameLabel.BackColor = System.Drawing.Color.Transparent
        Me.AppNameLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppNameLabel.Location = New System.Drawing.Point(5, 9)
        Me.AppNameLabel.Name = "AppNameLabel"
        Me.AppNameLabel.Size = New System.Drawing.Size(507, 32)
        Me.AppNameLabel.TabIndex = 17
        Me.AppNameLabel.Text = "AppName"
        '
        'GPLButton
        '
        Me.GPLButton.BackColor = System.Drawing.Color.Transparent
        Me.GPLButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GPLButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GPLButton.FlatAppearance.BorderSize = 0
        Me.GPLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GPLButton.Image = Global.mSXdevtools.spriteSX.My.Resources.Resources.gplv3_127x51
        Me.GPLButton.Location = New System.Drawing.Point(12, 355)
        Me.GPLButton.Name = "GPLButton"
        Me.GPLButton.Size = New System.Drawing.Size(133, 54)
        Me.GPLButton.TabIndex = 18
        Me.GPLButton.UseVisualStyleBackColor = False
        '
        'LicenseWin
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(524, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.GPLButton)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.AppNameLabel)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.copyleftLabel)
        Me.Controls.Add(Me.LicenseTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LicenseWin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "License"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LicenseTextBox As TextBox
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents versionLabel As Label
    Friend WithEvents copyleftLabel As Label
    Friend WithEvents AppNameLabel As Label
    Friend WithEvents GPLButton As Button
End Class
