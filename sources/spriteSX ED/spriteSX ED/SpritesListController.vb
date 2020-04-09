''' <summary>
''' Control que visualiza y gestiona los sprites de un proyecto.
''' </summary>
''' <remarks></remarks>
Public Class SpritesListController

    Public Const MAX_8xSPRITES As Integer = 255
    Public Const MAX_16xSPRITES As Integer = 63

    Private SpriteSelectedIcon As SpriteItemList

    Public sprites As New SpriteList

    'Public ProjectName As String
    'Name from control
    Public Version As String
    Public Author As String
    Public Group As String
    Public Description As String
    Public StartProjectDate As Long
    Public LastUpdate As Long

    Public ProjectSize As SpriteMSX.SPRITE_SIZE '= SpriteMSX.SPRITE_SIZE.INIT     ' 1=8x8,  2=16x16 
    Public ProjectMode As SpriteMSX.SPRITE_MODE '= SpriteMSX.SPRITE_MODE.MONO

    Public Event SelectedSpriteChanged(ByVal sprite As SpriteMSX)

    Public Event TotalSpriteChanged(ByVal number As Integer)

    'Private PaletteColors As PaletteMSX



    ''' <summary>
    ''' Numero total de sprites que contiene el proyecto.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Count() As Integer
        Get
            Return sprites.Count
        End Get
    End Property


    Public ReadOnly Property MaximumSPRITES() As Integer
        Get
            If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                Return MAX_16xSPRITES
            Else
                Return MAX_8xSPRITES
            End If
        End Get
    End Property

    ''' <summary>
    ''' Añade un nuevo sprite al control
    ''' </summary>
    ''' <param name="aSprite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewSprite(ByVal aSprite As SpriteMSX) As Boolean
        'Dim spriteOrder As Integer
        Dim spriteItem As SpriteItemList = New SpriteItemList


        ' controla el limite de sprites
        If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 And Me.Count > MAX_16xSPRITES Then
            Return False
        ElseIf Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 And Me.Count > MAX_8xSPRITES Then
            Return False
        End If

        aSprite.refresh() ' genera el bitmap (aunque lo proporciona el control del editor, se utiliza para corregir el problema de centrado en la lista en el caso de los sprites de 8x8)

        Me.SpriteListPanel.VerticalScroll.Value = 0

        Me.SuspendLayout()

        spriteItem.Name = aSprite.ID
        spriteItem.TabStop = False
        spriteItem.image = aSprite.aBitmap.Clone
        'spritePicture.BackColor = System.Drawing.Color.Gray
        'spritePicture.Dock = System.Windows.Forms.DockStyle.Top
        'spriteItem.MaximumSize = New System.Drawing.Size(34, 36)
        'spritePicture.Padding = New System.Windows.Forms.Padding(2)

        Me.SpriteListPanel.Controls.Add(spriteItem)

        spriteItem.Size = New System.Drawing.Size(36, 36)

        AddHandler spriteItem.EditSprite, AddressOf Me.EditSprite
        AddHandler spriteItem.SelectSprite, AddressOf Me.SelectSprite
        AddHandler spriteItem.CopySprite, AddressOf Me.Copy
        AddHandler spriteItem.DeleteSprite, AddressOf Me.Delete

        Me.ResumeLayout(False)

        Me.sprites.Add(aSprite.ID, aSprite, spriteItem)

        RaiseEvent TotalSpriteChanged(Me.sprites.Count)

        aSprite.order = Me.sprites.IndexOf(aSprite.ID)

        spriteItem.Location = New System.Drawing.Point(0, aSprite.order * 37)
        spriteItem.ToolTip = aSprite.order.ToString + ">" + aSprite.name

        Return True

    End Function


    ''' <summary>
    ''' Actualiza un sprite ya existente
    ''' </summary>
    ''' <param name="aSprite"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSprite(ByVal aSprite As SpriteMSX)
        Dim spriteItem As SpriteItemList

        aSprite.refresh() ' genera el bitmap (aunque lo proporciona el control del editor, se utiliza para corregir el problema de centrado en la lista en el caso de los sprites de 8x8)

        Me.sprites.Update(aSprite)

        spriteItem = Me.sprites.GetSpritePicture(aSprite.ID)
        spriteItem.ToolTip = aSprite.order.ToString + ">" + aSprite.name

    End Sub


    ''' <summary>
    ''' Actualiza las imagenes de los sprites, con los colores de una nueva paleta.
    ''' </summary>
    ''' <param name="PaletteColors"></param>
    ''' <remarks></remarks>
    Public Sub RefreshPalette(ByVal PaletteColors As MSXpalette)

        For Each aSprite As SpriteMSX In Me.sprites.Values
            aSprite.PaletteData = PaletteColors
            aSprite.refresh()
            Me.sprites.RefreshPicture(aSprite.ID)
        Next

        Me.SpriteListPanel.Refresh()

    End Sub


    ''' <summary>
    ''' borra todos los datos del proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clear()

        Me.Name = ""
        Me.Version = ""
        Me.Author = ""
        Me.Description = ""
        Me.Group = ""
        Me.StartProjectDate = DateTime.Today.Ticks
        Me.LastUpdate = DateTime.Today.Ticks

        Me.sprites.Clear()
        RaiseEvent TotalSpriteChanged(Me.sprites.Count)

        Me.SpriteListPanel.Refresh()

    End Sub


    ''' <summary>
    ''' Selecciona un item de la lista.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub SelectItem(ByVal id As Integer)

        Dim spriteItem As SpriteItemList = Me.sprites.GetSpritePicture(id)

        If Not SpriteSelectedIcon Is Nothing Then
            Me.SpriteSelectedIcon.ToUnselect()
        End If

        spriteItem.ToSelect()
        Me.SpriteSelectedIcon = spriteItem

    End Sub


    ''' <summary>
    ''' Selecciona un item de la lista y ajusta el scroll para que se muestre.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub ShowItem(ByVal id As Integer)
        SelectItem(id)
        Me.SpriteListPanel.ScrollControlIntoView(Me.SpriteSelectedIcon) ' situa el scroll para que se muestre el item seleccionado
    End Sub


    ''' <summary>
    ''' Accion para mandar al editor un sprite, lanzada desde el sprite (SpriteItemList).
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub EditSprite(ByVal id As Integer)
        Dim aSprite As SpriteMSX
        aSprite = sprites.Item(id)

        RaiseEvent SelectedSpriteChanged(aSprite)

    End Sub


    ''' <summary>
    ''' Accion de seleccion de un sprite, lanzada desde el sprite (SpriteItemList).
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub SelectSprite(ByVal id As Integer)
        SelectItem(id)
    End Sub


    ''' <summary>
    ''' Accion de copia de un sprite, lanzada desde el menu contextual del sprite (SpriteItemList).
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub Copy(ByVal id As Integer)
        Dim newSprite As SpriteMSX
        Dim result As Boolean

        If Me.sprites.Contains(id) Then
            newSprite = Me.sprites.Item(id).copy
            result = AddNewSprite(newSprite)
            'RefreshList()
            If result = True Then
                ShowItem(newSprite.ID)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Accion de borrado de un sprite, lanzada desde el menu contextual del sprite (SpriteItemList).
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub Delete(ByVal id As Integer)
        DeleteSprite(id)

        Me.SpriteSelectedIcon = Nothing

        Me.SpriteListPanel.Refresh()
    End Sub


    'Private Sub DeleteSpriteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Me.SpriteSelectedIcon Is Nothing Then

    '        MsgBox("Please. Select a sprite to delete.", MsgBoxStyle.Information, "Alert")

    '    Else

    '        DeleteSprite(Me.SpriteSelectedIcon.Name)

    '        Me.SpriteSelectedIcon = Nothing
    '        'Me.SpriteSelected = ""

    '        Me.SpriteListPanel.Refresh()
    '    End If
    'End Sub


    ''' <summary>
    ''' Elimina un sprite de la lista
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub DeleteSprite(ByVal id As Integer)
        If Me.sprites.Contains(id) Then
            Me.sprites.Remove(id)
            RaiseEvent TotalSpriteChanged(Me.sprites.Count)
            RefreshList()
        End If
    End Sub


    ''' <summary>
    ''' Decrementa una posición del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OrderDecreases()

        If Me.SpriteSelectedIcon Is Nothing Then
            Exit Sub
        End If

        Dim id As Integer = CInt(Me.SpriteSelectedIcon.Name)
        Dim spritenumber As Integer = Me.sprites.IndexOf(id)

        If spritenumber > 0 Then
            Me.sprites.ChangeOrder(spritenumber, spritenumber - 1)
            'reOrder()
            RefreshList()
        End If

    End Sub


    ''' <summary>
    ''' Incrementa la posicíon del sprite
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OrderIncreases()

        If Me.SpriteSelectedIcon Is Nothing Then
            Exit Sub
        End If

        Dim id As Integer = CInt(Me.SpriteSelectedIcon.Name)
        Dim spritenumber As Integer = Me.sprites.IndexOf(id)

        If spritenumber < Me.sprites.Count - 1 Then
            Me.sprites.ChangeOrder(spritenumber, spritenumber + 1)
            'reOrder()
            RefreshList()
        End If

    End Sub


    ''' <summary>
    ''' Actualiza la visualización de los items dentro de la lista segun su orden.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshList()
        Dim spriteItem As SpriteItemList

        Me.SpriteListPanel.VerticalScroll.Value = 0

        For Each sprite As SpriteMSX In Me.sprites.Values
            spriteItem = Me.sprites.GetSpritePicture(sprite.ID)
            spriteItem.Location = New System.Drawing.Point(spriteItem.Location.X, sprite.order * 37)
            spriteItem.ToolTip = sprite.order.ToString + ">" + sprite.name
        Next

        Me.SpriteListPanel.ScrollControlIntoView(Me.SpriteSelectedIcon) 'situa el scroll para que muestre el control seleccionado
        '

        Me.SpriteListPanel.Refresh()

    End Sub







    Private Sub OrderUpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderUpButton.Click
        OrderDecreases()
    End Sub


    Private Sub OrderDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderDownButton.Click
        OrderIncreases()
    End Sub


    'Private Sub SpritesListController_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    If e.Alt Then
    '        If e.KeyCode = Keys.Up Then
    '            OrderDecreases()
    '        End If
    '        If e.KeyCode = Keys.Down Then
    '            OrderIncreases()
    '        End If
    '    End If
    'End Sub

    

End Class
