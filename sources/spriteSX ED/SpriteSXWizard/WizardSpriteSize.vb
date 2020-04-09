Public Class WizardSpriteSize

    Public Event SetSize(ByVal _size As Integer)


    Private Sub EightButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EightButton.Click
        RaiseEvent SetSize(1)
    End Sub

    Private Sub SixteenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SixteenButton.Click
        RaiseEvent SetSize(2)
    End Sub
End Class
