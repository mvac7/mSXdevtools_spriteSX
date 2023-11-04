<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SpritePanelBase
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpritePanelBase))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CC_All_Button = New System.Windows.Forms.Button()
        Me.colorINKPictureBox = New System.Windows.Forms.Button()
        Me.colorBGPictureBox = New System.Windows.Forms.Button()
        Me.IC_All_Button = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.colorPanel = New System.Windows.Forms.Panel()
        Me.ColorsPanel = New System.Windows.Forms.Panel()
        Me.VRulerPicture = New System.Windows.Forms.PictureBox()
        Me.HRulerPicture = New System.Windows.Forms.PictureBox()
        Me.EC_All_Button = New System.Windows.Forms.Button()
        Me.infoPictureBox = New System.Windows.Forms.PictureBox()
        Me.SpriteContainerPanel = New System.Windows.Forms.PictureBox()
        Me.colorPanel.SuspendLayout()
        Me.ColorsPanel.SuspendLayout()
        CType(Me.VRulerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HRulerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolTip1.ForeColor = System.Drawing.Color.DarkBlue
        '
        'CC_All_Button
        '
        Me.CC_All_Button.BackColor = System.Drawing.Color.LightGreen
        Me.CC_All_Button.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.CC_All_Button.FlatAppearance.BorderSize = 0
        Me.CC_All_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CC_All_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_SelectAll_15px
        Me.CC_All_Button.Location = New System.Drawing.Point(16, 0)
        Me.CC_All_Button.Name = "CC_All_Button"
        Me.CC_All_Button.Padding = New System.Windows.Forms.Padding(1)
        Me.CC_All_Button.Size = New System.Drawing.Size(15, 15)
        Me.CC_All_Button.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.CC_All_Button, "Select/Unselect OR color (CC - Bit 6) on all lines")
        Me.CC_All_Button.UseVisualStyleBackColor = False
        '
        'colorINKPictureBox
        '
        Me.colorINKPictureBox.BackColor = System.Drawing.Color.White
        Me.colorINKPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorINKPictureBox.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.colorINKPictureBox.FlatAppearance.BorderSize = 0
        Me.colorINKPictureBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colorINKPictureBox.Location = New System.Drawing.Point(48, 0)
        Me.colorINKPictureBox.Margin = New System.Windows.Forms.Padding(0)
        Me.colorINKPictureBox.Name = "colorINKPictureBox"
        Me.colorINKPictureBox.Size = New System.Drawing.Size(15, 15)
        Me.colorINKPictureBox.TabIndex = 14
        Me.colorINKPictureBox.TabStop = False
        Me.colorINKPictureBox.UseVisualStyleBackColor = False
        '
        'colorBGPictureBox
        '
        Me.colorBGPictureBox.BackColor = System.Drawing.Color.Black
        Me.colorBGPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorBGPictureBox.FlatAppearance.BorderSize = 0
        Me.colorBGPictureBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colorBGPictureBox.Location = New System.Drawing.Point(64, 0)
        Me.colorBGPictureBox.Margin = New System.Windows.Forms.Padding(0)
        Me.colorBGPictureBox.Name = "colorBGPictureBox"
        Me.colorBGPictureBox.Padding = New System.Windows.Forms.Padding(1)
        Me.colorBGPictureBox.Size = New System.Drawing.Size(15, 15)
        Me.colorBGPictureBox.TabIndex = 13
        Me.colorBGPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorBGPictureBox, "Background color")
        Me.colorBGPictureBox.UseVisualStyleBackColor = False
        '
        'IC_All_Button
        '
        Me.IC_All_Button.BackColor = System.Drawing.Color.LightGreen
        Me.IC_All_Button.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.IC_All_Button.FlatAppearance.BorderSize = 0
        Me.IC_All_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IC_All_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_SelectAll_15px
        Me.IC_All_Button.Location = New System.Drawing.Point(32, 0)
        Me.IC_All_Button.Name = "IC_All_Button"
        Me.IC_All_Button.Padding = New System.Windows.Forms.Padding(1)
        Me.IC_All_Button.Size = New System.Drawing.Size(15, 15)
        Me.IC_All_Button.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.IC_All_Button, "Select/Unselect Ignore Collisions (IC - Bit 5) on all lines")
        Me.IC_All_Button.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "spriteED_colinfo_TMS.png")
        Me.ImageList1.Images.SetKeyName(1, "spriteED_colinfo_V9938.png")
        '
        'colorPanel
        '
        Me.colorPanel.Controls.Add(Me.ColorsPanel)
        Me.colorPanel.Controls.Add(Me.infoPictureBox)
        Me.colorPanel.Location = New System.Drawing.Point(275, 6)
        Me.colorPanel.Name = "colorPanel"
        Me.colorPanel.Size = New System.Drawing.Size(94, 41)
        Me.colorPanel.TabIndex = 27
        '
        'ColorsPanel
        '
        Me.ColorsPanel.Controls.Add(Me.IC_All_Button)
        Me.ColorsPanel.Controls.Add(Me.EC_All_Button)
        Me.ColorsPanel.Controls.Add(Me.colorBGPictureBox)
        Me.ColorsPanel.Controls.Add(Me.colorINKPictureBox)
        Me.ColorsPanel.Controls.Add(Me.CC_All_Button)
        Me.ColorsPanel.Location = New System.Drawing.Point(0, 25)
        Me.ColorsPanel.Name = "ColorsPanel"
        Me.ColorsPanel.Size = New System.Drawing.Size(82, 15)
        Me.ColorsPanel.TabIndex = 28
        '
        'VRulerPicture
        '
        Me.VRulerPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VRulerPicture.BackColor = System.Drawing.Color.White
        Me.VRulerPicture.BackgroundImage = Global.mSXdevtools.spriteEditor.My.Resources.Resources.V_ruler_16px
        Me.VRulerPicture.Location = New System.Drawing.Point(0, 47)
        Me.VRulerPicture.Name = "VRulerPicture"
        Me.VRulerPicture.Size = New System.Drawing.Size(16, 246)
        Me.VRulerPicture.TabIndex = 29
        Me.VRulerPicture.TabStop = False
        '
        'HRulerPicture
        '
        Me.HRulerPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HRulerPicture.BackColor = System.Drawing.Color.White
        Me.HRulerPicture.BackgroundImage = Global.mSXdevtools.spriteEditor.My.Resources.Resources.H_ruler_16px
        Me.HRulerPicture.Location = New System.Drawing.Point(17, 30)
        Me.HRulerPicture.Name = "HRulerPicture"
        Me.HRulerPicture.Size = New System.Drawing.Size(257, 16)
        Me.HRulerPicture.TabIndex = 28
        Me.HRulerPicture.TabStop = False
        '
        'EC_All_Button
        '
        Me.EC_All_Button.BackColor = System.Drawing.Color.LightGreen
        Me.EC_All_Button.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.EC_All_Button.FlatAppearance.BorderSize = 0
        Me.EC_All_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EC_All_Button.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EC_All_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_SelectAll_15px
        Me.EC_All_Button.Location = New System.Drawing.Point(0, 0)
        Me.EC_All_Button.Margin = New System.Windows.Forms.Padding(0)
        Me.EC_All_Button.Name = "EC_All_Button"
        Me.EC_All_Button.Padding = New System.Windows.Forms.Padding(1)
        Me.EC_All_Button.Size = New System.Drawing.Size(15, 15)
        Me.EC_All_Button.TabIndex = 27
        Me.EC_All_Button.TabStop = False
        Me.ToolTip1.SetToolTip(Me.EC_All_Button, "Select/Unselect Early Clock (EC - Bit 7) on all lines")
        Me.EC_All_Button.UseVisualStyleBackColor = False
        '
        'infoPictureBox
        '
        Me.infoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.infoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.infoPictureBox.Location = New System.Drawing.Point(0, 2)
        Me.infoPictureBox.Name = "infoPictureBox"
        Me.infoPictureBox.Size = New System.Drawing.Size(94, 22)
        Me.infoPictureBox.TabIndex = 25
        Me.infoPictureBox.TabStop = False
        '
        'SpriteContainerPanel
        '
        Me.SpriteContainerPanel.BackColor = System.Drawing.Color.DimGray
        Me.SpriteContainerPanel.Cursor = System.Windows.Forms.Cursors.Cross
        Me.SpriteContainerPanel.Location = New System.Drawing.Point(16, 46)
        Me.SpriteContainerPanel.Name = "SpriteContainerPanel"
        Me.SpriteContainerPanel.Size = New System.Drawing.Size(257, 257)
        Me.SpriteContainerPanel.TabIndex = 0
        Me.SpriteContainerPanel.TabStop = False
        '
        'SpritePanelBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.VRulerPicture)
        Me.Controls.Add(Me.HRulerPicture)
        Me.Controls.Add(Me.colorPanel)
        Me.Controls.Add(Me.SpriteContainerPanel)
        Me.DoubleBuffered = True
        Me.Name = "SpritePanelBase"
        Me.Size = New System.Drawing.Size(370, 310)
        Me.colorPanel.ResumeLayout(False)
        Me.ColorsPanel.ResumeLayout(False)
        CType(Me.VRulerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HRulerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteContainerPanel As System.Windows.Forms.PictureBox
    Friend WithEvents colorINKPictureBox As System.Windows.Forms.Button
    Friend WithEvents colorBGPictureBox As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents infoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CC_All_Button As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents colorPanel As System.Windows.Forms.Panel
    Friend WithEvents ColorsPanel As System.Windows.Forms.Panel
    Friend WithEvents HRulerPicture As PictureBox
    Friend WithEvents VRulerPicture As PictureBox
    Friend WithEvents IC_All_Button As Button
    Friend WithEvents EC_All_Button As Button
End Class
