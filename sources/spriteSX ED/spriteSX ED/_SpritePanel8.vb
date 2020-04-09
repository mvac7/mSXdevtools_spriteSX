Public Class _SpritePanel8
    Implements ISpriteContainer

    Private _SpriteName As String
    Private _PatternNumber As Integer
    Private _inkColor As MSXcolor
    Private _bgColor As MSXcolor
    Private _PaletteData As New MSXpalette

    Private _WorkSprite As SpriteMSX

    Private _test As Boolean = False

    Private aColorSelector As New ColorSelector()

    Private bite_MASKs(7) As Byte

    Private pixelData() As Boolean
    Private _matrixdataSize As Integer

    Private SpriteBitmap As Bitmap
    Private panelGraphics As Graphics

    Private _state As STATE_TOOL

    Private _step As Integer

    Private _step0_posX As Integer
    Private _step0_posY As Integer

    Dim undo As New SizedStack(16)
    Dim redo As New SizedStack(16)

    Private Const _WIDTH As Integer = 7
    Private Const _HIGH As Integer = 7

    Public Enum STATE_TOOL As Integer
        DRAW
        LINE
        RECTANGLE
        RECTANGLE_FILL
        CIRCLE
        CIRCLE_FILL
        FILL
    End Enum



    Public Event updateSprite() Implements ISpriteContainer.updateSprite

    Public Event MatrixCoordinates(ByVal xpos As Integer, ByVal ypos As Integer) Implements ISpriteContainer.MatrixCoordinates

    Public Event SpriteBitmapChanged(ByVal spriteBitmap As Bitmap) Implements ISpriteContainer.SpriteBitmapChanged

    Public Event SpriteInfoChanged(ByVal name As String, ByVal patternNumber As Integer) Implements ISpriteContainer.SpriteInfoChanged




    Public Property Test() As Boolean Implements ISpriteContainer.Test
        Get
            Return Me._test
        End Get
        Set(ByVal value As Boolean)
            Me._test = value
            testButton.Visible = value
        End Set
    End Property



    Public Property SpriteName() As String Implements ISpriteContainer.SpriteName
        Get
            Return Me._SpriteName
        End Get
        Set(ByVal value As String)
            Me._SpriteName = value
        End Set
    End Property


    Public Property PatternNumber() As Integer
        Get
            Return Me._PatternNumber
        End Get
        Set(ByVal value As Integer)
            Me._PatternNumber = value
        End Set
    End Property


    Public Property inkColor() As MSXcolor Implements ISpriteContainer.inkColor
        Get
            Return Me._inkColor
        End Get
        Set(ByVal value As MSXcolor)
            Me._inkColor = value
            If Not colorINKPictureBox Is Nothing Then
                Me.ToolTip1.SetToolTip(colorINKPictureBox, "Ink color: " + CStr(value.id))
                colorINKPictureBox.BackColor = _PaletteData.getRGB(value)
            End If
        End Set
    End Property


    Public Property bgColor() As MSXcolor Implements ISpriteContainer.bgColor
        Get
            Return Me._bgColor
        End Get
        Set(ByVal value As MSXcolor)
            Me._bgColor = value
            If Not colorBGPictureBox Is Nothing Then
                Me.ToolTip1.SetToolTip(colorBGPictureBox, "Background color: " + CStr(value.id))
                colorBGPictureBox.BackColor = _PaletteData.getRGB(value)
            End If
        End Set
    End Property


    Public Property PaletteData() As MSXpalette Implements ISpriteContainer.PaletteData
        Get
            Return Me._PaletteData
        End Get
        Set(ByVal value As MSXpalette)
            If Not value Is Nothing Then
                Me._PaletteData = value
                Me.inkColor = _PaletteData.GetColor(Me._inkColor.id)
                Me.bgColor = _PaletteData.GetColor(Me._bgColor.id)
                ShowSprite()
            End If
        End Set
    End Property




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.inkColor = New MSXcolor(15, 7, 7, 7)
        Me.bgColor = New MSXcolor(0, 0, 0, 0)

        Me.bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

        Me.panelGraphics = Me.SpriteContainerPanel.CreateGraphics

        Me.SpriteBitmap = New Bitmap((_WIDTH + 1) * 2, (_HIGH + 1) * 2)
        'Me.SpriteBitmap = New Bitmap(16, 16)

        _matrixdataSize = ((_WIDTH + 1) * (_HIGH + 1)) - 1
        ReDim pixelData(_matrixdataSize)

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

        Me.NewSprite()

    End Sub



    Private Sub SpritePanel8_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SpriteContainerPanel.Refresh()
        _step = 0
        Application.DoEvents()
    End Sub


    Private Sub SpritePanel8_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        ShowSprite()

        If _WIDTH > 14 Then
            Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
            Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        End If

    End Sub


    Private Sub ShowSprite()
        GeneratePreview()
        Application.DoEvents()
        GenerateMatrix()
        Application.DoEvents()
    End Sub


    ''' <summary>
    ''' Genera la matriz del editor con el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateMatrix()

        Dim contador As Integer = 0

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                putPixelZoom(x, y, pixelData(contador))
                contador += 1
            Next
        Next

        Application.DoEvents()

    End Sub


    ''' <summary>
    ''' Genera la vista previa a partir de los datos del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneratePreview()

        Dim contador As Integer = 0

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                putPixelPreview(x, y, pixelData(contador))
                contador += 1
            Next
        Next

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub


    ''' <summary>
    ''' Proporciona el foco al campo de nombre.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetNameFocus() Implements ISpriteContainer.SetNameFocus
        'Me.SpriteNameTextBox.Focus()
    End Sub


    ''' <summary>
    ''' Cambia el color de tinta.
    ''' </summary>
    ''' <param name="newColor"></param>
    ''' <remarks></remarks>
    Public Sub changeInkColor(ByVal newColor As MSXcolor) Implements ISpriteContainer.changeInkColor
        Me.inkColor = newColor
        'colorINKPictureBox.BackColor = newColor.RGBColor

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Cambia el color de fondo.
    ''' </summary>
    ''' <param name="newColor"></param>
    ''' <remarks></remarks>
    Public Sub changeBGColor(ByVal newColor As MSXcolor) Implements ISpriteContainer.changeBGColor
        Me.bgColor = newColor
        'colorBGPictureBox.BackColor = newColor.RGBColor

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Visualiza en el editor los datos proporcionados desde un objeto SpriteMSX.
    ''' </summary>
    ''' <param name="spriteData"></param>
    ''' <remarks></remarks>
    Public Sub SetSprite(ByVal spriteData As SpriteMSX) Implements ISpriteContainer.SetSprite

        Dim TempValue As Byte = 0
        Dim contador As Integer = 0

        Me._WorkSprite = spriteData.clone()

        For y As Integer = 0 To _HIGH

            TempValue = 0
            For x As Integer = 0 To _WIDTH
                contador = y * 8 + (7 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)

                TempValue = spriteData.gfxData(y) And Me.bite_MASKs(x)

                If TempValue = Me.bite_MASKs(x) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next

        Next

        Me.inkColor = Me.PaletteData.GetColor(spriteData.InkColor)
        Me.bgColor = Me.PaletteData.GetColor(spriteData.BGcolor)

        Me.SpriteName = spriteData.name
        Me.PatternNumber = spriteData.order

        Me.ShowSprite()
        'Me.spritePicture.Refresh()

    End Sub


    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSprite() As SpriteMSX Implements ISpriteContainer.GetSprite

        Dim tmpData(7) As Byte
        'ReDim tmpData(31)

        Dim aBit As Byte
        Dim TempValue As Byte = 0
        Dim Counter As Integer = 0
        Dim byteCounter As Integer = 0

        For y As Integer = 0 To 7
            TempValue = 0
            For x As Integer = 0 To 7
                Counter = y * 8 + (7 - x)

                If pixelData(Counter) Then
                    aBit = 1
                Else
                    aBit = 0
                End If

                TempValue = TempValue + aBit * 2 ^ x
            Next
            tmpData(byteCounter) = TempValue
            byteCounter += 1
        Next


        If Me._WorkSprite Is Nothing Then
            Me._WorkSprite = New SpriteMSX(Me.SpriteName, SpriteBitmap.Clone, SpriteMSX.SPRITE_SIZE.SIZE8, Me.inkColor.id, Me.bgColor.id, tmpData.Clone, Me.PaletteData)
        Else
            Me._WorkSprite.name = Me.SpriteName

            Me._WorkSprite.size = SpriteMSX.SPRITE_SIZE.SIZE8
            Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.MONO

            Me._WorkSprite.gfxData = tmpData.Clone
            Me._WorkSprite.aBitmap = SpriteBitmap.Clone

            Me._WorkSprite.InkColor = Me._inkColor.id
            Me._WorkSprite.BGcolor = Me._bgColor.id

            Me._WorkSprite.PaletteData = Me.PaletteData
        End If

        Return Me._WorkSprite

    End Function


    ''' <summary>
    ''' Inicializa un sprite eliminado toda la información del editor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewSprite() Implements ISpriteContainer.NewSprite

        Me.inkColor = Me.PaletteData.GetColor(15)
        Me.bgColor = Me.PaletteData.GetColor(0)

        ClearSprite()
        Me.PatternNumber = 0
        Me.SpriteName = ""
        Me._WorkSprite = Nothing

        undo.Clear()
        redo.Clear()

        RaiseEvent SpriteInfoChanged(Me.SpriteName, Me.PatternNumber)

    End Sub


    ''' <summary>
    ''' Borra el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSprite() Implements ISpriteContainer.ClearSprite

        AddUndo()

        For i As Integer = 0 To _matrixdataSize
            pixelData(i) = False
        Next

        _step = 0

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Voltear horizontalmente el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FlipHorizontalSprite() Implements ISpriteContainer.FlipHorizontalSprite

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _HIGH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(y * tsize + x) = tempPixelData(y * tsize + (_WIDTH - x))
            Next

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Voltear verticalmente el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FlipVerticalSprite() Implements ISpriteContainer.FlipVerticalSprite

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _HIGH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(y * tsize + x) = tempPixelData((_HIGH - y) * tsize + x)
            Next

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Rotacion a la derecha del grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RotateRightSprite() Implements ISpriteContainer.RotateRightSprite

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(x * tsize + y) = tempPixelData((_HIGH - y) * tsize + x)
            Next

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Rotacion a la izquierda del grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RotateLeftSprite() Implements ISpriteContainer.RotateLeftSprite

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(x * tsize + y) = tempPixelData(y * tsize + (_WIDTH - x))
            Next

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto a la izquierda, el grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveLeft() Implements ISpriteContainer.MoveLeft

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH - 1
                pixelData(y * tsize + x) = tempPixelData(y * tsize + x + 1)
            Next
            pixelData(y * tsize + _WIDTH) = False

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto a la derecha, el grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveRight() Implements ISpriteContainer.MoveRight

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH - 1
                pixelData(y * tsize + x + 1) = tempPixelData(y * tsize + x)
            Next
            pixelData(y * tsize) = False

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto hacia arriba el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveUp() Implements ISpriteContainer.MoveUp

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For x As Integer = 0 To _WIDTH

            For y As Integer = 0 To _HIGH - 1
                pixelData(y * tsize + x) = tempPixelData((y + 1) * tsize + x)
            Next
            pixelData(_HIGH * tsize + x) = False

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto hacia abajo el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveDown() Implements ISpriteContainer.MoveDown

        Dim tempPixelData(_matrixdataSize) As Boolean
        Dim tsize As Integer = _WIDTH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For x As Integer = 0 To _WIDTH

            For y As Integer = 0 To _HIGH - 1
                pixelData((y + 1) * tsize + x) = tempPixelData(y * tsize + x)
            Next
            pixelData(x) = False

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Sigue pintando/borrando mientras el boton este pulsado en el area del editor.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SpriteContainerPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpriteContainerPanel.MouseMove
        Dim posX As Integer = Int(e.X / 16)
        Dim posY As Integer = Int(e.Y / 16)

        showCoordinates(posX, posY)

        If Me._state = STATE_TOOL.DRAW Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                SetPixel(posX, posY, True) 'pinta/draw
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                SetPixel(posX, posY, False) 'borra/erase
            End If
        End If

        'Me.spritePicture.Refresh()

    End Sub



    ''' <summary>
    ''' Pinta o borra un punto al clicar en una celda del editor.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SpriteContainerPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpriteContainerPanel.MouseDown
        Dim posX As Integer = Int(e.X / 16)
        Dim posY As Integer = Int(e.Y / 16)

        Dim ink As Boolean = True

        showCoordinates(posX, posY)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            ink = True 'pinta/draw
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ink = False 'borra/erase
        Else
            Exit Sub
        End If


        Select Case Me._state
            Case STATE_TOOL.DRAW
                AddUndo()
                SetPixel(posX, posY, ink) 'pinta/draw


            Case STATE_TOOL.LINE

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    SetPixel(posX, posY, ink)
                Else
                    _step = 0
                    DrawLine(_step0_posX, _step0_posY, posX, posY, ink)
                End If

            Case STATE_TOOL.RECTANGLE

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    SetPixel(posX, posY, ink)
                Else
                    _step = 0
                    DrawRectangle(_step0_posX, _step0_posY, posX, posY, ink)
                End If

            Case STATE_TOOL.RECTANGLE_FILL

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    SetPixel(posX, posY, ink)
                Else
                    _step = 0
                    DrawRectangleFill(_step0_posX, _step0_posY, posX, posY, ink)
                End If


            Case STATE_TOOL.CIRCLE

                If _step = 0 Then
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    'SetPixel(posX, posY, True)
                Else
                    AddUndo()
                    _step = 0
                    Dim radio As Integer = calRadio(_step0_posX, _step0_posY, posX, posY)
                    DrawCircle(_step0_posX, _step0_posY, radio, ink)
                End If

            Case STATE_TOOL.CIRCLE_FILL

                If _step = 0 Then
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                Else
                    AddUndo()
                    _step = 0
                    Dim radio As Integer = calRadio(_step0_posX, _step0_posY, posX, posY)
                    DrawCircleFill(_step0_posX, _step0_posY, radio, ink)
                End If



            Case STATE_TOOL.FILL
                AddUndo()
                Fill(posX, posY, ink)




        End Select

        'Me.spritePicture.Refresh()

    End Sub




    Private Function calRadio(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer) As Integer
        ' get a radio (thanks to JamQue) 
        ' Pythagoras' Theorem hypotenuse calc
        Dim radio As Integer
        Dim squareA As Integer = Math.Abs(x0 - x1)
        Dim squareB As Integer = Math.Abs(y0 - y1)
        radio = CInt(Math.Sqrt((squareA * squareA) + (squareB * squareB)))
        Return radio
    End Function


    'http://s.agock.com/glcd-documentation/graphics_8c_source.html

    Private Sub DrawLine(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal ink As Boolean)
        Dim posX As Integer ' = x0
        'Dim posY As Integer = y0

        Dim dx As Integer
        Dim dy As Integer
        Dim err As Integer
        Dim ystep As Integer


        Dim steep As Integer = Math.Abs(y1 - y0) > Math.Abs(x1 - x0)
        'Dim stepY As Integer = step0_Y - step1_Y

        If steep Then
            Swap(x0, y0)
            Swap(x1, y1)
        End If

        If x0 > x1 Then
            Swap(x0, x1)
            Swap(y0, y1)
        End If

        dx = x1 - x0
        dy = Math.Abs(y1 - y0)
        err = dx / 2

        If y0 < y1 Then
            ystep = 1
        Else
            ystep = -1
        End If

        For posX = x0 To x1

            If steep Then
                SetPixel(y0, posX, ink)
            Else
                SetPixel(posX, y0, ink)
            End If

            err -= dy
            If err < 0 Then
                y0 += ystep
                err += dx
            End If

        Next

    End Sub


    Private Sub DrawRectangle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean)

        Dim i As Integer
        Dim width As Integer
        Dim high As Integer

        If posX0 > posX1 Then
            Swap(posX0, posX1)
        End If

        If posY0 > posY1 Then
            Swap(posY0, posY1)
        End If

        ' width and heigh calculate
        width = posX1 - posX0
        high = posY1 - posY0

        For i = posX0 To posX0 + width
            SetPixel(i, posY0, ink)
            SetPixel(i, posY0 + high, ink)
        Next

        For i = posY0 To posY0 + high
            SetPixel(posX0, i, ink)
            SetPixel(posX0 + width, i, ink)
        Next

    End Sub


    Private Sub DrawRectangleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean)
        Dim x As Integer
        Dim y As Integer
        Dim width As Integer
        Dim high As Integer

        If posX0 > posX1 Then
            Swap(posX0, posX1)
        End If

        If posY0 > posY1 Then
            Swap(posY0, posY1)
        End If

        ' width and heigh calculate
        width = posX1 - posX0
        high = posY1 - posY0

        For x = posX0 To posX0 + width
            For y = posY0 To posY0 + high
                SetPixel(x, y, ink)
            Next
        Next

    End Sub



    Private Sub DrawCircle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean)
        Dim f As Integer = 1 - radio
        Dim ddF_x As Integer = 1
        Dim ddF_y As Integer = -2 * radio
        Dim x As Integer = 0
        Dim y As Integer = radio

        SetPixel(posX0, posY0 + radio, ink)
        SetPixel(posX0, posY0 - radio, ink)
        SetPixel(posX0 + radio, posY0, ink)
        SetPixel(posX0 - radio, posY0, ink)

        Do While x < y
            If f >= 0 Then
                y -= 1
                ddF_y += 2
                f += ddF_y
            End If

            x += 1
            ddF_x += 2
            f += ddF_x

            SetPixel(posX0 + x, posY0 + y, ink)
            SetPixel(posX0 - x, posY0 + y, ink)
            SetPixel(posX0 + x, posY0 - y, ink)
            SetPixel(posX0 - x, posY0 - y, ink)

            SetPixel(posX0 + y, posY0 + x, ink)
            SetPixel(posX0 - y, posY0 + x, ink)
            SetPixel(posX0 + y, posY0 - x, ink)
            SetPixel(posX0 - y, posY0 - x, ink)
        Loop


    End Sub



    Private Sub DrawCircleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean)

        Dim f As Integer = 1 - radio
        Dim ddF_x As Integer = 1
        Dim ddF_y As Integer = -2 * radio
        Dim x As Integer = 0
        Dim y As Integer = radio

        Dim i As Integer

        For i = posY0 - radio To posY0 + radio
            SetPixel(posX0, i, ink)
        Next


        Do While x < y
            If f >= 0 Then
                y -= 1
                ddF_y += 2
                f += ddF_y
            End If

            x += 1
            ddF_x += 2
            f += ddF_x

            For i = posY0 - y To posY0 + y
                SetPixel(posX0 + x, i, ink)
                SetPixel(posX0 - x, i, ink)
            Next

            For i = posY0 - x To posY0 + x
                SetPixel(posX0 + y, i, ink)
                SetPixel(posX0 - y, i, ink)
            Next

        Loop
    End Sub



    Private Sub Fill(ByVal x As Integer, ByVal y As Integer, ByVal ink As Boolean)
        If GetPixel(x, y) = ink Then
            Return
        End If
        SetPixel(x, y, ink)
        If x < _WIDTH Then
            Fill(x + 1, y, ink)
        End If
        If y < _HIGH Then
            Fill(x, y + 1, ink)
        End If
        If x > 0 Then
            Fill(x - 1, y, ink)
        End If
        If y > 0 Then
            Fill(x, y - 1, ink)
        End If
    End Sub



    ''' <summary>
    ''' Herramienta que invierte el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Invert() Implements ISpriteContainer.Invert

        Dim tsize As Integer = _HIGH + 1

        AddUndo()

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(y * tsize + x) = Not pixelData(y * tsize + x)
            Next

        Next

        ShowSprite()

    End Sub


    Private Sub Swap(ByRef d1 As Object, ByRef d2 As Object)
        Dim d As Object = d2
        d2 = d1
        d1 = d
    End Sub




    ''' <summary>
    ''' Muestra la posicion del cursor.
    ''' </summary>
    ''' <param name="posX"></param>
    ''' <param name="posY"></param>
    ''' <remarks></remarks>
    Private Sub showCoordinates(ByVal posX As Integer, ByVal posY As Integer)
        If posX < 0 Then
            posX = 0
        ElseIf posX > 7 Then
            posX = 7
        End If

        If posY < 0 Then
            posY = 0
        ElseIf posY > 7 Then
            posY = 7
        End If

        RaiseEvent MatrixCoordinates(posX, posY)
    End Sub


    ''' <summary>
    ''' Pinta un punto.
    ''' </summary>
    ''' <param name="cX"></param>
    ''' <param name="cY"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub SetPixel(ByVal cX As Integer, ByVal cY As Integer, ByVal state As Boolean)

        Dim tsize As Integer = _WIDTH + 1

        If cX < 0 Or cX > _WIDTH Or cY < 0 Or cY > _HIGH Then
            Exit Sub
        End If

        Me.pixelData(cY * tsize + cX) = state

        Me.putPixelZoom(cX, cY, state)
        Me.putPixelPreview(cX, cY, state)

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub



    Private Function GetPixel(ByVal cX As Integer, ByVal cY As Integer) As Boolean
        Dim tsize As Integer = _WIDTH + 1
        Return Me.pixelData(cY * tsize + cX)
    End Function



    ''' <summary>
    ''' Pinta un punto en el editor.
    ''' </summary>
    ''' <param name="Xpos"></param>
    ''' <param name="Ypos"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub putPixelZoom(ByVal Xpos As Integer, ByVal Ypos As Integer, ByVal state As Boolean)

        'If cX < 0 Or cX > 15 Or cY < 0 Or cY > 15 Then
        '    Exit Sub
        'End If

        Dim cX As Integer = Xpos * 16 + 1
        Dim cY As Integer = Ypos * 16 + 1

        Dim BrushColor As SolidBrush

        If state Then
            BrushColor = New SolidBrush(_PaletteData.getRGB(Me.inkColor))
        Else
            BrushColor = New SolidBrush(_PaletteData.getRGB(Me.bgColor))
        End If

        Me.panelGraphics.FillRectangle(BrushColor, cX, cY, 15, 15)

    End Sub


    ''' <summary>
    ''' Pinta un punto en representación miniatura del sprite.
    ''' </summary>
    ''' <param name="Xpos"></param>
    ''' <param name="Ypos"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub putPixelPreview(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal state As Boolean)

        Dim tmpColor As Color

        Xpos *= 2
        Ypos *= 2

        If state Then
            tmpColor = _PaletteData.getRGB(Me.inkColor)
        Else
            tmpColor = _PaletteData.getRGB(Me.bgColor)
        End If

        Me.SpriteBitmap.SetPixel(Xpos, Ypos, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos + 1, Ypos, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos, Ypos + 1, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos + 1, Ypos + 1, tmpColor)

    End Sub


    ''' <summary>
    ''' Muestra un dialogo para la seleccion del color de tinta.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorINKPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorINKPictureBox.Click
        Dim result As DialogResult
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            colorINKPictureBox.BackColor = _PaletteData.getRGB(aColorSelector.ColorSelected)
            changeInkColor(aColorSelector.ColorSelected)
        End If

    End Sub


    ''' <summary>
    ''' Muestra un dialogo para la seleccion de un color de fondo.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorBGPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorBGPictureBox.Click
        Dim result As DialogResult
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition) 'Cursor.Position)

        If result = DialogResult.OK Then
            colorBGPictureBox.BackColor = _PaletteData.getRGB(aColorSelector.ColorSelected)
            Me.changeBGColor(aColorSelector.ColorSelected)
            'Me.spritePicture.Refresh()
        End If
    End Sub


    ''' <summary>
    ''' crea una copia del sprite del editor con un nuevo ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Copy() Implements ISpriteContainer.Copy
        If Not Me._WorkSprite Is Nothing Then
            Me._WorkSprite = Me._WorkSprite.copy()
        End If
    End Sub





    Public Sub SetState(ByVal newState As Integer) Implements ISpriteContainer.SetState
        Me._state = newState
        _step = 0
    End Sub


    ''' <summary>
    ''' Accion tecla Enter: actualiza el sprite en el control de proyecto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SpriteNameTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            RaiseEvent updateSprite()
        End If
    End Sub


    ''' <summary>
    ''' For test purposes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testButton.Click

        Dim testSprite() As Byte = New Byte() {60, 66, 165, 129, 165, 153, 66, 60}
        Dim demoSprite As New SpriteMSX
        demoSprite.gfxData = testSprite

        demoSprite.InkColor = 15
        demoSprite.BGcolor = 1

        demoSprite.name = "TEST"

        Me.SetSprite(demoSprite)

    End Sub


    'Private Sub TestButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TestButton.LostFocus
    '    Application.DoEvents() ' truco para solucionar el problema en el redibujado del control cuando la ventana recupera el foco
    'End Sub


    Private Sub AddUndo()
        undo.Push(pixelData.Clone)
    End Sub


    Private Sub AddRedo()
        redo.Push(pixelData.Clone)
    End Sub

    Public Sub SetUndo() Implements ISpriteContainer.SetUndo
        If undo.Count > 0 Then
            AddRedo()
            pixelData = undo.Pop
            ShowSprite()
        End If
    End Sub

    Public Sub SetRedo() Implements ISpriteContainer.SetRedo
        If redo.Count > 0 Then
            AddUndo()
            pixelData = redo.Pop
            ShowSprite()
        End If
    End Sub

End Class
