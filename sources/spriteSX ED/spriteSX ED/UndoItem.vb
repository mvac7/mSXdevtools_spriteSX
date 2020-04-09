Public Class UndoItem

    Public pixelData() As Boolean
    Public colorValues(15) As Byte
    Public ORvalues(15) As Boolean

    Public Sub New(ByVal _pixelData() As Boolean, ByVal _colorValues() As Byte, ByVal _ORvalues() As Boolean)
        Me.pixelData = _pixelData.Clone
        Me.colorValues = _colorValues.Clone
        Me.ORvalues = _ORvalues.Clone
    End Sub

End Class
