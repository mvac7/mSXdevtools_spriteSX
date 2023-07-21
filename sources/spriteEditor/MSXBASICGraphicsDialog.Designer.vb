<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MSXBASICGraphicsDialog
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.patternsPictureBox = New System.Windows.Forms.PictureBox()
        Me.SpritesetDataUC = New mSXdevtools.spriteEditor.SpritesetDataControl()
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.Ok_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Cancel_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Title_Label = New mSXdevtools.GUI.Controls.piXelST_Label()
        Me.SpritesPanel = New System.Windows.Forms.Panel()
        CType(Me.patternsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BottonsPanel.SuspendLayout()
        Me.SpritesPanel.SuspendLayout()
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
        'patternsPictureBox
        '
        Me.patternsPictureBox.BackColor = System.Drawing.Color.RoyalBlue
        Me.patternsPictureBox.Location = New System.Drawing.Point(106, 32)
        Me.patternsPictureBox.Name = "patternsPictureBox"
        Me.patternsPictureBox.Size = New System.Drawing.Size(256, 64)
        Me.patternsPictureBox.TabIndex = 22
        Me.patternsPictureBox.TabStop = False
        '
        'SpritesetDataUC
        '
        Me.SpritesetDataUC.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpritesetDataUC.Location = New System.Drawing.Point(0, 132)
        Me.SpritesetDataUC.MaximumSize = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.MinimumSize = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.Name = "SpritesetDataUC"
        Me.SpritesetDataUC.Size = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.TabIndex = 23
        '
        'BottonsPanel
        '
        Me.BottonsPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.BottonsPanel.Controls.Add(Me.Ok_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 410)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(504, 44)
        Me.BottonsPanel.TabIndex = 30
        '
        'Ok_Button
        '
        Me.Ok_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Ok_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.Ok_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Ok_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Ok_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Ok_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Ok_Button.Location = New System.Drawing.Point(273, 4)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Ok_Button.Size = New System.Drawing.Size(125, 36)
        Me.Ok_Button.TabIndex = 127
        Me.Ok_Button.TabStop = False
        Me.Ok_Button.Text = "Ok"
        Me.Ok_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Cancel_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Cancellation
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.Location = New System.Drawing.Point(398, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Size = New System.Drawing.Size(102, 36)
        Me.Cancel_Button.TabIndex = 128
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Title_Label
        '
        Me.Title_Label.BackColor = System.Drawing.Color.RoyalBlue
        Me.Title_Label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_Label.ForeColor = System.Drawing.Color.White
        Me.Title_Label.Location = New System.Drawing.Point(0, 0)
        Me.Title_Label.Name = "Title_Label"
        Me.Title_Label.Padding = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.Title_Label.Size = New System.Drawing.Size(504, 32)
        Me.Title_Label.TabIndex = 278
        Me.Title_Label.Text = "MSX BASIC Graphics"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SpritesPanel
        '
        Me.SpritesPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.SpritesPanel.Controls.Add(Me.patternsPictureBox)
        Me.SpritesPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpritesPanel.Location = New System.Drawing.Point(0, 32)
        Me.SpritesPanel.Name = "SpritesPanel"
        Me.SpritesPanel.Size = New System.Drawing.Size(504, 100)
        Me.SpritesPanel.TabIndex = 279
        '
        'MSXBASICGraphicsDialog
        '
        Me.AcceptButton = Me.Ok_Button
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(504, 454)
        Me.ControlBox = False
        Me.Controls.Add(Me.SpritesetDataUC)
        Me.Controls.Add(Me.SpritesPanel)
        Me.Controls.Add(Me.Title_Label)
        Me.Controls.Add(Me.BottonsPanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MSXBASICGraphicsDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.patternsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BottonsPanel.ResumeLayout(False)
        Me.SpritesPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents patternsPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents SpritesetDataUC As SpritesetDataControl
    Friend WithEvents BottonsPanel As Panel
    Friend WithEvents Ok_Button As piXelST_Button
    Friend WithEvents Cancel_Button As piXelST_Button
    Friend WithEvents Title_Label As piXelST_Label
    Friend WithEvents SpritesPanel As Panel
End Class
