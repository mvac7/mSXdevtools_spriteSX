<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainWin))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.NewProjectButton = New System.Windows.Forms.ToolStripButton
        Me.ClearPRJButton = New System.Windows.Forms.ToolStripButton
        Me.LoadProjectButton = New System.Windows.Forms.ToolStripButton
        Me.LoadMergeButton = New System.Windows.Forms.ToolStripButton
        Me.SaveProjectButton = New System.Windows.Forms.ToolStripButton
        Me.SaveAsProjectButton = New System.Windows.Forms.ToolStripButton
        Me.ProjectNameText = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EditPaletteButton = New System.Windows.Forms.ToolStripButton
        Me.GetDataButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutButton = New System.Windows.Forms.ToolStripButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.AddButton = New System.Windows.Forms.Button
        Me.FirstLoadButton = New System.Windows.Forms.Button
        Me.NewPrjButton = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.NewSpriteButton = New System.Windows.Forms.ToolStripButton
        Me.ClearSpriteButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.FlipHorizontalButton = New System.Windows.Forms.ToolStripButton
        Me.FlipVerticalButton = New System.Windows.Forms.ToolStripButton
        Me.RotateLeftButton = New System.Windows.Forms.ToolStripButton
        Me.RotateRightButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Move2LeftButton = New System.Windows.Forms.ToolStripButton
        Me.Move2RightButton = New System.Windows.Forms.ToolStripButton
        Me.Move2UpButton = New System.Windows.Forms.ToolStripButton
        Me.Move2downButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.InvertButton = New System.Windows.Forms.ToolStripButton
        Me.SpriteProject = New spriteSX_ED.SpritesListController
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectButton, Me.ClearPRJButton, Me.LoadProjectButton, Me.LoadMergeButton, Me.SaveProjectButton, Me.SaveAsProjectButton, Me.ProjectNameText, Me.ToolStripSeparator1, Me.EditPaletteButton, Me.GetDataButton, Me.ToolStripSeparator5, Me.AboutButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(524, 31)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewProjectButton
        '
        Me.NewProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewProjectButton.Enabled = False
        Me.NewProjectButton.Image = Global.spriteSX_ED.My.Resources.Resources._new
        Me.NewProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewProjectButton.Name = "NewProjectButton"
        Me.NewProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.NewProjectButton.Text = "ToolStripButton1"
        Me.NewProjectButton.ToolTipText = "New Project"
        '
        'ClearPRJButton
        '
        Me.ClearPRJButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearPRJButton.Enabled = False
        Me.ClearPRJButton.Image = Global.spriteSX_ED.My.Resources.Resources.ico_trashcan3_24x24
        Me.ClearPRJButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearPRJButton.Name = "ClearPRJButton"
        Me.ClearPRJButton.Size = New System.Drawing.Size(28, 28)
        Me.ClearPRJButton.Text = "ToolStripButton1"
        Me.ClearPRJButton.ToolTipText = "Clear Project"
        '
        'LoadProjectButton
        '
        Me.LoadProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadProjectButton.Enabled = False
        Me.LoadProjectButton.Image = Global.spriteSX_ED.My.Resources.Resources.load_24x24x32b
        Me.LoadProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadProjectButton.Name = "LoadProjectButton"
        Me.LoadProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadProjectButton.Text = "LoadButton"
        Me.LoadProjectButton.ToolTipText = "Load Project"
        '
        'LoadMergeButton
        '
        Me.LoadMergeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadMergeButton.Enabled = False
        Me.LoadMergeButton.Image = Global.spriteSX_ED.My.Resources.Resources.merge_24x24x32
        Me.LoadMergeButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadMergeButton.Name = "LoadMergeButton"
        Me.LoadMergeButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadMergeButton.Text = "LoadMergeButton"
        Me.LoadMergeButton.ToolTipText = "Merge Project"
        '
        'SaveProjectButton
        '
        Me.SaveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveProjectButton.Enabled = False
        Me.SaveProjectButton.Image = Global.spriteSX_ED.My.Resources.Resources.save2_x24
        Me.SaveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveProjectButton.Name = "SaveProjectButton"
        Me.SaveProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveProjectButton.Text = "ToolStripButton1"
        Me.SaveProjectButton.ToolTipText = "Save Project"
        '
        'SaveAsProjectButton
        '
        Me.SaveAsProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveAsProjectButton.Enabled = False
        Me.SaveAsProjectButton.Image = Global.spriteSX_ED.My.Resources.Resources.save_as_x24
        Me.SaveAsProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAsProjectButton.Name = "SaveAsProjectButton"
        Me.SaveAsProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveAsProjectButton.Text = "ToolStripButton3"
        Me.SaveAsProjectButton.ToolTipText = "Save As Project"
        '
        'ProjectNameText
        '
        Me.ProjectNameText.Enabled = False
        Me.ProjectNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectNameText.MaxLength = 32
        Me.ProjectNameText.Name = "ProjectNameText"
        Me.ProjectNameText.Size = New System.Drawing.Size(140, 31)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'EditPaletteButton
        '
        Me.EditPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditPaletteButton.Enabled = False
        Me.EditPaletteButton.Image = Global.spriteSX_ED.My.Resources.Resources.palette3_x24
        Me.EditPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditPaletteButton.Name = "EditPaletteButton"
        Me.EditPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.EditPaletteButton.Text = "ToolStripButton1"
        Me.EditPaletteButton.ToolTipText = "Edit Palette"
        '
        'GetDataButton
        '
        Me.GetDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GetDataButton.Enabled = False
        Me.GetDataButton.Image = Global.spriteSX_ED.My.Resources.Resources.ico_dataOutput_24x24
        Me.GetDataButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(28, 28)
        Me.GetDataButton.ToolTipText = "Generate data"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'AboutButton
        '
        Me.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutButton.Image = Global.spriteSX_ED.My.Resources.Resources.about_24
        Me.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(28, 28)
        Me.AboutButton.ToolTipText = "About this App"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 200
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'UpdateButton
        '
        Me.UpdateButton.Enabled = False
        Me.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UpdateButton.Image = Global.spriteSX_ED.My.Resources.Resources.tick_24
        Me.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.UpdateButton.Location = New System.Drawing.Point(415, 87)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(25, 152)
        Me.UpdateButton.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.UpdateButton, "Update sprite")
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.Enabled = False
        Me.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AddButton.Image = Global.spriteSX_ED.My.Resources.Resources.add_24
        Me.AddButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AddButton.Location = New System.Drawing.Point(415, 257)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(25, 203)
        Me.AddButton.TabIndex = 10
        Me.AddButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.AddButton, "Add new sprite")
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'FirstLoadButton
        '
        Me.FirstLoadButton.Image = Global.spriteSX_ED.My.Resources.Resources.load_project
        Me.FirstLoadButton.Location = New System.Drawing.Point(209, 122)
        Me.FirstLoadButton.Name = "FirstLoadButton"
        Me.FirstLoadButton.Size = New System.Drawing.Size(160, 160)
        Me.FirstLoadButton.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.FirstLoadButton, "Load Project")
        Me.FirstLoadButton.UseVisualStyleBackColor = True
        '
        'NewPrjButton
        '
        Me.NewPrjButton.Image = Global.spriteSX_ED.My.Resources.Resources.NEW_project128
        Me.NewPrjButton.Location = New System.Drawing.Point(28, 122)
        Me.NewPrjButton.Name = "NewPrjButton"
        Me.NewPrjButton.Size = New System.Drawing.Size(160, 160)
        Me.NewPrjButton.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.NewPrjButton, "New Project")
        Me.NewPrjButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox1.Controls.Add(Me.FirstLoadButton)
        Me.GroupBox1.Controls.Add(Me.NewPrjButton)
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 422)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sprite Editor"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Enabled = False
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewSpriteButton, Me.ClearSpriteButton, Me.ToolStripSeparator3, Me.FlipHorizontalButton, Me.FlipVerticalButton, Me.RotateLeftButton, Me.RotateRightButton, Me.ToolStripSeparator4, Me.Move2LeftButton, Me.Move2RightButton, Me.Move2UpButton, Me.Move2downButton, Me.ToolStripSeparator2, Me.InvertButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(394, 31)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'NewSpriteButton
        '
        Me.NewSpriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewSpriteButton.Image = Global.spriteSX_ED.My.Resources.Resources.new2_24
        Me.NewSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewSpriteButton.Name = "NewSpriteButton"
        Me.NewSpriteButton.Size = New System.Drawing.Size(28, 28)
        Me.NewSpriteButton.Text = "ToolStripButton1"
        Me.NewSpriteButton.ToolTipText = "New sprite"
        '
        'ClearSpriteButton
        '
        Me.ClearSpriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearSpriteButton.Image = Global.spriteSX_ED.My.Resources.Resources.edit_delete
        Me.ClearSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearSpriteButton.Name = "ClearSpriteButton"
        Me.ClearSpriteButton.Size = New System.Drawing.Size(28, 28)
        Me.ClearSpriteButton.Text = "ToolStripButton1"
        Me.ClearSpriteButton.ToolTipText = "Clear"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'FlipHorizontalButton
        '
        Me.FlipHorizontalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FlipHorizontalButton.Image = Global.spriteSX_ED.My.Resources.Resources.flip_horizontal
        Me.FlipHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipHorizontalButton.Name = "FlipHorizontalButton"
        Me.FlipHorizontalButton.Size = New System.Drawing.Size(28, 28)
        Me.FlipHorizontalButton.Text = "ToolStripButton1"
        Me.FlipHorizontalButton.ToolTipText = "Flip horizontal"
        '
        'FlipVerticalButton
        '
        Me.FlipVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FlipVerticalButton.Image = Global.spriteSX_ED.My.Resources.Resources.flip_vertical
        Me.FlipVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipVerticalButton.Name = "FlipVerticalButton"
        Me.FlipVerticalButton.Size = New System.Drawing.Size(28, 28)
        Me.FlipVerticalButton.Text = "ToolStripButton2"
        Me.FlipVerticalButton.ToolTipText = "Flip vertical"
        '
        'RotateLeftButton
        '
        Me.RotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateLeftButton.Image = Global.spriteSX_ED.My.Resources.Resources.object_rotate_left
        Me.RotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RotateLeftButton.Name = "RotateLeftButton"
        Me.RotateLeftButton.Size = New System.Drawing.Size(28, 28)
        Me.RotateLeftButton.Text = "ToolStripButton3"
        Me.RotateLeftButton.ToolTipText = "Rotate left"
        '
        'RotateRightButton
        '
        Me.RotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateRightButton.Image = Global.spriteSX_ED.My.Resources.Resources.object_rotate_right
        Me.RotateRightButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RotateRightButton.Name = "RotateRightButton"
        Me.RotateRightButton.Size = New System.Drawing.Size(28, 28)
        Me.RotateRightButton.Text = "ToolStripButton4"
        Me.RotateRightButton.ToolTipText = "Rotate right"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'Move2LeftButton
        '
        Me.Move2LeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2LeftButton.Image = Global.spriteSX_ED.My.Resources.Resources.gtk_go_back_ltr
        Me.Move2LeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2LeftButton.Name = "Move2LeftButton"
        Me.Move2LeftButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2LeftButton.ToolTipText = "Moves to the left"
        '
        'Move2RightButton
        '
        Me.Move2RightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2RightButton.Image = Global.spriteSX_ED.My.Resources.Resources.gtk_go_back_rtl
        Me.Move2RightButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2RightButton.Name = "Move2RightButton"
        Me.Move2RightButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2RightButton.Text = "ToolStripButton1"
        Me.Move2RightButton.ToolTipText = "Moves to the right"
        '
        'Move2UpButton
        '
        Me.Move2UpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2UpButton.Image = Global.spriteSX_ED.My.Resources.Resources.gtk_go_up
        Me.Move2UpButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2UpButton.Name = "Move2UpButton"
        Me.Move2UpButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2UpButton.ToolTipText = "Move up"
        '
        'Move2downButton
        '
        Me.Move2downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2downButton.Image = Global.spriteSX_ED.My.Resources.Resources.gtk_go_down
        Me.Move2downButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2downButton.Name = "Move2downButton"
        Me.Move2downButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2downButton.ToolTipText = "Move down"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'InvertButton
        '
        Me.InvertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InvertButton.Image = Global.spriteSX_ED.My.Resources.Resources.invert_x24
        Me.InvertButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InvertButton.Name = "InvertButton"
        Me.InvertButton.Size = New System.Drawing.Size(28, 28)
        Me.InvertButton.Text = "ToolStripButton1"
        Me.InvertButton.ToolTipText = "Invert"
        '
        'SpriteProject
        '
        Me.SpriteProject.Enabled = False
        Me.SpriteProject.Location = New System.Drawing.Point(443, 37)
        Me.SpriteProject.Name = "SpriteProject"
        Me.SpriteProject.Size = New System.Drawing.Size(72, 426)
        Me.SpriteProject.TabIndex = 7
        '
        'mainWin
        '
        Me.AcceptButton = Me.UpdateButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(524, 470)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SpriteProject)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(480, 440)
        Me.Name = "mainWin"
        Me.Text = "spriteSX ED"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewProjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadProjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveAsProjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditPaletteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ClearSpriteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FlipHorizontalButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FlipVerticalButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RotateLeftButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RotateRightButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GetDataButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AboutButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NewSpriteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Move2LeftButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2RightButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2UpButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2downButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProjectNameText As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpriteProject As spriteSX_ED.SpritesListController
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NewPrjButton As System.Windows.Forms.Button
    Friend WithEvents FirstLoadButton As System.Windows.Forms.Button
    Friend WithEvents LoadMergeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClearPRJButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SaveProjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InvertButton As System.Windows.Forms.ToolStripButton

End Class
