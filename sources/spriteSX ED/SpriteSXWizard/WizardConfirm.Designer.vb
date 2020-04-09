<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardConfirm
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
        Me.NameLabel = New System.Windows.Forms.Label
        Me.SizeLabel = New System.Windows.Forms.Label
        Me.ColorLabel = New System.Windows.Forms.Label
        Me.OkButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.ForeColor = System.Drawing.Color.Black
        Me.NameLabel.Location = New System.Drawing.Point(47, 9)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(29, 23)
        Me.NameLabel.TabIndex = 8
        Me.NameLabel.Text = "1."
        '
        'SizeLabel
        '
        Me.SizeLabel.AutoSize = True
        Me.SizeLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SizeLabel.ForeColor = System.Drawing.Color.Black
        Me.SizeLabel.Location = New System.Drawing.Point(47, 46)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(29, 23)
        Me.SizeLabel.TabIndex = 9
        Me.SizeLabel.Text = "2."
        '
        'ColorLabel
        '
        Me.ColorLabel.AutoSize = True
        Me.ColorLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorLabel.ForeColor = System.Drawing.Color.Black
        Me.ColorLabel.Location = New System.Drawing.Point(47, 81)
        Me.ColorLabel.Name = "ColorLabel"
        Me.ColorLabel.Size = New System.Drawing.Size(29, 23)
        Me.ColorLabel.TabIndex = 10
        Me.ColorLabel.Text = "3."
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.Color.LightGreen
        Me.OkButton.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.Color.Black
        Me.OkButton.Location = New System.Drawing.Point(278, 113)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(172, 35)
        Me.OkButton.TabIndex = 11
        Me.OkButton.Text = "Make Project"
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'WizardConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.ColorLabel)
        Me.Controls.Add(Me.SizeLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Name = "WizardConfirm"
        Me.Size = New System.Drawing.Size(460, 150)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents SizeLabel As System.Windows.Forms.Label
    Friend WithEvents ColorLabel As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button

End Class
