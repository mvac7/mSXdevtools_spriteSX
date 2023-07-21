<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigSpritesetDialog
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
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.Back_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Ok_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Cancel_Button = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.ProjectInfoUserControl1 = New mSXdevtools.GUI.Controls.ProjectInfoUserControl()
        Me.SpritesetDataUC = New mSXdevtools.spriteEditor.SpritesetDataControl()
        Me.Title_Label = New mSXdevtools.GUI.Controls.piXelST_Label()
        Me.BottonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottonsPanel
        '
        Me.BottonsPanel.Controls.Add(Me.Back_Button)
        Me.BottonsPanel.Controls.Add(Me.Ok_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 383)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(534, 44)
        Me.BottonsPanel.TabIndex = 291
        '
        'Back_Button
        '
        Me.Back_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Back_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.Back_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Back_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Back_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Back_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.icon_Back
        Me.Back_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Back_Button.Location = New System.Drawing.Point(178, 4)
        Me.Back_Button.Name = "Back_Button"
        Me.Back_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Back_Button.Size = New System.Drawing.Size(125, 36)
        Me.Back_Button.TabIndex = 131
        Me.Back_Button.TabStop = False
        Me.Back_Button.Text = "Back"
        Me.Back_Button.UseVisualStyleBackColor = True
        '
        'Ok_Button
        '
        Me.Ok_Button.ButtonColor = System.Drawing.Color.Gray
        Me.Ok_Button.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.Ok_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ok_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Ok_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Ok_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Ok_Button.Location = New System.Drawing.Point(303, 4)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Ok_Button.Size = New System.Drawing.Size(125, 36)
        Me.Ok_Button.TabIndex = 129
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
        Me.Cancel_Button.Location = New System.Drawing.Point(428, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Padding = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Size = New System.Drawing.Size(102, 36)
        Me.Cancel_Button.TabIndex = 130
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'ProjectInfoUserControl1
        '
        Me.ProjectInfoUserControl1.Author = ""
        Me.ProjectInfoUserControl1.BackColor = System.Drawing.Color.Gainsboro
        Me.ProjectInfoUserControl1.Description = ""
        Me.ProjectInfoUserControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProjectInfoUserControl1.EnableSubproject = True
        Me.ProjectInfoUserControl1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectInfoUserControl1.Group = ""
        Me.ProjectInfoUserControl1.Location = New System.Drawing.Point(0, 292)
        Me.ProjectInfoUserControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ProjectInfoUserControl1.Name = "ProjectInfoUserControl1"
        Me.ProjectInfoUserControl1.ProjectName = ""
        Me.ProjectInfoUserControl1.Size = New System.Drawing.Size(534, 379)
        Me.ProjectInfoUserControl1.SubProjectName = ""
        Me.ProjectInfoUserControl1.TabIndex = 1
        Me.ProjectInfoUserControl1.Version = ""
        Me.ProjectInfoUserControl1.Visible = False
        '
        'SpritesetDataUC
        '
        Me.SpritesetDataUC.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpritesetDataUC.Location = New System.Drawing.Point(0, 32)
        Me.SpritesetDataUC.MaximumSize = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.MinimumSize = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.Name = "SpritesetDataUC"
        Me.SpritesetDataUC.Size = New System.Drawing.Size(500, 260)
        Me.SpritesetDataUC.TabIndex = 0
        '
        'Title_Label
        '
        Me.Title_Label.BackColor = System.Drawing.Color.RoyalBlue
        Me.Title_Label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Title_Label.ForeColor = System.Drawing.Color.White
        Me.Title_Label.Location = New System.Drawing.Point(0, 0)
        Me.Title_Label.Name = "Title_Label"
        Me.Title_Label.Padding = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.Title_Label.Size = New System.Drawing.Size(534, 32)
        Me.Title_Label.TabIndex = 292
        Me.Title_Label.Text = "Config Spriteset"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConfigSpritesetDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(534, 427)
        Me.ControlBox = False
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.ProjectInfoUserControl1)
        Me.Controls.Add(Me.SpritesetDataUC)
        Me.Controls.Add(Me.Title_Label)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ConfigSpritesetDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.BottonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProjectInfoUserControl1 As ProjectInfoUserControl
    Friend WithEvents SpritesetDataUC As SpritesetDataControl
    Friend WithEvents BottonsPanel As Panel
    Friend WithEvents Back_Button As piXelST_Button
    Friend WithEvents Ok_Button As piXelST_Button
    Friend WithEvents Cancel_Button As piXelST_Button
    Friend WithEvents Title_Label As piXelST_Label
End Class
