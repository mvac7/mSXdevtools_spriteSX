<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OutputDataForm
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
        Me.components = New System.ComponentModel.Container
        Me.OutputText = New System.Windows.Forms.TextBox
        Me.GetDataButton = New System.Windows.Forms.Button
        Me.LanguageComboBox = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ExitButton = New System.Windows.Forms.Button
        Me.SaveDataButton = New System.Windows.Forms.Button
        Me.CopyAllButton = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PaletteSizeCombo = New System.Windows.Forms.ComboBox
        Me.SpriteSizeCombo = New System.Windows.Forms.ComboBox
        Me.ColorDataSizeCombo = New System.Windows.Forms.ComboBox
        Me.SpriteNumCombo = New System.Windows.Forms.ComboBox
        Me.ColorNumCombo = New System.Windows.Forms.ComboBox
        Me.PaletteNumCombo = New System.Windows.Forms.ComboBox
        Me.AllNumCombo = New System.Windows.Forms.ComboBox
        Me.AllSpritesButton = New System.Windows.Forms.Button
        Me.IntervalText = New System.Windows.Forms.TextBox
        Me.LineNumberText = New System.Windows.Forms.TextBox
        Me.fromTextBox = New System.Windows.Forms.TextBox
        Me.toTextBox = New System.Windows.Forms.TextBox
        Me.ColorSizeValuesCombo = New System.Windows.Forms.ComboBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SpriteCheck = New System.Windows.Forms.CheckBox
        Me.PaletteCheck = New System.Windows.Forms.CheckBox
        Me.LineNumberLabel = New System.Windows.Forms.Label
        Me.IntervalLabel = New System.Windows.Forms.Label
        Me.ColorDataCheck = New System.Windows.Forms.CheckBox
        Me.RemoveZerosCheck = New System.Windows.Forms.CheckBox
        Me.FromLabel = New System.Windows.Forms.Label
        Me.ToLabel = New System.Windows.Forms.Label
        Me.RangeCheck = New System.Windows.Forms.CheckBox
        Me.BasicGroupBox = New System.Windows.Forms.GroupBox
        Me.BasicGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputText.Location = New System.Drawing.Point(12, 183)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(500, 238)
        Me.OutputText.TabIndex = 0
        '
        'GetDataButton
        '
        Me.GetDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetDataButton.BackColor = System.Drawing.Color.PaleGreen
        Me.GetDataButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetDataButton.Location = New System.Drawing.Point(402, 145)
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(110, 32)
        Me.GetDataButton.TabIndex = 19
        Me.GetDataButton.Text = "Get Data!"
        Me.ToolTip1.SetToolTip(Me.GetDataButton, "Generate data")
        Me.GetDataButton.UseVisualStyleBackColor = False
        '
        'LanguageComboBox
        '
        Me.LanguageComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LanguageComboBox.FormattingEnabled = True
        Me.LanguageComboBox.Items.AddRange(New Object() {"BASIC", "C", "ASM", "ASM (SDCC)"})
        Me.LanguageComboBox.Location = New System.Drawing.Point(82, 12)
        Me.LanguageComboBox.Name = "LanguageComboBox"
        Me.LanguageComboBox.Size = New System.Drawing.Size(120, 21)
        Me.LanguageComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Language"
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.LightSalmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.ForeColor = System.Drawing.Color.Black
        Me.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ExitButton.Location = New System.Drawing.Point(452, 429)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(60, 26)
        Me.ExitButton.TabIndex = 22
        Me.ExitButton.Text = "Exit!"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'SaveDataButton
        '
        Me.SaveDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveDataButton.BackColor = System.Drawing.Color.LightGray
        Me.SaveDataButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveDataButton.Image = Global.mSXdevtools.spriteSXED.My.Resources.Resources.save2_x24
        Me.SaveDataButton.Location = New System.Drawing.Point(98, 427)
        Me.SaveDataButton.Name = "SaveDataButton"
        Me.SaveDataButton.Size = New System.Drawing.Size(36, 30)
        Me.SaveDataButton.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.SaveDataButton, "Save output to file")
        Me.SaveDataButton.UseVisualStyleBackColor = False
        '
        'CopyAllButton
        '
        Me.CopyAllButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CopyAllButton.BackColor = System.Drawing.Color.Gainsboro
        Me.CopyAllButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyAllButton.Location = New System.Drawing.Point(12, 427)
        Me.CopyAllButton.Name = "CopyAllButton"
        Me.CopyAllButton.Size = New System.Drawing.Size(80, 30)
        Me.CopyAllButton.TabIndex = 20
        Me.CopyAllButton.Text = "Copy All"
        Me.ToolTip1.SetToolTip(Me.CopyAllButton, "Copy output to clipboard")
        Me.CopyAllButton.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'PaletteSizeCombo
        '
        Me.PaletteSizeCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteSizeCombo.FormattingEnabled = True
        Me.PaletteSizeCombo.Items.AddRange(New Object() {"2", "4", "8", "16", "32"})
        Me.PaletteSizeCombo.Location = New System.Drawing.Point(132, 120)
        Me.PaletteSizeCombo.Name = "PaletteSizeCombo"
        Me.PaletteSizeCombo.Size = New System.Drawing.Size(70, 21)
        Me.PaletteSizeCombo.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.PaletteSizeCombo, "Number of values ​​per line, for palette data.")
        '
        'SpriteSizeCombo
        '
        Me.SpriteSizeCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteSizeCombo.FormattingEnabled = True
        Me.SpriteSizeCombo.Items.AddRange(New Object() {"2", "4", "8", "16", "32", "64"})
        Me.SpriteSizeCombo.Location = New System.Drawing.Point(132, 66)
        Me.SpriteSizeCombo.Name = "SpriteSizeCombo"
        Me.SpriteSizeCombo.Size = New System.Drawing.Size(70, 21)
        Me.SpriteSizeCombo.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.SpriteSizeCombo, "Number of values ​​per line, for sprites data.")
        '
        'ColorDataSizeCombo
        '
        Me.ColorDataSizeCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorDataSizeCombo.FormattingEnabled = True
        Me.ColorDataSizeCombo.Items.AddRange(New Object() {"2", "4", "8", "16"})
        Me.ColorDataSizeCombo.Location = New System.Drawing.Point(132, 93)
        Me.ColorDataSizeCombo.Name = "ColorDataSizeCombo"
        Me.ColorDataSizeCombo.Size = New System.Drawing.Size(70, 21)
        Me.ColorDataSizeCombo.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.ColorDataSizeCombo, "Number of values ​​per line, for color data.")
        '
        'SpriteNumCombo
        '
        Me.SpriteNumCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteNumCombo.FormattingEnabled = True
        Me.SpriteNumCombo.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.SpriteNumCombo.Location = New System.Drawing.Point(206, 66)
        Me.SpriteNumCombo.Name = "SpriteNumCombo"
        Me.SpriteNumCombo.Size = New System.Drawing.Size(80, 21)
        Me.SpriteNumCombo.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.SpriteNumCombo, "Numeral system.")
        '
        'ColorNumCombo
        '
        Me.ColorNumCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorNumCombo.FormattingEnabled = True
        Me.ColorNumCombo.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.ColorNumCombo.Location = New System.Drawing.Point(206, 93)
        Me.ColorNumCombo.Name = "ColorNumCombo"
        Me.ColorNumCombo.Size = New System.Drawing.Size(80, 21)
        Me.ColorNumCombo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.ColorNumCombo, "Numeral system.")
        '
        'PaletteNumCombo
        '
        Me.PaletteNumCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNumCombo.FormattingEnabled = True
        Me.PaletteNumCombo.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.PaletteNumCombo.Location = New System.Drawing.Point(206, 120)
        Me.PaletteNumCombo.Name = "PaletteNumCombo"
        Me.PaletteNumCombo.Size = New System.Drawing.Size(80, 21)
        Me.PaletteNumCombo.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.PaletteNumCombo, "Numeral system.")
        '
        'AllNumCombo
        '
        Me.AllNumCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllNumCombo.FormattingEnabled = True
        Me.AllNumCombo.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.AllNumCombo.Location = New System.Drawing.Point(206, 12)
        Me.AllNumCombo.Name = "AllNumCombo"
        Me.AllNumCombo.Size = New System.Drawing.Size(80, 21)
        Me.AllNumCombo.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.AllNumCombo, "Select numeral system " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for all data types.")
        '
        'AllSpritesButton
        '
        Me.AllSpritesButton.BackColor = System.Drawing.Color.Gainsboro
        Me.AllSpritesButton.Enabled = False
        Me.AllSpritesButton.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllSpritesButton.Location = New System.Drawing.Point(290, 38)
        Me.AllSpritesButton.Name = "AllSpritesButton"
        Me.AllSpritesButton.Size = New System.Drawing.Size(34, 22)
        Me.AllSpritesButton.TabIndex = 7
        Me.AllSpritesButton.Text = "All"
        Me.ToolTip1.SetToolTip(Me.AllSpritesButton, "Select All sprites")
        Me.AllSpritesButton.UseVisualStyleBackColor = False
        '
        'IntervalText
        '
        Me.IntervalText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntervalText.Location = New System.Drawing.Point(104, 49)
        Me.IntervalText.MaxLength = 3
        Me.IntervalText.Name = "IntervalText"
        Me.IntervalText.Size = New System.Drawing.Size(52, 21)
        Me.IntervalText.TabIndex = 4
        Me.IntervalText.Text = "10"
        Me.IntervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.IntervalText, "Interval lines (for BASIC)")
        '
        'LineNumberText
        '
        Me.LineNumberText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumberText.Location = New System.Drawing.Point(104, 22)
        Me.LineNumberText.MaxLength = 5
        Me.LineNumberText.Name = "LineNumberText"
        Me.LineNumberText.Size = New System.Drawing.Size(52, 21)
        Me.LineNumberText.TabIndex = 3
        Me.LineNumberText.Text = "10000"
        Me.LineNumberText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.LineNumberText, "Initial number of line (for BASIC)")
        '
        'fromTextBox
        '
        Me.fromTextBox.Enabled = False
        Me.fromTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromTextBox.Location = New System.Drawing.Point(170, 39)
        Me.fromTextBox.MaxLength = 3
        Me.fromTextBox.Name = "fromTextBox"
        Me.fromTextBox.Size = New System.Drawing.Size(30, 21)
        Me.fromTextBox.TabIndex = 5
        Me.fromTextBox.Text = "0"
        Me.fromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.fromTextBox, "First sprite")
        '
        'toTextBox
        '
        Me.toTextBox.Enabled = False
        Me.toTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toTextBox.Location = New System.Drawing.Point(256, 39)
        Me.toTextBox.MaxLength = 3
        Me.toTextBox.Name = "toTextBox"
        Me.toTextBox.Size = New System.Drawing.Size(30, 21)
        Me.toTextBox.TabIndex = 6
        Me.toTextBox.Text = "255"
        Me.toTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.toTextBox, "Last sprite")
        '
        'ColorSizeValuesCombo
        '
        Me.ColorSizeValuesCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorSizeValuesCombo.FormattingEnabled = True
        Me.ColorSizeValuesCombo.Items.AddRange(New Object() {"8", "16"})
        Me.ColorSizeValuesCombo.Location = New System.Drawing.Point(290, 93)
        Me.ColorSizeValuesCombo.Name = "ColorSizeValuesCombo"
        Me.ColorSizeValuesCombo.Size = New System.Drawing.Size(34, 21)
        Me.ColorSizeValuesCombo.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.ColorSizeValuesCombo, "Adds 8 values ​​(0), to achieve 16 values ​​per " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sprite, in the case of size 8 p" & _
                "ixels " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(for sending a single block to the VRAM).")
        '
        'SpriteCheck
        '
        Me.SpriteCheck.AutoSize = True
        Me.SpriteCheck.Checked = True
        Me.SpriteCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SpriteCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteCheck.Location = New System.Drawing.Point(30, 68)
        Me.SpriteCheck.Name = "SpriteCheck"
        Me.SpriteCheck.Size = New System.Drawing.Size(91, 17)
        Me.SpriteCheck.TabIndex = 10
        Me.SpriteCheck.Text = "Sprite Data"
        Me.SpriteCheck.UseVisualStyleBackColor = True
        '
        'PaletteCheck
        '
        Me.PaletteCheck.AutoSize = True
        Me.PaletteCheck.Checked = True
        Me.PaletteCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PaletteCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteCheck.Location = New System.Drawing.Point(30, 121)
        Me.PaletteCheck.Name = "PaletteCheck"
        Me.PaletteCheck.Size = New System.Drawing.Size(96, 17)
        Me.PaletteCheck.TabIndex = 16
        Me.PaletteCheck.Text = "Palette Data"
        Me.PaletteCheck.UseVisualStyleBackColor = True
        '
        'LineNumberLabel
        '
        Me.LineNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumberLabel.Location = New System.Drawing.Point(12, 25)
        Me.LineNumberLabel.Name = "LineNumberLabel"
        Me.LineNumberLabel.Size = New System.Drawing.Size(90, 13)
        Me.LineNumberLabel.TabIndex = 13
        Me.LineNumberLabel.Text = "Line number:"
        Me.LineNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IntervalLabel
        '
        Me.IntervalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntervalLabel.Location = New System.Drawing.Point(12, 52)
        Me.IntervalLabel.Name = "IntervalLabel"
        Me.IntervalLabel.Size = New System.Drawing.Size(90, 13)
        Me.IntervalLabel.TabIndex = 14
        Me.IntervalLabel.Text = "Interval:"
        Me.IntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColorDataCheck
        '
        Me.ColorDataCheck.AutoSize = True
        Me.ColorDataCheck.Checked = True
        Me.ColorDataCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ColorDataCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorDataCheck.Location = New System.Drawing.Point(30, 95)
        Me.ColorDataCheck.Name = "ColorDataCheck"
        Me.ColorDataCheck.Size = New System.Drawing.Size(88, 17)
        Me.ColorDataCheck.TabIndex = 13
        Me.ColorDataCheck.Text = "Color Data"
        Me.ColorDataCheck.UseVisualStyleBackColor = True
        '
        'RemoveZerosCheck
        '
        Me.RemoveZerosCheck.AutoSize = True
        Me.RemoveZerosCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RemoveZerosCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveZerosCheck.Location = New System.Drawing.Point(11, 77)
        Me.RemoveZerosCheck.Name = "RemoveZerosCheck"
        Me.RemoveZerosCheck.Size = New System.Drawing.Size(108, 17)
        Me.RemoveZerosCheck.TabIndex = 8
        Me.RemoveZerosCheck.Text = "Remove zeros"
        Me.RemoveZerosCheck.UseVisualStyleBackColor = True
        '
        'FromLabel
        '
        Me.FromLabel.Enabled = False
        Me.FromLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromLabel.Location = New System.Drawing.Point(121, 42)
        Me.FromLabel.Name = "FromLabel"
        Me.FromLabel.Size = New System.Drawing.Size(47, 13)
        Me.FromLabel.TabIndex = 24
        Me.FromLabel.Text = "From:"
        Me.FromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToLabel
        '
        Me.ToLabel.Enabled = False
        Me.ToLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToLabel.Location = New System.Drawing.Point(231, 42)
        Me.ToLabel.Name = "ToLabel"
        Me.ToLabel.Size = New System.Drawing.Size(23, 13)
        Me.ToLabel.TabIndex = 26
        Me.ToLabel.Text = "to:"
        Me.ToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RangeCheck
        '
        Me.RangeCheck.AutoSize = True
        Me.RangeCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeCheck.Location = New System.Drawing.Point(30, 41)
        Me.RangeCheck.Name = "RangeCheck"
        Me.RangeCheck.Size = New System.Drawing.Size(62, 17)
        Me.RangeCheck.TabIndex = 27
        Me.RangeCheck.Text = "Range"
        Me.RangeCheck.UseVisualStyleBackColor = True
        '
        'BasicGroupBox
        '
        Me.BasicGroupBox.Controls.Add(Me.LineNumberLabel)
        Me.BasicGroupBox.Controls.Add(Me.IntervalText)
        Me.BasicGroupBox.Controls.Add(Me.LineNumberText)
        Me.BasicGroupBox.Controls.Add(Me.IntervalLabel)
        Me.BasicGroupBox.Controls.Add(Me.RemoveZerosCheck)
        Me.BasicGroupBox.Location = New System.Drawing.Point(343, 6)
        Me.BasicGroupBox.Name = "BasicGroupBox"
        Me.BasicGroupBox.Size = New System.Drawing.Size(169, 100)
        Me.BasicGroupBox.TabIndex = 29
        Me.BasicGroupBox.TabStop = False
        Me.BasicGroupBox.Text = "Basic"
        '
        'OutputDataForm
        '
        Me.AcceptButton = Me.GetDataButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(524, 462)
        Me.Controls.Add(Me.BasicGroupBox)
        Me.Controls.Add(Me.ColorSizeValuesCombo)
        Me.Controls.Add(Me.RangeCheck)
        Me.Controls.Add(Me.AllSpritesButton)
        Me.Controls.Add(Me.ToLabel)
        Me.Controls.Add(Me.toTextBox)
        Me.Controls.Add(Me.FromLabel)
        Me.Controls.Add(Me.fromTextBox)
        Me.Controls.Add(Me.AllNumCombo)
        Me.Controls.Add(Me.PaletteNumCombo)
        Me.Controls.Add(Me.ColorNumCombo)
        Me.Controls.Add(Me.SpriteNumCombo)
        Me.Controls.Add(Me.ColorDataSizeCombo)
        Me.Controls.Add(Me.ColorDataCheck)
        Me.Controls.Add(Me.PaletteSizeCombo)
        Me.Controls.Add(Me.SpriteSizeCombo)
        Me.Controls.Add(Me.PaletteCheck)
        Me.Controls.Add(Me.SpriteCheck)
        Me.Controls.Add(Me.CopyAllButton)
        Me.Controls.Add(Me.SaveDataButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LanguageComboBox)
        Me.Controls.Add(Me.GetDataButton)
        Me.Controls.Add(Me.OutputText)
        Me.MinimumSize = New System.Drawing.Size(540, 440)
        Me.Name = "OutputDataForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Output Data"
        Me.BasicGroupBox.ResumeLayout(False)
        Me.BasicGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutputText As System.Windows.Forms.TextBox
    Friend WithEvents GetDataButton As System.Windows.Forms.Button
    Friend WithEvents LanguageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SaveDataButton As System.Windows.Forms.Button
    Friend WithEvents CopyAllButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SpriteCheck As System.Windows.Forms.CheckBox
    Friend WithEvents PaletteCheck As System.Windows.Forms.CheckBox
    Friend WithEvents SpriteSizeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents PaletteSizeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents IntervalText As System.Windows.Forms.TextBox
    Friend WithEvents LineNumberText As System.Windows.Forms.TextBox
    Friend WithEvents LineNumberLabel As System.Windows.Forms.Label
    Friend WithEvents IntervalLabel As System.Windows.Forms.Label
    Friend WithEvents ColorDataSizeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents ColorDataCheck As System.Windows.Forms.CheckBox
    Friend WithEvents SpriteNumCombo As System.Windows.Forms.ComboBox
    Friend WithEvents ColorNumCombo As System.Windows.Forms.ComboBox
    Friend WithEvents PaletteNumCombo As System.Windows.Forms.ComboBox
    Friend WithEvents AllNumCombo As System.Windows.Forms.ComboBox
    Friend WithEvents RemoveZerosCheck As System.Windows.Forms.CheckBox
    Friend WithEvents FromLabel As System.Windows.Forms.Label
    Friend WithEvents fromTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToLabel As System.Windows.Forms.Label
    Friend WithEvents toTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AllSpritesButton As System.Windows.Forms.Button
    Friend WithEvents RangeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ColorSizeValuesCombo As System.Windows.Forms.ComboBox
    Friend WithEvents BasicGroupBox As System.Windows.Forms.GroupBox
End Class
