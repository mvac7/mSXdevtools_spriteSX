<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardSpriteSize
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
        Me.SixteenButton = New System.Windows.Forms.Button
        Me.EightButton = New System.Windows.Forms.Button
        Me.IconPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SixteenButton
        '
        Me.SixteenButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SixteenButton.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SixteenButton.Location = New System.Drawing.Point(51, 79)
        Me.SixteenButton.Name = "SixteenButton"
        Me.SixteenButton.Size = New System.Drawing.Size(225, 45)
        Me.SixteenButton.TabIndex = 6
        Me.SixteenButton.Text = "16x16"
        Me.SixteenButton.UseVisualStyleBackColor = False
        '
        'EightButton
        '
        Me.EightButton.BackColor = System.Drawing.Color.Gainsboro
        Me.EightButton.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EightButton.Location = New System.Drawing.Point(51, 26)
        Me.EightButton.Name = "EightButton"
        Me.EightButton.Size = New System.Drawing.Size(225, 45)
        Me.EightButton.TabIndex = 5
        Me.EightButton.Text = "8x8"
        Me.EightButton.UseVisualStyleBackColor = False
        '
        'IconPictureBox
        '
        Me.IconPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPictureBox.Image = spriteSXED.Wizard.My.Resources.Resources.kopetestatusmessage_by_Alessandro_Rei_B
        Me.IconPictureBox.Location = New System.Drawing.Point(304, 12)
        Me.IconPictureBox.Name = "IconPictureBox"
        Me.IconPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.IconPictureBox.TabIndex = 4
        Me.IconPictureBox.TabStop = False
        '
        'WizardSpriteSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.SixteenButton)
        Me.Controls.Add(Me.EightButton)
        Me.Controls.Add(Me.IconPictureBox)
        Me.Name = "WizardSpriteSize"
        Me.Size = New System.Drawing.Size(460, 150)
        CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SixteenButton As System.Windows.Forms.Button
    Friend WithEvents EightButton As System.Windows.Forms.Button
    Friend WithEvents IconPictureBox As System.Windows.Forms.PictureBox

End Class
