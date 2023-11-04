Public Class UndoItem

    Public PatternLines As MatrixData
    Public ColorLines(15) As Byte
    Public ICLines(15) As Boolean
    Public CCLines(15) As Boolean
    Public ECLines(15) As Boolean

    Public Sub New(ByVal patternValues As MatrixData, ByVal colorValues() As Byte, ByVal ICvalues() As Boolean, ByVal CCvalues() As Boolean, ByVal ECvalues() As Boolean)
        Me.PatternLines = patternValues.Clone
        Me.ColorLines = colorValues.Clone
        Me.ICLines = ICvalues.Clone
        Me.CCLines = CCvalues.Clone
        Me.ECLines = ECvalues.Clone
    End Sub

End Class
