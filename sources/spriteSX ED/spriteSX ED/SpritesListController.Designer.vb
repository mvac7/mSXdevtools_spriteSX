<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpritesListController
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
        Me.spritesViewGroup = New System.Windows.Forms.GroupBox
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.OrderUpButton = New System.Windows.Forms.ToolStripButton
        Me.OrderDownButton = New System.Windows.Forms.ToolStripButton
        Me.SpriteListPanel = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.spritesViewGroup.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'spritesViewGroup
        '
        Me.spritesViewGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spritesViewGroup.Controls.Add(Me.ToolStrip3)
        Me.spritesViewGroup.Controls.Add(Me.SpriteListPanel)
        Me.spritesViewGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spritesViewGroup.Location = New System.Drawing.Point(0, 0)
        Me.spritesViewGroup.Name = "spritesViewGroup"
        Me.spritesViewGroup.Size = New System.Drawing.Size(68, 335)
        Me.spritesViewGroup.TabIndex = 8
        Me.spritesViewGroup.TabStop = False
        Me.spritesViewGroup.Text = "List"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrderUpButton, Me.OrderDownButton})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(62, 25)
        Me.ToolStrip3.TabIndex = 1
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'OrderUpButton
        '
        Me.OrderUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OrderUpButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_up
        Me.OrderUpButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OrderUpButton.Name = "OrderUpButton"
        Me.OrderUpButton.Size = New System.Drawing.Size(23, 22)
        Me.OrderUpButton.Text = "ToolStripButton1"
        Me.OrderUpButton.ToolTipText = "Order Up [Alt+Up]"
        '
        'OrderDownButton
        '
        Me.OrderDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OrderDownButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.gtk_go_down
        Me.OrderDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OrderDownButton.Name = "OrderDownButton"
        Me.OrderDownButton.Size = New System.Drawing.Size(23, 22)
        Me.OrderDownButton.Text = "ToolStripButton1"
        Me.OrderDownButton.ToolTipText = "Order Down [Alt+Down]"
        '
        'SpriteListPanel
        '
        Me.SpriteListPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SpriteListPanel.AutoScroll = True
        Me.SpriteListPanel.BackColor = System.Drawing.Color.DimGray
        Me.SpriteListPanel.Location = New System.Drawing.Point(9, 45)
        Me.SpriteListPanel.Name = "SpriteListPanel"
        Me.SpriteListPanel.Size = New System.Drawing.Size(55, 284)
        Me.SpriteListPanel.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'SpritesListController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.spritesViewGroup)
        Me.Name = "SpritesListController"
        Me.Size = New System.Drawing.Size(71, 338)
        Me.spritesViewGroup.ResumeLayout(False)
        Me.spritesViewGroup.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spritesViewGroup As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents SpriteListPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OrderUpButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OrderDownButton As System.Windows.Forms.ToolStripButton

End Class
