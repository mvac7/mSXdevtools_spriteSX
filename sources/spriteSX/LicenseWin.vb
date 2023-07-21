Imports System.Windows.Forms

Public Class LicenseWin

    Private Const URL_GPL As String = "http://www.gnu.org/licenses/gpl-3.0-standalone.html"

    Public Sub New(ByVal isCheck As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not isCheck Then
            Me.OK_Button.Visible = False
            Me.Cancel_Button.Text = "Ok"
            Me.Cancel_Button.BackColor = Color.PaleGreen
        End If


    End Sub





    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub LicenseWin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.AppNameLabel.Text = My.Application.Info.ProductName
        Me.versionLabel.Text = "v " + My.Application.Info.Version.ToString + "b" 'String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.copyleftLabel.Text = My.Application.Info.Copyright
        Me.DescriptionLabel.Text = My.Application.Info.Description
    End Sub


    Private Sub GPLButton_Click(sender As Object, e As EventArgs) Handles GPLButton.Click
        System.Diagnostics.Process.Start(URL_GPL)
    End Sub

End Class
