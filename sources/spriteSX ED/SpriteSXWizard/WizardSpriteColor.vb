Public Class WizardSpriteColor

    Public Event SetMode(ByVal _mode As Integer)


    Private Sub OneColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneColorButton.Click
        RaiseEvent SetMode(1)
    End Sub

    Private Sub MulticolorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MulticolorButton.Click
        RaiseEvent SetMode(2)
    End Sub
End Class
