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
        Me.ORselectedButton = New System.Windows.Forms.Button()
        Me.colorINKPictureBox = New System.Windows.Forms.Button()
        Me.colorBGPictureBox = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.colorPanel = New System.Windows.Forms.Panel()
        Me.ColorsPanel = New System.Windows.Forms.Panel()
        Me.infoPictureBox = New System.Windows.Forms.PictureBox()
        Me.VRulerPicture = New System.Windows.Forms.PictureBox()
        Me.HRulerPicture = New System.Windows.Forms.PictureBox()
        Me.SpriteContainerPanel = New System.Windows.Forms.PictureBox()
        Me.colorPanel.SuspendLayout()
        Me.ColorsPanel.SuspendLayout()
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VRulerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HRulerPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolTip1.ForeColor = System.Drawing.Color.DarkBlue
        '
        'ORselectedButton
        '
        Me.ORselectedButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ORselectedButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ORselectedButton.FlatAppearance.BorderSize = 0
        Me.ORselectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ORselectedButton.Location = New System.Drawing.Point(0, 0)
        Me.ORselectedButton.Name = "ORselectedButton"
        Me.ORselectedButton.Padding = New System.Windows.Forms.Padding(1)
        Me.ORselectedButton.Size = New System.Drawing.Size(15, 15)
        Me.ORselectedButton.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.ORselectedButton, "Select/Unselect All")
        Me.ORselectedButton.UseVisualStyleBackColor = False
        '
        'colorINKPictureBox
        '
        Me.colorINKPictureBox.BackColor = System.Drawing.Color.White
        Me.colorINKPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorINKPictureBox.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.colorINKPictureBox.FlatAppearance.BorderSize = 0
        Me.colorINKPictureBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colorINKPictureBox.Location = New System.Drawing.Point(16, 0)
        Me.colorINKPictureBox.Name = "colorINKPictureBox"
        Me.colorINKPictureBox.Size = New System.Drawing.Size(15, 15)
        Me.colorINKPictureBox.TabIndex = 14
        Me.colorINKPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorINKPictureBox, "Ink color")
        Me.colorINKPictureBox.UseVisualStyleBackColor = False
        '
        'colorBGPictureBox
        '
        Me.colorBGPictureBox.BackColor = System.Drawing.Color.Black
        Me.colorBGPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorBGPictureBox.FlatAppearance.BorderSize = 0
        Me.colorBGPictureBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colorBGPictureBox.Location = New System.Drawing.Point(32, 0)
        Me.colorBGPictureBox.Name = "colorBGPictureBox"
        Me.colorBGPictureBox.Padding = New System.Windows.Forms.Padding(1)
        Me.colorBGPictureBox.Size = New System.Drawing.Size(15, 15)
        Me.colorBGPictureBox.TabIndex = 13
        Me.colorBGPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorBGPictureBox, "Background color")
        Me.colorBGPictureBox.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "column_info_mono.png")
        Me.ImageList1.Images.SetKeyName(1, "column_info.png")
        '
        'colorPanel
        '
        Me.colorPanel.Controls.Add(Me.ColorsPanel)
        Me.colorPanel.Controls.Add(Me.infoPictureBox)
        Me.colorPanel.Location = New System.Drawing.Point(275, 6)
        Me.colorPanel.Name = "colorPanel"
        Me.colorPanel.Size = New System.Drawing.Size(74, 41)
        Me.colorPanel.TabIndex = 27
        '
        'ColorsPanel
        '
        Me.ColorsPanel.Controls.Add(Me.colorBGPictureBox)
        Me.ColorsPanel.Controls.Add(Me.colorINKPictureBox)
        Me.ColorsPanel.Controls.Add(Me.ORselectedButton)
        Me.ColorsPanel.Location = New System.Drawing.Point(0, 25)
        Me.ColorsPanel.Name = "ColorsPanel"
        Me.ColorsPanel.Size = New System.Drawing.Size(70, 16)
        Me.ColorsPanel.TabIndex = 28
        '
        'infoPictureBox
        '
        Me.infoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.infoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.infoPictureBox.Location = New System.Drawing.Point(8, 0)
        Me.infoPictureBox.Name = "infoPictureBox"
        Me.infoPictureBox.Size = New System.Drawing.Size(55, 24)
        Me.infoPictureBox.TabIndex = 25
        Me.infoPictureBox.TabStop = False
        '
        'VRulerPicture
        '
        Me.VRulerPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VRulerPicture.BackColor = System.Drawing.Color.White
        Me.VRulerPicture.BackgroundImage = Global.mSXdevtools.spriteEditor.My.Resources.Resources.V_ruler_16px
        Me.VRulerPicture.Location = New System.Drawing.Point(0, 47)
        Me.VRulerPicture.Name = "VRulerPicture"
        Me.VRulerPicture.Size = New System.Drawing.Size(16, 256)
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
        Me.HRulerPicture.Size = New System.Drawing.Size(256, 16)
        Me.HRulerPicture.TabIndex = 28
        Me.HRulerPicture.TabStop = False
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.VRulerPicture)
        Me.Controls.Add(Me.HRulerPicture)
        Me.Controls.Add(Me.colorPanel)
        Me.Controls.Add(Me.SpriteContainerPanel)
        Me.DoubleBuffered = True
        Me.Name = "SpritePanelBase"
        Me.Size = New System.Drawing.Size(350, 320)
        Me.colorPanel.ResumeLayout(False)
        Me.ColorsPanel.ResumeLayout(False)
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VRulerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HRulerPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteContainerPanel As System.Windows.Forms.PictureBox
    Friend WithEvents colorINKPictureBox As System.Windows.Forms.Button
    Friend WithEvents colorBGPictureBox As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents infoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ORselectedButton As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents colorPanel As System.Windows.Forms.Panel
    Friend WithEvents ColorsPanel As System.Windows.Forms.Panel
    Friend WithEvents HRulerPicture As PictureBox
    Friend WithEvents VRulerPicture As PictureBox
End Class
