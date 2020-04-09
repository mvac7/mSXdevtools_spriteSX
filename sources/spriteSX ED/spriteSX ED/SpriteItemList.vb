Public Class SpriteItemList

    Public Event SelectSprite(ByVal id As Integer)
    Public Event EditSprite(ByVal id As Integer)
    Public Event CopySprite(ByVal id As Integer)
    Public Event DeleteSprite(ByVal id As Integer)

    Public WriteOnly Property image() As System.Drawing.Bitmap
        Set(ByVal value As System.Drawing.Bitmap)
            'Me.spritePicture.Image = value
            Me.BackgroundImage = value
        End Set
    End Property

    'Public WriteOnly Property ItemColor() As System.Drawing.Color
    '    Set(ByVal value As System.Drawing.Color)
    '        'Me.spritePicture.BackColor = value
    '        Me.BackColor = value
    '    End Set
    'End Property

    Public WriteOnly Property ToolTip() As String
        Set(ByVal value As String)
            Me.ToolTip1.SetToolTip(Me, value)
        End Set
    End Property

    Private Sub spritePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Click
        RaiseEvent SelectSprite(CInt(Me.Name))
    End Sub

    Private Sub spritePicture_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        RaiseEvent EditSprite(CInt(Me.Name))
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RaiseEvent CopySprite(CInt(Me.Name))
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        RaiseEvent DeleteSprite(CInt(Me.Name))
    End Sub

    Public Sub ToSelect()
        Me.BackColor = Color.Orange
    End Sub

    Public Sub ToUnselect()
        Me.BackColor = Color.Gray
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        RaiseEvent EditSprite(CInt(Me.Name))
    End Sub


End Class
