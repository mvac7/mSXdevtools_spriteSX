Public Class AboutForm

    Private Const URL_GPL As String = "http://www.gnu.org/licenses/gpl-3.0-standalone.html"
    Private Const URL_303bcn As String = "http://aorante.blogspot.com.es/"
    'System.Diagnostics.Process.Start(Me.URL_GPL)

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'App_version = version

        Me.versionLabel.Text = "v " + My.Application.Info.Version.ToString + "b"
        Me.copyleftLabel.Text = My.Application.Info.Copyright

    End Sub



    Private Sub licenseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles licenseButton.Click
        System.Diagnostics.Process.Start(URL_GPL)
    End Sub


    'Private Sub link303bcnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles link303bcnButton.Click
    '    System.Diagnostics.Process.Start(URL_303bcn)
    'End Sub


    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        System.Diagnostics.Process.Start(URL_303bcn)
    End Sub
End Class