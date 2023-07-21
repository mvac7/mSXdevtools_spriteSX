Public Class ConfigSpritesetDialog

    'Private _size As Integer = 0
    'Private _mode As Integer = 0

    Private _paletteID As Integer '= 0

    'Private _foregroundColor As Byte = 15
    'Private _backgroundColor As Byte = 0

    'Private isProject As Boolean = False

    Private AppConfig As Config

    Private Project As tMSgfXProject

    Private spritesetID As Integer = -1


    Public DialogType As DIALOG_TYPE

    Private PageState As PAGE

    Public Enum DIALOG_TYPE As Integer
        NEW_PROJECT
        NEW_SPRITESET
        UPDATE_SPRITESET
    End Enum



    Private Enum PAGE As Integer
        PROJECT_CONFIG
        SPRITESET_CONFIG
    End Enum




    Public Overloads Property Name() As String
        Get
            Return Me.SpritesetDataUC.Name
        End Get
        Set(value As String)
            Me.SpritesetDataUC.Name = value
        End Set
    End Property



    Public ReadOnly Property SpriteSize() As SpriteMSX.SPRITE_SIZE
        Get
            Return Me.SpritesetDataUC.SpriteSize
        End Get
    End Property


    Public ReadOnly Property SpriteMode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me.SpritesetDataUC.SpriteMode
        End Get
    End Property


    Public ReadOnly Property PaletteID() As Integer
        Get
            Return Me.SpritesetDataUC.PaletteID
        End Get
    End Property


    Public ReadOnly Property InkColor() As Byte
        Get
            Return Me.SpritesetDataUC.InkColor
        End Get
    End Property


    Public ReadOnly Property BackgroundColor() As Byte
        Get
            Return Me.SpritesetDataUC.BackgroundColor
        End Get
    End Property



    ''' <summary>
    ''' New Spriteset
    ''' </summary>
    ''' <param name="_config"></param>
    ''' <param name="_project"></param>
    Public Sub New(ByRef _config As Config, ByRef _project As tMSgfXProject, ByVal spritesetName As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Back_Button.Visible = False

        Me.Name = spritesetName
        'Me._size = 1
        'Me._mode = 0

        Me.AppConfig = _config
        Me.Project = _project

        Me._paletteID = Me.Project.Palettes.GetIDFromIndex(0)

        Me.DialogType = DIALOG_TYPE.NEW_SPRITESET

    End Sub



    ''' <summary>
    ''' New Project (project info + project config)
    ''' </summary>
    ''' <param name="_config"></param>
    ''' <param name="_project"></param>
    Public Sub New(ByRef _config As Config, ByRef _project As tMSgfXProject)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Name = "spriteset00"

        Me.AppConfig = _config
        Me.Project = _project

        Me._paletteID = Me.Project.Palettes.GetIDFromIndex(0)

        Me.Title_Label.Text = "New Spriteset Project"

        'Me.isProject = True

        Me.Cancel_Button.Visible = False
        'Me.Ok_Button.Location = New System.Drawing.Point(368, 297)
        'Me.Back_Button.Location = New Point(Me.Ok_Button.Location.X - 86, Me.Back_Button.Location.Y)

        Me.ProjectInfoUserControl1.Dock = DockStyle.Top

        Me.ProjectInfoUserControl1.ProjectName = Me.Project.Info.ProjectName

        Me.ProjectInfoUserControl1.SubProjectName = Me.Project.Info.Name
        Me.ProjectInfoUserControl1.Version = Me.Project.Info.Version
        Me.ProjectInfoUserControl1.Group = Me.Project.Info.Group

        If Me.Project.Info.Author = "" Then
            Me.ProjectInfoUserControl1.Author = _config.Author
        Else
            Me.ProjectInfoUserControl1.Author = Me.Project.Info.Author
        End If

        Me.ProjectInfoUserControl1.Description = Me.Project.Info.Description
        Me.ProjectInfoUserControl1.StartDate = New DateTime(Me.Project.Info.StartDate).ToShortDateString
        Me.ProjectInfoUserControl1.LastUpdate = New DateTime(Me.Project.Info.LastUpdate).ToShortDateString

        Me.DialogType = DIALOG_TYPE.NEW_PROJECT

        ShowProjectForm(PAGE.PROJECT_CONFIG)

    End Sub



    ''' <summary>
    ''' Update spriteset config
    ''' </summary>
    ''' <param name="_config"></param>
    ''' <param name="_project"></param>
    ''' <param name="_spritesetID"></param>
    Public Sub New(ByRef _config As Config, ByRef _project As tMSgfXProject, ByVal _spritesetID As Integer) 'ByVal setName As String, ByVal spriteSize As SpriteMSX.SPRITE_SIZE, ByVal spriteMode As SpriteMSX.SPRITE_MODE, ByVal _palID As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Back_Button.Visible = False

        Me.AppConfig = _config
        Me.Project = _project
        Me.spritesetID = _spritesetID

        Me.DialogType = DIALOG_TYPE.UPDATE_SPRITESET

    End Sub



    Private Sub ConfigSpritesetDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim spriteset As SpritesetMSX

        Me.Size = New Size(Me.Size.Width, 470)

        If Me.DialogType = DIALOG_TYPE.UPDATE_SPRITESET Then
            spriteset = Me.Project.SpriteSets.GetSpritesetByID(Me.spritesetID)
            SpritesetDataUC.Initialize(Me.AppConfig, Me.Project, spriteset, True)
        Else
            SpritesetDataUC.Initialize(Me.AppConfig, Me.Project, Nothing, False)
        End If

    End Sub



    Private Sub Ok_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok_Button.Click

        If Me.PageState = PAGE.PROJECT_CONFIG Then    'Ok_Button.ImageIndex = 1 Then
            ShowProjectForm(PAGE.SPRITESET_CONFIG)
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub



    Private Sub Back_Button_Click(sender As Object, e As EventArgs) Handles Back_Button.Click
        ShowProjectForm(PAGE.PROJECT_CONFIG)
    End Sub



    Public Function GetProjectInfo() As ProjectInfo

        Dim projectInfo As New ProjectInfo

        projectInfo.Name = Me.ProjectInfoUserControl1.SubProjectName
        projectInfo.Version = Me.ProjectInfoUserControl1.Version
        projectInfo.ProjectName = Me.ProjectInfoUserControl1.ProjectName
        projectInfo.Group = Me.ProjectInfoUserControl1.Group
        projectInfo.Author = Me.ProjectInfoUserControl1.Author
        projectInfo.Description = Me.ProjectInfoUserControl1.Description

        Return projectInfo

    End Function



    Private Sub ShowProjectForm(ByVal newPage As PAGE)

        Me.PageState = newPage

        If newPage = PAGE.PROJECT_CONFIG Then
            Me.ProjectInfoUserControl1.Visible = True
            Me.SpritesetDataUC.Visible = False
            Me.Back_Button.Visible = False
            Me.Ok_Button.Text = "Next" 'ImageIndex = 1
            Me.Ok_Button.Image = Global.mSXdevtools.spriteEditor.My.Resources.Resources.icon_Next
        Else
            Me.ProjectInfoUserControl1.Visible = False
            Me.SpritesetDataUC.Visible = True
            Me.Back_Button.Visible = True
            Me.Ok_Button.Text = "Ok" 'ImageIndex = 0
            Me.Ok_Button.Image = Nothing
        End If

    End Sub


End Class