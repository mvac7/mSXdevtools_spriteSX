Imports System.IO
Imports mSXdevtools.GUI.Controls




Public Class mainWin

    Private AppConfig As Config

    Private anEditor As mSXdevtools.spriteEditor.SpriteEditor

    Private Const URL_GPL3 As String = "https://www.gnu.org/licenses/gpl-3.0.html"
    Private Const License As String = "GNU General Public License v3"

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.Text = My.Application.Info.AssemblyName

        Me.AppConfig = New Config() 'Application.StartupPath + Path.DirectorySeparatorChar + ConfigFileName

        Dim gradientBG As New Bitmap(Me.Width, Me.Height)
        Dim newBrush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(0, gradientBG.Height), Color.Gainsboro, Color.SlateGray)
        Dim oneGraphic As Graphics = Graphics.FromImage(gradientBG)
        oneGraphic.FillRectangle(newBrush, New RectangleF(0, 0, gradientBG.Width, gradientBG.Height))
        Me.BackgroundImage = gradientBG

    End Sub



    Private Sub mainWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim lastProjects As LastProjectsList

        Me.anEditor = New spriteEditor.SpriteEditor(Me.AppConfig)
        Me.anEditor.Name = "SpriteEditor"

        Me.AppIconPictureBox.Image = Me.anEditor.AboutIcon()
        Me.AppLogoPictureBox.Image = Me.anEditor.AboutLogo()


        If Me.AppConfig.Load() Then
            lastProjects = Me.AppConfig.GetRecentProjectList(My.Application.Info.AssemblyName)
            Me.InitLauncher1.SetProjectsList(lastProjects)

        Else
            ' if not exist config file
            ShowLicense()

        End If

        Me.LicenseLinkLabel.Text = License
        Me.versionLabel.Text = "v " + My.Application.Info.Version.ToString + "b" 'String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.copyleftLabel.Text = My.Application.Info.Copyright
        'Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.DescriptionLabel.Text = My.Application.Info.Description

    End Sub



    Private Sub InitLauncher1_SetNew() Handles InitLauncher1.SetNew
        LaunchApp("")
    End Sub



    Private Sub InitLauncher1_SetLoad() Handles InitLauncher1.SetLoad
        Dim filePath As String

        filePath = LoadFile()

        If Not filePath = "" Then
            LaunchApp(filePath)
        End If

    End Sub



    Private Sub InitLauncher1_SetFile(ByVal filePath As System.String) Handles InitLauncher1.SetFile
        LaunchApp(filePath)
    End Sub



    Private Sub LaunchApp(ByVal filePath As String)

        Dim anEditorWin As mSXdevtools.GUI.Controls.EditorWin

        Me.Hide()
        Application.DoEvents()

        If filePath IsNot "" Then
            anEditorWin = New mSXdevtools.GUI.Controls.EditorWin(Me.AppConfig, anEditor, filePath)
        Else
            anEditorWin = New mSXdevtools.GUI.Controls.EditorWin(Me.AppConfig, anEditor)
        End If

        anEditorWin.Icon = Me.Icon
        'anEditorWin.MinimumSize = New System.Drawing.Size(680, 640)
        anEditorWin.Size = New System.Drawing.Size(680, 670)
        'anEditorWin.MaximizeBox = True
        anEditorWin.StartPosition = FormStartPosition.CenterScreen
        anEditorWin.FormBorderStyle = FormBorderStyle.FixedSingle
        anEditorWin.Show()

        Application.DoEvents()

        Me.Close()

    End Sub



    ''' <summary>
    ''' Muestra la ventana de dialogo para la carga de un proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Function LoadFile() As String

        'Me.OpenFileDialog1.DefaultExt = "*.*"
        Me.OpenFileDialog1.Filter = mSXdevtools.spriteEditor.SpriteEditor.LoadTypes
        Me.OpenFileDialog1.InitialDirectory = Me.AppConfig.PathItemSprite.Path
        Me.OpenFileDialog1.FileName = ""

        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return OpenFileDialog1.FileName
        Else
            Return ""
        End If

    End Function



    Private Sub ShowLicense()

        Dim aboutWinObject As New mSXdevtools.GUI.Controls.AboutWin()
        aboutWinObject.SetIcon = Me.anEditor.AboutIcon()
        aboutWinObject.SetLogo = Me.anEditor.AboutLogo()
        aboutWinObject.StartPosition = FormStartPosition.CenterScreen
        aboutWinObject.ShowDialog()

        'Dim LicenseDialog As New LicenseWin(True)
        'If LicenseDialog.ShowDialog(Me) = DialogResult.Cancel Then
        '    Me.Close()
        'End If
    End Sub


    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub


    Private Sub LicenseLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LicenseLinkLabel.LinkClicked
        System.Diagnostics.Process.Start(URL_GPL3)  'open default system WEB browser
    End Sub

End Class