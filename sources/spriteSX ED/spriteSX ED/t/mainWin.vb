Imports System.IO
Imports System.Xml
Imports MSXLibrary




Public Class mainWin

    Private _TEST As Boolean = False

    Private Const AppName As String = "spriteSX ED"
    Private Const version As String = "0.7.7a" ' last:0.7.6a(23/11/2012), 0.7.5a(12/11/2012), 0.7.4a (11/11/2012), 0.7.3a (9/11/2012), 0.7.2a (21/2/2012)
    Private Const versionDate As String = "(1/12/2012)"

    'Private ProjectName As String = ""
    'Private ProjectSize As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.INIT     ' 1=8x8,  2=16x16 
    'Private ProjectMode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO  ' 1=MSX1, 2=MSX2 or +

    Private ProjectFileName As String = ""


    Private OutputDataDialog As New OutputDataForm()

    Private SpriteContainer As ISpriteContainer 'SpritePanel16mode2
    Private SpriteControl As Control

    Private paletteDialog As New palette512Dialog()

    'Private sprites As New SortedList
    'Private spritePictures As New SortedList

    'Private SpriteSelected As String
    'Private SpriteSelectedIcon As PictureBox


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.SpriteContainer.ChanguePalette(paletteDialog.PaletteColors)

    End Sub



    Private Sub EditPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPaletteButton.Click
        Dim result As DialogResult
        result = paletteDialog.ShowWinDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
            Me.SpriteProject.RefreshPalette(paletteDialog.PaletteColors)
        End If

    End Sub

    Private Sub mainWin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Application.DoEvents()
        'Me.Refresh()
        'SpriteContainer.Refresh()
        'Application.DoEvents()
    End Sub

    'Private Sub mainWin_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
    '    SpriteContainer.SpriteNameTextBox.Focus()
    'End Sub

    'Private Sub mainWin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
    '    SpriteContainer.SpriteNameTextBox.Focus()

    'End Sub

    Private Sub mainWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = AppName + " v" + version + " " + versionDate
    End Sub



    Private Sub NewSpriteButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSpriteButton.Click
        Me.SpriteContainer.NewSprite()
    End Sub


    Private Sub CopySpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopySpriteButton.Click
        CopySprite()
    End Sub

    Private Sub NewSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSpriteButton.Click
        Me.SpriteContainer.ClearSprite()
    End Sub

    Private Sub FlipHorizontalButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipHorizontalButton.Click
        Me.SpriteContainer.FlipHorizontalSprite()
    End Sub

    Private Sub FlipVerticalButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipVerticalButton.Click
        Me.SpriteContainer.FlipVerticalSprite()
    End Sub

    Private Sub RotateLeftButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateLeftButton.Click
        Me.SpriteContainer.RotateLeftSprite()
    End Sub

    Private Sub RotateRightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateRightButton.Click
        Me.SpriteContainer.RotateRightSprite()
    End Sub

    Private Sub checkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkButton.Click
        AddAction()
    End Sub


    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        AddAction()
    End Sub




    ' ##########################################################
    ' PROVISIONAL
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Me.SpriteContainer.Focus()

        Timer1.Enabled = False

    End Sub




    ''' <summary>
    ''' Recoge el sprite el sprite del editor y lo manda al controlador del proyecto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddAction()
        Dim aSprite As SpriteMSX

        aSprite = Me.SpriteContainer.GetSprite()

        AddSprite(aSprite)

        SpriteProject.ShowItem(aSprite.ID)

    End Sub


    Private Sub AddSprite(ByVal aSprite As SpriteMSX)

        If Not Me.SpriteProject.sprites.Contains(aSprite.ID) Then 'comprueba que no exista ya en la lista
            ' añade
            SpriteProject.AddNewSprite(aSprite)
        Else
            ' lo reemplaza
            SpriteProject.UpdateSprite(aSprite)
        End If

    End Sub


    Private Sub CopySprite()
        If Me.SpriteContainer.WorkSprite Is Nothing Then
            ' en el caso de que no haya un sprite en el editor

        Else
            Me.SpriteContainer.Copy()
            AddAction()
        End If
    End Sub


    Private Sub GetDataButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDataButton.Click

        'Private OutputDataDialog As New OutputDataForm()
        'Me.ProjectName, Me.SpriteListBox1.sprites, Me.paletteDialog.PaletteColors, Me.ProjectMode, Me.ProjectType)
        Me.OutputDataDialog.ProjectName = Me.SpriteProject.ProjectName
        Me.OutputDataDialog.ProjectMode = Me.SpriteProject.ProjectMode
        Me.OutputDataDialog.ProjectSize = Me.SpriteProject.ProjectSize
        Me.OutputDataDialog.Sprites = Me.SpriteProject.sprites
        Me.OutputDataDialog.PaletteColors = Me.paletteDialog.PaletteColors

        OutputDataDialog.ShowDialog()

    End Sub


    'Private Sub addNewSpritePic(ByVal name As String, ByVal Image As Bitmap)
    '    Dim spritePicture = New System.Windows.Forms.PictureBox
    '    Me.SuspendLayout()
    '    spritePicture.BackColor = System.Drawing.Color.Gray
    '    spritePicture.Dock = System.Windows.Forms.DockStyle.Top
    '    spritePicture.Location = New System.Drawing.Point(0, 0)
    '    spritePicture.Name = name
    '    spritePicture.Size = New System.Drawing.Size(36, 36)
    '    spritePicture.MaximumSize = New System.Drawing.Size(36, 36)
    '    spritePicture.Padding = New System.Windows.Forms.Padding(2)
    '    spritePicture.TabIndex = 0
    '    spritePicture.TabStop = False
    '    spritePicture.Image = Image
    '    Me.SpriteListPanel.Controls.Add(spritePicture)

    '    Me.ToolTip1.SetToolTip(spritePicture, name)

    '    AddHandler spritePicture.MouseDoubleClick, AddressOf Me.sprite_DblClick
    '    AddHandler spritePicture.MouseClick, AddressOf Me.sprite_Click

    '    Me.ResumeLayout(False)

    '    Me.spritePictures.Add(name, spritePicture)

    '    spritePicture.BringToFront()

    'End Sub


    'Private Sub sprite_DblClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim aSprite As SpriteMSX
    '    aSprite = sprites.Item(sender.name)
    '    'Me.SpriteNameTextBox.Text = sender.name
    '    Me.SpriteContainer.SetSprite(aSprite)
    'End Sub




    'Private Sub sprite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim aSpritePicture As PictureBox = sender

    '    If Not SpriteSelectedIcon Is Nothing Then
    '        Me.SpriteSelectedIcon.BackColor = Color.Gray
    '    End If

    '    aSpritePicture.BackColor = Color.Orange
    '    Me.SpriteSelectedIcon = aSpritePicture
    '    Me.SpriteSelected = aSpritePicture.Name

    'End Sub


    'Private Sub DeleteSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSpriteButton.Click
    '    Dim aSpritePicture As PictureBox
    '    If Not Me.SpriteSelected = "" Then
    '        aSpritePicture = Me.spritePictures.Item(Me.SpriteSelected)
    '        aSpritePicture.Dispose()
    '        Me.spritePictures.Remove(Me.SpriteSelected)
    '        Me.sprites.Remove(Me.SpriteSelected)
    '        SpriteListPanel.Refresh()

    '        Me.SpriteSelectedIcon = Nothing
    '        Me.SpriteSelected = ""

    '    End If

    'End Sub


    'Private Sub DeleteSprite(ByVal name As String)
    '    If Me.sprites.ContainsKey(name) Then

    '    End If
    'End Sub


    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        Dim aboutDialog As New AboutForm(version + " " + versionDate)
        aboutDialog.ShowDialog()
    End Sub


    Private Sub LoadProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProjectButton.Click
        LoadFile(True, False)
    End Sub


    Private Sub LoadMergeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMergeButton.Click
        LoadFile(False, True)
    End Sub

    Private Sub SaveProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectButton.Click
        Me.SaveFile()
    End Sub


    Private Sub SaveFile()
        Dim resultado As System.Windows.Forms.DialogResult

        If Me.ProjectFileName = "" Then
            Me.ProjectFileName = Me.SpriteProject.ProjectName + ".xspr"
        End If

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        Me.SaveFileDialog1.DefaultExt = "xspr"
        Me.SaveFileDialog1.Filter = "Sprite file|*.xspr"

        resultado = SaveFileDialog1.ShowDialog()

        If resultado = Windows.Forms.DialogResult.OK Then

            'Me.ProjectFilePath = SaveFileDialog1.FileName
            Me.ProjectFileName = Path.GetFileName(SaveFileDialog1.FileName)

            Me.SaveData(SaveFileDialog1.FileName)

        End If

    End Sub


    Private Sub LoadFile(ByVal clear As Boolean, ByVal merge As Boolean)
        Dim resultado As System.Windows.Forms.DialogResult

        Me.OpenFileDialog1.DefaultExt = "xspr"
        Me.OpenFileDialog1.Filter = "Sprite file|*.xspr"

        resultado = Me.OpenFileDialog1.ShowDialog

        If resultado = Windows.Forms.DialogResult.OK Then

            If clear Then
                Me.ClearAllData()
                'Me.SpriteControl.Dispose()
                'Application.DoEvents()
            End If

            Me.ProjectFileName = Path.GetFileName(OpenFileDialog1.FileName)

            Me.LoadData(OpenFileDialog1.FileName, merge)

        End If

    End Sub


    Private Sub LoadData(ByVal filePath As String, ByVal merge As Boolean)
        Dim aXmlDoc As New XmlDocument
        'Dim rootElement As XmlElement

        Dim aNodeList As XmlNodeList

        Dim tmpsprites As New SortedList

        Dim i As Integer
        Dim tmpByte(15) As Byte

        Dim _ProjectSize As SpriteMSX.SPRITE_SIZE
        Dim _ProjectMode As SpriteMSX.SPRITE_MODE

        Dim datasize As Integer
        Dim colorsize As Integer

        'Dim txtElement As XmlText
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode
        Dim subNode As XmlNode
        'Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute


        Dim tmpPalette As New PaletteMSX
        'Dim tmpColor As ColorMSX
        'Dim namePalette As String
        Dim id As Integer
        Dim red As Integer
        Dim green As Integer
        Dim blue As Integer

        'Dim tmpSprite As SpriteMSX
        Dim name As String
        Dim order As Integer
        'Dim type As Integer
        'Dim mode As Integer
        Dim InkColor As Byte
        Dim BGcolor As Byte
        Dim gfxData As String = ""
        Dim colorData As String = ""

        ' primero hace un clear de los datos



        aXmlDoc.Load(filePath)


        If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then

            ' Paleta de colores ##############################################3
            If Not merge Then  ' en el caso de merge pasa de la paleta

                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/palette") ' comprueba si contiene datos de la paleta
                If Not aDataNode Is Nothing Then

                    Me.paletteDialog.SetPalette(aDataNode)

                    'aNode = aDataNode.SelectSingleNode("@name")
                    'If aNode Is Nothing Then
                    '    tmpPalette.name = "Default"
                    'Else
                    '    tmpPalette.name = aNode.InnerText
                    'End If

                    'aNodeList = aDataNode.SelectNodes("color")
                    'For Each anItemElement As XmlElement In aNodeList

                    '    anAttribute = anItemElement.GetAttributeNode("id")
                    '    If anAttribute Is Nothing Then

                    '    Else
                    '        id = anAttribute.InnerText
                    '    End If

                    '    anAttribute = anItemElement.GetAttributeNode("red")
                    '    If anAttribute Is Nothing Then
                    '        red = 0
                    '    Else
                    '        red = anAttribute.InnerText
                    '    End If

                    '    anAttribute = anItemElement.GetAttributeNode("green")
                    '    If anAttribute Is Nothing Then
                    '        green = 0
                    '    Else
                    '        green = anAttribute.InnerText
                    '    End If

                    '    anAttribute = anItemElement.GetAttributeNode("blue")
                    '    If anAttribute Is Nothing Then
                    '        blue = 0
                    '    Else
                    '        blue = anAttribute.InnerText
                    '    End If

                    '    tmpPalette.SetColor(id, New ColorMSX(id, red, green, blue))

                    'Next

                    'paletteDialog.PaletteColors.clear()
                    'paletteDialog.PaletteColors = tmpPalette.clone

                End If
            End If
            ' END paleta de colores ##############################################




            aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/sprites") ' comprueba si contiene datos de la paleta
            If Not aDataNode Is Nothing Then

                ' get info ############################################
                If Not merge Then
                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.SpriteProject.ProjectName = ""
                    Else
                        Me.SpriteProject.ProjectName = aNode.InnerText
                    End If
                    Me.ProjectNameText.Text = Me.SpriteProject.ProjectName
                End If

                aNode = aDataNode.SelectSingleNode("@type")
                If aNode Is Nothing Then
                    _ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16
                Else
                    _ProjectSize = CInt(aNode.InnerText)
                End If

                aNode = aDataNode.SelectSingleNode("@mode")
                If aNode Is Nothing Then
                    _ProjectMode = SpriteMSX.SPRITE_MODE.MONO
                Else
                    _ProjectMode = CInt(aNode.InnerText)
                End If
                ' end get info #########################################



                ' elige el tipo de editor
                If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.INIT Then
                    ' la primera vez que se ejecuta, desde el wizard

                    Me.SpriteProject.ProjectSize = _ProjectSize
                    Me.SpriteProject.ProjectMode = _ProjectMode

                    SetSpriteContainer()
                    Application.DoEvents()

                Else

                    If Not merge Then

                        If Not Me.SpriteProject.ProjectSize = _ProjectSize Or Not Me.SpriteProject.ProjectMode = _ProjectMode Then

                            Dim result As DialogResult

                            result = MsgBox("Sprites are different to current editor mode. Do you want to adapt the sprites?", MsgBoxStyle.YesNo, "Alert")

                            If result = DialogResult.No Then

                                Me.SpriteProject.ProjectSize = _ProjectSize
                                Me.SpriteProject.ProjectMode = _ProjectMode

                                Me.SpriteControl.Dispose()
                                Application.DoEvents()
                                SetSpriteContainer()
                                Application.DoEvents()

                                'Else

                            End If

                        End If

                        '
                        Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
                    Else
                        ' es merge <<<<<<<<<<<<<<<<<<<<<



                    End If

                End If





                If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                    datasize = 7
                    colorsize = 7
                Else
                    datasize = 31
                    colorsize = 15
                End If

                ' get sprites ##########################################
                aNodeList = aDataNode.SelectNodes("item")
                For Each anItemElement As XmlElement In aNodeList

                    'anAttribute = anItemElement.GetAttributeNode("id")
                    'If anAttribute Is Nothing Then
                    '    id = -1
                    'Else
                    '    id = CInt(anAttribute.InnerText)
                    'End If

                    anAttribute = anItemElement.GetAttributeNode("name")
                    If anAttribute Is Nothing Then
                        name = "SPRITE"
                    Else
                        name = anAttribute.InnerText
                    End If

                    anAttribute = anItemElement.GetAttributeNode("order")
                    If anAttribute Is Nothing Then
                        order = tmpsprites.Count + 100 ' add in end of list
                        'order = -1
                    Else
                        order = CInt(anAttribute.InnerText)
                    End If


                    'anAttribute = anItemElement.GetAttributeNode("type")
                    'If anAttribute Is Nothing Then
                    '    type = SpriteMSX.SPRITE_SIZE16
                    'Else
                    '    type = CInt(anAttribute.InnerText)
                    'End If

                    'anAttribute = anItemElement.GetAttributeNode("mode")
                    'If anAttribute Is Nothing Then
                    '    mode = 1
                    'Else
                    '    mode = CInt(anAttribute.InnerText)
                    'End If

                    anAttribute = anItemElement.GetAttributeNode("InkColor")
                    If anAttribute Is Nothing Then
                        InkColor = 15 ' blanco
                    Else
                        InkColor = CInt(anAttribute.InnerText)
                    End If

                    anAttribute = anItemElement.GetAttributeNode("BGcolor")
                    If anAttribute Is Nothing Then
                        BGcolor = 1 ' negro
                    Else
                        BGcolor = CInt(anAttribute.InnerText)
                    End If

                    subNode = anItemElement.SelectSingleNode("gfxData")
                    gfxData = subNode.InnerText

                    'If mode = 2 Then
                    'subNode = anItemElement.SelectSingleNode("colorData")
                    'colorData = subNode.InnerText
                    'End If


                    ' recoge o genera los datos de los colores (uno para cada linea para MSX2)
                    If _ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
                        For i = 0 To 15
                            tmpByte(i) = InkColor
                        Next
                        colorData = Me.joinData(tmpByte)
                    Else
                        subNode = anItemElement.SelectSingleNode("colorData")
                        If subNode Is Nothing Then
                            For i = 0 To 15
                                tmpByte(i) = InkColor
                            Next
                            colorData = Me.joinData(tmpByte)
                        Else
                            colorData = subNode.InnerText
                        End If
                    End If


                    If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 And _ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                        order = tmpsprites.Count
                        tmpsprites.Add(order, New SpriteMSX(name + "_1", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 0), ByteSpliter(colorData, colorsize, 0), paletteDialog.PaletteColors))
                        order = tmpsprites.Count
                        tmpsprites.Add(order, New SpriteMSX(name + "_2", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 8), ByteSpliter(colorData, colorsize, 8), paletteDialog.PaletteColors))
                        order = tmpsprites.Count
                        tmpsprites.Add(order, New SpriteMSX(name + "_3", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 16), ByteSpliter(colorData, colorsize, 0), paletteDialog.PaletteColors))
                        order = tmpsprites.Count
                        tmpsprites.Add(order, New SpriteMSX(name + "_4", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 24), ByteSpliter(colorData, colorsize, 8), paletteDialog.PaletteColors))
                    Else
                        If tmpsprites.ContainsKey(order) Then
                            order = tmpsprites.Count + 100 ' add in end of list
                        End If
                        tmpsprites.Add(order, New SpriteMSX(name, Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 0), ByteSpliter(colorData, colorsize, 0), paletteDialog.PaletteColors))
                    End If

                    'Try
                    'If Me.ProjectMode = SpriteMSX.SPRITE_MONO Then
                    '    tmpsprites.Add(order, New SpriteMSX(name, Me.ProjectSize, InkColor, BGcolor, ByteSpliter(gfxData), paletteDialog.PaletteColors))
                    'Else

                    'End If
                    'Catch ex As Exception
                    '    'ERROR, posible repeticion de key en la lista
                    'End Try


                Next
                ' end get sprites ######################################

                For Each aSprite As SpriteMSX In tmpsprites.Values
                    Me.AddSprite(aSprite)
                Next

            Else

                ' No hay datos de sprites

            End If

        Else

            'No es un fichero de datos de msxdevtools


        End If



    End Sub



    ''' <summary>
    ''' Guarda en un fichero todos los datos del proyecto.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub SaveData(ByVal filePath As String)
        'Try

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement
        Dim txtElement As XmlText
        Dim anElement As XmlElement
        Dim subElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim tmpColorData(15) As Byte

        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute("app")
        anAttribute.Value = "spriteSX"
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = version
        rootElement.SetAttributeNode(anAttribute)

        anElement = aXmlDoc.CreateElement("palette")
        rootElement.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = paletteDialog.PaletteColors.name
        anElement.SetAttributeNode(anAttribute)


        For Each aColor As ColorMSX In paletteDialog.PaletteColors.Colors.Values
            anItemElement = aXmlDoc.CreateElement("color")
            anElement.AppendChild(anItemElement)

            anAttribute = aXmlDoc.CreateAttribute("id")
            anAttribute.Value = aColor.id
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("red")
            anAttribute.Value = aColor.Red
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("green")
            anAttribute.Value = aColor.Green
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("blue")
            anAttribute.Value = aColor.Blue
            anItemElement.SetAttributeNode(anAttribute)
        Next


        anElement = aXmlDoc.CreateElement("sprites")
        rootElement.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.SpriteProject.ProjectName
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("mode")
        anAttribute.Value = Me.SpriteProject.ProjectMode
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("type")
        anAttribute.Value = Me.SpriteProject.ProjectSize
        anElement.SetAttributeNode(anAttribute)

        For Each aSprite As SpriteMSX In Me.SpriteProject.sprites.Values
            anItemElement = aXmlDoc.CreateElement("item")
            anElement.AppendChild(anItemElement)

            'anAttribute = aXmlDoc.CreateAttribute("id")
            'anAttribute.Value = CStr(aSprite.ID)
            'anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("name")
            anAttribute.Value = aSprite.name
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("order")
            anAttribute.Value = CStr(aSprite.order)
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("type") 'size
            anAttribute.Value = CStr(aSprite.size)
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("mode")
            anAttribute.Value = CStr(aSprite.mode)
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("InkColor")
            anAttribute.Value = CStr(aSprite.InkColor)
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("BGcolor")
            anAttribute.Value = CStr(aSprite.BGcolor)
            anItemElement.SetAttributeNode(anAttribute)

            subElement = aXmlDoc.CreateElement("gfxData")
            txtElement = aXmlDoc.CreateTextNode(joinData(aSprite.gfxData))
            subElement.AppendChild(txtElement)
            anItemElement.AppendChild(subElement)

            If Me.SpriteProject.ProjectMode = SpriteMSX.SPRITE_MODE.COLOR Then
                subElement = aXmlDoc.CreateElement("colorData")
                tmpColorData = joinColorData(aSprite.colorData, aSprite.ORbitData)
                txtElement = aXmlDoc.CreateTextNode(joinData(tmpColorData))
                subElement.AppendChild(txtElement)
                anItemElement.AppendChild(subElement)
            End If

        Next

        '
        aXmlDoc.Save(filePath)


        'Catch ex As Exception
        '    ' error! No se ha podido guardar la configuración
        'End Try

    End Sub



    Private Function joinData(ByVal aData As Byte()) As String
        Dim anOutput As String = ""
        Dim i As Integer
        'Dim dataLength As Integer = aData.Length

        'If Me.ProjectSize = SpriteMSX.SPRITE_SIZE8 Then
        '    dataLength = 7
        'End If

        'For i = 0 To aData.Length - 2
        For i = 0 To aData.Length - 2
            anOutput += aData(i).ToString + ","
        Next
        anOutput += aData(i).ToString

        Return anOutput
    End Function



    Private Function joinColorData(ByVal colorData As Byte(), ByVal orData As Boolean()) As Byte()
        Dim anOutput As Byte()
        Dim i As Integer

        ReDim anOutput(colorData.Length - 1)

        For i = 0 To colorData.Length - 1
            If orData(i) = True Then
                anOutput(i) = colorData(i) + 64
            Else
                anOutput(i) = colorData(i)
            End If
        Next

        Return anOutput
    End Function



    Private Function ByteSpliter(ByVal data As String) As Byte()
        Dim tmpData As Byte()
        Dim numitems As Integer

        Dim counter As Integer = 0

        Dim splitdata As String() = data.Split(",")
        numitems = splitdata.GetLength(0)

        ReDim tmpData(numitems - 1)

        For Each aValue As String In splitdata
            tmpData(counter) = CByte(aValue)
            counter += 1
        Next

        Return tmpData
    End Function


    Private Function ByteSpliter(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer) As Byte()
        Dim tmpData As Byte()
        Dim numitems As Integer = 0
        Dim counter As Integer = 0

        data += ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"

        ReDim tmpData(size)

        Dim splitdata As String() = data.Split(",")
        numitems = splitdata.GetLength(0)

        For i As Integer = initpos To initpos + size
            tmpData(counter) = CByte(splitdata(i))
            counter += 1
        Next

        Return tmpData
    End Function


    Private Sub NewProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectButton.Click

        Dim result As DialogResult

        result = MsgBox("This option will delete all data. Are you sure?", MsgBoxStyle.YesNo, "Alert")

        If result = DialogResult.Yes Then
            result = NewProject()

            If result = DialogResult.OK Then

                Application.DoEvents()

                SetSpriteContainer()

            End If
        End If

    End Sub



    Private Sub ClearPRJButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearPRJButton.Click
        Dim result As System.Windows.Forms.DialogResult

        result = MsgBox("This option will delete all data. Are you sure?", MsgBoxStyle.YesNo, "Alert")

        If result = Windows.Forms.DialogResult.Yes Then

            Me.ClearAllData()

        End If
    End Sub



    Private Sub NewPrjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPrjButton.Click

        Dim result As System.Windows.Forms.DialogResult

        result = NewProject()

        If result = Windows.Forms.DialogResult.OK Then

            NewPrjButton.Dispose()
            FirstLoadButton.Dispose()

            Application.DoEvents()

            stateWork()

            SetSpriteContainer()

        End If

    End Sub



    Private Function NewProject() As System.Windows.Forms.DialogResult

        Dim result As System.Windows.Forms.DialogResult

        Me.ClearAllData()

        Dim wizard As New WizardDialog()
        result = wizard.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.SpriteProject.ProjectSize = wizard.SpriteSize  ' 1=8x8,  2=16x16 
            Me.SpriteProject.ProjectMode = wizard.SpriteMode  ' 1=monocolor, 2=multicolor MSX2
        End If

        Return result

    End Function


    Private Sub ClearAllData()

        Me.SpriteProject.ProjectName = ""
        Me.ProjectNameText.Text = ""
        Me.ProjectFileName = ""

        Me.SpriteProject.clear()

        Me.paletteDialog.SetDefaultPalette()

    End Sub




    Private Sub Move2LeftButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Move2LeftButton.Click
        Me.SpriteContainer.MoveLeft()
    End Sub

    Private Sub Move2RightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Move2RightButton.Click
        Me.SpriteContainer.MoveRight()
    End Sub

    Private Sub Move2UpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Move2UpButton.Click
        Me.SpriteContainer.MoveUp()
    End Sub

    Private Sub Move2downButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Move2downButton.Click
        Me.SpriteContainer.MoveDown()
    End Sub

    Private Sub ProjectNameText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectNameText.TextChanged
        Me.SpriteProject.ProjectName = Me.ProjectNameText.Text
    End Sub

    Private Sub SpriteListBox1_SelectedSpriteChanged(ByVal sprite As spriteSX_ED.SpriteMSX) Handles SpriteProject.SelectedSpriteChanged
        Me.SpriteContainer.SetSprite(sprite)
    End Sub


    Private Sub SetSpriteContainer()
        'SpriteContainer
        'Dim SpriteContainer As Control

        If Not Me.SpriteControl Is Nothing Then
            Me.SpriteControl.Dispose()
        End If

        If Me.SpriteProject.ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
            'one color
            If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                ' 8x8
                Me.SpriteControl = New spriteSX_ED.SpritePanel8
            Else
                ' 16x16
                Me.SpriteControl = New spriteSX_ED.SpritePanel16
            End If


        Else
            'line color (msx2 or +)
            If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                ' 8x8
                Me.SpriteControl = New spriteSX_ED.SpritePanel8mode2
            Else
                ' 16x16
                Me.SpriteControl = New spriteSX_ED.SpritePanel16mode2
            End If

        End If

        Me.SpriteContainer = Me.SpriteControl


        Me.SuspendLayout()

        '
        'SpriteControl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SpriteControl.Visible = False
        Me.SpriteControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpriteControl.Location = New System.Drawing.Point(0, 80)
        Me.SpriteControl.Name = "SpriteContainer"
        Me.SpriteControl.Size = New System.Drawing.Size(394, 372)
        Me.SpriteControl.TabIndex = 2

        Me.GroupBox1.Controls.Add(Me.SpriteContainer)

        Me.SpriteControl.BringToFront()

        Me.SpriteContainer.Test = Me._TEST
        Me.SpriteContainer.SpriteName = ""
        Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
        'Me.SpriteContainer.ChanguePalette(paletteDialog.PaletteColors)

        AddHandler SpriteContainer.updateSprite, AddressOf Me.setUpdateSprite

        Me.ResumeLayout(False)
        Me.PerformLayout()

        Application.DoEvents()
        Me.SpriteControl.Visible = True

        Application.DoEvents()

    End Sub


    Private Sub setUpdateSprite()
        Me.AddAction()
    End Sub


    Private Sub FirstLoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstLoadButton.Click

        'ToolStrip2.Enabled = True
        'AddButton.Enabled = True
        'SpriteProject.Enabled = True

        NewPrjButton.Dispose()
        FirstLoadButton.Dispose()

        'EditPaletteButton.Enabled = True
        'GetDataButton.Enabled = True
        'SaveProjectButton.Enabled = True

        stateWork()

        LoadFile(False, False)

    End Sub


    Private Sub stateWork()
        ToolStrip2.Enabled = True
        AddButton.Enabled = True
        SpriteProject.Enabled = True
        LoadMergeButton.Enabled = True
        LoadProjectButton.Enabled = True
        ClearPRJButton.Enabled = True
        NewProjectButton.Enabled = True

        EditPaletteButton.Enabled = True
        GetDataButton.Enabled = True
        SaveProjectButton.Enabled = True

        Application.DoEvents()
    End Sub







End Class
