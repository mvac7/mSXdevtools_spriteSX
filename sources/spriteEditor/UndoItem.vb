Public Class UndoItem

    Public spriteLines As MatrixData
    Public colorValues(15) As Byte
    Public ORvalues(15) As Boolean

    Public Sub New(ByVal _spriteLines As MatrixData, ByVal _colorValues() As Byte, ByVal _ORvalues() As Boolean)
        Me.spriteLines = _spriteLines.Clone
        Me.colorValues = _colorValues.Clone
        Me.ORvalues = _ORvalues.Clone
    End Sub

End Class
