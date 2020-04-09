<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardSpriteColor
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
        Me.MulticolorButton = New System.Windows.Forms.Button
        Me.OneColorButton = New System.Windows.Forms.Button
        Me.IconPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MulticolorButton
        '
        Me.MulticolorButton.BackColor = System.Drawing.Color.Gainsboro
        Me.MulticolorButton.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MulticolorButton.Location = New System.Drawing.Point(51, 79)
        Me.MulticolorButton.Name = "MulticolorButton"
        Me.MulticolorButton.Size = New System.Drawing.Size(225, 45)
        Me.MulticolorButton.TabIndex = 9
        Me.MulticolorButton.Text = "multicolor (mode2)"
        Me.MulticolorButton.UseVisualStyleBackColor = False
        '
        'OneColorButton
        '
        Me.OneColorButton.BackColor = System.Drawing.Color.Gainsboro
        Me.OneColorButton.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OneColorButton.Location = New System.Drawing.Point(51, 26)
        Me.OneColorButton.Name = "OneColorButton"
        Me.OneColorButton.Size = New System.Drawing.Size(225, 45)
        Me.OneColorButton.TabIndex = 8
        Me.OneColorButton.Text = "one color"
        Me.OneColorButton.UseVisualStyleBackColor = False
        '
        'IconPictureBox
        '
        Me.IconPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox.Image = spriteSXED.Wizard.My.Resources.Resources.color_by_Alessandro_Rei_B
        Me.IconPictureBox.Location = New System.Drawing.Point(304, 12)
        Me.IconPictureBox.Name = "IconPictureBox"
        Me.IconPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.IconPictureBox.TabIndex = 7
        Me.IconPictureBox.TabStop = False
        '
        'WizardSpriteColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.MulticolorButton)
        Me.Controls.Add(Me.OneColorButton)
        Me.Controls.Add(Me.IconPictureBox)
        Me.Name = "WizardSpriteColor"
        Me.Size = New System.Drawing.Size(460, 150)
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MulticolorButton As System.Windows.Forms.Button
    Friend WithEvents OneColorButton As System.Windows.Forms.Button
    Friend WithEvents IconPictureBox As System.Windows.Forms.PictureBox

End Class
