<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpriteItemList
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
        Me.SpriteListMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SpriteListMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SpriteListMenuStrip
        '
        Me.SpriteListMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.CopyToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.SpriteListMenuStrip.Name = "ContextMenuStrip1"
        Me.SpriteListMenuStrip.Size = New System.Drawing.Size(108, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.edit_16
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.copy_blue_16px
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.trash3_red_x16
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'SpriteItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ContextMenuStrip = Me.SpriteListMenuStrip
        Me.MaximumSize = New System.Drawing.Size(36, 36)
        Me.Name = "SpriteItemList"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(36, 36)
        Me.SpriteListMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteListMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
