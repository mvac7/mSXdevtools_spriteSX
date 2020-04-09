Public Class WizardConfirm

    Public Event SetData(ByVal value As Boolean)

    Public WriteOnly Property ProjectName() As String
        Set(ByVal value As String)
            NameLabel.Text = "1. " + value
        End Set
    End Property

    Public WriteOnly Property ProjectSize() As String
        Set(ByVal value As String)
            SizeLabel.Text = "2. " + value
        End Set
    End Property

    Public WriteOnly Property ProjectMode() As String
        Set(ByVal value As String)
            ColorLabel.Text = "3. " + value
        End Set
    End Property


    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        RaiseEvent SetData(True)
    End Sub

    Private Sub WizardConfirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ActiveControl = Me.OkButton
    End Sub
End Class
