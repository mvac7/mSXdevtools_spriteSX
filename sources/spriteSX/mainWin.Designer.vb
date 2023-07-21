<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainWin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainWin))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.versionLabel = New System.Windows.Forms.Label()
        Me.copyleftLabel = New System.Windows.Forms.Label()
        Me.AppIconPictureBox = New System.Windows.Forms.PictureBox()
        Me.AppLogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.bottomPanel = New System.Windows.Forms.Panel()
        Me.InitLauncher1 = New mSXdevtools.GUI.Controls.InitLauncher()
        Me.LicenseLabel = New System.Windows.Forms.Label()
        Me.LicenseLinkLabel = New System.Windows.Forms.LinkLabel()
        CType(Me.AppIconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppLogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomPanel.SuspendLayout()
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
        'DescriptionLabel
        '
        Me.DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.DescriptionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(148, 171)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(408, 63)
        Me.DescriptionLabel.TabIndex = 16
        Me.DescriptionLabel.Text = "description..."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Version:"
        '
        'versionLabel
        '
        Me.versionLabel.BackColor = System.Drawing.Color.Transparent
        Me.versionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionLabel.Location = New System.Drawing.Point(222, 100)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(334, 18)
        Me.versionLabel.TabIndex = 13
        Me.versionLabel.Text = "version"
        '
        'copyleftLabel
        '
        Me.copyleftLabel.BackColor = System.Drawing.Color.Transparent
        Me.copyleftLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyleftLabel.Location = New System.Drawing.Point(148, 122)
        Me.copyleftLabel.Name = "copyleftLabel"
        Me.copyleftLabel.Size = New System.Drawing.Size(408, 18)
        Me.copyleftLabel.TabIndex = 12
        Me.copyleftLabel.Text = "copyleft"
        '
        'AppIconPictureBox
        '
        Me.AppIconPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AppIconPictureBox.Location = New System.Drawing.Point(4, 12)
        Me.AppIconPictureBox.Name = "AppIconPictureBox"
        Me.AppIconPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.AppIconPictureBox.TabIndex = 21
        Me.AppIconPictureBox.TabStop = False
        '
        'AppLogoPictureBox
        '
        Me.AppLogoPictureBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppLogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AppLogoPictureBox.Location = New System.Drawing.Point(142, 12)
        Me.AppLogoPictureBox.Name = "AppLogoPictureBox"
        Me.AppLogoPictureBox.Size = New System.Drawing.Size(464, 83)
        Me.AppLogoPictureBox.TabIndex = 20
        Me.AppLogoPictureBox.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.Transparent
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.FlatAppearance.BorderSize = 0
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Image = Global.mSXdevtools.spriteSX.My.Resources.Resources.button_Exit
        Me.ExitButton.Location = New System.Drawing.Point(508, 12)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(105, 30)
        Me.ExitButton.TabIndex = 17
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'bottomPanel
        '
        Me.bottomPanel.BackColor = System.Drawing.Color.Transparent
        Me.bottomPanel.Controls.Add(Me.ExitButton)
        Me.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomPanel.Location = New System.Drawing.Point(0, 551)
        Me.bottomPanel.Name = "bottomPanel"
        Me.bottomPanel.Size = New System.Drawing.Size(618, 47)
        Me.bottomPanel.TabIndex = 22
        '
        'InitLauncher1
        '
        Me.InitLauncher1.BackColor = System.Drawing.Color.Transparent
        Me.InitLauncher1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.InitLauncher1.Location = New System.Drawing.Point(0, 245)
        Me.InitLauncher1.Name = "InitLauncher1"
        Me.InitLauncher1.Size = New System.Drawing.Size(618, 306)
        Me.InitLauncher1.TabIndex = 0
        '
        'LicenseLabel
        '
        Me.LicenseLabel.BackColor = System.Drawing.Color.Transparent
        Me.LicenseLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseLabel.Location = New System.Drawing.Point(148, 146)
        Me.LicenseLabel.Name = "LicenseLabel"
        Me.LicenseLabel.Size = New System.Drawing.Size(78, 18)
        Me.LicenseLabel.TabIndex = 23
        Me.LicenseLabel.Text = "License:"
        '
        'LicenseLinkLabel
        '
        Me.LicenseLinkLabel.AutoSize = True
        Me.LicenseLinkLabel.BackColor = System.Drawing.Color.Transparent
        Me.LicenseLinkLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseLinkLabel.Location = New System.Drawing.Point(210, 146)
        Me.LicenseLinkLabel.Name = "LicenseLinkLabel"
        Me.LicenseLinkLabel.Size = New System.Drawing.Size(74, 14)
        Me.LicenseLinkLabel.TabIndex = 24
        Me.LicenseLinkLabel.TabStop = True
        Me.LicenseLinkLabel.Text = "LinkLabel1"
        '
        'mainWin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(618, 598)
        Me.ControlBox = False
        Me.Controls.Add(Me.LicenseLinkLabel)
        Me.Controls.Add(Me.LicenseLabel)
        Me.Controls.Add(Me.InitLauncher1)
        Me.Controls.Add(Me.bottomPanel)
        Me.Controls.Add(Me.AppIconPictureBox)
        Me.Controls.Add(Me.AppLogoPictureBox)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.copyleftLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mainWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.AppIconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppLogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InitLauncher1 As mSXdevtools.GUI.Controls.InitLauncher
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents versionLabel As Label
    Friend WithEvents copyleftLabel As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents AppIconPictureBox As PictureBox
    Friend WithEvents AppLogoPictureBox As PictureBox
    Friend WithEvents bottomPanel As Panel
    Friend WithEvents LicenseLabel As Label
    Friend WithEvents LicenseLinkLabel As LinkLabel
End Class
