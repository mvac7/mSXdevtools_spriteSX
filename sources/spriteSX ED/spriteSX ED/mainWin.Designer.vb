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
        Me.LoadRecentButton = New System.Windows.Forms.ToolStripButton
        Me.LoadMergeButton = New System.Windows.Forms.ToolStripButton
        Me.SaveProjectButton = New System.Windows.Forms.ToolStripButton
        Me.SaveAsProjectButton = New System.Windows.Forms.ToolStripButton
        Me.BitmapButton = New System.Windows.Forms.ToolStripButton
        Me.ProjectNameText = New System.Windows.Forms.ToolStripTextBox
        Me.ProjectInfoButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EditPaletteButton = New System.Windows.Forms.ToolStripButton
        Me.GetDataButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpingButton = New System.Windows.Forms.ToolStripButton
        Me.AboutButton = New System.Windows.Forms.ToolStripButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SpritePatternNumber = New System.Windows.Forms.TextBox
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.AddButton = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.paintToolBox = New System.Windows.Forms.ToolStrip
        Me.PencilButton = New System.Windows.Forms.ToolStripButton
        Me.LineButton = New System.Windows.Forms.ToolStripButton
        Me.SquareButton = New System.Windows.Forms.ToolStripButton
        Me.CircleButton = New System.Windows.Forms.ToolStripButton
        Me.FillButton = New System.Windows.Forms.ToolStripButton
        Me.InfoPanel = New System.Windows.Forms.Panel
        Me.spritePreviewPicture = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SpriteName = New System.Windows.Forms.TextBox
        Me.PosY_TextBox = New System.Windows.Forms.TextBox
        Me.PosX_TextBox = New System.Windows.Forms.TextBox
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
        Me.UndoButton = New System.Windows.Forms.ToolStripButton
        Me.aStatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.totalLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.FilesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrjImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.toolboxImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SpriteProject = New mSXdevtools.spriteSXED.SpritesListController
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.paintToolBox.SuspendLayout()
        Me.InfoPanel.SuspendLayout()
        CType(Me.spritePreviewPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.aStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectButton, Me.ClearPRJButton, Me.LoadProjectButton, Me.LoadRecentButton, Me.LoadMergeButton, Me.SaveProjectButton, Me.SaveAsProjectButton, Me.BitmapButton, Me.ProjectNameText, Me.ProjectInfoButton, Me.ToolStripSeparator1, Me.EditPaletteButton, Me.GetDataButton, Me.ToolStripSeparator5, Me.HelpingButton, Me.AboutButton})
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
        Me.NewProjectButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources._new
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
        Me.ClearPRJButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.ico_trashcan3_24x24
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
        Me.LoadProjectButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.load_24x24x32b
        Me.LoadProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadProjectButton.Name = "LoadProjectButton"
        Me.LoadProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadProjectButton.Text = "LoadButton"
        Me.LoadProjectButton.ToolTipText = "Load Project [Ctrl+O]"
        '
        'LoadRecentButton
        '
        Me.LoadRecentButton.AutoSize = False
        Me.LoadRecentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadRecentButton.Enabled = False
        Me.LoadRecentButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.more_9x24
        Me.LoadRecentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadRecentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LoadRecentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadRecentButton.Name = "LoadRecentButton"
        Me.LoadRecentButton.Size = New System.Drawing.Size(14, 28)
        Me.LoadRecentButton.Text = "ToolStripButton1"
        Me.LoadRecentButton.ToolTipText = "Load recent Project"
        '
        'LoadMergeButton
        '
        Me.LoadMergeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadMergeButton.Enabled = False
        Me.LoadMergeButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.merge_24x24x32
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
        Me.SaveProjectButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save2_x24
        Me.SaveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveProjectButton.Name = "SaveProjectButton"
        Me.SaveProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveProjectButton.Text = "ToolStripButton1"
        Me.SaveProjectButton.ToolTipText = "Save Project [Ctrl+S]"
        '
        'SaveAsProjectButton
        '
        Me.SaveAsProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveAsProjectButton.Enabled = False
        Me.SaveAsProjectButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save_as_x24
        Me.SaveAsProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAsProjectButton.Name = "SaveAsProjectButton"
        Me.SaveAsProjectButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveAsProjectButton.Text = "ToolStripButton3"
        Me.SaveAsProjectButton.ToolTipText = "Save As Project"
        '
        'BitmapButton
        '
        Me.BitmapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BitmapButton.Enabled = False
        Me.BitmapButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.disk_bitmap_x24
        Me.BitmapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BitmapButton.Name = "BitmapButton"
        Me.BitmapButton.Size = New System.Drawing.Size(28, 28)
        Me.BitmapButton.Text = "ToolStripButton1"
        Me.BitmapButton.ToolTipText = "Load or Save Bitmap"
        '
        'ProjectNameText
        '
        Me.ProjectNameText.Enabled = False
        Me.ProjectNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectNameText.MaxLength = 32
        Me.ProjectNameText.Name = "ProjectNameText"
        Me.ProjectNameText.Size = New System.Drawing.Size(130, 31)
        '
        'ProjectInfoButton
        '
        Me.ProjectInfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjectInfoButton.Enabled = False
        Me.ProjectInfoButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.project_properties_24
        Me.ProjectInfoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ProjectInfoButton.Name = "ProjectInfoButton"
        Me.ProjectInfoButton.Size = New System.Drawing.Size(28, 28)
        Me.ProjectInfoButton.Text = "ProjectInfoButton"
        Me.ProjectInfoButton.ToolTipText = "Edit project info"
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
        Me.EditPaletteButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.palette3_x24
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
        Me.GetDataButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.ico_dataOutput_24x24
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
        'HelpingButton
        '
        Me.HelpingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpingButton.Enabled = False
        Me.HelpingButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.help_24
        Me.HelpingButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpingButton.Name = "HelpingButton"
        Me.HelpingButton.Size = New System.Drawing.Size(28, 28)
        Me.HelpingButton.Text = "ToolStripButton1"
        Me.HelpingButton.ToolTipText = "Help"
        '
        'AboutButton
        '
        Me.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.about_24
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
        'SpritePatternNumber
        '
        Me.SpritePatternNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpritePatternNumber.Location = New System.Drawing.Point(80, 21)
        Me.SpritePatternNumber.MaxLength = 2
        Me.SpritePatternNumber.Name = "SpritePatternNumber"
        Me.SpritePatternNumber.ReadOnly = True
        Me.SpritePatternNumber.Size = New System.Drawing.Size(41, 21)
        Me.SpritePatternNumber.TabIndex = 36
        Me.SpritePatternNumber.TabStop = False
        Me.SpritePatternNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.SpritePatternNumber, "Pattern number")
        '
        'UpdateButton
        '
        Me.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateButton.Enabled = False
        Me.UpdateButton.FlatAppearance.BorderSize = 0
        Me.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.UpdateButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.tick_24
        Me.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.UpdateButton.Location = New System.Drawing.Point(415, 87)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(25, 152)
        Me.UpdateButton.TabIndex = 0
        Me.UpdateButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.UpdateButton, "Update sprite [Ctrl+ENTER]")
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AddButton.Enabled = False
        Me.AddButton.FlatAppearance.BorderSize = 0
        Me.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddButton.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AddButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.add_24
        Me.AddButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AddButton.Location = New System.Drawing.Point(415, 257)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(25, 203)
        Me.AddButton.TabIndex = 1
        Me.AddButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.AddButton, "Add new sprite [Ctrl]+[+]")
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox1.Controls.Add(Me.paintToolBox)
        Me.GroupBox1.Controls.Add(Me.InfoPanel)
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 436)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sprite Editor"
        '
        'paintToolBox
        '
        Me.paintToolBox.AutoSize = False
        Me.paintToolBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.paintToolBox.GripMargin = New System.Windows.Forms.Padding(0)
        Me.paintToolBox.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.paintToolBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PencilButton, Me.LineButton, Me.SquareButton, Me.CircleButton, Me.FillButton})
        Me.paintToolBox.Location = New System.Drawing.Point(3, 47)
        Me.paintToolBox.Name = "paintToolBox"
        Me.paintToolBox.Padding = New System.Windows.Forms.Padding(0)
        Me.paintToolBox.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.paintToolBox.Size = New System.Drawing.Size(29, 326)
        Me.paintToolBox.TabIndex = 3
        '
        'PencilButton
        '
        Me.PencilButton.BackColor = System.Drawing.Color.Transparent
        Me.PencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PencilButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.pencil_x24
        Me.PencilButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PencilButton.Name = "PencilButton"
        Me.PencilButton.Size = New System.Drawing.Size(28, 28)
        Me.PencilButton.Tag = "0"
        Me.PencilButton.Text = "ToolStripButton1"
        Me.PencilButton.ToolTipText = "Draw [Alt+D]"
        '
        'LineButton
        '
        Me.LineButton.BackColor = System.Drawing.Color.Transparent
        Me.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LineButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.line_x24
        Me.LineButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LineButton.Name = "LineButton"
        Me.LineButton.Size = New System.Drawing.Size(28, 28)
        Me.LineButton.Tag = "1"
        Me.LineButton.Text = "Line"
        Me.LineButton.ToolTipText = "Line [Alt+L]"
        '
        'SquareButton
        '
        Me.SquareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SquareButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.square_tool_x24
        Me.SquareButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SquareButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SquareButton.Name = "SquareButton"
        Me.SquareButton.Size = New System.Drawing.Size(28, 28)
        Me.SquareButton.Tag = "2"
        Me.SquareButton.Text = "ToolStripButton3"
        Me.SquareButton.ToolTipText = "Rectangle  [Alt+R] / Fill rectangle "
        '
        'CircleButton
        '
        Me.CircleButton.BackColor = System.Drawing.Color.Transparent
        Me.CircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CircleButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.circle_tool_x24
        Me.CircleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CircleButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CircleButton.Name = "CircleButton"
        Me.CircleButton.Size = New System.Drawing.Size(28, 28)
        Me.CircleButton.Tag = "3"
        Me.CircleButton.Text = "ToolStripButton4"
        Me.CircleButton.ToolTipText = "Circle  [Alt+C] / Fill circle"
        '
        'FillButton
        '
        Me.FillButton.BackColor = System.Drawing.Color.Transparent
        Me.FillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FillButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.paint_x24
        Me.FillButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FillButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FillButton.Name = "FillButton"
        Me.FillButton.Size = New System.Drawing.Size(28, 28)
        Me.FillButton.Tag = "4"
        Me.FillButton.Text = "ToolStripButton5"
        Me.FillButton.ToolTipText = "Fill  [Alt+F]"
        '
        'InfoPanel
        '
        Me.InfoPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.InfoPanel.Controls.Add(Me.spritePreviewPicture)
        Me.InfoPanel.Controls.Add(Me.Label5)
        Me.InfoPanel.Controls.Add(Me.Label4)
        Me.InfoPanel.Controls.Add(Me.Label3)
        Me.InfoPanel.Controls.Add(Me.Label2)
        Me.InfoPanel.Controls.Add(Me.Label1)
        Me.InfoPanel.Controls.Add(Me.SpritePatternNumber)
        Me.InfoPanel.Controls.Add(Me.SpriteName)
        Me.InfoPanel.Controls.Add(Me.PosY_TextBox)
        Me.InfoPanel.Controls.Add(Me.PosX_TextBox)
        Me.InfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.InfoPanel.Location = New System.Drawing.Point(3, 373)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.Size = New System.Drawing.Size(394, 60)
        Me.InfoPanel.TabIndex = 2
        '
        'spritePreviewPicture
        '
        Me.spritePreviewPicture.BackColor = System.Drawing.Color.Black
        Me.spritePreviewPicture.Cursor = System.Windows.Forms.Cursors.Default
        Me.spritePreviewPicture.Location = New System.Drawing.Point(285, 21)
        Me.spritePreviewPicture.Name = "spritePreviewPicture"
        Me.spritePreviewPicture.Size = New System.Drawing.Size(32, 32)
        Me.spritePreviewPicture.TabIndex = 42
        Me.spritePreviewPicture.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(282, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "View"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(127, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 14)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(82, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Num."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(37, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 14)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "X"
        '
        'SpriteName
        '
        Me.SpriteName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteName.Location = New System.Drawing.Point(127, 21)
        Me.SpriteName.MaxLength = 24
        Me.SpriteName.Name = "SpriteName"
        Me.SpriteName.Size = New System.Drawing.Size(136, 21)
        Me.SpriteName.TabIndex = 33
        '
        'PosY_TextBox
        '
        Me.PosY_TextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosY_TextBox.Location = New System.Drawing.Point(36, 21)
        Me.PosY_TextBox.Name = "PosY_TextBox"
        Me.PosY_TextBox.ReadOnly = True
        Me.PosY_TextBox.Size = New System.Drawing.Size(26, 21)
        Me.PosY_TextBox.TabIndex = 35
        Me.PosY_TextBox.TabStop = False
        Me.PosY_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PosX_TextBox
        '
        Me.PosX_TextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosX_TextBox.Location = New System.Drawing.Point(6, 21)
        Me.PosX_TextBox.Name = "PosX_TextBox"
        Me.PosX_TextBox.ReadOnly = True
        Me.PosX_TextBox.Size = New System.Drawing.Size(26, 21)
        Me.PosX_TextBox.TabIndex = 34
        Me.PosX_TextBox.TabStop = False
        Me.PosX_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Enabled = False
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewSpriteButton, Me.ClearSpriteButton, Me.ToolStripSeparator3, Me.FlipHorizontalButton, Me.FlipVerticalButton, Me.RotateLeftButton, Me.RotateRightButton, Me.ToolStripSeparator4, Me.Move2LeftButton, Me.Move2RightButton, Me.Move2UpButton, Me.Move2downButton, Me.ToolStripSeparator2, Me.InvertButton, Me.UndoButton})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(394, 31)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'NewSpriteButton
        '
        Me.NewSpriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewSpriteButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.new2_24
        Me.NewSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewSpriteButton.Name = "NewSpriteButton"
        Me.NewSpriteButton.Size = New System.Drawing.Size(28, 28)
        Me.NewSpriteButton.Text = "ToolStripButton1"
        Me.NewSpriteButton.ToolTipText = "New sprite [Ctrl+N]"
        '
        'ClearSpriteButton
        '
        Me.ClearSpriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearSpriteButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.edit_delete
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
        Me.FlipHorizontalButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.flip_horizontal
        Me.FlipHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipHorizontalButton.Name = "FlipHorizontalButton"
        Me.FlipHorizontalButton.Size = New System.Drawing.Size(28, 28)
        Me.FlipHorizontalButton.Text = "ToolStripButton1"
        Me.FlipHorizontalButton.ToolTipText = "Flip horizontal"
        '
        'FlipVerticalButton
        '
        Me.FlipVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FlipVerticalButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.flip_vertical
        Me.FlipVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipVerticalButton.Name = "FlipVerticalButton"
        Me.FlipVerticalButton.Size = New System.Drawing.Size(28, 28)
        Me.FlipVerticalButton.Text = "ToolStripButton2"
        Me.FlipVerticalButton.ToolTipText = "Flip vertical"
        '
        'RotateLeftButton
        '
        Me.RotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateLeftButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.object_rotate_left
        Me.RotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RotateLeftButton.Name = "RotateLeftButton"
        Me.RotateLeftButton.Size = New System.Drawing.Size(28, 28)
        Me.RotateLeftButton.Text = "ToolStripButton3"
        Me.RotateLeftButton.ToolTipText = "Rotate left"
        '
        'RotateRightButton
        '
        Me.RotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateRightButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.object_rotate_right
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
        Me.Move2LeftButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_back_ltr
        Me.Move2LeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2LeftButton.Name = "Move2LeftButton"
        Me.Move2LeftButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2LeftButton.ToolTipText = "Moves to the left"
        '
        'Move2RightButton
        '
        Me.Move2RightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2RightButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_back_rtl
        Me.Move2RightButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2RightButton.Name = "Move2RightButton"
        Me.Move2RightButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2RightButton.Text = "ToolStripButton1"
        Me.Move2RightButton.ToolTipText = "Moves to the right"
        '
        'Move2UpButton
        '
        Me.Move2UpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2UpButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_up
        Me.Move2UpButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2UpButton.Name = "Move2UpButton"
        Me.Move2UpButton.Size = New System.Drawing.Size(28, 28)
        Me.Move2UpButton.ToolTipText = "Move up"
        '
        'Move2downButton
        '
        Me.Move2downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2downButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_down
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
        Me.InvertButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.invert_x24
        Me.InvertButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InvertButton.Name = "InvertButton"
        Me.InvertButton.Size = New System.Drawing.Size(28, 28)
        Me.InvertButton.Text = "ToolStripButton1"
        Me.InvertButton.ToolTipText = "Invert [Ctrl+I]"
        '
        'UndoButton
        '
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.undo_clear
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(28, 28)
        Me.UndoButton.Text = "ToolStripButton1"
        Me.UndoButton.ToolTipText = "Undo [Ctrl+Z] / Redo [Ctrl+Y]"
        '
        'aStatusStrip
        '
        Me.aStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.totalLabel, Me.ToolStripStatusLabel2})
        Me.aStatusStrip.Location = New System.Drawing.Point(0, 480)
        Me.aStatusStrip.Name = "aStatusStrip"
        Me.aStatusStrip.Size = New System.Drawing.Size(524, 22)
        Me.aStatusStrip.TabIndex = 9
        Me.aStatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(100, 17)
        Me.ToolStripStatusLabel1.Text = "Total sprites:"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'totalLabel
        '
        Me.totalLabel.AutoSize = False
        Me.totalLabel.BackColor = System.Drawing.Color.Transparent
        Me.totalLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalLabel.ForeColor = System.Drawing.Color.Black
        Me.totalLabel.Name = "totalLabel"
        Me.totalLabel.Size = New System.Drawing.Size(100, 17)
        Me.totalLabel.Text = "0"
        Me.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(260, 17)
        '
        'FilesContextMenuStrip
        '
        Me.FilesContextMenuStrip.Name = "FilesContextMenuStrip"
        Me.FilesContextMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'PrjImageList
        '
        Me.PrjImageList.ImageStream = CType(resources.GetObject("PrjImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PrjImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.PrjImageList.Images.SetKeyName(0, "new2_16.png")
        '
        'toolboxImageList
        '
        Me.toolboxImageList.ImageStream = CType(resources.GetObject("toolboxImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.toolboxImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.toolboxImageList.Images.SetKeyName(0, "circle_tool_x24.png")
        Me.toolboxImageList.Images.SetKeyName(1, "circle_x24.png")
        Me.toolboxImageList.Images.SetKeyName(2, "circleFill_x24.png")
        Me.toolboxImageList.Images.SetKeyName(3, "square_tool_x24.png")
        Me.toolboxImageList.Images.SetKeyName(4, "square_x24.png")
        Me.toolboxImageList.Images.SetKeyName(5, "squareFill_x24.png")
        '
        'SpriteProject
        '
        Me.SpriteProject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SpriteProject.Enabled = False
        Me.SpriteProject.Location = New System.Drawing.Point(443, 37)
        Me.SpriteProject.Name = "SpriteProject"
        Me.SpriteProject.Size = New System.Drawing.Size(72, 440)
        Me.SpriteProject.TabIndex = 7
        '
        'mainWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(524, 502)
        Me.Controls.Add(Me.aStatusStrip)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SpriteProject)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(540, 540)
        Me.Name = "mainWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "spriteSX devtool"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.paintToolBox.ResumeLayout(False)
        Me.paintToolBox.PerformLayout()
        Me.InfoPanel.ResumeLayout(False)
        Me.InfoPanel.PerformLayout()
        CType(Me.spritePreviewPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.aStatusStrip.ResumeLayout(False)
        Me.aStatusStrip.PerformLayout()
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
    Friend WithEvents SpriteProject As spriteSXED.SpritesListController
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LoadMergeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClearPRJButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SaveProjectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InvertButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadRecentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents aStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents totalLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents HelpingButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FilesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrjImageList As System.Windows.Forms.ImageList
    Friend WithEvents BitmapButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProjectInfoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InfoPanel As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SpritePatternNumber As System.Windows.Forms.TextBox
    Friend WithEvents SpriteName As System.Windows.Forms.TextBox
    Friend WithEvents PosY_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PosX_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents spritePreviewPicture As System.Windows.Forms.PictureBox
    Friend WithEvents paintToolBox As System.Windows.Forms.ToolStrip
    Friend WithEvents PencilButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LineButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SquareButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CircleButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FillButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UndoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolboxImageList As System.Windows.Forms.ImageList

End Class
