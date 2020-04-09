<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpritePanelBase
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpritePanelBase))
        Me.testButton = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ORselectedButton = New System.Windows.Forms.Button
        Me.colorINKPictureBox = New System.Windows.Forms.PictureBox
        Me.colorBGPictureBox = New System.Windows.Forms.PictureBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.infoPictureBox = New System.Windows.Forms.PictureBox
        Me.SpriteContainerPanel = New System.Windows.Forms.PictureBox
        Me.colorPanel = New System.Windows.Forms.Panel
        CType(Me.colorINKPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.colorBGPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.colorPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'testButton
        '
        Me.testButton.BackColor = System.Drawing.Color.Gold
        Me.testButton.CausesValidation = False
        Me.testButton.Location = New System.Drawing.Point(14, 19)
        Me.testButton.Name = "testButton"
        Me.testButton.Size = New System.Drawing.Size(41, 21)
        Me.testButton.TabIndex = 9
        Me.testButton.TabStop = False
        Me.testButton.Text = "Test"
        Me.testButton.UseVisualStyleBackColor = False
        '
        'ORselectedButton
        '
        Me.ORselectedButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ORselectedButton.Location = New System.Drawing.Point(0, 25)
        Me.ORselectedButton.Name = "ORselectedButton"
        Me.ORselectedButton.Size = New System.Drawing.Size(16, 16)
        Me.ORselectedButton.TabIndex = 26
        Me.ToolTip1.SetToolTip(Me.ORselectedButton, "Select/Unselect All")
        Me.ORselectedButton.UseVisualStyleBackColor = False
        '
        'colorINKPictureBox
        '
        Me.colorINKPictureBox.BackColor = System.Drawing.Color.White
        Me.colorINKPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.colorINKPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorINKPictureBox.Location = New System.Drawing.Point(17, 26)
        Me.colorINKPictureBox.Name = "colorINKPictureBox"
        Me.colorINKPictureBox.Size = New System.Drawing.Size(14, 14)
        Me.colorINKPictureBox.TabIndex = 14
        Me.colorINKPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorINKPictureBox, "Ink color")
        '
        'colorBGPictureBox
        '
        Me.colorBGPictureBox.BackColor = System.Drawing.Color.Black
        Me.colorBGPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.colorBGPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorBGPictureBox.Location = New System.Drawing.Point(33, 26)
        Me.colorBGPictureBox.Name = "colorBGPictureBox"
        Me.colorBGPictureBox.Size = New System.Drawing.Size(14, 14)
        Me.colorBGPictureBox.TabIndex = 13
        Me.colorBGPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorBGPictureBox, "Background color")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "column_info_mono.png")
        Me.ImageList1.Images.SetKeyName(1, "column_info.png")
        '
        'infoPictureBox
        '
        Me.infoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.infoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.infoPictureBox.Location = New System.Drawing.Point(7, 0)
        Me.infoPictureBox.Name = "infoPictureBox"
        Me.infoPictureBox.Size = New System.Drawing.Size(55, 24)
        Me.infoPictureBox.TabIndex = 25
        Me.infoPictureBox.TabStop = False
        '
        'SpriteContainerPanel
        '
        Me.SpriteContainerPanel.BackColor = System.Drawing.Color.DimGray
        Me.SpriteContainerPanel.Cursor = System.Windows.Forms.Cursors.Cross
        Me.SpriteContainerPanel.Location = New System.Drawing.Point(14, 46)
        Me.SpriteContainerPanel.Name = "SpriteContainerPanel"
        Me.SpriteContainerPanel.Size = New System.Drawing.Size(257, 257)
        Me.SpriteContainerPanel.TabIndex = 0
        Me.SpriteContainerPanel.TabStop = False
        '
        'colorPanel
        '
        Me.colorPanel.Controls.Add(Me.infoPictureBox)
        Me.colorPanel.Controls.Add(Me.ORselectedButton)
        Me.colorPanel.Controls.Add(Me.colorBGPictureBox)
        Me.colorPanel.Controls.Add(Me.colorINKPictureBox)
        Me.colorPanel.Location = New System.Drawing.Point(275, 4)
        Me.colorPanel.Name = "colorPanel"
        Me.colorPanel.Size = New System.Drawing.Size(72, 41)
        Me.colorPanel.TabIndex = 27
        '
        'SpritePanelBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.colorPanel)
        Me.Controls.Add(Me.testButton)
        Me.Controls.Add(Me.SpriteContainerPanel)
        Me.DoubleBuffered = True
        Me.Name = "SpritePanelBase"
        Me.Size = New System.Drawing.Size(350, 320)
        CType(Me.colorINKPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.colorBGPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.infoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpriteContainerPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.colorPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteContainerPanel As System.Windows.Forms.PictureBox
    Friend WithEvents colorINKPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents colorBGPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents testButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents infoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ORselectedButton As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents colorPanel As System.Windows.Forms.Panel

End Class
