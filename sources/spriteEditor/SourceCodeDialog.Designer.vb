<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SourceCodeDialog
    Inherits mSXdevtools.GUI.Controls.OutputDataDialog

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataTypeInput = New mSXdevtools.GUI.Controls.DataTypeInputControl()
        Me.RangePanel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fromTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.toTextBox = New System.Windows.Forms.TextBox()
        Me.RangeResetButton = New System.Windows.Forms.Button()
        Me.InfoPanel = New System.Windows.Forms.Panel()
        Me.InfoSpriteModeLabel = New System.Windows.Forms.Label()
        Me.InfoSpriteSizeLabel = New System.Windows.Forms.Label()
        Me.DatatypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ItemSelectorComboBox = New System.Windows.Forms.ComboBox()
        Me.OutputInfoPanel.SuspendLayout()
        Me.RangePanel.SuspendLayout()
        Me.InfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OutputText.ForeColor = System.Drawing.Color.Black
        Me.OutputText.Location = New System.Drawing.Point(0, 253)
        Me.OutputText.Size = New System.Drawing.Size(584, 273)
        '
        'SaveSourceButton
        '
        Me.ToolTip1.SetToolTip(Me.SaveSourceButton, "Save output to TXT file")
        '
        'SaveBinaryButton
        '
        Me.ToolTip1.SetToolTip(Me.SaveBinaryButton, "Save output to Binary file")
        '
        'OutputInfoPanel
        '
        Me.OutputInfoPanel.Controls.Add(Me.RangePanel)
        Me.OutputInfoPanel.Controls.Add(Me.InfoPanel)
        Me.OutputInfoPanel.Controls.Add(Me.DatatypeComboBox)
        Me.OutputInfoPanel.Controls.Add(Me.Label2)
        Me.OutputInfoPanel.Controls.Add(Me.Label3)
        Me.OutputInfoPanel.Controls.Add(Me.ItemSelectorComboBox)
        Me.OutputInfoPanel.Controls.Add(Me.DataTypeInput)
        Me.OutputInfoPanel.Size = New System.Drawing.Size(584, 220)
        '
        'DataTypeInput
        '
        Me.DataTypeInput.BackColor = System.Drawing.Color.Transparent
        Me.DataTypeInput.CompressType = mSXdevtools.DataCompressEncoders.iCompressEncoder.COMPRESS_TYPE.RAW
        Me.DataTypeInput.EnableAssemblerIndex = False
        Me.DataTypeInput.EnableCompress = True
        Me.DataTypeInput.EnableDataSizeLine = False
        Me.DataTypeInput.FieldName = "DATA"
        Me.DataTypeInput.Location = New System.Drawing.Point(12, 97)
        Me.DataTypeInput.Name = "DataTypeInput"
        Me.DataTypeInput.Size = New System.Drawing.Size(518, 117)
        Me.DataTypeInput.SizeLineIndex = 6
        Me.DataTypeInput.TabIndex = 0
        '
        'RangePanel
        '
        Me.RangePanel.Controls.Add(Me.Label6)
        Me.RangePanel.Controls.Add(Me.fromTextBox)
        Me.RangePanel.Controls.Add(Me.Label5)
        Me.RangePanel.Controls.Add(Me.toTextBox)
        Me.RangePanel.Controls.Add(Me.RangeResetButton)
        Me.RangePanel.Location = New System.Drawing.Point(10, 40)
        Me.RangePanel.Name = "RangePanel"
        Me.RangePanel.Size = New System.Drawing.Size(305, 25)
        Me.RangePanel.TabIndex = 288
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 22)
        Me.Label6.TabIndex = 245
        Me.Label6.Text = "Range:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fromTextBox
        '
        Me.fromTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromTextBox.Location = New System.Drawing.Point(100, 2)
        Me.fromTextBox.MaxLength = 3
        Me.fromTextBox.Name = "fromTextBox"
        Me.fromTextBox.Size = New System.Drawing.Size(34, 22)
        Me.fromTextBox.TabIndex = 15
        Me.fromTextBox.Text = "0"
        Me.fromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(136, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "to"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'toTextBox
        '
        Me.toTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toTextBox.Location = New System.Drawing.Point(190, 2)
        Me.toTextBox.MaxLength = 3
        Me.toTextBox.Name = "toTextBox"
        Me.toTextBox.Size = New System.Drawing.Size(34, 22)
        Me.toTextBox.TabIndex = 17
        Me.toTextBox.Text = "255"
        Me.toTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RangeResetButton
        '
        Me.RangeResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.RangeResetButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeResetButton.Location = New System.Drawing.Point(226, 1)
        Me.RangeResetButton.Name = "RangeResetButton"
        Me.RangeResetButton.Size = New System.Drawing.Size(44, 23)
        Me.RangeResetButton.TabIndex = 21
        Me.RangeResetButton.Text = "All"
        Me.RangeResetButton.UseVisualStyleBackColor = False
        '
        'InfoPanel
        '
        Me.InfoPanel.BackColor = System.Drawing.Color.Transparent
        Me.InfoPanel.Controls.Add(Me.InfoSpriteModeLabel)
        Me.InfoPanel.Controls.Add(Me.InfoSpriteSizeLabel)
        Me.InfoPanel.Location = New System.Drawing.Point(467, 9)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.Size = New System.Drawing.Size(89, 22)
        Me.InfoPanel.TabIndex = 287
        '
        'InfoSpriteModeLabel
        '
        Me.InfoSpriteModeLabel.BackColor = System.Drawing.Color.LightGray
        Me.InfoSpriteModeLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoSpriteModeLabel.Location = New System.Drawing.Point(54, 0)
        Me.InfoSpriteModeLabel.Name = "InfoSpriteModeLabel"
        Me.InfoSpriteModeLabel.Size = New System.Drawing.Size(30, 22)
        Me.InfoSpriteModeLabel.TabIndex = 277
        Me.InfoSpriteModeLabel.Text = "M1"
        Me.InfoSpriteModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfoSpriteSizeLabel
        '
        Me.InfoSpriteSizeLabel.BackColor = System.Drawing.Color.LightGray
        Me.InfoSpriteSizeLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoSpriteSizeLabel.Location = New System.Drawing.Point(0, 0)
        Me.InfoSpriteSizeLabel.Name = "InfoSpriteSizeLabel"
        Me.InfoSpriteSizeLabel.Size = New System.Drawing.Size(48, 22)
        Me.InfoSpriteSizeLabel.TabIndex = 276
        Me.InfoSpriteSizeLabel.Text = "16x16"
        Me.InfoSpriteSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DatatypeComboBox
        '
        Me.DatatypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DatatypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DatatypeComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatatypeComboBox.FormattingEnabled = True
        Me.DatatypeComboBox.Items.AddRange(New Object() {"Pattern", "Color", "Pattern + Color"})
        Me.DatatypeComboBox.Location = New System.Drawing.Point(111, 71)
        Me.DatatypeComboBox.Name = "DatatypeComboBox"
        Me.DatatypeComboBox.Size = New System.Drawing.Size(170, 22)
        Me.DatatypeComboBox.TabIndex = 286
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 22)
        Me.Label2.TabIndex = 285
        Me.Label2.Text = "Data:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 22)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "Spriteset:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ItemSelectorComboBox
        '
        Me.ItemSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemSelectorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ItemSelectorComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemSelectorComboBox.FormattingEnabled = True
        Me.ItemSelectorComboBox.Items.AddRange(New Object() {"All Maps"})
        Me.ItemSelectorComboBox.Location = New System.Drawing.Point(110, 9)
        Me.ItemSelectorComboBox.Name = "ItemSelectorComboBox"
        Me.ItemSelectorComboBox.Size = New System.Drawing.Size(350, 22)
        Me.ItemSelectorComboBox.TabIndex = 283
        '
        'SourceCodeDialog
        '
        Me.ClientSize = New System.Drawing.Size(584, 584)
        Me.Name = "SourceCodeDialog"
        Me.OutputInfoPanel.ResumeLayout(False)
        Me.RangePanel.ResumeLayout(False)
        Me.RangePanel.PerformLayout()
        Me.InfoPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataTypeInput As DataTypeInputControl
    Friend WithEvents RangePanel As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents fromTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents toTextBox As TextBox
    Friend WithEvents RangeResetButton As Button
    Friend WithEvents InfoPanel As Panel
    Friend WithEvents InfoSpriteModeLabel As Label
    Friend WithEvents InfoSpriteSizeLabel As Label
    Friend WithEvents DatatypeComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ItemSelectorComboBox As ComboBox
End Class
