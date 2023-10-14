Public Class SourceCodeDialog

    Public Project As SpriteProject
    Private _compressData As New Compress

    Private Const SUFFIX_TYPE = "_SSET" 'SpriteSET

    Private Enum TYPE_OF_DATA As Integer
        PATTERN
        COLOR
        PATTERN_AND_COLOR
    End Enum



    Public Sub New(ByVal app_config As Config, ByVal project_Info As ProjectInfo, ByVal sprite_Project As SpriteProject, ByVal selectedID As Integer, project_path As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.binaryFiles = New Hashtable

        Me.AppConfig = app_config
        Me.Info = project_Info
        Me.Project = sprite_Project
        Me.SelectedItemID = selectedID
        Me.ProjectPath = project_path

    End Sub


    Private Sub OutputDataForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim counter As Integer = 1

        Me.DataTypeInput.InitControl(Me.AppConfig, Project.CodeFormat)

        ' includes tilesets list names in combolist
        Me.ItemSelectorComboBox.Items.Clear()
        If Me.Project.Count > 1 Then
            Me.ItemSelectorComboBox.Items.Add("All Spritesets")
        End If

        For Each aName As String In Me.Project.GetNameList
            Me.ItemSelectorComboBox.Items.Add(CStr(counter) + " - " + aName)
            counter += 1
        Next

        If Me.Project.Count > 1 Then
            If Me.Project.Contains(Me.SelectedItemID) Then
                Me.ItemSelectorComboBox.SelectedIndex = Me.Project.GetIndexFromID(Me.SelectedItemID) + 1
            Else
                Me.ItemSelectorComboBox.SelectedIndex = 0
            End If
        Else
            Me.ItemSelectorComboBox.SelectedIndex = 0
        End If

        SelectItem(ItemSelectorComboBox.SelectedIndex)

        Me.DatatypeComboBox.SelectedIndex = 0

        OutputText.ForeColor = Me.AppConfig.Color_OUTPUT_INK
        OutputText.BackColor = Me.AppConfig.Color_OUTPUT_BG

        AddHandler ItemSelectorComboBox.SelectedIndexChanged, AddressOf Me.ItemSelectorComboBox_SelectedIndexChanged
        AddHandler DatatypeComboBox.SelectedIndexChanged, AddressOf Me.DatatypeComboBox_SelectedIndexChanged
        AddHandler DataTypeInput.DataChanged, AddressOf Me.DataTypeInput_DataChanged

        GenData()

    End Sub



    Public Function GetCodeFormat() As SourceCodeInfo
        Return Me.DataTypeInput.GetCodeFormat()
    End Function



    Private Sub GenData()

        Dim outputSource As String

        Dim lebelsList As ArrayList

        Dim _spriteset As SpritesetMSX

        Dim dataLabel As String

        Dim comments As New ArrayList

        Dim data As Byte()

        Dim itemIndex As Integer

        Dim itemFirst As Integer
        Dim itemLast As Integer

        Dim startSprite As Integer = CInt(fromTextBox.Text)
        Dim endSprite As Integer = CInt(toTextBox.Text)

        _dataFormat.BASIC_Line = DataTypeInput.BASIClineNumber
        _dataFormat.BASIC_increment = DataTypeInput.BASIClineInterval

        Me.binaryFiles.Clear()

        outputSource = _dataFormat.GetProjectInfoComments(Me.Info, Me.DataTypeInput.LanguageCode)
        'outputSource += vbNewLine

        'rango de spritesets a generar. Todos o uno concreto.
        'mejora: se podria añadir un control para seleccionar y generar una lista con los spritesets a generar
        If Me.Project.Count > 1 Then
            If ItemSelectorComboBox.SelectedIndex = 0 Then
                itemFirst = 0
                itemLast = Me.Project.Count - 1
            Else
                itemFirst = ItemSelectorComboBox.SelectedIndex - 1
                itemLast = itemFirst
            End If
        Else
            itemFirst = 0
            itemLast = 0
        End If


        'indexes for assembler
        If Me.DataTypeInput.ProgrammingLanguage = SourceCodeInfo.PROGRAMMING_LANGUAGE.ASSEMBLER And Me.DataTypeInput.ASMaddIndex Then

            ' For pattern data
            If Not DatatypeComboBox.SelectedIndex = TYPE_OF_DATA.COLOR Then
                ' Generate the Assembler Labels Index 

                lebelsList = New ArrayList

                For Each aName As String In Me.Project.GetNameList
                    lebelsList.Add(_dataFormat.GetAsmFieldFormat(aName) + SUFFIX_TYPE + "_PAT")
                Next

                outputSource += _assembler.GetLabelsIndex("SPRPATTERN_INDEX", lebelsList, DataTypeInput.AsmDataWordCommand)
                'outputSource += vbNewLine

            End If


            ' For color data
            If Not DatatypeComboBox.SelectedIndex = TYPE_OF_DATA.PATTERN Then

                ' Generate the Assembler Labels Index 
                If Me.Project.Count > 0 Then

                    lebelsList = New ArrayList
                    For itemIndex = itemFirst To itemLast
                        _spriteset = Me.Project.GetSpriteset(itemIndex)
                        If _spriteset.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
                            lebelsList.Add(_dataFormat.GetAsmFieldFormat(_spriteset.Name) + SUFFIX_TYPE + "_COL")
                        End If
                    Next

                    outputSource += _assembler.GetLabelsIndex("SPRCOLORS_INDEX", lebelsList, DataTypeInput.AsmDataWordCommand)
                    'outputSource += vbNewLine

                End If

            End If

        End If


        If Not DatatypeComboBox.SelectedIndex = TYPE_OF_DATA.COLOR Then
            ' pattern data ---


            ' Generate a Sprites Pattern Data
            For spritesetIndex = itemFirst To itemLast
                _spriteset = Me.Project.GetSpriteset(spritesetIndex)

                If itemLast = itemFirst Then
                    ' only one item
                    dataLabel = Me.DataTypeInput.FieldName
                Else
                    dataLabel = _spriteset.Name
                End If

                dataLabel += SUFFIX_TYPE + "_PAT" ' + Me.DataTypeInput.GetInfoSuffix()
                data = _spriteset.GetPatternData(startSprite, endSprite)
                comments.Clear()
                comments.Add("SpriteSet Pattern Data - " + GetSpriteInfo(_spriteset)) 'SpritesetMSX.SizeLabel(_spriteset.Size))
                comments.Add("Sprite range: " + CStr(startSprite) + " to " + CStr(endSprite))
                outputSource += GetItemDataSource(dataLabel, data, comments) '+ vbNewLine
                'outputSource += vbNewLine
            Next


        End If


        If Not DatatypeComboBox.SelectedIndex = TYPE_OF_DATA.PATTERN Then
            ' Color/OR data ---


            ' Generate a Sprites Color Data
            For spritesetIndex = itemFirst To itemLast
                _spriteset = Me.Project.GetSpriteset(spritesetIndex)
                If _spriteset.Mode = SpriteMSX.SPRITE_MODE.COLOR Then

                    If itemLast = itemFirst Then
                        ' only one item
                        dataLabel = Me.DataTypeInput.FieldName
                    Else
                        dataLabel = _spriteset.Name
                    End If

                    dataLabel += SUFFIX_TYPE + "_COL" ' + Me.DataTypeInput.GetInfoSuffix()
                    data = _spriteset.GetColorData(startSprite, endSprite)
                    If Not data Is Nothing Then
                        comments.Clear()
                        comments.Add("SpriteSet Color Data - " + GetSpriteInfo(_spriteset))
                        comments.Add("Sprite range: " + CStr(startSprite) + " to " + CStr(endSprite))
                        'If _spriteset.Mode = TMS9918A.SCREEN_MODE.G2 Then
                        'End If
                        outputSource += GetItemDataSource(dataLabel, data, comments) '+ vbNewLine
                        'outputSource += vbNewLine
                    End If
                    'Else
                    '    outputSource += comment_command + _spriteset.Name + " does NOT contain color data" + vbNewLine
                    '    outputSource += vbNewLine
                End If
            Next

        End If


        OutputText.Text = outputSource

    End Sub



    Private Function GetItemDataSource(ByVal setName As String, ByVal data As Byte(), ByVal comments As ArrayList) As String

        Dim outputData As DataFormat.DataItem

        outputData = _dataFormat.GetSourceCode(setName, Me.DataTypeInput.GetCodeFormat(), data, comments)

        Me.binaryFiles.Add(setName, outputData.Data)

        Return outputData.SourceCode

    End Function



    Private Sub fromTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ValidateFromSpriteValue(sender)
    End Sub



    Private Sub toTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        ValidateToSpriteValue(sender)
    End Sub



    Private Sub ValidateFromSpriteValue(ByVal sender As TextBox)
        Dim value As String = sender.Text
        Dim maxSize As Integer = Me.Project.GetSpritesetByID(Me.SelectedItemID).TotalSprites

        If IsNumeric(value) Then
            If value < 0 Then
                sender.Text = "0"
            ElseIf value > maxSize Then
                sender.Text = "0"
            End If
        Else
            sender.Text = "0"
        End If
    End Sub



    Private Sub ValidateToSpriteValue(ByVal sender As TextBox)
        Dim value As String = sender.Text
        Dim maxSize As Integer = Me.Project.GetSpritesetByID(Me.SelectedItemID).TotalSprites

        If IsNumeric(value) Then
            If value > maxSize Then
                sender.Text = CStr(maxSize)
            End If
        Else
            sender.Text = CStr(maxSize)
        End If
    End Sub



    Private Sub ItemSelectorComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles SpritesetComboBox.SelectedIndexChanged

        SelectItem(ItemSelectorComboBox.SelectedIndex)

    End Sub



    Private Sub ShowSpriteInfo(ByVal tilesetIndex As Integer)

        Dim _spriteset As SpritesetMSX

        If tilesetIndex < 0 Then
            Me.InfoPanel.Visible = False
        Else
            _spriteset = Me.Project.GetSpriteset(tilesetIndex)

            If Not _spriteset Is Nothing Then

                If _spriteset.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                    InfoSpriteSizeLabel.Text = "16x16"
                Else
                    InfoSpriteSizeLabel.Text = "8x8"
                End If

                If _spriteset.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
                    InfoSpriteModeLabel.Text = "M2"
                    Me.ToolTip1.SetToolTip(Me.InfoSpriteModeLabel, "Multicolor V9938")
                Else
                    InfoSpriteModeLabel.Text = "M1"
                    Me.ToolTip1.SetToolTip(Me.InfoSpriteModeLabel, "Monocolor TMS9918A")
                End If

                Me.InfoPanel.Visible = True

            Else

                Me.InfoPanel.Visible = False

            End If
        End If

    End Sub



    Private Function GetSpriteInfo(ByRef _spriteset As SpritesetMSX) As String

        Dim result As String = ""

        If Not _spriteset Is Nothing Then

            result = "Size="

            If _spriteset.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                result += "16x16"
            Else
                result += "8x8"
            End If

            result += " - Mode "

            If _spriteset.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
                result += "2 Multicolor V9938"
            Else
                result += "1 Monocolor"
            End If

        End If

        Return result

    End Function



    Private Sub SelectItem(ByVal index As Integer)

        If index = 0 And Me.Project.Count > 1 Then
            ' All items

            Me.DataTypeInput.EnableAssemblerIndex = True
            Me.RangePanel.Enabled = False
            Me.InfoPanel.Visible = False

            Me.DataTypeInput.FieldName = "DATA"

        Else
            ' only one

            If Me.Project.Count > 1 Then
                index -= 1
            End If

            ShowSpriteInfo(index)

            Me.DataTypeInput.EnableAssemblerIndex = False
            Me.InfoPanel.Visible = True
            Me.RangePanel.Enabled = True

            Me.SelectedItemID = Me.Project.GetIDFromIndex(index)

            InitRange()

            Me.DataTypeInput.FieldName = Me.Project.GetSpriteset(index).Name

        End If

        GenData()

    End Sub




    Private Sub InitRange()
        Me.fromTextBox.Text = "0"
        Me.toTextBox.Text = CStr(Me.Project.GetSpritesetByID(Me.SelectedItemID).TotalSprites)
    End Sub







#Region "------------------------------------------------------------------------------------------------ events"


    Private Sub DatatypeComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        GenData()
    End Sub


    Private Sub DataTypeInput_DataChanged() 'Handles DataTypeInput.DataChanged
        GenData()
    End Sub



    Private Sub SaveSourceButton_Click(sender As Object, e As EventArgs) Handles SaveSourceButton.Click
        SaveSourceCodeDialog(DataTypeInput.ProgrammingLanguage)
    End Sub



    Private Sub SaveBinaryButton_Click(sender As Object, e As EventArgs) Handles SaveBinaryButton.Click

        Dim fileName As String
        Dim fileExtension As String = Me._compressData.Compresors_Extensions(DataTypeInput.CompressType)
        Dim filesFilter As String = Me._compressData.FileDialog_Filter(DataTypeInput.CompressType)

        'si es all items usar nombre del subproyecto
        fileName = Me.Info.Name
        ' si no usar el nombre del item

        SaveBinaryDialog(fileName, fileExtension, filesFilter, Me.DataTypeInput.LanguageCode, Me.DataTypeInput.ASMaddIndex, Me.DataTypeInput.AsmDataWordCommand)

    End Sub



    Private Sub RangeResetButton_Click(sender As Object, e As EventArgs) Handles RangeResetButton.Click
        InitRange()
    End Sub



#End Region




End Class
