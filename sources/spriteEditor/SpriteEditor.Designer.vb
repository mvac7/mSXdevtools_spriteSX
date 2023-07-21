<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SpriteEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpriteEditor))
        Me.SpriteEditorPanel = New System.Windows.Forms.Panel()
        Me.ClipboardPiXelGroupBox = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.PasteSpriteButton = New System.Windows.Forms.Button()
        Me.CopySpriteButton = New System.Windows.Forms.Button()
        Me.ClipboardPictureBox = New System.Windows.Forms.PictureBox()
        Me.SpritePaintToolBox = New System.Windows.Forms.ToolStrip()
        Me.PencilButton = New System.Windows.Forms.ToolStripButton()
        Me.LineButton = New System.Windows.Forms.ToolStripButton()
        Me.SquareButton = New System.Windows.Forms.ToolStripButton()
        Me.CircleButton = New System.Windows.Forms.ToolStripButton()
        Me.FillButton = New System.Windows.Forms.ToolStripButton()
        Me.UndoButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PosX_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PosY_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PiXelGroupBox1 = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.SpriteNumberLabel = New mSXdevtools.GUI.Controls.piXelST_Label()
        Me.UpdateSpriteButton = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.spritePreviewPicture = New System.Windows.Forms.PictureBox()
        Me.SpriteName = New System.Windows.Forms.TextBox()
        Me.SpriteEDPanel = New System.Windows.Forms.Panel()
        Me.SpriteToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ClearSpriteButton = New System.Windows.Forms.ToolStripButton()
        Me.InvertButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FlipHorizontalButton = New System.Windows.Forms.ToolStripButton()
        Me.FlipVerticalButton = New System.Windows.Forms.ToolStripButton()
        Me.RotateLeftButton = New System.Windows.Forms.ToolStripButton()
        Me.RotateRightButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Move2LeftButton = New System.Windows.Forms.ToolStripButton()
        Me.Move2RightButton = New System.Windows.Forms.ToolStripButton()
        Me.Move2UpButton = New System.Windows.Forms.ToolStripButton()
        Me.Move2downButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpdateButton = New System.Windows.Forms.ToolStripButton()
        Me.SpritesetPanel = New System.Windows.Forms.Panel()
        Me.aSpritesetControl = New mSXdevtools.GUI.Controls.SpritesetControl()
        Me.TilesetToolboxStrip = New System.Windows.Forms.ToolStrip()
        Me.SelectTileButton = New System.Windows.Forms.ToolStripButton()
        Me.ExchangeTilesButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyTileButton = New System.Windows.Forms.ToolStripButton()
        Me.TilesetToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewSpritesetButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadSpritesetButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopySpritesetButton = New System.Windows.Forms.ToolStripButton()
        Me.SpritesetComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ConfigSpritesetButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteTilesetButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveSpritesetButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveMSXBASICbinaryButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveBitmapButton = New System.Windows.Forms.ToolStripButton()
        Me.toolboxImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.SpriteEditorPanel.SuspendLayout()
        Me.ClipboardPiXelGroupBox.SuspendLayout()
        CType(Me.ClipboardPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SpritePaintToolBox.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.PiXelGroupBox1.SuspendLayout()
        CType(Me.spritePreviewPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SpriteToolStrip.SuspendLayout()
        Me.SpritesetPanel.SuspendLayout()
        Me.TilesetToolboxStrip.SuspendLayout()
        Me.TilesetToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SpriteEditorPanel
        '
        Me.SpriteEditorPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SpriteEditorPanel.Controls.Add(Me.ClipboardPiXelGroupBox)
        Me.SpriteEditorPanel.Controls.Add(Me.SpritePaintToolBox)
        Me.SpriteEditorPanel.Controls.Add(Me.StatusStrip1)
        Me.SpriteEditorPanel.Controls.Add(Me.PiXelGroupBox1)
        Me.SpriteEditorPanel.Controls.Add(Me.SpriteEDPanel)
        Me.SpriteEditorPanel.Controls.Add(Me.SpriteToolStrip)
        Me.SpriteEditorPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpriteEditorPanel.Location = New System.Drawing.Point(0, 0)
        Me.SpriteEditorPanel.Name = "SpriteEditorPanel"
        Me.SpriteEditorPanel.Size = New System.Drawing.Size(600, 370)
        Me.SpriteEditorPanel.TabIndex = 12
        '
        'ClipboardPiXelGroupBox
        '
        Me.ClipboardPiXelGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.ClipboardPiXelGroupBox.BGColor = System.Drawing.Color.LightSkyBlue
        Me.ClipboardPiXelGroupBox.Controls.Add(Me.PasteSpriteButton)
        Me.ClipboardPiXelGroupBox.Controls.Add(Me.CopySpriteButton)
        Me.ClipboardPiXelGroupBox.Controls.Add(Me.ClipboardPictureBox)
        Me.ClipboardPiXelGroupBox.LineColor = System.Drawing.Color.DimGray
        Me.ClipboardPiXelGroupBox.Location = New System.Drawing.Point(401, 70)
        Me.ClipboardPiXelGroupBox.Name = "ClipboardPiXelGroupBox"
        Me.ClipboardPiXelGroupBox.Padding = New System.Windows.Forms.Padding(0)
        Me.ClipboardPiXelGroupBox.Size = New System.Drawing.Size(160, 74)
        Me.ClipboardPiXelGroupBox.TabIndex = 9
        Me.ClipboardPiXelGroupBox.TabStop = False
        Me.ClipboardPiXelGroupBox.Text = "Clipboard"
        '
        'PasteSpriteButton
        '
        Me.PasteSpriteButton.BackColor = System.Drawing.Color.Transparent
        Me.PasteSpriteButton.BackgroundImage = Global.mSXdevtools.spriteEditor.My.Resources.Resources.button_paste
        Me.PasteSpriteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PasteSpriteButton.FlatAppearance.BorderSize = 0
        Me.PasteSpriteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PasteSpriteButton.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteSpriteButton.Location = New System.Drawing.Point(62, 26)
        Me.PasteSpriteButton.Name = "PasteSpriteButton"
        Me.PasteSpriteButton.Size = New System.Drawing.Size(44, 32)
        Me.PasteSpriteButton.TabIndex = 263
        Me.PasteSpriteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.PasteSpriteButton, "Paste Sprite from clipboard [Ctrl+V]")
        Me.PasteSpriteButton.UseVisualStyleBackColor = False
        '
        'CopySpriteButton
        '
        Me.CopySpriteButton.BackColor = System.Drawing.Color.Transparent
        Me.CopySpriteButton.BackgroundImage = Global.mSXdevtools.spriteEditor.My.Resources.Resources.button_copy
        Me.CopySpriteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CopySpriteButton.FlatAppearance.BorderSize = 0
        Me.CopySpriteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CopySpriteButton.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopySpriteButton.Location = New System.Drawing.Point(12, 26)
        Me.CopySpriteButton.Name = "CopySpriteButton"
        Me.CopySpriteButton.Size = New System.Drawing.Size(44, 32)
        Me.CopySpriteButton.TabIndex = 262
        Me.CopySpriteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CopySpriteButton, "Copy current Sprite to clipboard [Ctrl+C]")
        Me.CopySpriteButton.UseVisualStyleBackColor = False
        '
        'ClipboardPictureBox
        '
        Me.ClipboardPictureBox.BackColor = System.Drawing.Color.Black
        Me.ClipboardPictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.ClipboardPictureBox.Location = New System.Drawing.Point(115, 26)
        Me.ClipboardPictureBox.Name = "ClipboardPictureBox"
        Me.ClipboardPictureBox.Size = New System.Drawing.Size(32, 32)
        Me.ClipboardPictureBox.TabIndex = 42
        Me.ClipboardPictureBox.TabStop = False
        '
        'SpritePaintToolBox
        '
        Me.SpritePaintToolBox.AutoSize = False
        Me.SpritePaintToolBox.BackColor = System.Drawing.Color.Gainsboro
        Me.SpritePaintToolBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.SpritePaintToolBox.GripMargin = New System.Windows.Forms.Padding(0)
        Me.SpritePaintToolBox.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.SpritePaintToolBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PencilButton, Me.LineButton, Me.SquareButton, Me.CircleButton, Me.FillButton, Me.UndoButton})
        Me.SpritePaintToolBox.Location = New System.Drawing.Point(0, 39)
        Me.SpritePaintToolBox.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.SpritePaintToolBox.Name = "SpritePaintToolBox"
        Me.SpritePaintToolBox.Padding = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.SpritePaintToolBox.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.SpritePaintToolBox.Size = New System.Drawing.Size(38, 309)
        Me.SpritePaintToolBox.TabIndex = 3
        '
        'PencilButton
        '
        Me.PencilButton.BackColor = System.Drawing.Color.Transparent
        Me.PencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PencilButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_pencil_x32
        Me.PencilButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PencilButton.Name = "PencilButton"
        Me.PencilButton.Size = New System.Drawing.Size(36, 36)
        Me.PencilButton.Tag = "0"
        Me.PencilButton.Text = "ToolStripButton1"
        Me.PencilButton.ToolTipText = "Draw [Alt+D]"
        '
        'LineButton
        '
        Me.LineButton.BackColor = System.Drawing.Color.Transparent
        Me.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LineButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_line_32px
        Me.LineButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LineButton.Name = "LineButton"
        Me.LineButton.Size = New System.Drawing.Size(36, 36)
        Me.LineButton.Tag = "1"
        Me.LineButton.Text = "Line"
        Me.LineButton.ToolTipText = "Line [Alt+L]"
        '
        'SquareButton
        '
        Me.SquareButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SquareButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_square_32px
        Me.SquareButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SquareButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SquareButton.Name = "SquareButton"
        Me.SquareButton.Size = New System.Drawing.Size(36, 36)
        Me.SquareButton.Tag = "2"
        Me.SquareButton.Text = "ToolStripButton3"
        Me.SquareButton.ToolTipText = "Rectangle  [Alt+R] / Fill rectangle "
        '
        'CircleButton
        '
        Me.CircleButton.BackColor = System.Drawing.Color.Transparent
        Me.CircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CircleButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_ellipse_32px
        Me.CircleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CircleButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CircleButton.Name = "CircleButton"
        Me.CircleButton.Size = New System.Drawing.Size(36, 36)
        Me.CircleButton.Tag = "3"
        Me.CircleButton.Text = "ToolStripButton4"
        Me.CircleButton.ToolTipText = "Ellipse [Alt+C] / Filled Ellipse"
        '
        'FillButton
        '
        Me.FillButton.BackColor = System.Drawing.Color.Transparent
        Me.FillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FillButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_paint_32px
        Me.FillButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FillButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FillButton.Name = "FillButton"
        Me.FillButton.Size = New System.Drawing.Size(36, 36)
        Me.FillButton.Tag = "4"
        Me.FillButton.Text = "ToolStripButton5"
        Me.FillButton.ToolTipText = "Fill  [Alt+F]"
        '
        'UndoButton
        '
        Me.UndoButton.BackColor = System.Drawing.Color.Transparent
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_undo_32px
        Me.UndoButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(36, 36)
        Me.UndoButton.Text = "ToolStripButton1"
        Me.UndoButton.ToolTipText = "Undo [Ctrl+Z] / Redo [Ctrl+Y]"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.PosX_Label, Me.ToolStripStatusLabel2, Me.PosY_Label})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 348)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(600, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(70, 17)
        Me.ToolStripStatusLabel3.Text = "X:"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosX_Label
        '
        Me.PosX_Label.AutoSize = False
        Me.PosX_Label.Name = "PosX_Label"
        Me.PosX_Label.Size = New System.Drawing.Size(26, 17)
        Me.PosX_Label.Text = "00"
        Me.PosX_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(30, 17)
        Me.ToolStripStatusLabel2.Text = "Y:"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosY_Label
        '
        Me.PosY_Label.AutoSize = False
        Me.PosY_Label.Name = "PosY_Label"
        Me.PosY_Label.Size = New System.Drawing.Size(26, 17)
        Me.PosY_Label.Text = "00"
        Me.PosY_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PiXelGroupBox1
        '
        Me.PiXelGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.PiXelGroupBox1.BGColor = System.Drawing.Color.LightSkyBlue
        Me.PiXelGroupBox1.Controls.Add(Me.SpriteNumberLabel)
        Me.PiXelGroupBox1.Controls.Add(Me.UpdateSpriteButton)
        Me.PiXelGroupBox1.Controls.Add(Me.Label4)
        Me.PiXelGroupBox1.Controls.Add(Me.spritePreviewPicture)
        Me.PiXelGroupBox1.Controls.Add(Me.SpriteName)
        Me.PiXelGroupBox1.LineColor = System.Drawing.Color.DimGray
        Me.PiXelGroupBox1.Location = New System.Drawing.Point(401, 186)
        Me.PiXelGroupBox1.Name = "PiXelGroupBox1"
        Me.PiXelGroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.PiXelGroupBox1.Size = New System.Drawing.Size(160, 149)
        Me.PiXelGroupBox1.TabIndex = 8
        Me.PiXelGroupBox1.TabStop = False
        Me.PiXelGroupBox1.Text = "Sprite"
        '
        'SpriteNumberLabel
        '
        Me.SpriteNumberLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.SpriteNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SpriteNumberLabel.Location = New System.Drawing.Point(17, 67)
        Me.SpriteNumberLabel.Name = "SpriteNumberLabel"
        Me.SpriteNumberLabel.Size = New System.Drawing.Size(64, 32)
        Me.SpriteNumberLabel.TabIndex = 44
        Me.SpriteNumberLabel.Text = "000"
        Me.SpriteNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UpdateSpriteButton
        '
        Me.UpdateSpriteButton.BackColor = System.Drawing.Color.LightSkyBlue
        Me.UpdateSpriteButton.ButtonColor = System.Drawing.Color.Gray
        Me.UpdateSpriteButton.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.UpdateSpriteButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateSpriteButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.UpdateSpriteButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.icon_Ok
        Me.UpdateSpriteButton.Location = New System.Drawing.Point(10, 109)
        Me.UpdateSpriteButton.Name = "UpdateSpriteButton"
        Me.UpdateSpriteButton.Padding = New System.Windows.Forms.Padding(4)
        Me.UpdateSpriteButton.Size = New System.Drawing.Size(140, 32)
        Me.UpdateSpriteButton.TabIndex = 43
        Me.UpdateSpriteButton.Text = "Update"
        Me.ToolTip1.SetToolTip(Me.UpdateSpriteButton, "Update Sprite [Ctrl+ENTER]")
        Me.UpdateSpriteButton.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(14, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 14)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Name"
        '
        'spritePreviewPicture
        '
        Me.spritePreviewPicture.BackColor = System.Drawing.Color.Black
        Me.spritePreviewPicture.Cursor = System.Windows.Forms.Cursors.Default
        Me.spritePreviewPicture.Location = New System.Drawing.Point(115, 67)
        Me.spritePreviewPicture.Name = "spritePreviewPicture"
        Me.spritePreviewPicture.Size = New System.Drawing.Size(32, 32)
        Me.spritePreviewPicture.TabIndex = 42
        Me.spritePreviewPicture.TabStop = False
        '
        'SpriteName
        '
        Me.SpriteName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteName.Location = New System.Drawing.Point(15, 35)
        Me.SpriteName.MaxLength = 24
        Me.SpriteName.Name = "SpriteName"
        Me.SpriteName.Size = New System.Drawing.Size(132, 22)
        Me.SpriteName.TabIndex = 33
        '
        'SpriteEDPanel
        '
        Me.SpriteEDPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.SpriteEDPanel.Location = New System.Drawing.Point(39, 40)
        Me.SpriteEDPanel.Name = "SpriteEDPanel"
        Me.SpriteEDPanel.Size = New System.Drawing.Size(350, 306)
        Me.SpriteEDPanel.TabIndex = 5
        '
        'SpriteToolStrip
        '
        Me.SpriteToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.SpriteToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.SpriteToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearSpriteButton, Me.InvertButton, Me.ToolStripSeparator3, Me.FlipHorizontalButton, Me.FlipVerticalButton, Me.RotateLeftButton, Me.RotateRightButton, Me.ToolStripSeparator4, Me.Move2LeftButton, Me.Move2RightButton, Me.Move2UpButton, Me.Move2downButton, Me.ToolStripSeparator2, Me.UpdateButton})
        Me.SpriteToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.SpriteToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SpriteToolStrip.Name = "SpriteToolStrip"
        Me.SpriteToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.SpriteToolStrip.Size = New System.Drawing.Size(600, 39)
        Me.SpriteToolStrip.TabIndex = 1
        '
        'ClearSpriteButton
        '
        Me.ClearSpriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearSpriteButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_trash_32px
        Me.ClearSpriteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearSpriteButton.Name = "ClearSpriteButton"
        Me.ClearSpriteButton.Size = New System.Drawing.Size(36, 36)
        Me.ClearSpriteButton.Text = "ToolStripButton1"
        Me.ClearSpriteButton.ToolTipText = "Clear"
        '
        'InvertButton
        '
        Me.InvertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InvertButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_invert_32px
        Me.InvertButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InvertButton.Name = "InvertButton"
        Me.InvertButton.Size = New System.Drawing.Size(36, 36)
        Me.InvertButton.Text = "ToolStripButton1"
        Me.InvertButton.ToolTipText = "Invert [Ctrl+I]"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'FlipHorizontalButton
        '
        Me.FlipHorizontalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FlipHorizontalButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_flip_horizontal_32px
        Me.FlipHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipHorizontalButton.Name = "FlipHorizontalButton"
        Me.FlipHorizontalButton.Size = New System.Drawing.Size(36, 36)
        Me.FlipHorizontalButton.Text = "ToolStripButton1"
        Me.FlipHorizontalButton.ToolTipText = "Flip horizontal"
        '
        'FlipVerticalButton
        '
        Me.FlipVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FlipVerticalButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_flip_vertical_32px
        Me.FlipVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FlipVerticalButton.Name = "FlipVerticalButton"
        Me.FlipVerticalButton.Size = New System.Drawing.Size(36, 36)
        Me.FlipVerticalButton.Text = "ToolStripButton2"
        Me.FlipVerticalButton.ToolTipText = "Flip vertical"
        '
        'RotateLeftButton
        '
        Me.RotateLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateLeftButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_rotate_left_32px
        Me.RotateLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RotateLeftButton.Name = "RotateLeftButton"
        Me.RotateLeftButton.Size = New System.Drawing.Size(36, 36)
        Me.RotateLeftButton.Text = "ToolStripButton3"
        Me.RotateLeftButton.ToolTipText = "Rotate left"
        '
        'RotateRightButton
        '
        Me.RotateRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RotateRightButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_rotate_right_32px
        Me.RotateRightButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RotateRightButton.Name = "RotateRightButton"
        Me.RotateRightButton.Size = New System.Drawing.Size(36, 36)
        Me.RotateRightButton.Text = "ToolStripButton4"
        Me.RotateRightButton.ToolTipText = "Rotate right"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'Move2LeftButton
        '
        Me.Move2LeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2LeftButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_left_32px
        Me.Move2LeftButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2LeftButton.Name = "Move2LeftButton"
        Me.Move2LeftButton.Size = New System.Drawing.Size(36, 36)
        Me.Move2LeftButton.ToolTipText = "Moves to the left"
        '
        'Move2RightButton
        '
        Me.Move2RightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2RightButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_right_32px
        Me.Move2RightButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2RightButton.Name = "Move2RightButton"
        Me.Move2RightButton.Size = New System.Drawing.Size(36, 36)
        Me.Move2RightButton.Text = "ToolStripButton1"
        Me.Move2RightButton.ToolTipText = "Moves to the right"
        '
        'Move2UpButton
        '
        Me.Move2UpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2UpButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_up_32px
        Me.Move2UpButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2UpButton.Name = "Move2UpButton"
        Me.Move2UpButton.Size = New System.Drawing.Size(36, 36)
        Me.Move2UpButton.ToolTipText = "Move up"
        '
        'Move2downButton
        '
        Me.Move2downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move2downButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_down_32px
        Me.Move2downButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Move2downButton.Name = "Move2downButton"
        Me.Move2downButton.Size = New System.Drawing.Size(36, 36)
        Me.Move2downButton.ToolTipText = "Move down"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'UpdateButton
        '
        Me.UpdateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UpdateButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_tick_32px
        Me.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(36, 36)
        Me.UpdateButton.Text = "ToolStripButton1"
        Me.UpdateButton.ToolTipText = "Update Sprite [Ctrl+ENTER]"
        '
        'SpritesetPanel
        '
        Me.SpritesetPanel.BackColor = System.Drawing.Color.Silver
        Me.SpritesetPanel.Controls.Add(Me.aSpritesetControl)
        Me.SpritesetPanel.Controls.Add(Me.TilesetToolboxStrip)
        Me.SpritesetPanel.Controls.Add(Me.TilesetToolStrip)
        Me.SpritesetPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpritesetPanel.Location = New System.Drawing.Point(0, 370)
        Me.SpritesetPanel.Name = "SpritesetPanel"
        Me.SpritesetPanel.Size = New System.Drawing.Size(600, 188)
        Me.SpritesetPanel.TabIndex = 13
        '
        'aSpritesetControl
        '
        Me.aSpritesetControl.BackColor = System.Drawing.Color.Gray
        Me.aSpritesetControl.Location = New System.Drawing.Point(40, 39)
        Me.aSpritesetControl.Name = "aSpritesetControl"
        Me.aSpritesetControl.Size = New System.Drawing.Size(545, 137)
        Me.aSpritesetControl.TabIndex = 23
        Me.aSpritesetControl.WorkMode = mSXdevtools.GUI.Controls.SpritesetControl.CONTROL_MODE.SELECTER
        '
        'TilesetToolboxStrip
        '
        Me.TilesetToolboxStrip.AutoSize = False
        Me.TilesetToolboxStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.TilesetToolboxStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.TilesetToolboxStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.TilesetToolboxStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectTileButton, Me.ExchangeTilesButton, Me.CopyTileButton})
        Me.TilesetToolboxStrip.Location = New System.Drawing.Point(0, 39)
        Me.TilesetToolboxStrip.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.TilesetToolboxStrip.Name = "TilesetToolboxStrip"
        Me.TilesetToolboxStrip.Padding = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.TilesetToolboxStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TilesetToolboxStrip.Size = New System.Drawing.Size(38, 149)
        Me.TilesetToolboxStrip.TabIndex = 22
        Me.TilesetToolboxStrip.Text = "ToolStrip1"
        '
        'SelectTileButton
        '
        Me.SelectTileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SelectTileButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_selecter_32px
        Me.SelectTileButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SelectTileButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectTileButton.Name = "SelectTileButton"
        Me.SelectTileButton.Size = New System.Drawing.Size(36, 36)
        Me.SelectTileButton.Text = "ToolStripButton1"
        Me.SelectTileButton.ToolTipText = "Edit sprite"
        '
        'ExchangeTilesButton
        '
        Me.ExchangeTilesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExchangeTilesButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_exchange_32px
        Me.ExchangeTilesButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExchangeTilesButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExchangeTilesButton.Name = "ExchangeTilesButton"
        Me.ExchangeTilesButton.Size = New System.Drawing.Size(36, 36)
        Me.ExchangeTilesButton.Text = "ToolStripButton2"
        Me.ExchangeTilesButton.ToolTipText = "Exchange sprites"
        '
        'CopyTileButton
        '
        Me.CopyTileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyTileButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_copy_32px
        Me.CopyTileButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CopyTileButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyTileButton.Name = "CopyTileButton"
        Me.CopyTileButton.Size = New System.Drawing.Size(36, 36)
        Me.CopyTileButton.Text = "ToolStripButton3"
        Me.CopyTileButton.ToolTipText = "Copy sprites"
        '
        'TilesetToolStrip
        '
        Me.TilesetToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.TilesetToolStrip.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.TilesetToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewSpritesetButton, Me.LoadSpritesetButton, Me.ToolStripSeparator7, Me.CopySpritesetButton, Me.SpritesetComboBox, Me.ConfigSpritesetButton, Me.DeleteTilesetButton, Me.ToolStripSeparator6, Me.SaveSpritesetButton, Me.SaveMSXBASICbinaryButton, Me.SaveBitmapButton})
        Me.TilesetToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TilesetToolStrip.Name = "TilesetToolStrip"
        Me.TilesetToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TilesetToolStrip.Size = New System.Drawing.Size(600, 39)
        Me.TilesetToolStrip.TabIndex = 24
        '
        'NewSpritesetButton
        '
        Me.NewSpritesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewSpritesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_new_32px
        Me.NewSpritesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewSpritesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewSpritesetButton.Name = "NewSpritesetButton"
        Me.NewSpritesetButton.Size = New System.Drawing.Size(36, 36)
        Me.NewSpritesetButton.ToolTipText = "Create a New Spriteset"
        '
        'LoadSpritesetButton
        '
        Me.LoadSpritesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadSpritesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_merge_32px
        Me.LoadSpritesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LoadSpritesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadSpritesetButton.Name = "LoadSpritesetButton"
        Me.LoadSpritesetButton.Size = New System.Drawing.Size(36, 36)
        Me.LoadSpritesetButton.Text = "ToolStripButton2"
        Me.LoadSpritesetButton.ToolTipText = "Add a Spriteset"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'CopySpritesetButton
        '
        Me.CopySpritesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopySpritesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_copy_paste_32px
        Me.CopySpritesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CopySpritesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopySpritesetButton.Name = "CopySpritesetButton"
        Me.CopySpritesetButton.Size = New System.Drawing.Size(36, 36)
        Me.CopySpritesetButton.Text = "ToolStripButton1"
        Me.CopySpritesetButton.ToolTipText = "Copy current Spriteset"
        '
        'SpritesetComboBox
        '
        Me.SpritesetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpritesetComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SpritesetComboBox.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpritesetComboBox.Name = "SpritesetComboBox"
        Me.SpritesetComboBox.Size = New System.Drawing.Size(280, 39)
        '
        'ConfigSpritesetButton
        '
        Me.ConfigSpritesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConfigSpritesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_config_prj_32px
        Me.ConfigSpritesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigSpritesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConfigSpritesetButton.Name = "ConfigSpritesetButton"
        Me.ConfigSpritesetButton.Size = New System.Drawing.Size(36, 36)
        Me.ConfigSpritesetButton.Text = "ToolStripButton1"
        Me.ConfigSpritesetButton.ToolTipText = "Config current Spriteset"
        '
        'DeleteTilesetButton
        '
        Me.DeleteTilesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteTilesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_trash_32px
        Me.DeleteTilesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteTilesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteTilesetButton.Name = "DeleteTilesetButton"
        Me.DeleteTilesetButton.Size = New System.Drawing.Size(36, 36)
        Me.DeleteTilesetButton.Text = "ToolStripButton5"
        Me.DeleteTilesetButton.ToolTipText = "Delete selected Spriteset"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'SaveSpritesetButton
        '
        Me.SaveSpritesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveSpritesetButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_save_32px
        Me.SaveSpritesetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveSpritesetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveSpritesetButton.Name = "SaveSpritesetButton"
        Me.SaveSpritesetButton.Size = New System.Drawing.Size(36, 36)
        Me.SaveSpritesetButton.Text = "ToolStripButton3"
        Me.SaveSpritesetButton.ToolTipText = "Save current Spriteset in native format (XSPR)"
        '
        'SaveMSXBASICbinaryButton
        '
        Me.SaveMSXBASICbinaryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveMSXBASICbinaryButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_save_bin_32px
        Me.SaveMSXBASICbinaryButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveMSXBASICbinaryButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveMSXBASICbinaryButton.Name = "SaveMSXBASICbinaryButton"
        Me.SaveMSXBASICbinaryButton.Size = New System.Drawing.Size(36, 36)
        Me.SaveMSXBASICbinaryButton.Text = "ToolStripButton3"
        Me.SaveMSXBASICbinaryButton.ToolTipText = "Save current Spriteset in MSX BASIC Binary (spr)"
        '
        'SaveBitmapButton
        '
        Me.SaveBitmapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveBitmapButton.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.ico_save_bitmap_32px
        Me.SaveBitmapButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveBitmapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveBitmapButton.Name = "SaveBitmapButton"
        Me.SaveBitmapButton.Size = New System.Drawing.Size(36, 36)
        Me.SaveBitmapButton.Text = "ToolStripButton1"
        Me.SaveBitmapButton.ToolTipText = "Save Bitmap"
        '
        'toolboxImageList
        '
        Me.toolboxImageList.ImageStream = CType(resources.GetObject("toolboxImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.toolboxImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.toolboxImageList.Images.SetKeyName(0, "ico_ellipse_32px.png")
        Me.toolboxImageList.Images.SetKeyName(1, "ico_ellipse-empty_32px.png")
        Me.toolboxImageList.Images.SetKeyName(2, "ico_ellipse-fill_32px.png")
        Me.toolboxImageList.Images.SetKeyName(3, "ico_square_32px.png")
        Me.toolboxImageList.Images.SetKeyName(4, "ico_square-empty_32px.png")
        Me.toolboxImageList.Images.SetKeyName(5, "ico_square-fill_32px.png")
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolTip1.ForeColor = System.Drawing.Color.DarkBlue
        Me.ToolTip1.IsBalloon = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 558)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(600, 22)
        Me.StatusStrip2.TabIndex = 14
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'SpriteEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SpritesetPanel)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.SpriteEditorPanel)
        Me.Name = "SpriteEditor"
        Me.Size = New System.Drawing.Size(600, 580)
        Me.SpriteEditorPanel.ResumeLayout(False)
        Me.SpriteEditorPanel.PerformLayout()
        Me.ClipboardPiXelGroupBox.ResumeLayout(False)
        CType(Me.ClipboardPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SpritePaintToolBox.ResumeLayout(False)
        Me.SpritePaintToolBox.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PiXelGroupBox1.ResumeLayout(False)
        Me.PiXelGroupBox1.PerformLayout()
        CType(Me.spritePreviewPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SpriteToolStrip.ResumeLayout(False)
        Me.SpriteToolStrip.PerformLayout()
        Me.SpritesetPanel.ResumeLayout(False)
        Me.SpritesetPanel.PerformLayout()
        Me.TilesetToolboxStrip.ResumeLayout(False)
        Me.TilesetToolboxStrip.PerformLayout()
        Me.TilesetToolStrip.ResumeLayout(False)
        Me.TilesetToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SpriteEditorPanel As System.Windows.Forms.Panel
    Friend WithEvents SpriteEDPanel As System.Windows.Forms.Panel
    Friend WithEvents SpritePaintToolBox As System.Windows.Forms.ToolStrip
    Friend WithEvents PencilButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LineButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SquareButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CircleButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FillButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UndoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpriteToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ClearSpriteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InvertButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FlipHorizontalButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FlipVerticalButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RotateLeftButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RotateRightButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Move2LeftButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2RightButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2UpButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Move2downButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpdateButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents spritePreviewPicture As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SpriteName As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PosX_Label As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PosY_Label As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SpritesetPanel As System.Windows.Forms.Panel
    Friend WithEvents aSpritesetControl As mSXdevtools.GUI.Controls.SpritesetControl
    Private WithEvents TilesetToolboxStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents SelectTileButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExchangeTilesButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyTileButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TilesetToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NewSpritesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadSpritesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveSpritesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveMSXBASICbinaryButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveBitmapButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopySpritesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpritesetComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ConfigSpritesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteTilesetButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolboxImageList As System.Windows.Forms.ImageList
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PiXelGroupBox1 As piXelST_GroupBox
    Friend WithEvents ClipboardPiXelGroupBox As piXelST_GroupBox
    Friend WithEvents ClipboardPictureBox As PictureBox
    Friend WithEvents UpdateSpriteButton As piXelST_Button
    Friend WithEvents CopySpriteButton As Button
    Friend WithEvents PasteSpriteButton As Button
    Friend WithEvents SpriteNumberLabel As piXelST_Label
    Friend WithEvents StatusStrip2 As StatusStrip
End Class
