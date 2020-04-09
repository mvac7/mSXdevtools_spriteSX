Public Class SpriteList

    Private sprites As New SortedList
    Public spritesIndex As New ArrayList
    Private spritesPictures As New SortedList

    Public ReadOnly Property Values() As System.Collections.ICollection
        Get
            Return sprites.Values
        End Get
    End Property


    Public Sub Add(ByVal id As Integer, ByVal sprite As SpriteMSX, ByVal spriteItem As SpriteItemList)
        Me.sprites.Add(id, sprite)
        Me.spritesIndex.Add(id)
        Me.spritesPictures.Add(id, spriteItem)
    End Sub


    Public Sub Remove(ByVal id As Integer)
        If Me.sprites.ContainsKey(id) Then
            Dim spriteItem As SpriteItemList
            spriteItem = Me.spritesPictures.Item(id)
            spriteItem.Dispose()
            Me.spritesPictures.Remove(id)
            Me.sprites.Remove(id)
            Me.spritesIndex.Remove(id)
            reOrder()
        End If
    End Sub


    Public Sub Clear()
        Me.sprites.Clear()
        Me.spritesIndex.Clear()

        For Each spriteItem As SpriteItemList In Me.spritesPictures.Values
            spriteItem.Dispose()
        Next
        Me.spritesPictures.Clear()
    End Sub


    Public Function Item(ByVal id As Integer) As SpriteMSX
        Return sprites.Item(id)
    End Function


    Public Function GetSpriteByIndex(ByVal number As Integer) As SpriteMSX
        'Dim aSpriteMSX As SpriteMSX
        Dim id As Integer = spritesIndex.Item(number)
        Return sprites.Item(id)
    End Function


    Public Function GetSpritePicture(ByVal id As Integer) As SpriteItemList
        Return spritesPictures.Item(id)
    End Function


    Public Function IndexOf(ByVal id As Integer) As Integer
        Return spritesIndex.IndexOf(id)
    End Function


    Public Function Count() As Integer
        Return spritesIndex.Count
    End Function


    Public Sub Update(ByVal sprite As SpriteMSX)
        Dim newOrder As Integer = 0
        'Dim oldSprite As SpriteMSX
        If Me.sprites.ContainsKey(sprite.ID) Then
            newOrder = Me.sprites.Item(sprite.ID).order
            'newOrder = oldSprite.order
            sprite.order = newOrder
            Me.sprites.Item(sprite.ID) = sprite
            Me.spritesPictures.Item(sprite.ID).Image = sprite.aBitmap.Clone
        End If

    End Sub


    Public Sub RefreshPicture(ByVal id As Integer)
        Me.spritesPictures.Item(id).Image = Me.sprites.Item(id).aBitmap.Clone
    End Sub

    Public Function Contains(ByVal id As Integer) As Boolean
        Return sprites.ContainsKey(id)
    End Function


    Public Sub ChangeOrder(ByVal oldPosition, ByVal newPosition)
        Dim id As Integer = spritesIndex.Item(oldPosition)
        Me.spritesIndex.RemoveAt(oldPosition)
        Me.spritesIndex.Insert(newPosition, id)
        reOrder()
    End Sub


    Private Sub reOrder()
        For Each sprite As SpriteMSX In Me.sprites.Values
            sprite.order = Me.spritesIndex.IndexOf(sprite.ID)
        Next
    End Sub

End Class
