Imports System.IO



''' <summary>
''' tMSgfX spriteSX devtool
''' Copyright mvac7 (aka aorante) 2023 
''' This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License 
''' as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
''' This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
''' without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
''' You should have received a copy of the GNU General Public License along with this program.  If not, see http://www.gnu.org/licenses/.
''' 
''' Description:
''' Tool to create a project of sprite sets, for TMS9918 and V9938 video processors 
''' (MSX, colecovision, SG1000, etc...), which provides the source code for Assembler, C and Basic.
''' </summary>
''' <remarks></remarks>
Public Class SpriteEditor
    Implements IEditorContainer


    Private AppConfig As Config
    Private _AppID As String = "spriteSX"

    Private _isanApp As Boolean = False

    Private _ProgressController As ProgressController

    Private SpriteContainer As ISpriteContainer
    Private SpriteControl As Control

    Private Project As tMSgfXProject

    Private _spritesetSelected As SpritesetMSX

    Private _clipboard As SpriteMSX

    Private _spriteType As Integer = 0 ' se utiliza para controlar el cambio del control de editor de sprite

    Private oldtoolControl As ToolStripButton
    Private oldtoolSpriteset As ToolStripButton



    Public Shadows Const LoadTypes As String = "All files|*." + MSXOpenDocumentIO.Extension_SpriteDocument + ";*." + MSXOpenDocumentIO.Extension_SpriteOLDformat + ";*." + MSXOpenDocumentIO.Extension_ProjectDocument + ";*.SPR;*.SC*;*.png|MSX Open Document Sprite Project|*." + MSXOpenDocumentIO.Extension_SpriteDocument + ";*." + MSXOpenDocumentIO.Extension_SpriteOLDformat + "|MSX Open Document Project|*." + MSXOpenDocumentIO.Extension_ProjectDocument + "|MSX BASIC Graphic|*.SC*;*.SPR|Bitmap file|*.png"
    Public Shadows Const SaveTypes As String = "MSX Open Document Sprite Project|*." + MSXOpenDocumentIO.Extension_SpriteDocument + "|MSX Open Document Project|*." + MSXOpenDocumentIO.Extension_ProjectDocument


    Private Enum SPRSET_TOOLBOX As Integer
        SELECTER
        EXCHANGE
        COPY
    End Enum



    Public ReadOnly Property AppID As String Implements GUI.Controls.IEditorContainer.AppID
        Get
            Return Me._AppID
        End Get
    End Property



    Public Property IsanApp As Boolean Implements GUI.Controls.IEditorContainer.IsanApp
        Get
            Return Me._isanApp
        End Get
        Set(value As Boolean)
            Me._isanApp = value
        End Set
    End Property


    Public ReadOnly Property HaveAddFile As Boolean Implements IEditorContainer.HaveAddFile
        Get
            Return True
        End Get
    End Property


    Public ReadOnly Property HaveDataOutput As Boolean Implements IEditorContainer.HaveDataOutput
        Get
            Return True
        End Get
    End Property



    Public ReadOnly Property ProjectName As String Implements GUI.Controls.IEditorContainer.ProjectName
        Get
            If Me.Project Is Nothing Then
                Return ""
            Else
                Return Me.Project.Info.Name
            End If
        End Get
    End Property



    Public ReadOnly Property AboutIcon As Image Implements GUI.Controls.IEditorContainer.AboutIcon
        Get
            Return Global.mSXdevtools.spriteEditor.My.Resources.spriteSX_icon_128px
        End Get
    End Property



    Public ReadOnly Property AboutLogo As Image Implements GUI.Controls.IEditorContainer.AboutLogo
        Get
            Return Global.mSXdevtools.spriteEditor.My.Resources.spriteSX_logo_x2
        End Get
    End Property



    Public ReadOnly Property LoadFileTypes As String Implements IEditorContainer.LoadFileTypes
        Get
            Return LoadTypes
        End Get
    End Property


    Public ReadOnly Property SaveFileTypes As String Implements IEditorContainer.SaveFileTypes
        Get
            Return SaveTypes
        End Get
    End Property





    Public Sub New(ByVal _config As Config)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.Project = New tMSgfXProject

    End Sub



    Public Sub New(ByRef _config As Config, ByRef _project As tMSgfXProject)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.Project = _project

    End Sub



    Private Sub SpriteEditor_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.Project)

        Me._ProgressController = New ProgressController(Me.ParentForm)

        Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)


        If Me.Project.SpriteSets Is Nothing Then
            Me.Project.SpriteSets = New SpriteProject(Me.Project.Palettes)
        End If

        Me.oldtoolControl = Me.PencilButton
        oldtoolControl.BackColor = Color.PaleGreen


        If Me.IsanApp = False Then
            RefreshEditor()
        End If

        AddHandler Me.ParentForm.KeyDown, AddressOf Editor_KeyDown   ' solution for when keyboard events are not collected in the usercontrol 

    End Sub



    Public Sub RefreshEditor() Implements GUI.Controls.IEditorContainer.RefreshEditor

        ' si ha fallado la carga o no hay un proyecto, añade un set vacio
        ifProjectEmpty()

        InitEditor(0)

    End Sub



    Public Sub UpdateConfig() Implements IEditorContainer.UpdateConfig
        Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)
        RefreshEditor()
    End Sub



    ''' <summary>
    ''' Opens the project information editing window.
    ''' </summary>
    Public Sub EditProjectInfo() Implements IEditorContainer.EditProjectInfo
        Dim ProjectProperties As New ProjectPropertiesDialog(Me.AppConfig, Me.Project.Info)

        If ProjectProperties.ShowDialog = DialogResult.OK Then

            Me.Project.Info = ProjectProperties.GetProjectInfo()

        End If
    End Sub



    Private Sub EditPalette() Implements IEditorContainer.EditPalette

        Dim PaletteDialog = New Palette512Dialog(Me.AppConfig, Me.Project, 0)

        If PaletteDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Me._paletteID = PaletteDialog.SelectedPaletteID

            RefreshEditor()
        End If

    End Sub



    Public Function AcceptType(ByVal filePath As String) As Boolean Implements IEditorContainer.AcceptType

        Dim extension As String = Path.GetExtension(filePath).ToUpper

        Select Case extension
            Case "." + MSXOpenDocumentIO.Extension_SpriteDocument
                Return True

            Case "." + MSXOpenDocumentIO.Extension_SpriteOLDformat
                Return True

            Case "." + MSXOpenDocumentIO.Extension_ProjectDocument
                Return True

            Case ".PNG" ',".GIF"  Bitmap
                Return True

            Case "." + MSXBasicGraphicsFileIO.Extension_MSXBASICsprites, "." + MSXBasicGraphicsFileIO.Extension_MSXBASICscreen1, "." + MSXBasicGraphicsFileIO.Extension_MSXBASICscreen2, "." + MSXBasicGraphicsFileIO.Extension_MSXBASICscreen4 ' MSX Basic Binary ' MSX Basic Binary
                Return True

            Case Else
                Return False

        End Select

    End Function



    Private Sub ifProjectEmpty()
        If Me.Project.SpriteSets.Count = 0 Then
            Me.Project.SpriteSets.Add(New SpritesetMSX("spriteset", SpriteMSX.SPRITE_SIZE.SIZE16, SpriteMSX.SPRITE_MODE.MONO, 15, 0, Me.Project.Palettes.GetPalette(0)))
        End If
    End Sub



    Private Sub InitEditor(ByVal spritesetID As Integer)

        RemoveHandler Me.aSpritesetControl.SelectedSpriteChanged, AddressOf Me.aSpritesetControl_SelectedSpriteChanged
        RemoveHandler Me.SpritesetComboBox.SelectedIndexChanged, AddressOf Me.SpritesetComboBox_SelectedIndexChanged

        If spritesetID = 0 Then
            spritesetID = Me.Project.SpriteSets.GetIDFromIndex(0)
        End If

        RefreshSpritesetSelector()
        SpritesetComboBox.SelectedIndex = Me.Project.SpriteSets.GetIndexFromID(spritesetID)

        SelectSpriteset(spritesetID)

        SelectTool(SPRSET_TOOLBOX.SELECTER)

        AddHandler Me.aSpritesetControl.SelectedSpriteChanged, AddressOf Me.aSpritesetControl_SelectedSpriteChanged
        AddHandler Me.SpritesetComboBox.SelectedIndexChanged, AddressOf Me.SpritesetComboBox_SelectedIndexChanged

    End Sub



    Private Sub NewProject() Implements GUI.Controls.IEditorContainer.NewProject

        Dim tmpProjectInfo As ProjectInfo

        ClearProject()

        Dim configDialog As New ConfigSpritesetDialog(Me.AppConfig, Me.Project)
        configDialog.ShowDialog()

        tmpProjectInfo = configDialog.GetProjectInfo()
        Me.Project.Info.Name = tmpProjectInfo.Name
        Me.Project.Info.Version = tmpProjectInfo.Version
        Me.Project.Info.Group = tmpProjectInfo.Group
        Me.Project.Info.Author = tmpProjectInfo.Author
        Me.Project.Info.Description = tmpProjectInfo.Description

        AddSpriteset(New SpritesetMSX(configDialog.Name, configDialog.SpriteSize, configDialog.SpriteMode, configDialog.InkColor, configDialog.BackgroundColor, Me.Project.Palettes.GetPaletteByID(configDialog.PaletteID)))

        RefreshEditor()

    End Sub





    ''' <summary>
    ''' Borra todos los datos de un proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearProject()

        If Me._isanApp = True Then

            Me.Project = New tMSgfXProject
            Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)

            Me.Project.SpriteSets = New SpriteProject()
            Me.Project.SpriteSets.Palettes = Me.Project.Palettes

        Else
            'tMSgfX project
            Me.Project.SpriteSets.Clear()  '<--- clear only Spritesets project

        End If

    End Sub




    Private Sub RefreshSpritesetSelector()
        Dim counter As Integer = 1
        Me.SpritesetComboBox.Items.Clear()
        If Me.Project.SpriteSets.Count > 0 Then
            For Each aName As String In Me.Project.SpriteSets.GetNameList
                Me.SpritesetComboBox.Items.Add(CStr(counter) + " - " + aName)
                counter += 1
            Next
        End If
    End Sub



    Private Sub SelectSpriteset(ByVal ID As Integer)

        If Me.Project.SpriteSets.Contains(ID) Then

            Me._spritesetSelected = Me.Project.SpriteSets.GetSpritesetByID(ID)


            Me.aSpritesetControl.SetSpriteset(Me._spritesetSelected)

            SetSpriteContainer(Me._spritesetSelected.Size, Me._spritesetSelected.Mode)
            Me.SpriteContainer.Palette = Me._spritesetSelected.Palette

            EditSpriteByIndex(0)
        End If

        Me.spritePreviewPicture.Focus()

    End Sub



    Private Sub AddSpriteset(ByVal aSpriteset As SpritesetMSX)

        Me.Project.SpriteSets.Add(aSpriteset)
        RefreshSpritesetSelector()
        SpritesetComboBox.SelectedIndex = Me.Project.SpriteSets.GetIndexFromID(aSpriteset.ID)

    End Sub



    Private Sub NewSpriteset()

        Dim configDialog As New ConfigSpritesetDialog(Me.AppConfig, Me.Project, "spriteset00")
        If configDialog.ShowDialog() = DialogResult.OK Then
            AddSpriteset(New SpritesetMSX(configDialog.Name, configDialog.SpriteSize, configDialog.SpriteMode, configDialog.InkColor, configDialog.BackgroundColor, Me.Project.Palettes.GetPaletteByID(configDialog.PaletteID)))
        End If

    End Sub



    Private Sub ConfigSpriteset()

        'Dim oldName As String = Me._spritesetSelected.Name
        Dim configDialog As New ConfigSpritesetDialog(Me.AppConfig, Me.Project, Me._spritesetSelected.ID) 'oldName, Me._spritesetSelected.Size, Me._spritesetSelected.Mode, Me._spritesetSelected.Palette.ID)

        If configDialog.ShowDialog() = DialogResult.OK Then

            If Not Me._spritesetSelected.Size = configDialog.SpriteSize Or Not Me._spritesetSelected.Mode = configDialog.SpriteMode Then
                Me._spritesetSelected.Palette = Me.Project.Palettes.GetPaletteByID(configDialog.PaletteID)
                Me._spritesetSelected.ConvertSpriteType(configDialog.SpriteSize, configDialog.SpriteMode)
            Else
                Me._spritesetSelected.SetPalette(Me.Project.Palettes.GetPaletteByID(configDialog.PaletteID))
                Me.aSpritesetControl.RefreshPalette()
            End If

            If Not Me._spritesetSelected.Name = configDialog.Name Then
                Me.Project.SpriteSets.ChangeName(Me._spritesetSelected.ID, configDialog.Name)
                RefreshSpritesetSelector() 'se refresca la lista del combobox
                SpritesetComboBox.SelectedIndex = Me.Project.SpriteSets.GetIndexFromID(Me._spritesetSelected.ID)
            End If

            'Me._spritesetSelected.InkColor = configDialog.InkColor
            'Me._spritesetSelected.BackgroundColor = configDialog.BackgroundColor

            'se selecciona el tileset por que en el evento ded combo lo descrimina al ser el mismo que ya esta seleccionado
            SelectSpriteset(Me._spritesetSelected.ID)

        End If

    End Sub



    Private Sub CopySpriteset() 'ByVal index As Integer

        Dim newName As String

        Dim result As DialogResult

        'Dim tileset As TilesetMSX = Me._tilesetProject.GetTileset(index)
        Dim newTileset As SpritesetMSX = Me._spritesetSelected.Clone

        Dim aCommonFunctions As New CommonFunctions

        newName = aCommonFunctions.GetNameWithNumberByRepetition(newTileset.Name, Me.Project.SpriteSets.GetNameList())

        Dim _entryTextDialog = New EntryTextDialog("Enter a name for new map:", newName)
        result = _entryTextDialog.ShowDialog()

        If result = DialogResult.OK Then

            newName = _entryTextDialog.TextValue

            If newName = "" Then
                newName = "newtileset_0"
            End If

            'newTileset = Me._tilesetSelected.Clone
            newTileset.Name = newName

            AddSpriteset(newTileset)

            'RefreshSpritesetSelector()
            'SpritesetComboBox.SelectedIndex = Me._spriteProject.Count - 1

        End If

    End Sub



    Private Sub DeleteSpriteset()

        'Dim result As DialogResult
        'result = MsgBox("This option will delete a current Sprite Set." + Chr(13) + "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

        Dim messageWin As New MessageDialog("Question", "This option will delete a current Sprite Set." + Chr(13) + "Are you sure?", MessageDialog.DIALOG_TYPE.YES_NO)

        If messageWin.ShowDialog(Me) = DialogResult.Yes Then
            Me.Project.SpriteSets.DeleteByID(Me._spritesetSelected.ID)

            ifProjectEmpty()

            RefreshSpritesetSelector()
            SpritesetComboBox.SelectedIndex = 0
        End If

    End Sub



    Private Sub SelectTool(ByVal numtool As SPRSET_TOOLBOX)

        Dim itemButton As ToolStripButton
        itemButton = TilesetToolboxStrip.Items.Item(numtool)

        If Not oldtoolSpriteset Is Nothing Then
            oldtoolSpriteset.BackColor = Drawing.Color.Transparent
        End If

        itemButton.BackColor = Drawing.Color.PaleGreen
        oldtoolSpriteset = itemButton

        Select Case numtool

            Case SPRSET_TOOLBOX.EXCHANGE
                aSpritesetControl.SetWorkMode(SpritesetControl.CONTROL_MODE.EXCHANGER)

            Case SPRSET_TOOLBOX.COPY
                aSpritesetControl.SetWorkMode(SpritesetControl.CONTROL_MODE.COPY)

            Case Else
                aSpritesetControl.SetWorkMode(SpritesetControl.CONTROL_MODE.SELECTER)
        End Select

    End Sub



    ''' <summary>
    ''' Shows the type of sprite editor according to the selected mode
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSpriteContainer(ByVal projectSize As SpriteMSX.SPRITE_SIZE, ByVal projectMode As SpriteMSX.SPRITE_MODE)

        Try

            If Not Me._spriteType = (projectSize * 2) + projectMode Then


                Me._spriteType = (projectSize * 2) + projectMode

                If Not Me.SpriteControl Is Nothing Then
                    Me.SpriteControl.Dispose()
                End If


                If projectMode = SpriteMSX.SPRITE_MODE.MONO Then
                    'one color
                    If projectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                        ' 8x8
                        Me.SpriteControl = New SpritePanel8(Me._spritesetSelected.Palette) 'paletteDialog.Palette
                    Else
                        ' 16x16
                        Me.SpriteControl = New SpritePanel16(Me._spritesetSelected.Palette) 'SpritePanel16 paletteDialog.Palette
                    End If

                Else
                    'line color (msx2 or +)
                    If projectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                        ' 8x8
                        Me.SpriteControl = New SpritePanel8mode2(Me._spritesetSelected.Palette) 'paletteDialog.Palette
                    Else
                        ' 16x16
                        Me.SpriteControl = New SpritePanel16mode2(Me._spritesetSelected.Palette) 'paletteDialog.Palette
                    End If

                End If

                Me.SpriteContainer = Me.SpriteControl

                Me.SuspendLayout()

                If projectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                    Me.spritePreviewPicture.Size = New System.Drawing.Size(16, 16)
                Else
                    Me.spritePreviewPicture.Size = New System.Drawing.Size(32, 32)
                End If


                '
                'SpriteControl.BackColor = System.Drawing.Color.WhiteSmoke
                Me.SpriteControl.Visible = False
                'Me.SpriteControl.Dock = DockStyle.Fill
                Me.SpriteControl.Location = New System.Drawing.Point(0, 0)
                Me.SpriteControl.Name = "SpriteContainer"
                Me.SpriteControl.Size = New System.Drawing.Size(360, 314) '(394, 372)
                Me.SpriteControl.TabIndex = 2

                Me.SpriteEDPanel.Controls.Add(Me.SpriteContainer)

                'Me.SpriteControl.BringToFront()

                Me.SpriteContainer.SpriteName = ""

                AddHandler SpriteContainer.updateSprite, AddressOf Me.UpdateSprite
                AddHandler SpriteContainer.MatrixCoordinates, AddressOf Me.setMatrixCoordinates
                AddHandler SpriteContainer.SpriteBitmapChanged, AddressOf Me.SpriteBitmapChanged
                'AddHandler SpriteContainer.SpriteInfoChanged, AddressOf Me.setSpriteInfoChanged

                Me.ResumeLayout(False)
                Me.PerformLayout()

                Me.SpriteControl.Visible = True

                Me.Refresh()
                'Application.DoEvents()

            End If


            selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.DRAW) ' pone el paint toolbox por defecto a draw


        Catch ex As Exception

        End Try

    End Sub



    Private Sub EditSpriteByIndex(ByVal index As Integer)
        Dim aSprite As SpriteMSX
        aSprite = Me._spritesetSelected.GetSprite(index)
        EditSprite(aSprite)
    End Sub



    Private Sub EditSprite(ByVal sprite As SpriteMSX)
        Me.SpriteContainer.SetSprite(sprite)
        Me.SpriteNumberLabel.Text = CStr(sprite.Index)
        Me.SpriteName.Text = sprite.Name
    End Sub



    Private Sub selectSpriteEditorTool(ByVal numtool As Integer)

        Dim itemButton As ToolStripButton

        Select Case numtool
            Case 2
                SquareButton.Image = toolboxImageList.Images.Item(4)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = SpritePaintToolBox.Items.Item(2)
            Case 3
                SquareButton.Image = toolboxImageList.Images.Item(5)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = SpritePaintToolBox.Items.Item(2)
            Case 4
                CircleButton.Image = toolboxImageList.Images.Item(1)
                SquareButton.Image = toolboxImageList.Images.Item(3)
                itemButton = SpritePaintToolBox.Items.Item(3)
            Case 5
                CircleButton.Image = toolboxImageList.Images.Item(2)
                SquareButton.Image = toolboxImageList.Images.Item(3)
                itemButton = SpritePaintToolBox.Items.Item(3)
            Case 6
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = SpritePaintToolBox.Items.Item(4)
            Case Else
                SquareButton.Image = toolboxImageList.Images.Item(3)
                CircleButton.Image = toolboxImageList.Images.Item(0)
                itemButton = SpritePaintToolBox.Items.Item(numtool)
        End Select

        oldtoolControl.BackColor = Color.Transparent
        itemButton.BackColor = Color.PaleGreen
        oldtoolControl = itemButton

        Me.SpriteContainer.SetState(numtool)

        'End If
    End Sub



    ''' <summary>
    ''' Recoge el sprite del editor y lo añade al controlador del proyecto y lo selecciona (resalta) en la lista.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateSprite()
        Dim aSprite As SpriteMSX

        aSprite = Me.SpriteContainer.GetSprite().Clone()  ' recoge el sprite del contenedor
        aSprite.Name = Me.SpriteName.Text   'fix Bug 891  
        'aSprite.Index = CInt(Me.SpriteNumberTextBox.Text)  'Allows you to change the target pattern

        Me.aSpritesetControl.UpdateSprite(aSprite)

    End Sub



    ''' <summary>
    ''' Muestra la ventana donde se configura y se generan los datos formateados para diferentes lenguajes de programación.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowOutputDataWindow() Implements IEditorContainer.ShowOutputDataWindow

        Dim OutputDataDialog As New SourceCodeDialog(Me.AppConfig, Me.Project.Info, Me.Project.SpriteSets, Me._spritesetSelected.ID, Me.Project.Path)
        OutputDataDialog.ShowDialog()

    End Sub





    'Private Sub EditPalette()
    '    'Dim result As DialogResult


    '    ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
    '    If Not Me.SpriteControl Is Nothing Then
    '        Me.SpriteControl.Enabled = False
    '    End If


    '    Dim paletteDialog As New Palette512Dialog(Me.AppConfig, Me.Project, Me._spritesetSelected.Palette.ID)

    '    If paletteDialog.ShowDialog = DialogResult.OK Then
    '        Me._spritesetSelected.SetPalette(Me.Project.Palettes.GetPaletteByID(paletteDialog.SelectedPaletteID)) 'paletteDialog.SelectedPalette

    '        Me.SpriteContainer.Palette = Me._spritesetSelected.Palette
    '        Me.aSpritesetControl.RefreshPalette()

    '    End If


    '    ' habilita el editor de sprites
    '    If Not Me.SpriteControl Is Nothing Then
    '        Me.SpriteControl.Enabled = True
    '        Me.SpriteControl.Refresh()
    '        Me.SpriteContainer.SetNameFocus()
    '        'Application.DoEvents()
    '    End If

    'End Sub



    'Private Function AreYouSure() As Boolean
    '    Dim result As DialogResult

    '    result = MsgBox("This option will delete all data." + Chr(13) + "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

    '    If result = DialogResult.Yes Then
    '        Return True
    '    End If

    '    Return False

    'End Function


    Private Sub Cut()
        Me.SpriteContainer.AddUndo()
        CopyToClipboard()
        Me.SpriteContainer.ClearSprite()
        UpdateSprite()
    End Sub



    Private Sub Copy()
        CopyToClipboard()
    End Sub



    Private Sub Paste()
        PasteFromClipboard()
    End Sub



    Public Sub CopyToClipboard()
        If Not Me.SpriteContainer.Sprite Is Nothing Then
            Me._clipboard = Me.SpriteContainer.GetSprite().Clone()
            ClipboardPictureBox.Image = Me._clipboard.GetBitmapX2()
        End If
    End Sub



    Public Sub PasteFromClipboard()

        If Not Me._clipboard Is Nothing Then
            Me.SpriteContainer.AddUndo()
            Me._clipboard.Index = Me.SpriteContainer.Sprite.Index
            Me.SpriteContainer.SetSprite(Me._clipboard)
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






    ' SAVE ################################################################################################################################################################################


    Public Function SaveProject(filepath As String) As Boolean Implements GUI.Controls.IEditorContainer.SaveProject

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)
        Dim result As Boolean
        Dim extension As String

        Me._ProgressController.ShowProgressWin()

        extension = Path.GetExtension(filepath).ToUpper

        Select Case extension

            Case "." + MSXOpenDocumentIO.Extension_ProjectDocument
                result = _tmsgfxIO.SaveProject(filepath)

            Case "." + MSXOpenDocumentIO.Extension_SpriteDocument
                result = _tmsgfxIO.SaveSpriteProject(filepath)

        End Select


        Application.DoEvents()
        Me._ProgressController.CloseProgressWin()

        Return result

    End Function



    Private Sub SaveSpritesetDialog()

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)

        If Me.Project.Path = "" Then
            Me.SaveFileDialog1.FileName = Me._spritesetSelected.Name
            Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemSprite.Path
        Else
            Me.SaveFileDialog1.FileName = Me._spritesetSelected.Name
            Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.Project.Path)
        End If

        Me.SaveFileDialog1.Filter = "MSX Open Document Sprite Project|*." + MSXOpenDocumentIO.Extension_SpriteDocument

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            _tmsgfxIO.SaveSpriteset(SaveFileDialog1.FileName, Me._spritesetSelected.ID)
            Me.AppConfig.PathItemSprite.UpdateLastPath(Path.GetDirectoryName(SaveFileDialog1.FileName))
        End If

    End Sub



    Private Sub SaveMSXBASICGraphic()
        Dim aBinaryDialog As New MSXBASICGraphicsDialog(Me.AppConfig, Me.Project, Me._spritesetSelected.ID)
        aBinaryDialog.ShowDialog(Me)
    End Sub



    Private Sub SaveSpritesBitmap()
        Dim aBitmapWin As New SaveBitmapDialog(Me.AppConfig, Me.Project.SpriteSets, Me.Project.Palettes, Me.Project.Info.Name, Me._spritesetSelected.ID) ', Me.Path_SC2, Me.Path_Bitmap
        aBitmapWin.ShowDialog()
    End Sub

    ' ################################################################################################################################################################################ END SAVE








    ' LOAD ################################################################################################################################################################################

    Public Function AddProject(ByVal filePath As String) As Boolean Implements GUI.Controls.IEditorContainer.AddProject

        Return LoadSpriteSet(filePath)

    End Function




    Public Function LoadProject(ByVal filePath As String) As Boolean Implements GUI.Controls.IEditorContainer.LoadProject

        Dim result As Boolean = False
        Dim extension As String
        Dim newID As Integer = 0

        ' comprueba si existe el fichero
        If System.IO.File.Exists(filePath) Then

            ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = False
            End If


            extension = Path.GetExtension(filePath).ToUpper

            Select Case extension
                Case "." + MSXOpenDocumentIO.Extension_SpriteDocument, "." + MSXOpenDocumentIO.Extension_SpriteOLDformat
                    result = LoadMSXOpenDocumentProject(filePath)

                Case "." + MSXOpenDocumentIO.Extension_ProjectDocument
                    result = LoadMSXOpenDocumentProject(filePath)

                Case ".PNG" ' ,".GIF"  Bitmap 
                    newID = LoadBitmap(filePath, True) ', Me.isanApp)

                Case ".SC1", ".SC2", ".SC3", ".SC4", ".SPR"
                    newID = LoadMSXBasicGraphics(filePath, True)

            End Select

            If newID > 0 Then
                If Me._isanApp = True Then
                    SetProjectInfoData(filePath)
                End If
                result = True
            End If


            If result = True Then
                If Me._isanApp = True Then
                    Me.Project.Path = filePath
                End If
                'Me.AppConfig.AddRecentProject(Me.Project.Path, AppID)
                ifProjectEmpty()
                InitEditor(0)
            End If


            ' habilita el editor de sprites
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = True
                Me.SpriteControl.Refresh()
            End If

        Else
            ' en el caso de que no exista
            'MsgBox("The file does not exist!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Load Project")
            Dim messageWin As New MessageDialog("Load Project", "The file does not exist!", MessageDialog.DIALOG_TYPE.ALERT)
            messageWin.ShowDialog(Me)
        End If

        Return result

    End Function



    Private Sub LoadSpritesetDialog()

        Me.OpenFileDialog1.Filter = "All files|*." + MSXOpenDocumentIO.Extension_SpriteDocument + ";*." + MSXOpenDocumentIO.Extension_SpriteOLDformat + ";*." + MSXOpenDocumentIO.Extension_ProjectDocument + ";*.SPR;*.SC*;*.png|MSX Open Document Sprite Project|*." + MSXOpenDocumentIO.Extension_SpriteDocument + "|MSX BASIC Graphic|*.SC*;*.SPR|Bitmap file|*.png"

        If Me.Project.Path = "" Then
            Me.OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.InitialDirectory = Me.AppConfig.PathItemSprite.Path
        Else
            'Me.OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.Project.Path)
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadSpriteSet(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Function LoadSpriteSet(ByVal filePath As String) As Boolean

        Dim extension As String
        Dim newID As Integer
        Dim aResult As Boolean = True

        ' comprueba si existe el fichero
        If System.IO.File.Exists(filePath) Then

            ' inhabilita el control del editor de sprites, para evitar algunas excepciones por eventos
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = False
            End If

            extension = Path.GetExtension(filePath).ToUpper
            Select Case extension
                Case "." + MSXOpenDocumentIO.Extension_ProjectDocument, "." + MSXOpenDocumentIO.Extension_SpriteDocument, "." + MSXOpenDocumentIO.Extension_SpriteOLDformat
                    newID = LoadMSXOpenDocumentSpriteset(filePath)

                Case ".PNG"  ',".GIF"
                    newID = LoadBitmap(filePath, False)

                Case ".SC1", ".SC2", ".SC3", ".SC4", ".SPR"
                    newID = LoadMSXBasicGraphics(filePath, False) ' MSX Basic Binary

            End Select


            If newID > 0 Then

                Me.AppConfig.PathItemSprite.UpdateLastPath(Path.GetDirectoryName(filePath))

                RefreshSpritesetSelector()
                SpritesetComboBox.SelectedIndex = Me.Project.SpriteSets.GetIndexFromID(newID)

            Else

                aResult = False

            End If

            ' habilita el editor de sprites
            If Not Me.SpriteControl Is Nothing Then
                Me.SpriteControl.Enabled = True
                Me.SpriteControl.Refresh()
            End If

        Else
            '    ' en el caso de que no exista
            aResult = False

            '    Dim messageWin As New MessageDialog("Load Project", "The file does not exist!", MessageDialog.DIALOG_TYPE.ALERT)
            '    messageWin.ShowDialog(Me)

        End If

        Return aResult

    End Function



    Private Sub SetProjectInfoData(ByVal filePath As String)
        Me.Project.Info.Name = Path.GetFileNameWithoutExtension(filePath)
        Me.Project.Info.Author = Me.AppConfig.Author
    End Sub



    Private Function LoadMSXOpenDocumentProject(ByVal filePath As String) As Boolean

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)
        Dim result As Boolean = False

        'If Me.AppState = APP_STATE.TOOL Then
        '    loadInfo = False
        'Else
        '    loadInfo = True
        'End If

        Me._ProgressController.ShowProgressWin()

        If _tmsgfxIO.LoadProject(filePath) = False Then
            ' prueba si es el formato antiguo
            result = _tmsgfxIO.LoadOLDspriteSXProject(filePath, True) '= True Then
            'Me.Project.Path = filePath
            'result = True
            'End If
        Else
            'Me.Project.Path = filePath
            result = True
        End If

        Application.DoEvents()
        Me._ProgressController.CloseProgressWin()


        If result = True Then
            Me.Project = _tmsgfxIO.Project   ' << OJO >> En _tmsgfxIO se pierde la referencia al objeto Project... ¿¿????? 
            ' Si se pasa cuando el resultado de la carga es correcto, puede ser interesante ya que conservaria los datos anteriores.
        Else
            'MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
            Dim messageWin As New MessageDialog("Load Project", "Disk I/O error!", MessageDialog.DIALOG_TYPE.ALERT)
            messageWin.ShowDialog(Me)
        End If

        Return result

    End Function



    Private Function AddMSXOpenDocumentProject(ByVal filePath As String) As Boolean

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)
        Dim result As Boolean = False

        'If Me.AppState = APP_STATE.TOOL Then
        '    loadInfo = False
        'Else
        '    loadInfo = True
        'End If

        Me._ProgressController.ShowProgressWin()

        If _tmsgfxIO.AddProject(filePath) = False Then
            ' prueba si es el formato antiguo
            result = _tmsgfxIO.LoadOLDspriteSXProject(filePath, True) '= True Then
            'Me.Project.Path = filePath
            'result = True
            'End If
        Else
            'Me.Project.Path = filePath
            result = True
        End If

        Application.DoEvents()
        Me._ProgressController.CloseProgressWin()


        If result = True Then
            Me.Project = _tmsgfxIO.Project   ' << OJO >> En _tmsgfxIO se pierde la referencia al objeto Project... ¿¿????? 
            ' Si se pasa cuando el resultado de la carga es correcto, puede ser interesante ya que conservaria los datos anteriores.
        Else
            Dim messageWin As New MessageDialog("Load Project", "Disk I/O error!", MessageDialog.DIALOG_TYPE.ALERT)
            messageWin.ShowDialog(Me)
        End If


        Return result

    End Function



    Private Function LoadMSXOpenDocumentSpriteset(ByVal filePath As String) As Integer

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)
        Dim itemName As String = ""
        Dim nameList As ArrayList


        If Not Path.GetExtension(filePath).ToUpper = "." + MSXOpenDocumentIO.Extension_SpriteOLDformat Then

            ' Get Map List
            nameList = _tmsgfxIO.GetNameListByNodeName(filePath, MSXOpenDocumentIO.SPRITES, MSXOpenDocumentIO.SPRITES_SET)

            ' si solo hay uno, lo carga directamente
            If nameList.Count = 1 Then
                itemName = nameList.Item(0)
            ElseIf nameList.Count > 1 Then
                ' show win with Map selector
                Dim aListSelectorDialog As New ListSelectorDialog("Load Spriteset", "Select a Spriteset:", "All Spritesets", nameList)
                If aListSelectorDialog.ShowDialog() = DialogResult.OK Then
                    If aListSelectorDialog.SelectedIndex = 0 Then
                        itemName = ""
                    Else
                        itemName = aListSelectorDialog.SelectedItem()
                    End If
                End If
            End If

        End If


        Return _tmsgfxIO.LoadSpriteset(filePath, itemName)

    End Function



    Private Function LoadMSXBasicGraphics(ByVal filePath As String, ByVal clearPRJ As Boolean) As Integer

        Dim outputID As Integer = -1

        Dim aBinaryDialog As New MSXBASICGraphicsDialog(Me.AppConfig, Me.Project, filePath)
        If aBinaryDialog.ShowDialog(Me) = DialogResult.OK Then
            If clearPRJ = True Then
                ClearProject()
            End If

            If Not aBinaryDialog.Sprites Is Nothing Then
                outputID = Me.Project.SpriteSets.Add(aBinaryDialog.Sprites)
            End If

        End If

        Return outputID

    End Function



    Private Function LoadBitmap(ByVal filePath As String, ByVal clearPRJ As Boolean) As Integer
        Dim result As DialogResult
        'Dim tmpsprites As SortedList

        Dim aBitmapWin As New LoadBitmapDialog(Me.AppConfig, Me.Project.Palettes, filePath) ', Me.Path_SC2, Me.Path_Bitmap

        Dim aSpriteset As SpritesetMSX

        result = aBitmapWin.ShowDialog()

        If result = DialogResult.OK Then

            aSpriteset = aBitmapWin.GetSpriteset()
            If Not aSpriteset Is Nothing Then
                If clearPRJ = True Then
                    ClearProject()
                End If
                AddSpriteset(aSpriteset)
                Return aSpriteset.ID
            End If
        End If

        Return -1
    End Function

    ' ################################################################################################################################################################################ END Load






    ' ################################################################################################################################################################################ events


    Private Sub Editor_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) ' Handles MyBase.KeyDown


        'If e.KeyCode = Keys.F1 Then
        '    If HelpAppButton.Enabled = True Then
        '        ShowHelp()
        '    End If
        'End If


        If e.Control Then

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
                UpdateSprite()
            End If

            'If e.KeyCode = Keys.Oemplus Then ' +
            '    CopySprite()
            'End If

            'If e.KeyCode = Keys.O Then
            '    If AreYouSure() Then
            '        LoadProjectDialog()
            '    End If
            'End If

            'If e.KeyCode = Keys.S Then
            '    Save()
            'End If

            'If e.KeyCode = Keys.N Then
            '    Me.SpriteContainer.NewSprite()
            'End If

            If e.KeyCode = Keys.D Then
                selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.DRAW) 'pencil
            End If

            If e.KeyCode = Keys.Up Then
                Me.SpriteContainer.MoveUp(False)
            End If

            If e.KeyCode = Keys.Down Then
                Me.SpriteContainer.MoveDown(False)
            End If

            If e.KeyCode = Keys.Right Then
                Me.SpriteContainer.MoveRight(False)
            End If

            If e.KeyCode = Keys.Left Then
                Me.SpriteContainer.MoveLeft(False)
            End If



            If e.KeyCode = Keys.X Then
                Me.Cut()
            End If

            If e.KeyCode = Keys.C Then
                Me.Copy()
            End If

            If e.KeyCode = Keys.V Then
                Me.Paste()
            End If


        ElseIf e.Alt Then

            If e.KeyCode = Keys.D Then
                selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.DRAW) 'pencil
            End If

            If e.KeyCode = Keys.L Then
                selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.LINE) 'line
            End If

            If e.KeyCode = Keys.F Then
                selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.FILL) 'fill
            End If

            'If e.KeyCode = Keys.Up Then
            '    Me.aSpritesetControl.OrderDecreases()
            'End If

            'If e.KeyCode = Keys.Down Then
            '    Me.aSpritesetControl.OrderIncreases()
            'End If


            If e.Shift Then
                If e.KeyCode = Keys.R Then
                    selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.RECTANGLE_FILL) 'rectangle
                End If

                If e.KeyCode = Keys.C Then
                    selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.ELLIPSE_FILL) 'circle
                End If
            Else
                If e.KeyCode = Keys.R Then
                    selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.RECTANGLE) 'rectangle
                End If

                If e.KeyCode = Keys.C Then
                    selectSpriteEditorTool(SpritePanelBase.STATE_TOOL.ELLIPSE) 'circle
                End If
            End If

        End If

    End Sub



    ''' <summary>
    ''' Pasa un sprite de la lista (proyecto) al editor
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="sprite"></param>
    ''' <remarks></remarks>
    Private Sub aSpritesetControl_SelectedSpriteChanged(ByVal index As System.Int32, ByVal sprite As SpriteMSX)


        If Not aSpritesetControl.WorkMode = TilesetControl.CONTROL_MODE.SELECTER Then
            SelectTool(SPRSET_TOOLBOX.SELECTER)
        Else
            EditSprite(sprite)
        End If

    End Sub



    Private Sub SpritesetComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles TilesetComboBox.SelectedIndexChanged

        Dim tmpID As Integer = Me.Project.SpriteSets.GetIDFromIndex(SpritesetComboBox.SelectedIndex)

        If Not Me._spritesetSelected.ID = tmpID Then
            SelectSpriteset(tmpID)
        End If

    End Sub



    Private Sub setMatrixCoordinates(ByVal xpos As Integer, ByVal ypos As Integer)
        PosX_Label.Text = CStr(xpos + 1)
        PosY_Label.Text = CStr(ypos + 1)
    End Sub



    Private Sub SpriteBitmapChanged(ByVal aBitmap As Bitmap)
        spritePreviewPicture.Image = aBitmap
    End Sub



    'Private Sub setSpriteInfoChanged(ByVal name As String, ByVal patternNumber As Integer)
    '    Me.SpriteName.Text = name
    '    Me.SpriteNumberLabel.Text = CStr(patternNumber)
    'End Sub


    Private Sub NewSpritesetButton_Click(sender As System.Object, e As System.EventArgs) Handles NewSpritesetButton.Click
        NewSpriteset()
    End Sub

    Private Sub LoadSpritesetButton_Click(sender As System.Object, e As System.EventArgs) Handles LoadSpritesetButton.Click
        LoadSpritesetDialog()
    End Sub

    Private Sub SaveSpritesetButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveSpritesetButton.Click
        SaveSpritesetDialog()
    End Sub

    Private Sub SaveMSXBASICbinaryButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveMSXBASICbinaryButton.Click
        SaveMSXBASICGraphic()
    End Sub

    Private Sub SaveBitmapButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveBitmapButton.Click
        SaveSpritesBitmap()
    End Sub

    Private Sub CopySpritesetButton_Click(sender As System.Object, e As System.EventArgs) Handles CopySpritesetButton.Click
        CopySpriteset()
    End Sub

    Private Sub ConfigSpritesetButton_Click(sender As System.Object, e As System.EventArgs) Handles ConfigSpritesetButton.Click
        ConfigSpriteset()
    End Sub

    Private Sub DeleteTilesetButton_Click(sender As System.Object, e As System.EventArgs) Handles DeleteTilesetButton.Click
        DeleteSpriteset()
    End Sub

    'Private Sub EditPaletteButton_Click(sender As System.Object, e As System.EventArgs) Handles EditPaletteButton.Click
    '    EditPalette()
    'End Sub

    Private Sub SelectTileButton_Click(sender As System.Object, e As System.EventArgs) Handles SelectTileButton.Click
        SelectTool(SPRSET_TOOLBOX.SELECTER)
    End Sub

    Private Sub ExchangeTilesButton_Click(sender As System.Object, e As System.EventArgs) Handles ExchangeTilesButton.Click
        SelectTool(SPRSET_TOOLBOX.EXCHANGE)
    End Sub

    Private Sub CopyTileButton_Click(sender As System.Object, e As System.EventArgs) Handles CopyTileButton.Click
        SelectTool(SPRSET_TOOLBOX.COPY)
    End Sub


    ' eventos de las herramientas de edicion #############################################################
    Private Sub ClearSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSpriteButton.Click
        Me.SpriteContainer.ClearSprite()
    End Sub

    Private Sub InvertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertButton.Click
        Me.SpriteContainer.Invert()
    End Sub


    Private Sub FlipHorizontalButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipHorizontalButton.Click
        Me.SpriteContainer.FlipHorizontal()
    End Sub

    Private Sub FlipVerticalButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipVerticalButton.Click
        Me.SpriteContainer.FlipVertical()
    End Sub

    Private Sub RotateLeftButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateLeftButton.Click
        Me.SpriteContainer.RotateLeft()
    End Sub

    Private Sub RotateRightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateRightButton.Click
        Me.SpriteContainer.RotateRight()
    End Sub

    Private Sub Move2LeftButton_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Move2LeftButton.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.SpriteContainer.MoveLeft(True)
        Else
            Me.SpriteContainer.MoveLeft(False)
        End If
    End Sub

    Private Sub Move2RightButton_MouseDownk(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Move2RightButton.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.SpriteContainer.MoveRight(True)
        Else
            Me.SpriteContainer.MoveRight(False)
        End If
    End Sub

    Private Sub Move2UpButton_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Move2UpButton.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.SpriteContainer.MoveUp(True)
        Else
            Me.SpriteContainer.MoveUp(False)
        End If
    End Sub

    Private Sub Move2downButton_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles Move2downButton.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.SpriteContainer.MoveDown(True)
        Else
            Me.SpriteContainer.MoveDown(False)
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As System.Object, e As System.EventArgs) Handles UpdateButton.Click
        UpdateSprite()
    End Sub
    ' END eventos de las herramientas de edicion #############################################################



    Private Sub toolbox_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles SquareButton.MouseDown, LineButton.MouseDown, PencilButton.MouseDown, CircleButton.MouseDown, FillButton.MouseDown
        If e.Button = MouseButtons.Right Then
            selectSpriteEditorTool(translateIDtool(sender.Tag, True))
        Else
            selectSpriteEditorTool(translateIDtool(sender.Tag, False))
        End If
    End Sub


    Private Sub UndoButton_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles UndoButton.MouseDown
        If e.Button = MouseButtons.Right Then
            Me.SpriteContainer.SetRedo()
        Else
            Me.SpriteContainer.SetUndo()
        End If
    End Sub


    ' END events ################################################################################################################################################################################ 




    ' IEditorContainer  ################################################################################################################################################################################ 





    Public Sub Close() Implements GUI.Controls.IEditorContainer.Close

        RemoveHandler Me.ParentForm.KeyDown, AddressOf Editor_KeyDown

        Me.Dispose()

    End Sub



    Private Sub spritePreviewPicture_MouseMove(sender As Object, e As MouseEventArgs) Handles spritePreviewPicture.MouseMove
        Dim spritePicture As PictureBox = sender
        Dim aSprite As SpriteMSX

        If e.Button = 0 Then Exit Sub

        aSprite = Me.SpriteContainer.GetSprite().Clone()  ' recoge el sprite del contenedor
        aSprite.Name = Me.SpriteName.Text

        Dim data As New DataObject
        data.SetData("SpriteMSX", aSprite)

        spritePicture.DoDragDrop(data, DragDropEffects.Move)
    End Sub



    Private Sub spritePreviewPicture_DragEnter(sender As Object, e As DragEventArgs) Handles spritePreviewPicture.DragEnter
        If e.Data.GetDataPresent("SpriteMSX") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub UpdateSpriteButton_Click(sender As Object, e As EventArgs) Handles UpdateSpriteButton.Click
        UpdateSprite()
    End Sub



    'Private Sub SpriteNumberTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)

    '    Dim aSprite As SpriteMSX = Me.SpriteContainer.GetSprite()
    '    Dim value As Integer
    '    Dim MaxLength As Integer

    '    If Not IsNumeric(SpriteNumberTextBox.Text) Then
    '        SpriteNumberTextBox.Text = CStr(aSprite.Index)

    '    Else
    '        value = CInt(SpriteNumberTextBox.Text)

    '        If Not value = aSprite.Index Then
    '            If aSprite.Size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
    '                MaxLength = 255
    '            Else
    '                MaxLength = 63
    '            End If

    '            If value < 0 Or value > MaxLength Then
    '                SpriteNumberTextBox.Text = CStr(aSprite.Index)
    '            Else
    '                SpriteNumberTextBox.Text = CStr(value)
    '            End If
    '        End If

    '    End If

    'End Sub



    Private Sub SpriteName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SpriteName.Validating
        Me.SpriteContainer.SpriteName = SpriteName.Text
    End Sub



    Private Sub CopySpriteButton_Click(sender As Object, e As EventArgs) Handles CopySpriteButton.Click
        CopyToClipboard()
    End Sub


    Private Sub PasteSpriteButton_Click(sender As Object, e As EventArgs) Handles PasteSpriteButton.Click
        PasteFromClipboard()
    End Sub


End Class
