<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _SpritePanel8mode2
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
        Me.SpriteContainerPanel = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ORselectedButton = New System.Windows.Forms.Button
        Me.colorINKPictureBox = New System.Windows.Forms.PictureBox
        Me.colorBGPictureBox = New System.Windows.Forms.PictureBox
        Me.testButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.colorINKPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.colorBGPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpriteContainerPanel
        '
        Me.SpriteContainerPanel.BackColor = System.Drawing.Color.DimGray
        Me.SpriteContainerPanel.Cursor = System.Windows.Forms.Cursors.Cross
        Me.SpriteContainerPanel.Location = New System.Drawing.Point(14, 46)
        Me.SpriteContainerPanel.Name = "SpriteContainerPanel"
        Me.SpriteContainerPanel.Size = New System.Drawing.Size(129, 129)
        Me.SpriteContainerPanel.TabIndex = 0
        '
        'ORselectedButton
        '
        Me.ORselectedButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ORselectedButton.Location = New System.Drawing.Point(151, 29)
        Me.ORselectedButton.Name = "ORselectedButton"
        Me.ORselectedButton.Size = New System.Drawing.Size(16, 16)
        Me.ORselectedButton.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.ORselectedButton, "Select/Unselect All")
        Me.ORselectedButton.UseVisualStyleBackColor = False
        '
        'colorINKPictureBox
        '
        Me.colorINKPictureBox.BackColor = System.Drawing.Color.White
        Me.colorINKPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.colorINKPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorINKPictureBox.Location = New System.Drawing.Point(168, 30)
        Me.colorINKPictureBox.Name = "colorINKPictureBox"
        Me.colorINKPictureBox.Size = New System.Drawing.Size(14, 14)
        Me.colorINKPictureBox.TabIndex = 21
        Me.colorINKPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorINKPictureBox, "Ink color for all lines")
        '
        'colorBGPictureBox
        '
        Me.colorBGPictureBox.BackColor = System.Drawing.Color.Black
        Me.colorBGPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.colorBGPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.colorBGPictureBox.Location = New System.Drawing.Point(184, 30)
        Me.colorBGPictureBox.Name = "colorBGPictureBox"
        Me.colorBGPictureBox.Size = New System.Drawing.Size(14, 14)
        Me.colorBGPictureBox.TabIndex = 20
        Me.colorBGPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.colorBGPictureBox, "Background color")
        '
        'testButton
        '
        Me.testButton.BackColor = System.Drawing.Color.Gold
        Me.testButton.Location = New System.Drawing.Point(14, 19)
        Me.testButton.Name = "testButton"
        Me.testButton.Size = New System.Drawing.Size(41, 21)
        Me.testButton.TabIndex = 7
        Me.testButton.TabStop = False
        Me.testButton.Text = "Test"
        Me.testButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.column_info1
        Me.PictureBox1.Location = New System.Drawing.Point(158, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(58, 24)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        '_SpritePanel8mode2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ORselectedButton)
        Me.Controls.Add(Me.colorINKPictureBox)
        Me.Controls.Add(Me.colorBGPictureBox)
        Me.Controls.Add(Me.testButton)
        Me.Controls.Add(Me.SpriteContainerPanel)
        Me.Name = "_SpritePanel8mode2"
        Me.Size = New System.Drawing.Size(350, 320)
        CType(Me.colorINKPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.colorBGPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpriteContainerPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents testButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ORselectedButton As System.Windows.Forms.Button
    Friend WithEvents colorINKPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents colorBGPictureBox As System.Windows.Forms.PictureBox

End Class
