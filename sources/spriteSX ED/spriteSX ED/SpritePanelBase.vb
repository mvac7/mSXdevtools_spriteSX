Public Class SpritePanelBase
    Implements ISpriteContainer

    Public _SpriteSize As SPRITESIZES = SPRITESIZES.SPRITE8x8
    Public _SpriteMode2 As Boolean

    Public _SpriteName As String
    Public _PatternNumber As Integer
    Public _inkColor As MSXcolor
    Public _bgColor As MSXcolor
    Public _PaletteData As New MSXpalette

    Public _WorkSprite As SpriteMSX

    Public _test As Boolean = False

    Public aColorSelector As New ColorSelector()

    Public bite_MASKs(7) As Byte

    Public pixelData() As Boolean
    Public _matrixdataSize As Integer

    Public colorPic() As PictureBox
    Public orPic() As PictureBox

    Public ORvalues(15) As Boolean
    Public colorValues(15) As Byte

    Public _ORselected As Boolean = False

    Public SpriteBitmap As Bitmap
    Public panelGraphics As Graphics

    'public _ORselected As Boolean = False

    Public _state As STATE_TOOL

    Public _step As Integer

    Public _step0_posX As Integer
    Public _step0_posY As Integer

    Public undo As New SizedStack(16)
    Public redo As New SizedStack(16)

    Public _WIDTH As Integer = 15
    Public _HIGH As Integer = 15

    Public ENDinit As Boolean = False

    Public Shadows Enum STATE_TOOL As Integer
        DRAW
        LINE
        RECTANGLE
        RECTANGLE_FILL
        CIRCLE
        CIRCLE_FILL
        FILL
    End Enum

    Public Shadows Enum SPRITESIZES As Integer
        SPRITE8x8 = 8
        SPRITE16x16 = 16
    End Enum

    Public Event updateSprite() Implements ISpriteContainer.updateSprite

    Public Event MatrixCoordinates(ByVal xpos As Integer, ByVal ypos As Integer) Implements ISpriteContainer.MatrixCoordinates

    Public Event SpriteBitmapChanged(ByVal spriteBitmap As Bitmap) Implements ISpriteContainer.SpriteBitmapChanged

    Public Event SpriteInfoChanged(ByVal name As String, ByVal patternNumber As Integer) Implements ISpriteContainer.SpriteInfoChanged


    Public Property SpriteSize() As SPRITESIZES
        Get
            Return Me._SpriteSize
        End Get
        Set(ByVal value As SPRITESIZES)
            Me._SpriteSize = value
        End Set
    End Property

    Public Property SpriteMode2() As Boolean
        Get
            Return Me._SpriteMode2
        End Get
        Set(ByVal value As Boolean)
            Me._SpriteMode2 = value
        End Set
    End Property


    Public Property Test() As Boolean Implements ISpriteContainer.Test
        Get
            Return Me._test
        End Get
        Set(ByVal value As Boolean)
            Me._test = value
            testButton.Visible = Me._test
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
                If SpriteMode2 Then
                    For i As Integer = 0 To _HIGH
                        Me.colorPic(i).BackColor = _PaletteData.getRGB(Me.colorValues(i))
                    Next
                End If
                ShowSprite()
            End If
        End Set
    End Property




    Public Sub New(ByVal aPaletteData As MSXpalette)

        Me._PaletteData = aPaletteData

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.inkColor = New MSXcolor(15, 7, 7, 7)
        Me.bgColor = New MSXcolor(0, 0, 0, 0)

        Me.bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

        Me.panelGraphics = Me.SpriteContainerPanel.CreateGraphics

    End Sub



    Public Sub SpritePanelBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer

        Me.SuspendLayout()

        _step = 0

        If Me._SpriteSize = SPRITESIZES.SPRITE8x8 Then
            Me.SpriteContainerPanel.Size = New System.Drawing.Size(129, 129)
            Me._WIDTH = 7
            Me._HIGH = 7
            Me.colorPanel.Location = New System.Drawing.Point(150, 4)
        Else
            Me.SpriteContainerPanel.Size = New System.Drawing.Size(257, 257)
            Me._WIDTH = 15
            Me._HIGH = 15
        End If

        Me.SpriteBitmap = New Bitmap((_WIDTH + 1) * 2, (_HIGH + 1) * 2)


        _matrixdataSize = ((_WIDTH + 1) * (_HIGH + 1)) - 1
        ReDim pixelData(_matrixdataSize)

        ReDim colorPic(_HIGH)
        ReDim orPic(_HIGH)

        If Me._SpriteMode2 Then
            'multicolor (V9938 or +)
            ORselectedButton.Visible = True
            Me.infoPictureBox.Image = Me.ImageList1.Images.Item(1)

            For i = 0 To _HIGH
                GenerateColorLine(i)
            Next

        Else
            ORselectedButton.Visible = False
            Me.infoPictureBox.Image = Me.ImageList1.Images.Item(0)
        End If

        Me.NewSprite()

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

        AddHandler Me.Paint, AddressOf SpritePanelBase_Paint

        Me.SpriteContainerPanel.Refresh()

        Me.ResumeLayout(False)

        Application.DoEvents()
        Me.ENDinit = True

    End Sub



    Private Sub GenerateColorLine(ByVal numy As Integer)

        Dim y As Integer = numy * 16 + 47 '24
        Dim x As Integer

        Dim ORBitLine As PictureBox = New PictureBox
        Dim colorINKLine As PictureBox = New PictureBox


        If Me._SpriteSize = SPRITESIZES.SPRITE8x8 Then
            x = 151
        Else
            x = 276
        End If


        '
        'ORPictureCheckBox
        '
        ORBitLine.BackColor = System.Drawing.Color.DimGray  'PaleGreen
        ORBitLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ORBitLine.Cursor = System.Windows.Forms.Cursors.Hand
        ORBitLine.Location = New System.Drawing.Point(x, y)
        ORBitLine.Name = "ORPictureCheckBox" + CStr(numy)
        ORBitLine.Size = New System.Drawing.Size(15, 15)
        ORBitLine.TabIndex = numy
        ORBitLine.TabStop = False

        '
        'colorINKPictureBox
        '
        colorINKLine.BackColor = System.Drawing.Color.White
        colorINKLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        colorINKLine.Cursor = System.Windows.Forms.Cursors.Hand
        colorINKLine.Location = New System.Drawing.Point(x + 16, y)
        colorINKLine.Name = "colorINKPictureBox" + CStr(numy)
        colorINKLine.Size = New System.Drawing.Size(14, 14)
        colorINKLine.TabIndex = numy
        colorINKLine.TabStop = False

        Me.Controls.Add(ORBitLine)
        Me.Controls.Add(colorINKLine)

        AddHandler ORBitLine.Click, AddressOf Me.ORBitLine_Click
        AddHandler colorINKLine.Click, AddressOf Me.colorINKLine_Click

        'Me.ResumeLayout(False)

        Me.orPic(numy) = ORBitLine
        Me.colorPic(numy) = colorINKLine

    End Sub



    Public Sub SpritePanelBase_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        ShowSprite()

        If Me._SpriteSize = SPRITESIZES.SPRITE16x16 Then
            Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
            Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        End If

    End Sub



    Overridable Sub ShowSprite()
        If Me.ENDinit And Not Me.PaletteData Is Nothing Then
            GeneratePreview()
            Application.DoEvents()
            GenerateMatrix()
            Application.DoEvents()
        End If
    End Sub


    ''' <summary>
    ''' Genera la matriz del editor con el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GenerateMatrix()

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
    Public Sub GeneratePreview()

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
    Overridable Sub SetSprite(ByVal spriteData As SpriteMSX) Implements ISpriteContainer.SetSprite

        ClearUndo()

        Me.inkColor = Me.PaletteData.GetColor(spriteData.InkColor)
        Me.bgColor = Me.PaletteData.GetColor(spriteData.BGcolor)

        Me.SpriteName = spriteData.name
        Me.PatternNumber = spriteData.order

        Me.ShowSprite()

    End Sub


    ''' <summary>
    ''' Proporciona un objeto SpriteMSX a partir de los datos del editor.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable Function GetSprite() As SpriteMSX Implements ISpriteContainer.GetSprite
        Dim tmpSprite = New SpriteMSX
        Return tmpSprite
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

        ClearUndo()

        RaiseEvent SpriteInfoChanged(Me.SpriteName, Me.PatternNumber)

    End Sub


    ''' <summary>
    ''' Borra el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub ClearSprite() Implements ISpriteContainer.ClearSprite

        AddUndo()

        _step = 0

        For i As Integer = 0 To _matrixdataSize
            pixelData(i) = False
        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Voltear horizontalmente el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub FlipHorizontalSprite() Implements ISpriteContainer.FlipHorizontalSprite

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
    Overridable Sub FlipVerticalSprite() Implements ISpriteContainer.FlipVerticalSprite

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
    Overridable Sub RotateRightSprite() Implements ISpriteContainer.RotateRightSprite

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
    Overridable Sub RotateLeftSprite() Implements ISpriteContainer.RotateLeftSprite

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
    Overridable Sub MoveLeft() Implements ISpriteContainer.MoveLeft

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
    Overridable Sub MoveRight() Implements ISpriteContainer.MoveRight

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
    Overridable Sub MoveUp() Implements ISpriteContainer.MoveUp

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
    Overridable Sub MoveDown() Implements ISpriteContainer.MoveDown

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
    Public Sub SpriteContainerPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpriteContainerPanel.MouseMove
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
    Public Sub SpriteContainerPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpriteContainerPanel.MouseDown
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


    Public Function calRadio(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer) As Integer
        ' get a radio (thanks to JamQue) 
        ' Pythagoras' Theorem hypotenuse calc
        Dim radio As Integer
        Dim squareA As Integer = Math.Abs(x0 - x1)
        Dim squareB As Integer = Math.Abs(y0 - y1)
        radio = CInt(Math.Sqrt((squareA * squareA) + (squareB * squareB)))
        Return radio
    End Function


    'http://s.agock.com/glcd-documentation/graphics_8c_source.html

    Public Sub DrawLine(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal ink As Boolean)
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


    Public Sub DrawRectangle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean)

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


    Public Sub DrawRectangleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean)
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



    Public Sub DrawCircle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean)
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



    Public Sub DrawCircleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean)

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



    Public Sub Fill(ByVal x As Integer, ByVal y As Integer, ByVal ink As Boolean)
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


    Public Sub Swap(ByRef d1 As Object, ByRef d2 As Object)
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
    Public Sub showCoordinates(ByVal posX As Integer, ByVal posY As Integer)
        If posX < 0 Then
            posX = 0
        ElseIf posX > _WIDTH Then
            posX = _WIDTH
        End If

        If posY < 0 Then
            posY = 0
        ElseIf posY > _HIGH Then
            posY = _HIGH
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
    Public Sub SetPixel(ByVal cX As Integer, ByVal cY As Integer, ByVal state As Boolean)

        Dim tsize As Integer = _WIDTH + 1

        If cX < 0 Or cX > _WIDTH Or cY < 0 Or cY > _HIGH Then
            Exit Sub
        End If

        Me.pixelData(cY * tsize + cX) = state

        Me.putPixelZoom(cX, cY, state)
        Me.putPixelPreview(cX, cY, state)

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub



    Public Function GetPixel(ByVal cX As Integer, ByVal cY As Integer) As Boolean
        Dim tsize As Integer = _WIDTH + 1
        Return Me.pixelData(cY * tsize + cX)
    End Function



    ''' <summary>
    ''' Pinta un punto en el editor.
    ''' </summary>
    ''' <param name="Xpos"></param>
    ''' <param name="Ypos"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Overridable Sub putPixelZoom(ByVal Xpos As Integer, ByVal Ypos As Integer, ByVal value As Boolean)
        Try
            'If cX < 0 Or cX > 15 Or cY < 0 Or cY > 15 Then
            '    Exit Sub
            'End If
            Dim aColor As MSXcolor

            Dim cX As Integer = Xpos * 16 + 1
            Dim cY As Integer = Ypos * 16 + 1

            If value Then
                If SpriteMode2 Then
                    aColor = Me.PaletteData.GetColor(Me.colorValues(Ypos))
                Else
                    aColor = Me._inkColor
                End If
            Else
                aColor = Me._bgColor
            End If

            Me.panelGraphics.FillRectangle(New SolidBrush(_PaletteData.getRGB(aColor)), cX, cY, 15, 15)

        Catch ex As Exception

        End Try

    End Sub


    ''' <summary>
    ''' Pinta un punto en representación miniatura del sprite.
    ''' </summary>
    ''' <param name="Xpos"></param>
    ''' <param name="Ypos"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Overridable Sub putPixelPreview(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal state As Boolean)

        Dim aColor As MSXcolor
        Dim tmpColor As Color

        If state Then
            If SpriteMode2 Then
                aColor = Me.PaletteData.GetColor(Me.colorValues(Ypos))
            Else
                aColor = Me._inkColor
            End If
        Else
            aColor = Me._bgColor
        End If

        Xpos *= 2
        Ypos *= 2

        tmpColor = _PaletteData.getRGB(aColor)
        Me.SpriteBitmap.SetPixel(Xpos, Ypos, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos + 1, Ypos, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos, Ypos + 1, tmpColor)
        Me.SpriteBitmap.SetPixel(Xpos + 1, Ypos + 1, tmpColor)

    End Sub



    ''' <summary>
    ''' Cambia el estado del bit de OR de todas las lineas.
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Public Sub SetORstate(ByVal state As Boolean)

        Me._ORselected = state

        If state Then
            ORselectedButton.BackColor = System.Drawing.Color.PaleGreen
        Else
            ORselectedButton.BackColor = System.Drawing.Color.Gainsboro
        End If

        For i As Integer = 0 To Me._HIGH
            ORvalues(i) = state
        Next

        'For Each aPic As PictureBox In Me.orPic
        '    aPic.TabStop = state
        'Next

        showORstates()

    End Sub



    ''' <summary>
    ''' Muestra el estado del bit de OR de cada linea, en cada indicador/boton.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showORstates()
        'Dim aPic As PictureBox
        For i As Integer = 0 To Me._HIGH
            'aPic = Me.orPic(i)
            If ORvalues(i) Then
                Me.orPic(i).BackColor = System.Drawing.Color.PaleGreen
            Else
                Me.orPic(i).BackColor = System.Drawing.Color.DimGray
            End If
        Next
        'For Each aPic As PictureBox In Me.orPic
        '    If aPic.TabStop Then
        '        aPic.BackColor = System.Drawing.Color.PaleGreen
        '    Else
        '        aPic.BackColor = System.Drawing.Color.DimGray
        '    End If
        'Next
    End Sub


    ''' <summary>
    ''' Muestra el color el color de cada linea, en cada indicador/boton.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub showColorLines()
        For i As Integer = 0 To _HIGH
            Me.colorPic(i).BackColor = _PaletteData.getRGB(Me.colorValues(i))
        Next
    End Sub


    ''' <summary>
    ''' Activa/desactiva el bit de OR en todas las lineas.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ORselectedButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORselectedButton.Click

        SetORstate(Not Me._ORselected)

    End Sub


    ''' <summary>
    ''' Muestra un dialogo para la seleccion del color de tinta.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorINKPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorINKPictureBox.Click
        Dim result As DialogResult
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition)

        If result = DialogResult.OK Then
            colorINKPictureBox.BackColor = _PaletteData.getRGB(aColorSelector.ColorSelected)
            Me.inkColor = aColorSelector.ColorSelected

            If SpriteMode2 Then
                For Each aPic As PictureBox In Me.colorPic
                    aPic.BackColor = _PaletteData.getRGB(Me.inkColor)
                    Me.colorValues(aPic.TabIndex) = Me.inkColor.id
                Next
            End If

            ShowSprite()
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
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition) 'Cursor.Position

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


    'Public Sub Draw_State() Implements ISpriteContainer.Draw_State
    '    _state = STATE_TOOL.DRAW
    'End Sub



    'Public Sub Line_State() Implements ISpriteContainer.Line_State
    '    _state = STATE_TOOL.LINE
    '    _step = 0
    'End Sub


    'Public Sub Rectangle_State() Implements ISpriteContainer.Rectangle_State
    '    _state = STATE_TOOL.RECTANGLE
    '    _step = 0
    'End Sub



    'Public Sub Circle_State() Implements ISpriteContainer.Circle_State
    '    _state = STATE_TOOL.CIRCLE
    '    _step = 0
    'End Sub


    'Public Sub Paint_State() Implements ISpriteContainer.Paint_State
    '    _state = STATE_TOOL.FILL
    'End Sub


    'Public Sub SpriteNameTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        RaiseEvent updateSprite()
    '    End If
    'End Sub



    ''' <summary>
    ''' For test purposes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testButton.Click
        SetTest()
    End Sub


    Overridable Sub SetTest()
        Dim testSprite() As Byte = New Byte() {&HF0, &HF0, &HF0, &HF0, &HF, &HF, &HF, &HF, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF}
        Dim demoSprite As New SpriteMSX
        demoSprite.gfxData = testSprite

        demoSprite.InkColor = 15
        demoSprite.BGcolor = 0

        demoSprite.name = "TEST"

        Me.SetSprite(demoSprite)
    End Sub


    Public Sub TestButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles testButton.LostFocus
        Application.DoEvents() ' truco para solucionar el problema en el redibujado del control cuando la ventana recupera el foco
    End Sub




    ''' <summary>
    ''' Modifica el estado del bit de OR, en una linea.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ORBitLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim anORpicture As PictureBox = CType(sender, PictureBox)

        If Me.ORvalues(anORpicture.TabIndex) Then
            anORpicture.BackColor = System.Drawing.Color.DimGray
        Else
            anORpicture.BackColor = System.Drawing.Color.PaleGreen
        End If

        Me.ORvalues(anORpicture.TabIndex) = Not Me.ORvalues(anORpicture.TabIndex)

    End Sub


    ''' <summary>
    ''' Selección del color de tinta de una linea.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorINKLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As DialogResult
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            sender.BackColor = _PaletteData.getRGB(aColorSelector.ColorSelected)
            Me.colorValues(sender.TabIndex) = aColorSelector.ColorSelected.id
            ShowSprite()
        End If

    End Sub


    Public Sub ClearUndo()
        undo.Clear()
        redo.Clear()
    End Sub


    Public Sub AddUndo()
        undo.Push(New UndoItem(Me.pixelData, Me.colorValues, Me.ORvalues))
    End Sub


    Public Sub AddRedo()
        redo.Push(New UndoItem(Me.pixelData, Me.colorValues, Me.ORvalues))
    End Sub

    Public Sub SetUndo() Implements ISpriteContainer.SetUndo
        Dim tmpUndoItem As UndoItem
        If undo.Count > 0 Then
            AddRedo()
            tmpUndoItem = undo.Pop
            Me.pixelData = tmpUndoItem.pixelData
            Me.colorValues = tmpUndoItem.colorValues
            Me.ORvalues = tmpUndoItem.ORvalues

            ShowSprite()
        End If
    End Sub

    Public Sub SetRedo() Implements ISpriteContainer.SetRedo
        Dim tmpUndoItem As UndoItem
        If redo.Count > 0 Then
            AddUndo()
            tmpUndoItem = redo.Pop
            Me.pixelData = tmpUndoItem.pixelData
            Me.colorValues = tmpUndoItem.colorValues
            Me.ORvalues = tmpUndoItem.ORvalues
            ShowSprite()
        End If
    End Sub


End Class
