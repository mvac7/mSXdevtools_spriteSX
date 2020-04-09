<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardSpritePrjName
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
        Me.Next1Button = New System.Windows.Forms.Button
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.IconPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Next1Button
        '
        Me.Next1Button.BackColor = System.Drawing.Color.Gainsboro
        Me.Next1Button.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Next1Button.Location = New System.Drawing.Point(51, 79)
        Me.Next1Button.Name = "Next1Button"
        Me.Next1Button.Size = New System.Drawing.Size(225, 45)
        Me.Next1Button.TabIndex = 2
        Me.Next1Button.Text = "Next"
        Me.Next1Button.UseVisualStyleBackColor = False
        '
        'NameTextBox
        '
        Me.NameTextBox.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.Location = New System.Drawing.Point(51, 30)
        Me.NameTextBox.MaxLength = 24
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(225, 31)
        Me.NameTextBox.TabIndex = 1
        '
        'IconPictureBox
        '
        Me.IconPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox.Image = spriteSXED.Wizard.My.Resources.Resources.entrymessage
        Me.IconPictureBox.Location = New System.Drawing.Point(304, 12)
        Me.IconPictureBox.Name = "IconPictureBox"
        Me.IconPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.IconPictureBox.TabIndex = 10
        Me.IconPictureBox.TabStop = False
        '
        'WizardSpritePrjName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.Next1Button)
        Me.Controls.Add(Me.IconPictureBox)
        Me.Name = "WizardSpritePrjName"
        Me.Size = New System.Drawing.Size(460, 150)
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Next1Button As System.Windows.Forms.Button
    Friend WithEvents IconPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox

End Class
