Imports System.Windows.Forms

Public Class WizardSpritePrjName

    Public Event SetName(ByVal namePrj As String)

    Private Sub Next1Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Next1Button.Click
        RaiseEvent SetName(Me.NameTextBox.Text)
    End Sub


    Private Sub NameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            RaiseEvent SetName(Me.NameTextBox.Text)
        End If
    End Sub
End Class
