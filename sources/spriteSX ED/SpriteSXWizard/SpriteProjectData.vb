Public Class SpriteProjectData

    Public Name As String = ""
    Public Size As Integer = 0
    Public Mode As Integer = 0

    Public Sub New(ByVal name As String, ByVal size As Integer, ByVal mode As Integer)
        Me.Name = name
        Me.Size = size
        Me.Mode = mode
    End Sub

End Class
