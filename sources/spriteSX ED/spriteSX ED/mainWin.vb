Imports System.IO
Imports System.Xml
Imports mSXdevtools.GUIcontrols

' MSX sprites info (portar)
' http://nocash.emubase.de/portar.htm#foregroundsprites

''' <summary>
''' spriteSX 
''' Copyleft 303bcn 2014 
''' This program is distributed under the terms of the GNU General Public License. 
''' http://www.gnu.org/licenses/
''' Tool to create a collection of sprites, for TMS9918 and V9938 video processors 
''' (MSX, colecovision, etc...), which provides the source code for Assembler, C and Basic.
''' </summary>
''' <remarks></remarks>
Public Class mainWin

    Private const _TEST As Boolean = False

    Private Const version_type As String = "b" 'a - alpha ; b - beta

    'Private App_version As String = My.Application.Info.Version.ToString + "b"
    'Private App_versionDate As String = "(01/04/2014)"
    ' last:
    '(24/03/2014) (9/05/2013) (3/04/2013)
    ' 0.8.9.8b(06/02/2013)
    ' 0.8.2.0a(08/01/2013)  
    ' 0.8.1.0a(05/01/2013)  
    ' 0.7.6.0a(23/11/2012), 0.7.5a(12/11/2012), 0.7.4a (11/11/2012), 0.7.3a (9/11/2012), 0.7.2a (21/2/2012)

    Private ProjectDefaultPath As String = ""
    Private Path_SC2 As String = ""
    Private Path_Bitmap As String = ""

    Private ProjectFileName As String = ""
    Private ProjectFilePath As String = ""

    Private _InitLauncher As InitLauncher

    Private RecentProjects As RecentProjectsList

    Private OutputDataDialog As New OutputDataForm()

    Private SpriteContainer As ISpriteContainer 'SpritePanel16mode2
    Private SpriteControl As Control

    Private paletteDialog As New palette512Dialog()

    Private aProgressForm As Form

    Private ConfigFileName As String = My.Application.Info.AssemblyName + ".config"

    Delegate Sub InvokeDelegate()

    Private oldtoolControl As ToolStripButton


    Private appState As APP_STATE = APP_STATE.RUNING

    Public Enum APP_STATE As Integer
        RUNING
        INIT
        WORK
    End Enum


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.SpriteContainer.ChanguePalette(paletteDialog.PaletteColors)
       

        Me.Text = My.Application.Info.Title + " v" + My.Application.Info.Version.ToString + version_type '+ " · " + My.Application.Info.Copyright

        Me.appState = APP_STATE.INIT


        ' la primera vez se muestra la ventana de licencia       
        Dim result As Boolean
        result = LoadConfig()
        If Not result Then
            'Dim aLicenseWin As New LicenseWin(False, LicenseWin.LANCODE.ENG, My.Application.Info.Title, App_version + " " + App_versionDate, My.Application.Info.Copyright)
            'aLicenseWin.ShowDialog()
            ShowAbout()
        End If
        

        _InitLauncher = New InitLauncher(Me.RecentProjects)
        Me.SuspendLayout()
        _InitLauncher.Dock = System.Windows.Forms.DockStyle.Fill
        _InitLauncher.Location = New System.Drawing.Point(0, 0)
        _InitLauncher.Name = "InitLauncher"
        '_InitLauncher.Size = New System.Drawing.Size(464, 150)
        Me.Controls.Add(_InitLauncher)
        Me.ResumeLayout(False)
        _InitLauncher.BringToFront()

        AddHandler _InitLauncher.SetNew, AddressOf Me.SetNew
        AddHandler _InitLauncher.SetLoad, AddressOf Me.SetLoad
        AddHandler _InitLauncher.SetFile, AddressOf Me.SetFile

    End Sub



    Private Sub mainWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.oldtoolControl = Me.PencilButton
        oldtoolControl.BackColor = Color.PaleGreen


        '' la primera vez se muestra la ventana de licencia       
        'Dim result As Boolean
        'result = LoadConfig()
        'If Not result Then
        '    Dim aLicenseWin As New LicenseWin(False, LicenseWin.LANCODE.ENG, My.Application.Info.Title, App_version + " " + App_versionDate, My.Application.Info.Copyright)
        '    aLicenseWin.ShowDialog()
        'End If

        'Me.appState = APP_STATE.INIT


        'Dim aLicenseWin As New LicenseWin(True, LicenseWin.LANCODE.ENG, My.Application.Info.Title, App_version + " " + App_versionDate, My.Application.Info.Copyright)
        'Dim LicenseResult As Boolean

        'LicenseResult = aLicenseWin.AcceptLicense(My.Application.Info.ProductName)
        'If Not LicenseResult Then
        '    Me.Close()
        'End If
    End Sub




    ''' <summary>
    ''' Controla que no se ha pulsado por error el boton de cerrar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mainWin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As System.Windows.Forms.DialogResult

        SaveConfig()

        Application.DoEvents()

        If Me.appState = APP_STATE.WORK Then

            Beep()

            result = MessageBox.Show(Me, "Are you sure you want to close spriteSX?", "Closing Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'result = MsgBox("Are you sure you want to close spriteSX?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert")

            If result = Windows.Forms.DialogResult.No Then
                e.Cancel = True 'cancela la salida de la aplicacion
            End If

        End If

    End Sub



    Private Sub mainWin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Application.DoEvents()
        'Me.Refresh()
        'SpriteContainer.Refresh()
        'Application.DoEvents()
    End Sub



    Public Sub SetLoad()
        LoadFile(False)
    End Sub



    Public Sub SetFile(ByVal filePath As String)
        LoadFile(filePath, False)
    End Sub



    Public Function LoadConfig() As Boolean
        Try

            Dim aXmlDoc As New XmlDocument
            Dim aNode As XmlNode
            Dim aNodeList As XmlNodeList
            Dim aValue As String
            'Dim anotherValue As String

            Dim tmpList As New SortedList
            Dim itemIndex As Integer

            Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName


            If System.IO.File.Exists(ConfigFileAdress) Then

                aXmlDoc.Load(ConfigFileAdress)


                '
                '
                aNode = aXmlDoc.SelectSingleNode("config/ProjectDefaultPath")
                'aValue = aNode.InnerText
                If Not aNode Is Nothing Then
                    '    Me.ProjectDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                    'ElseIf aNode.InnerText = "" Then
                    '    Me.ProjectDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                    'Else
                    Me.ProjectDefaultPath = aNode.InnerText
                End If

                'PaletteDefaultPath
                aNode = aXmlDoc.SelectSingleNode("config/PaletteDefaultPath")
                'aValue = aNode.InnerText
                If Not aNode Is Nothing Then
                    '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                    'ElseIf aNode.InnerText = "" Then
                    '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                    'Else
                    Me.paletteDialog.PaletteDefaultPath = aNode.InnerText
                End If


                aNode = aXmlDoc.SelectSingleNode("config/Path_SC2")
                If Not aNode Is Nothing Then
                    Me.Path_SC2 = aNode.InnerText
                End If

                aNode = aXmlDoc.SelectSingleNode("config/Path_Bitmap")
                If Not aNode Is Nothing Then
                    Me.Path_Bitmap = aNode.InnerText
                End If


                aNodeList = aXmlDoc.SelectNodes("config/RecentProjects/item")
                If aNodeList Is Nothing Then
                    Me.RecentProjects = New RecentProjectsList

                Else

                    For Each aNodeItem As XmlNode In aNodeList

                        itemIndex = CInt(aNodeItem.Attributes.GetNamedItem("index").InnerText)
                        aValue = aNodeItem.Attributes.GetNamedItem("path").InnerText

                        tmpList.Add(itemIndex, aValue)

                    Next

                    Me.RecentProjects = New RecentProjectsList(tmpList)

                End If


                Return True

            Else
                Me.ProjectDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                Me.RecentProjects = New RecentProjectsList
                Return False
            End If



        Catch ex As Exception
            ' error! No se ha podido cargar la configuración
            Return False
        End Try

    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveConfig()
        Try

            Dim aXmlDoc As New XmlDocument
            Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName
            Dim rootElement As XmlElement
            Dim txtElement As XmlText
            Dim anElement As XmlElement
            Dim anAttribute As XmlAttribute
            Dim anItemElement As XmlElement

            ' crea el nodo root
            rootElement = aXmlDoc.CreateElement("config")
            aXmlDoc.AppendChild(rootElement)

            anAttribute = aXmlDoc.CreateAttribute("app")
            anAttribute.Value = My.Application.Info.ProductName
            rootElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("version")
            anAttribute.Value = My.Application.Info.Version.ToString + "b"
            rootElement.SetAttributeNode(anAttribute)

            'debug data
            'anAttribute = aXmlDoc.CreateAttribute("dotnetvers")
            'anAttribute.Value = Environment.Version.ToString()
            'rootElement.SetAttributeNode(anAttribute)


            anElement = aXmlDoc.CreateElement("ProjectDefaultPath")
            txtElement = aXmlDoc.CreateTextNode(Me.ProjectDefaultPath)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("PaletteDefaultPath")
            txtElement = aXmlDoc.CreateTextNode(Me.paletteDialog.PaletteDefaultPath)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_SC2")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_SC2)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_Bitmap")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_Bitmap)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            
            anElement = aXmlDoc.CreateElement("RecentProjects")
            rootElement.AppendChild(anElement)
            For i As Integer = 0 To RecentProjects.Count - 1
                anItemElement = aXmlDoc.CreateElement("item")
                anElement.AppendChild(anItemElement)

                anAttribute = aXmlDoc.CreateAttribute("index")
                anAttribute.Value = CStr(i)
                anItemElement.SetAttributeNode(anAttribute)

                anAttribute = aXmlDoc.CreateAttribute("path")
                anAttribute.Value = Me.RecentProjects.GetFileItem(i).Path
                anItemElement.SetAttributeNode(anAttribute)
            Next

            '
            aXmlDoc.Save(ConfigFileAdress)


            'Me.StatusBarLabel.Text = ApplicationInfo.GetLiteral("mssge.configsaved", "Settings saved")

        Catch ex As Exception
            ' error! No se ha podido guardar la configuración
        End Try
    End Sub



    Private Sub ShowAbout()
        Dim aboutDialog As New AboutForm() ' version + " " + versionDate
        aboutDialog.ShowDialog()
    End Sub


    '
    ' eventos de la botonera de proyecto #####################################################3
    '
    Private Sub EditPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPaletteButton.Click
        EditPalette()
    End Sub

    Private Sub GetDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDataButton.Click
        GetData()
    End Sub

    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        ShowAbout()
    End Sub

    Private Sub LoadProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProjectButton.Click
        If AreYouSure() Then
            LoadFile(False)
        End If
    End Sub

    Private Sub LoadMergeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMergeButton.Click
        LoadFile(True)
    End Sub

    Private Sub SaveAsProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsProjectButton.Click
        Me.SaveFile()
    End Sub

    Private Sub SaveProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectButton.Click
        Save()
    End Sub

    Private Sub ClearPRJButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearPRJButton.Click

        If AreYouSure() Then
            Me.ClearAllData()
            Me.SpriteContainer.NewSprite() ' borra el contenido del editor
        End If

    End Sub

    ''' <summary>
    ''' Accion de nuevo proyecto, lanzado desde la botonera de proyecto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectButton.Click

        NewProject()

    End Sub


    'Private Sub ProjectNameText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectNameText.TextChanged
    '    Me.SpriteProject.ProjectName = Me.ProjectNameText.Text
    'End Sub
    '
    ' END de la botonera de proyecto #####################################################



    ' eventos del control de lista de sprites (proyecto) ######################################

    ''' <summary>
    ''' Pasa un sprite de la lista (proyecto) al editor
    ''' </summary>
    ''' <param name="sprite"></param>
    ''' <remarks></remarks>
    Private Sub SpriteListBox1_SelectedSpriteChanged(ByVal sprite As spriteSXED.SpriteMSX) Handles SpriteProject.SelectedSpriteChanged
        Me.SpriteContainer.SetSprite(sprite)
        Me.SpritePatternNumber.Text = CStr(sprite.order)
        Me.SpriteName.Text = sprite.name
    End Sub
    '
    ' END eventos del control de lista de sprites (proyecto) ##################################



    ''' <summary>
    ''' Muestra la ventana de edicion de la paleta.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditPalette()
        Dim result As DialogResult

        ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
        If Not Me.SpriteControl Is Nothing Then
            Me.SpriteControl.Enabled = False
        End If

        result = paletteDialog.ShowWinDialog()

        'If result = Windows.Forms.DialogResult.OK Then
        'BUG: Al refrescar SpriteContainer se pierde la referencia al objeto de la paleta y peta
        'al cancelar, se asigna la paleta igualmente y se evita el error.
        Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
        Me.SpriteProject.RefreshPalette(paletteDialog.PaletteColors)
        'End If


        ' habilita el editor de sprites
        If Not Me.SpriteControl Is Nothing Then
            Me.SpriteControl.Enabled = True
            Me.SpriteControl.Refresh()
            Me.SpriteContainer.SetNameFocus()
            Application.DoEvents()
        End If

    End Sub



    ''' <summary>
    ''' Recoge el sprite del editor y lo añade al controlador del proyecto y lo selecciona (resalta) en la lista.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddAction()
        Dim aSprite As SpriteMSX
        Dim result As Boolean

        aSprite = Me.SpriteContainer.GetSprite() ' recoge el sprite del contenedor

        If Me.SpriteProject.sprites.Contains(aSprite.ID) Then 'comprueba si existe en la lista
            ' lo reemplaza
            SpriteProject.UpdateSprite(aSprite)
            SpriteProject.ShowItem(aSprite.ID)
        Else
            ' lo añade
            result = SpriteProject.AddNewSprite(aSprite)

            If result = True Then
                SpriteProject.ShowItem(aSprite.ID)
            End If
        End If

        'SpriteProject.ShowItem(aSprite.ID) ' selecciona el sprite en la lista

    End Sub



    ''' <summary>
    ''' Añade un sprite al proyecto. Para ser usado en la carga de datos.
    ''' </summary>
    ''' <param name="aSprite"></param>
    ''' <remarks></remarks>
    Private Sub AddSprite(ByVal aSprite As SpriteMSX)

        If Not Me.SpriteProject.sprites.Contains(aSprite.ID) Then 'comprueba que no exista ya en la lista
            ' añade
            SpriteProject.AddNewSprite(aSprite)
        Else
            ' lo reemplaza
            SpriteProject.UpdateSprite(aSprite)
        End If

    End Sub


    ''' <summary>
    ''' copia un sprite
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopySprite()
        ' controla el limite de sprites
        If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 And Me.SpriteProject.Count > SpritesListController.MAX_16xSPRITES Then
            Exit Sub
        ElseIf Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 And Me.SpriteProject.Count > SpritesListController.MAX_8xSPRITES Then
            Exit Sub
        End If

        Me.SpriteContainer.Copy()
        AddAction()
    End Sub


    ''' <summary>
    ''' Muestra la ventana donde se configura y se generan los datos formateados para diferentes lenguajes de programación.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetData()
        'Private OutputDataDialog As New OutputDataForm()
        'Me.ProjectName, Me.SpriteListBox1.sprites, Me.paletteDialog.PaletteColors, Me.ProjectMode, Me.ProjectType)
        Me.OutputDataDialog.ProjectName = Me.SpriteProject.Name
        Me.OutputDataDialog.ProjectSize = Me.SpriteProject.ProjectSize
        Me.OutputDataDialog.ProjectMode = Me.SpriteProject.ProjectMode
        Me.OutputDataDialog.Sprites = Me.SpriteProject.sprites
        Me.OutputDataDialog.PaletteColors = Me.paletteDialog.PaletteColors

        OutputDataDialog.ShowDialog()
    End Sub


    Private Sub Save()
        If Me.ProjectFilePath = "" Then
            ' si no se ha cargado un proyecto, pide que se indique el nombre y ruta del fichero
            SaveFile()
        Else
            ' guarda directamente
            Me.SaveData(Me.ProjectFilePath)
        End If
    End Sub


    ''' <summary>
    ''' Muestra la ventana de dialogo para el guardado de un proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveFile()
        Dim resultado As System.Windows.Forms.DialogResult

        ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
        If Not Me.SpriteControl Is Nothing Then
            Me.SpriteControl.Enabled = False
        End If

        If Me.ProjectDefaultPath = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Me.ProjectDefaultPath
        End If

        If Me.ProjectFileName = "" Then
            Me.ProjectFileName = Me.SpriteProject.Name ' + ".xspr"
        End If

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        Me.SaveFileDialog1.DefaultExt = "xspr"
        Me.SaveFileDialog1.Filter = "Sprite file|*.xspr"

        resultado = SaveFileDialog1.ShowDialog()

        If resultado = Windows.Forms.DialogResult.OK Then

            Me.ProjectDefaultPath = System.IO.Directory.GetParent(SaveFileDialog1.FileName).FullName
            Me.ProjectFilePath = SaveFileDialog1.FileName
            Me.ProjectFileName = Path.GetFileName(Me.ProjectFilePath)
            Me.SaveData(Me.ProjectFilePath)

        End If

        ' habilita el editor de sprites
        If Not Me.SpriteControl Is Nothing Then
            Me.SpriteControl.Enabled = True
            Me.SpriteControl.Refresh()
            Me.SpriteContainer.SetNameFocus()
            Application.DoEvents()
        End If

    End Sub


    ''' <summary>
    ''' Muestra la ventana de dialogo para la carga de un proyecto
    ''' </summary>
    ''' <param name="merge">agrega los datos de un proyecto al proyecto ya existente</param>
    ''' <remarks></remarks>
    Private Sub LoadFile(ByVal merge As Boolean)
        Dim resultado As System.Windows.Forms.DialogResult



        Me.OpenFileDialog1.DefaultExt = "xspr"
        Me.OpenFileDialog1.Filter = "Sprite file|*.xspr"

        Me.OpenFileDialog1.FileName = Me.ProjectFileName

        If Me.ProjectDefaultPath = "" Then
            Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.OpenFileDialog1.InitialDirectory = Me.ProjectDefaultPath
        End If

        resultado = Me.OpenFileDialog1.ShowDialog

        If resultado = Windows.Forms.DialogResult.OK Then

            LoadFile(OpenFileDialog1.FileName, merge)

        End If

    End Sub


    ''' <summary>
    ''' Carga o fusiona un proyecto, a partir de una ruta absoluta.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="merge"></param>
    ''' <remarks></remarks>
    Private Sub LoadFile(ByVal filePath As String, ByVal merge As Boolean)

        ' comprueba si existe el fichero
        If System.IO.File.Exists(filePath) Then

            ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = False
            End If

            'If appState < APP_STATE.WORK Then
            '    ' si es la primera vez que se ejecuta (desde la ventana de inicio)
            '    ' cambia la visualización de la ventana al modo de trabajo
            '    FirstNewPrjButton.Dispose()
            '    FirstLoadButton.Dispose()
            'End If

            If Not merge Then
                Me.ClearAllData()
            End If

            If merge Then
                Me.LoadData(filePath, True)
            Else
                ' si no es merge, guarda los valores del fichero seleccionado como los del proyecto
                Me.ProjectDefaultPath = System.IO.Directory.GetParent(filePath).FullName
                Me.ProjectFilePath = filePath
                Me.ProjectFileName = Path.GetFileName(Me.ProjectFilePath)

                Me.LoadData(Me.ProjectFilePath, False)
            End If

            If appState < APP_STATE.WORK Then
                ' si es la primera vez que se ejecuta (desde la ventana de inicio)
                ' cambia la visualización de la ventana al modo de trabajo
                SetWorkState()
            End If


            ' habilita el editor de sprites
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = True
                Me.SpriteControl.Refresh()
                Me.SpriteContainer.SetNameFocus()
                Application.DoEvents()
            End If

        Else
            ' en el caso de que no exista
            MsgBox("The file does not exist!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Load Project")
            Exit Sub
        End If

    End Sub



    ''' <summary>
    ''' Carga los datos de un proyecto. 
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="merge"></param>
    ''' <remarks></remarks>
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

        Dim aDataNode As XmlNode
        Dim aNode As XmlNode
        Dim subNode As XmlNode
        Dim anAttribute As XmlAttribute


        Dim tmpPalette As New MSXpalette
        'Dim tmpColor As ColorMSX
        'Dim namePalette As String
        'Dim id As Integer
        'Dim red As Integer
        'Dim green As Integer
        'Dim blue As Integer

        'Dim tmpSprite As SpriteMSX
        Dim name As String
        Dim order As Integer
        'Dim type As Integer
        'Dim mode As Integer
        Dim InkColor As Byte
        Dim BGcolor As Byte
        Dim gfxData As String = ""
        Dim colorData As String = ""

        aXmlDoc.Load(filePath)


        ' comprueba que el fichero de datos es para este programa
        'If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then
        If Not aXmlDoc.SelectSingleNode("msxdevtools/sprites") Is Nothing Then

            AddRecentProject(filePath) ' lo añade a la lista de proyectos recientes


            ' Paleta de colores ##############################################3
            aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/palette") ' comprueba si contiene datos de la paleta
            If Not aDataNode Is Nothing Then

                If merge Then
                    Dim result As DialogResult
                    result = MsgBox("Do you wan to load the new palette?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Merge Project")
                    If result = DialogResult.Yes Then
                        Me.paletteDialog.SetPaletteFromNode(aDataNode)

                        ' refresca la paleta del editor y de la lista
                        Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
                        Me.SpriteProject.RefreshPalette(paletteDialog.PaletteColors)
                        Application.DoEvents()
                    End If

                Else
                    Me.paletteDialog.SetPaletteFromNode(aDataNode)
                End If


            End If

            ' END paleta de colores ##############################################

            showProgressWin()

            aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/sprites") ' comprueba si contiene datos de la paleta
            'If Not aDataNode Is Nothing Then

            ' get project info ############################################
            If Not merge Then
                aNode = aDataNode.SelectSingleNode("@name")
                If aNode Is Nothing Then
                    setProjectName("")
                Else
                    setProjectName(aNode.InnerText)
                End If

                aNode = aDataNode.SelectSingleNode("@version")
                If aNode Is Nothing Then
                    Me.SpriteProject.Version = "0"
                Else
                    Me.SpriteProject.Version = aNode.InnerText
                End If

                aNode = aDataNode.SelectSingleNode("@group")
                If aNode Is Nothing Then
                    Me.SpriteProject.Group = ""
                Else
                    Me.SpriteProject.Group = aNode.InnerText
                End If

                aNode = aDataNode.SelectSingleNode("@author")
                If aNode Is Nothing Then
                    Me.SpriteProject.Author = ""
                Else
                    Me.SpriteProject.Author = aNode.InnerText
                End If


                aNode = aDataNode.SelectSingleNode("@startDate")
                If aNode Is Nothing Then
                    Me.SpriteProject.StartProjectDate = DateTime.Today.Ticks
                Else
                    Me.SpriteProject.StartProjectDate = CLng(aNode.InnerText)
                End If

                aNode = aDataNode.SelectSingleNode("@lastUpdate")
                If aNode Is Nothing Then
                    Me.SpriteProject.LastUpdate = DateTime.Today.Ticks
                Else
                    Me.SpriteProject.LastUpdate = CLng(aNode.InnerText)
                End If

                aNode = aDataNode.SelectSingleNode("description")
                If aNode Is Nothing Then
                    Me.SpriteProject.Description = ""
                Else
                    Me.SpriteProject.Description = aNode.InnerText
                End If


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
            ' end get project info #########################################


            ' prepara el editor para el modo de sprites requerido
            If appState < APP_STATE.WORK Then
                'If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.INIT Then
                ' la primera vez que se ejecuta, desde la pantalla de inicio
                ' requiere iniciar el editor al modo que viene indicado en los datos

                Me.SpriteProject.ProjectSize = _ProjectSize
                Me.SpriteProject.ProjectMode = _ProjectMode

                SetSpriteContainer()
                Application.DoEvents()

                Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors

            Else


                If Not merge Then

                    ' si no es una carga de union (merge), comprueba si los datos son diferentes al modo en curso
                    'If Not Me.SpriteProject.ProjectSize = _ProjectSize Or Not Me.SpriteProject.ProjectMode = _ProjectMode Then

                    'Dim result As DialogResult

                    '' se pregunta para dar la oportunidad de transformar los datos a un modo diferente
                    'result = MsgBox("Sprites are different to current editor mode." + Chr(13) + "Do you want to adapt the sprites?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

                    'If result = DialogResult.No Then
                    ' si es NO, cambia el editor al tipo indicado en los datos
                    Me.SpriteProject.ProjectSize = _ProjectSize
                    Me.SpriteProject.ProjectMode = _ProjectMode

                    Me.SpriteControl.Dispose()
                    Application.DoEvents()

                    SetSpriteContainer()
                    Application.DoEvents()

                    'Else

                    'End If

                    'End If


                End If

            End If

            Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors


            ' define las longitudes de los datos, dependiendo del tipo de sprite
            If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                datasize = 7
                colorsize = 15
            Else
                datasize = 31
                colorsize = 15
            End If

            ' get sprites ##########################################
            aNodeList = aDataNode.SelectNodes("item")
            For Each anItemElement As XmlElement In aNodeList

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

                ' si los datos son diferentes al modo indicado, se adaptan
                If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 And _ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                    ' si los sprites son de 16x16 los convierte a 4 sprites de 8x8
                    order = order * 4 'tmpsprites.Count
                    tmpsprites.Add(order, New SpriteMSX(name + "_1", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 0, 0), ByteSpliter(colorData, colorsize, 0, InkColor), paletteDialog.PaletteColors))
                    order += 1
                    tmpsprites.Add(order, New SpriteMSX(name + "_2", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 8, 0), ByteSpliter(colorData, colorsize, 8, InkColor), paletteDialog.PaletteColors))
                    order += 1
                    tmpsprites.Add(order, New SpriteMSX(name + "_3", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 16, 0), ByteSpliter(colorData, colorsize, 0, InkColor), paletteDialog.PaletteColors))
                    order += 1
                    tmpsprites.Add(order, New SpriteMSX(name + "_4", Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 24, 0), ByteSpliter(colorData, colorsize, 8, InkColor), paletteDialog.PaletteColors))
                Else
                    If tmpsprites.ContainsKey(order) Then
                        order = tmpsprites.Count + 100 ' add in end of list
                    End If
                    tmpsprites.Add(order, New SpriteMSX(name, Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, InkColor, BGcolor, ByteSpliter(gfxData, datasize, 0, 0), ByteSpliter(colorData, colorsize, 0, 0), paletteDialog.PaletteColors))
                End If


            Next
            ' end get sprites ######################################

            For Each aSprite As SpriteMSX In tmpsprites.Values
                Me.AddSprite(aSprite)
            Next

            'Else

            '    ' No hay datos de sprites

            'End If

        Else

            'No es un fichero de datos de msxdevtools


        End If


        closeProgressWin()
        Application.DoEvents()

    End Sub


    ''' <summary>
    ''' Guarda en un fichero todos los datos del proyecto (lista de sprites + paleta de colores).
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

        showProgressWin()

        AddRecentProject(filePath) ' lo añade a la lista de proyectos recientes


        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute("app")
        anAttribute.Value = My.Application.Info.Title
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = My.Application.Info.Version.ToString
        rootElement.SetAttributeNode(anAttribute)

        ' palette data ##############################################
        rootElement.AppendChild(Me.paletteDialog.getPaletteElement(aXmlDoc))
        ' END palette data ##############################################

        anElement = aXmlDoc.CreateElement("sprites")
        rootElement.AppendChild(anElement)

        ' project data ##############################################
        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.SpriteProject.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = Me.SpriteProject.Version
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("group")
        anAttribute.Value = Me.SpriteProject.Group
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = Me.SpriteProject.Author
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("startDate")
        anAttribute.Value = CStr(Me.SpriteProject.StartProjectDate)
        anElement.SetAttributeNode(anAttribute)

        Me.SpriteProject.LastUpdate = DateTime.Today.Ticks
        anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        anAttribute.Value = CStr(Me.SpriteProject.LastUpdate)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("mode")
        anAttribute.Value = Me.SpriteProject.ProjectMode
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("type")
        anAttribute.Value = Me.SpriteProject.ProjectSize
        anElement.SetAttributeNode(anAttribute)

        anItemElement = aXmlDoc.CreateElement("description")
        txtElement = aXmlDoc.CreateTextNode(Me.SpriteProject.Description)
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)
        'END project data ##############################################


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

        closeProgressWin()
        Application.DoEvents()

    End Sub


    ''' <summary>
    ''' Proporciona una cadena con una serie de datos separados por comas, extraidos de un array.
    ''' </summary>
    ''' <param name="aData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function joinData(ByVal aData As Byte()) As String
        Dim anOutput As String = ""
        Dim i As Integer
        'Dim dataLength As Integer = aData.Length

        'If Me.ProjectSize = SpriteMSX.SPRITE_SIZE8 Then
        '    dataLength = 7
        'End If

        For i = 0 To aData.Length - 2
            anOutput += aData(i).ToString + ","
        Next
        anOutput += aData(i).ToString

        Return anOutput

    End Function


    ''' <summary>
    ''' Fusiona los datos de color + bit de OR en un solo array.
    ''' </summary>
    ''' <param name="colorData"></param>
    ''' <param name="orData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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


    'Private Function ByteSpliter(ByVal data As String) As Byte()
    '    Dim tmpData As Byte()
    '    Dim numitems As Integer

    '    Dim counter As Integer = 0

    '    Dim splitdata As String() = data.Split(",")
    '    numitems = splitdata.GetLength(0)

    '    ReDim tmpData(numitems - 1)

    '    For Each aValue As String In splitdata
    '        tmpData(counter) = CByte(aValue)
    '        counter += 1
    '    Next

    '    Return tmpData
    'End Function


    ''' <summary>
    ''' Proporciona un array a partir de una cadena con datos separados por comas.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="size"></param>
    ''' <param name="initpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ByteSpliter(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer, ByVal defaultvalue As Byte) As Byte()
        Dim tmpData As Byte()
        Dim numitems As Integer = 0
        Dim counter As Integer = 0

        Dim defaultString As String = "," + CStr(defaultvalue)

        For i As Integer = 0 To 31
            data += defaultString
        Next
        'data += ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"

        ReDim tmpData(size)

        Dim splitdata As String() = data.Split(",")
        numitems = splitdata.GetLength(0)

        For i As Integer = initpos To initpos + size
            tmpData(counter) = CByte(splitdata(i))
            counter += 1
        Next

        Return tmpData
    End Function


    ''' <summary>
    ''' Muestra una ventana que avisa y pide confirmación, ya que la accion ejecutada borrará todos los datos del proyecto.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreYouSure() As Boolean
        Dim result As System.Windows.Forms.DialogResult

        result = MsgBox("This option will delete all data." + Chr(13) + "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

        If result = Windows.Forms.DialogResult.Yes Then
            Return True
        End If

        Return False

    End Function


    Public Sub SetNew()
        Dim result As DialogResult

        result = ShowNewProject()

        If result = DialogResult.OK Then
            'FirstNewPrjButton.Dispose()
            'FirstLoadButton.Dispose()

            SetWorkState()

            SetSpriteContainer()

            Application.DoEvents()

        End If
    End Sub



    Private Sub NewProject()
        If AreYouSure() Then

            If ShowNewProject() = DialogResult.OK Then

                SetSpriteContainer()

                Application.DoEvents()

            End If
        End If
    End Sub


    ''' <summary>
    ''' Inicializa un nuevo proyecto mediante un wizard donde se indica el nombre, tamaño y modo de color de los sprites.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowNewProject() As System.Windows.Forms.DialogResult

        Dim result As System.Windows.Forms.DialogResult

        Dim wizard As New WizardDialog()
        result = wizard.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.ClearAllData()

            Me.SpriteProject.ProjectSize = wizard.SpriteSize  ' 1=8x8,  2=16x16 
            Me.SpriteProject.ProjectMode = wizard.SpriteMode  ' 1=monocolor, 2=multicolor MSX2
            Me.SpriteProject.StartProjectDate = DateTime.Today.Ticks
            setProjectName(wizard.SpritePrjName)

            totalLabel.Text = CStr(SpriteProject.Count) + " (" + CStr(SpriteProject.MaximumSPRITES + 1) + ")"
        End If

        Return result

    End Function


    ''' <summary>
    ''' Borra todos los datos de un proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllData()

        Me.ProjectNameText.Text = ""
        Me.totalLabel.Text = "0"

        Me.ProjectFilePath = ""
        Me.ProjectFileName = ""

        Me.SpriteProject.clear()

        Me.paletteDialog.SetDefaultPalette()

    End Sub



    ''' <summary>
    ''' Muestra el editor de sprites correspondiente segun el modo seleccionado.
    ''' </summary>
    ''' <remarks></remarks>
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
                Me.SpriteControl = New spriteSXED.SpritePanel8(paletteDialog.PaletteColors)
            Else
                ' 16x16
                Me.SpriteControl = New spriteSXED.SpritePanel16(paletteDialog.PaletteColors) 'SpritePanel16
            End If


        Else
            'line color (msx2 or +)
            If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                ' 8x8
                Me.SpriteControl = New spriteSXED.SpritePanel8mode2(paletteDialog.PaletteColors)
            Else
                ' 16x16
                Me.SpriteControl = New spriteSXED.SpritePanel16mode2(paletteDialog.PaletteColors)
            End If

        End If

        Me.SpriteContainer = Me.SpriteControl


        Me.SuspendLayout()


        If Me.SpriteProject.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            Me.spritePreviewPicture.Size = New System.Drawing.Size(16, 16)
        Else
            Me.spritePreviewPicture.Size = New System.Drawing.Size(32, 32)
        End If


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

        Me.SpriteContainer.Test = _TEST
        Me.SpriteContainer.SpriteName = ""
        'Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
        'Me.SpriteContainer.ChanguePalette(paletteDialog.PaletteColors)

        AddHandler SpriteContainer.updateSprite, AddressOf Me.setUpdateSprite
        AddHandler SpriteContainer.MatrixCoordinates, AddressOf Me.setMatrixCoordinates
        AddHandler SpriteContainer.SpriteBitmapChanged, AddressOf Me.setSpriteBitmapChanged
        AddHandler SpriteContainer.SpriteInfoChanged, AddressOf Me.setSpriteInfoChanged

        selectTool(SpritePanelBase.STATE_TOOL.DRAW) ' pone el paint toolbox por defecto a draw

        Me.ResumeLayout(False)
        Me.PerformLayout()

        Application.DoEvents()
        Me.SpriteControl.Visible = True

        Me.Refresh()
        Application.DoEvents()

    End Sub


    ''' <summary>
    ''' Actualiza el sprite en la lista de proyecto, accion (evento) del editor.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setUpdateSprite()
        Me.AddAction()
    End Sub


    Private Sub setMatrixCoordinates(ByVal xpos As Integer, ByVal ypos As Integer)
        PosX_TextBox.Text = CStr(xpos + 1)
        PosY_TextBox.Text = CStr(ypos + 1)
    End Sub


    Private Sub setSpriteBitmapChanged(ByVal spriteBitmap As Bitmap)
        spritePreviewPicture.Image = spriteBitmap
    End Sub


    Private Sub setSpriteInfoChanged(ByVal name As String, ByVal patternNumber As Integer)
        Me.SpriteName.Text = name
        Me.SpritePatternNumber.Text = CStr(patternNumber)
    End Sub



    ''' <summary>
    ''' Cambia el estado de los controles, al modo de trabajo, despues del estado de inicio.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetWorkState()
        'FirstNewPrjButton.Dispose()
        'FirstLoadButton.Dispose()
        _InitLauncher.Dispose()


        ToolStrip2.Enabled = True
        UpdateButton.Enabled = True
        AddButton.Enabled = True
        SpriteProject.Enabled = True

        ClearPRJButton.Enabled = True
        NewProjectButton.Enabled = True

        LoadProjectButton.Enabled = True
        LoadRecentButton.Enabled = True
        LoadMergeButton.Enabled = True
        SaveProjectButton.Enabled = True
        SaveAsProjectButton.Enabled = True

        BitmapButton.Enabled = True

        ProjectNameText.Enabled = True
        ProjectInfoButton.Enabled = True

        EditPaletteButton.Enabled = True
        GetDataButton.Enabled = True


        Me.appState = APP_STATE.WORK  'cambia el estado de la app

        Application.DoEvents()
    End Sub







    ' eventos de las herramientas de edicion #############################################################

    Private Sub NewSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSpriteButton.Click
        Me.SpriteContainer.NewSprite()
    End Sub

    Private Sub ClearSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSpriteButton.Click
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

    Private Sub InvertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertButton.Click
        Me.SpriteContainer.Invert()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        AddAction()
    End Sub

    Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
        CopySprite()
    End Sub

    ' END eventos de las herramientas de edicion #############################################################



    ' evita que al pulsar Enter, se copie el sprite. Enter se reserva para actualizar el sprite.
    'Private Sub AddButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Enter
    '    If Not Me.SpriteControl Is Nothing Then
    '        Me.ActiveControl = Me.SpriteControl
    '    End If
    'End Sub



    Public Sub AddRecentProject(ByVal path As String)
        Me.RecentProjects.Add(path)
    End Sub


    'Public Function GetProjectItem(ByVal index As Integer) As ProjectFileItem
    '    Return Me.RecentProjects.GetFileItem(index)
    'End Function


    Private Sub SpriteProject_TotalSpriteChanged(ByVal number As Integer) Handles SpriteProject.TotalSpriteChanged
        totalLabel.Text = CStr(number) + " (" + CStr(SpriteProject.MaximumSPRITES + 1) + ")"
    End Sub




    Private Sub LoadRecentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadRecentButton.Click

        getRecentListContextMenu()


        'Dim RecentContextualList = New RecentListWin(Me.RecentProjects)

        'RecentContextualList.Location = New System.Drawing.Point(Me.Location.X + 70, Me.Location.Y + 60)
        'If RecentContextualList.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    LoadFile(RecentContextualList.ItemSelected, False)
        'End If
        'RecentContextualList.Dispose()

    End Sub

    ''' <summary>
    ''' genera y muestra el menu contextual con la lista de proyectos recientes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRecentListContextMenu()
        Dim aProjectItem As ProjectFileItem
        Dim ToolStripMenuItem1 As ToolStripMenuItem

        FilesContextMenuStrip.Items.Clear()

        For i As Integer = 0 To Me.RecentProjects.Count - 1
            ToolStripMenuItem1 = New ToolStripMenuItem

            aProjectItem = Me.RecentProjects.GetFileItem(i)
            ToolStripMenuItem1.Name = aProjectItem.Path
            ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
            ToolStripMenuItem1.Text = aProjectItem.Name
            ToolStripMenuItem1.Image = PrjImageList.Images.Item(0)

            Me.FilesContextMenuStrip.Items.Add(ToolStripMenuItem1)

            AddHandler ToolStripMenuItem1.Click, AddressOf Me.ToolStripMenuItem1
        Next

        FilesContextMenuStrip.Show(New System.Drawing.Point(Me.Location.X + 70, Me.Location.Y + 60))
    End Sub

    ''' <summary>
    ''' evento de pulsación de una opción del menu contextual de la lista de proyectos recientes
    ''' carga un fichero
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim aSender As ToolStripMenuItem = sender
        LoadFile(aSender.Name, False)
    End Sub



    Private Sub BitmapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitmapButton.Click
        Dim result As System.Windows.Forms.DialogResult
        Dim tmpsprites As SortedList

        Dim aBitmapWin As New BitmapWin(Me.SpriteProject.Name, Me.SpriteProject.ProjectSize, Me.SpriteProject.ProjectMode, Me.SpriteProject.sprites, paletteDialog.PaletteColors, Me.Path_SC2, Me.Path_Bitmap)

        result = aBitmapWin.ShowDialog()

        Me.Path_SC2 = aBitmapWin.Path_SC2
        Me.Path_Bitmap = aBitmapWin.Path_Bitmap

        If result = Windows.Forms.DialogResult.OK Then

            tmpsprites = aBitmapWin.getSpritesData()
            If Not tmpsprites Is Nothing Then

                paletteDialog.PaletteColors = aBitmapWin.PaletteMSX
                Me.SpriteContainer.PaletteData = paletteDialog.PaletteColors
                Me.SpriteProject.RefreshPalette(paletteDialog.PaletteColors)

                showProgressWin()

                'Me.ClearAllData()
                Me.totalLabel.Text = "0"
                Me.ProjectFilePath = ""
                Me.ProjectFileName = ""
                Me.SpriteProject.clear()
                Me.SpriteContainer.NewSprite()

                setProjectName(aBitmapWin.ProjectName)

                'Me.SpriteContainer.ClearSprite()

                For Each aSprite As SpriteMSX In tmpsprites.Values
                    Me.AddSprite(aSprite)
                Next

                closeProgressWin()

                Application.DoEvents()
            End If

        End If

    End Sub




    'Private Sub StartThread()
    '    Dim WC As New ProgressForm(Me.Location, Me.Size)
    '    BackgroundWorker1.RunWorkerAsync(WC)
    'End Sub

    Private Sub showProgressWin()
        Me.Enabled = False

        'StartThread()
        ' http://msdn.microsoft.com/en-us/library/vstudio/system.componentmodel.backgroundworker
        Dim aThread As System.Threading.Thread = New Threading.Thread(AddressOf Task_form)
        aThread.SetApartmentState(Threading.ApartmentState.STA)
        aThread.Start()

        System.Threading.Thread.Sleep(1000)

    End Sub

    Private Sub closeProgressWin()
        'Me.BackgroundWorker1.CancelAsync()
        Application.DoEvents()
        Try
            If Not aProgressForm Is Nothing Then
                aProgressForm.BeginInvoke(New InvokeDelegate(AddressOf aProgressForm.Close))
            End If
            Me.Enabled = True
            Me.Refresh()
            Application.DoEvents()

        Catch ex As Exception
            System.Threading.Thread.Sleep(2000)
            closeProgressWin()
        End Try
    End Sub

    Public Sub Task_form()
        aProgressForm = New ProgressForm(Me.Location, Me.Size) ' Must be created on this thread!
        Application.Run(aProgressForm)
    End Sub


    Private Sub setProjectName(ByVal name As String)
        Me.ProjectNameText.Text = name
        Me.SpriteProject.Name = name
    End Sub


    Private Sub ProjectNameText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ProjectNameText.Validating
        Me.SpriteProject.Name = Me.ProjectNameText.Text
    End Sub


    'Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    If e.Cancel Then
    '        Dim worker As ProgressForm = CType(sender, ProgressForm)
    '        worker.Close()
    '    End If
    'End Sub

    Private Sub ProjectInfoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectInfoButton.Click
        setProjectInfo()
    End Sub

    ''' <summary>
    ''' Opens the project information editing window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setProjectInfo()

        Dim ProjectProperties As New ProjectPropertiesWin

        ProjectProperties.ProjectFile = Me.ProjectFileName
        ProjectProperties.ProjectName = Me.SpriteProject.Name
        ProjectProperties.ProjectVersion = Me.SpriteProject.Version
        ProjectProperties.ProjectGroup = Me.SpriteProject.Group
        ProjectProperties.ProjectAuthor = Me.SpriteProject.Author
        ProjectProperties.ProjectDescription = Me.SpriteProject.Description
        ProjectProperties.ProjectStartDate = Me.SpriteProject.StartProjectDate
        ProjectProperties.ProjectLastUpdate = Me.SpriteProject.LastUpdate

        If ProjectProperties.ShowDialog = Windows.Forms.DialogResult.OK Then
            setProjectName(ProjectProperties.ProjectName)
            Me.SpriteProject.Version = ProjectProperties.ProjectVersion
            Me.SpriteProject.Group = ProjectProperties.ProjectGroup
            Me.SpriteProject.Author = ProjectProperties.ProjectAuthor
            Me.SpriteProject.Description = ProjectProperties.ProjectDescription
        End If

    End Sub



    Private Sub SpriteName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SpriteName.Validating
        If Not Me.SpriteContainer Is Nothing Then
            Me.SpriteContainer.SpriteName = SpriteName.Text
        End If
    End Sub



    Private Sub toolbox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SquareButton.MouseDown, LineButton.MouseDown, PencilButton.MouseDown, CircleButton.MouseDown, FillButton.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            selectTool(translateIDtool(sender.Tag, True))
        Else
            selectTool(translateIDtool(sender.Tag, False))
        End If
    End Sub


    Private Function translateIDtool(ByVal tagtool As String, ByVal isSecond As Boolean) As Integer
        Dim numTool As Integer = CInt(tagtool)
        Dim anID As Integer = numTool
        Select Case numTool
            Case 2
                If isSecond Then
                    anID = 3
                End If
            Case 3
                If isSecond Then
                    anID = 5
                Else
                    anID = 4
                End If
            Case 4
                anID = 6
        End Select

        Return anID
    End Function



    Private Sub selectTool(ByVal numtool As Integer)

        Dim itemButton As ToolStripButton

        Select Case numtool
            Case 2
                SquareButton.Image = toolboxImageList.Images.Item(4)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = paintToolBox.Items.Item(2)
            Case 3
                SquareButton.Image = toolboxImageList.Images.Item(5)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = paintToolBox.Items.Item(2)
            Case 4
                CircleButton.Image = toolboxImageList.Images.Item(1)
                SquareButton.Image = toolboxImageList.Images.Item(3)
                itemButton = paintToolBox.Items.Item(3)
            Case 5
                CircleButton.Image = toolboxImageList.Images.Item(2)
                SquareButton.Image = toolboxImageList.Images.Item(3)
                itemButton = paintToolBox.Items.Item(3)
            Case 6
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = paintToolBox.Items.Item(4)
            Case Else
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = paintToolBox.Items.Item(numtool)
        End Select

        oldtoolControl.BackColor = Color.Transparent
        itemButton.BackColor = Color.PaleGreen
        oldtoolControl = itemButton

        Me.SpriteContainer.SetState(numtool)

        'End If
    End Sub



    Private Sub selectSecondTool(ByVal numtool As Integer)

        'Dim numtool As Integer = CInt(sender.Tag)
        Dim itemButton As ToolStripButton
        'If numtool > paintToolBox.Items.Count Then
        '    Exit Sub
        'End If

        itemButton = paintToolBox.Items.Item(numtool)

        oldtoolControl.BackColor = Color.Transparent
        itemButton.BackColor = Color.PaleGreen
        oldtoolControl = itemButton


        Select Case numtool

            Case 3
                SquareButton.Image = toolboxImageList.Images.Item(5)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                Me.SpriteContainer.SetState(SpritePanelBase.STATE_TOOL.RECTANGLE_FILL)

            Case 5
                CircleButton.Image = toolboxImageList.Images.Item(2)
                SquareButton.Image = toolboxImageList.Images.Item(3)
                Me.SpriteContainer.SetState(SpritePanelBase.STATE_TOOL.CIRCLE_FILL)
            Case 4
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                Me.SpriteContainer.SetState(SpritePanelBase.STATE_TOOL.FILL)


            Case Else
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                Me.SpriteContainer.SetState(numtool)

        End Select

    End Sub



    'Private Sub UndoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoButton.Click
    '    Me.SpriteContainer.SetUndo()
    'End Sub

    Private Sub UndoButton_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UndoButton.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.SpriteContainer.SetRedo()
        Else
            Me.SpriteContainer.SetUndo()
        End If
    End Sub



    
   
    Private Sub mainWin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then

            If e.KeyCode = Keys.F1 Then
                ' help
            End If

            If e.KeyCode = Keys.Z Then
                Me.SpriteContainer.SetUndo()
            End If
            If e.KeyCode = Keys.Y Then
                Me.SpriteContainer.SetRedo()
            End If

            If e.KeyCode = Keys.I Then
                Me.SpriteContainer.Invert()
            End If

            If e.KeyCode = Keys.Enter Then
                AddAction()
            End If

            If e.KeyCode = Keys.Oemplus Then ' +
                CopySprite()
            End If

            If e.KeyCode = Keys.O Then
                If AreYouSure() Then
                    LoadFile(False)
                End If
            End If

            If e.KeyCode = Keys.S Then
                Save()
            End If

            If e.KeyCode = Keys.N Then
                Me.SpriteContainer.NewSprite()
                'NewProject()
            End If

            If e.KeyCode = Keys.D Then
                selectTool(SpritePanelBase.STATE_TOOL.DRAW) 'pencil
            End If

            If e.KeyCode = Keys.Up Then
                Me.SpriteContainer.MoveUp()
            End If

            If e.KeyCode = Keys.Down Then
                Me.SpriteContainer.MoveDown()
            End If

            If e.KeyCode = Keys.Right Then
                Me.SpriteContainer.MoveRight()
            End If

            If e.KeyCode = Keys.Left Then
                Me.SpriteContainer.MoveLeft()
            End If


        ElseIf e.Alt Then

            If e.KeyCode = Keys.D Then
                selectTool(SpritePanelBase.STATE_TOOL.DRAW) 'pencil
            End If

            If e.KeyCode = Keys.L Then
                selectTool(SpritePanelBase.STATE_TOOL.LINE) 'line
            End If

            If e.KeyCode = Keys.F Then
                selectTool(SpritePanelBase.STATE_TOOL.FILL) 'fill
            End If

            If e.KeyCode = Keys.Up Then
                SpriteProject.OrderDecreases()
            End If
            If e.KeyCode = Keys.Down Then
                SpriteProject.OrderIncreases()
            End If


            If e.Shift Then
                If e.KeyCode = Keys.R Then
                    selectTool(SpritePanelBase.STATE_TOOL.RECTANGLE_FILL) 'rectangle
                End If

                If e.KeyCode = Keys.C Then
                    selectTool(SpritePanelBase.STATE_TOOL.CIRCLE_FILL) 'circle
                End If
            Else
                If e.KeyCode = Keys.R Then
                    selectTool(SpritePanelBase.STATE_TOOL.RECTANGLE) 'rectangle
                End If

                If e.KeyCode = Keys.C Then
                    selectTool(SpritePanelBase.STATE_TOOL.CIRCLE) 'circle
                End If
            End If
        Else
            

        End If

    End Sub



End Class
