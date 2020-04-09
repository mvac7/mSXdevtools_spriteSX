<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpritePixel
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
        Me.PixelBox = New System.Windows.Forms.PictureBox
        CType(Me.PixelBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PixelBox
        '
        Me.PixelBox.BackColor = System.Drawing.Color.Black
        Me.PixelBox.Location = New System.Drawing.Point(0, 0)
        Me.PixelBox.Name = "PixelBox"
        Me.PixelBox.Size = New System.Drawing.Size(15, 15)
        Me.PixelBox.TabIndex = 0
        Me.PixelBox.TabStop = False
        '
        'SpritePixel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.PixelBox)
        Me.MaximumSize = New System.Drawing.Size(16, 16)
        Me.MinimumSize = New System.Drawing.Size(16, 16)
        Me.Name = "SpritePixel"
        Me.Size = New System.Drawing.Size(16, 16)
        CType(Me.PixelBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PixelBox As System.Windows.Forms.PictureBox

End Class
