Public Class SizedStack

    Private data As New ArrayList

    Private _size As Integer

    Public ReadOnly Property Count() As Integer
        Get
            Return data.Count
        End Get
    End Property

    Public Sub Clear()
        data.Clear()
    End Sub

    Public Sub New(ByVal size As Integer)
        Me._size = size - 1
    End Sub

    Public Sub Push(ByVal item As Object)
        If data.Count > Me._size Then
            data.RemoveAt(0)
        End If
        data.Add(item)
    End Sub

    Public Function Pop() As Object
        Dim oitem As Object = data.Item(data.Count - 1)
        data.RemoveAt(data.Count - 1)
        Return oitem
    End Function
End Class
