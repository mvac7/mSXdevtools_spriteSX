Public Class SpritePanelBase
    Implements ISpriteContainer

    Private _SpriteSize As SpriteMSX.SPRITE_SIZE  'SPRITESIZES = SPRITESIZES.SPRITE8x8
    Private _SpriteMode As SpriteMSX.SPRITE_MODE

    'Public _SpriteName As String
    Public _PatternNumber As Integer

    Public _Palette As iPaletteMSX
    Public _inkColor As Integer
    Public _bgColor As Integer


    Public _WorkSprite As SpriteMSX

    Public _test As Boolean = False

    Public aColorSelector As New ColorSelector()

    'Private bitMASK = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}
    Public bitMASKi = New Byte() {128, 64, 32, 16, 8, 4, 2, 1}


    Public spriteLines As MatrixData  'ArrayList

    Public colorPic() As System.Windows.Forms.Button
    Public orPic() As System.Windows.Forms.Button

    Public ORvalues(15) As Boolean
    Public colorValues(15) As Byte

    Public _ORselected As Boolean = False

    Public SpriteBitmap As Bitmap
    Public panelGraphics As Graphics

    ' MouseMove event control
    Private old_posX As Integer
    Private old_posY As Integer

    Public _state As STATE_TOOL

    Public _step As Integer

    Public _step0_posX As Integer
    Public _step0_posY As Integer


    Private Const UNDO_MAX = 64

    Public undo As New SizedStack(UNDO_MAX)
    Public redo As New SizedStack(UNDO_MAX)

    Public _WIDTH As Integer = 15
    Public _HIGH As Integer = 15

    Public ENDinit As Boolean = False

    Public Shadows Enum STATE_TOOL As Integer
        DRAW
        LINE
        RECTANGLE
        RECTANGLE_FILL
        ELLIPSE
        ELLIPSE_FILL
        FILL
    End Enum


    Public Event updateSprite() Implements ISpriteContainer.updateSprite

    Public Event MatrixCoordinates(ByVal xpos As Integer, ByVal ypos As Integer) Implements ISpriteContainer.MatrixCoordinates

    Public Event SpriteBitmapChanged(ByVal spriteBitmap As Bitmap) Implements ISpriteContainer.SpriteBitmapChanged

    'Public Event SpriteInfoChanged(ByVal name As String, ByVal patternNumber As Integer) Implements ISpriteContainer.SpriteInfoChanged


    Public Property SpriteSize() As SpriteMSX.SPRITE_SIZE   ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO puede confundirse con el size del sprite, (en este caso devuelve el size de datos)
        Get
            Return Me._SpriteSize
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_SIZE)
            Me._SpriteSize = value
        End Set
    End Property


    Public Property SpriteMode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me._SpriteMode
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_MODE)
            Me._SpriteMode = value
        End Set
    End Property



    Public Property SpriteName() As String Implements ISpriteContainer.SpriteName
        Get
            If Me._WorkSprite Is Nothing Then
                Return " "
            Else
                Return Me._WorkSprite.Name
            End If
        End Get
        Set(ByVal value As String)
            If Not Me._WorkSprite Is Nothing Then
                Me._WorkSprite.Name = value
            End If
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


    Public Property InkColor() As Integer Implements ISpriteContainer.InkColor
        Get
            Return Me._inkColor
        End Get
        Set(ByVal value As Integer)
            Me._inkColor = value
            If Not colorINKPictureBox Is Nothing Then

                Me.ToolTip1.SetToolTip(colorINKPictureBox, "Ink color: " + CStr(value))
                colorINKPictureBox.BackColor = Me._Palette.GetRGBColor(value) 'value.GetRGBColor()
            End If
        End Set
    End Property


    Public Property BackgroundColor() As Integer Implements ISpriteContainer.BackgroundColor
        Get
            Return Me._bgColor
        End Get
        Set(ByVal value As Integer)
            Me._bgColor = value
            If Not colorBGPictureBox Is Nothing Then
                Me.ToolTip1.SetToolTip(colorBGPictureBox, "Background color: " + CStr(value))
                colorBGPictureBox.BackColor = Me._Palette.GetRGBColor(value) 'value.GetRGBColor()
            End If
        End Set
    End Property



    Public Property Palette() As iPaletteMSX Implements ISpriteContainer.Palette
        Get
            Return Me._Palette
        End Get
        Set(ByVal value As iPaletteMSX)
            If Not value Is Nothing Then
                Me._Palette = value
                Me.InkColor = Me._inkColor
                Me.BackgroundColor = Me._bgColor
                If SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                    ShowColorLines()
                End If
                ShowSprite()
            End If
        End Set
    End Property




    Public Property Sprite() As SpriteMSX Implements ISpriteContainer.Sprite
        Get
            Return Me._WorkSprite
        End Get
        Set(ByVal value As SpriteMSX)
            SetSprite(value)
        End Set
    End Property




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Palette = New PaletteTMS9918

        Me.InkColor = 15
        Me.BackgroundColor = 0

        Me.panelGraphics = Me.SpriteContainerPanel.CreateGraphics

    End Sub



    Public Sub New(ByVal aPaletteData As iPaletteMSX)

        Me._Palette = aPaletteData

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.InkColor = 15
        Me.BackgroundColor = 0

        Me.panelGraphics = Me.SpriteContainerPanel.CreateGraphics

    End Sub




    Public Sub SpritePanelBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer

        Me.SuspendLayout()

        _step = 0

        If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            '8x8
            Me.SpriteContainerPanel.Size = New System.Drawing.Size(129, 129)
            Me.HRulerPicture.Size = New System.Drawing.Size(128, 16)
            Me.VRulerPicture.Size = New System.Drawing.Size(16, 128)
            Me._WIDTH = 7
            Me._HIGH = 7
            Me.colorPanel.Location = New System.Drawing.Point(Me.SpriteContainerPanel.Location.X + Me.SpriteContainerPanel.Size.Width + 2, Me.colorPanel.Location.Y)
        Else
            '16x16
            Me.SpriteContainerPanel.Size = New System.Drawing.Size(257, 257)
            Me.HRulerPicture.Size = New System.Drawing.Size(256, 16)
            Me.VRulerPicture.Size = New System.Drawing.Size(16, 256)
            Me._WIDTH = 15
            Me._HIGH = 15
        End If

        Me.SpriteBitmap = New Bitmap((_WIDTH + 1) * 2, (_HIGH + 1) * 2)


        '_matrixdataSize = ((_WIDTH + 1) * (_HIGH + 1)) - 1
        'ReDim pixelData(_matrixdataSize)


        ' init sprite matrix data
        Me.spriteLines = New MatrixData(_HIGH)

        ReDim colorPic(_HIGH)
        ReDim orPic(_HIGH)

        If Me._SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
            'multicolor (V9938 or +)
            ORselectedButton.Visible = True
            Me.infoPictureBox.Image = Me.ImageList1.Images.Item(1)

            Me.colorINKPictureBox.Location = New System.Drawing.Point(16, 0)
            Me.colorBGPictureBox.Location = New System.Drawing.Point(32, 0)

            For i = 0 To _HIGH
                GenerateColorLine(i)
            Next

        Else
            ORselectedButton.Visible = False
            Me.infoPictureBox.Image = Me.ImageList1.Images.Item(0)

            Me.colorINKPictureBox.Location = New System.Drawing.Point(0, 0)
            Me.colorBGPictureBox.Location = New System.Drawing.Point(16, 0)
        End If

        'NewSprite()

        'RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

        Dim aMemoryStream As System.IO.MemoryStream
        aMemoryStream = New System.IO.MemoryStream(My.Resources.cursor_draw01)
        'Me.Cursor_Draw = New Cursor(aMemoryStream)
        Me.SpriteContainerPanel.Cursor = New Cursor(aMemoryStream)



        AddHandler Me.Paint, AddressOf SpritePanelBase_Paint
        'AddHandler SpriteContainerPanel.MouseMove, AddressOf SpriteContainerPanel_MouseMove

        Me.ResumeLayout(False)

        Me.SpriteContainerPanel.Refresh()

        Me.ENDinit = True


        Application.DoEvents()

    End Sub



    Public Sub SpritePanelBase_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        'If Me.ENDinit And Not Me.PaletteData Is Nothing Then
        '    GeneratePreview()
        '    Application.DoEvents()
        'End If

        Application.DoEvents()

        ShowSprite()

        'If Me._SpriteSize = SPRITESIZES.SPRITE16x16 Then
        '    Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
        '    Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        'End If

    End Sub



    Private Sub GenerateColorLine(ByVal numy As Integer)

        Dim posY As Integer = numy * 16 + 47
        Dim posX As Integer

        Dim ORBitLine = New System.Windows.Forms.Button()
        Dim colorINKLine = New System.Windows.Forms.Button()


        'If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
        '    x = 151
        'Else
        '    x = 275
        'End If

        posX = Me.SpriteContainerPanel.Location.X + Me.SpriteContainerPanel.Size.Width + 2

        '
        'ORPicture Checker
        '
        ORBitLine.BackColor = System.Drawing.Color.DarkGray
        ORBitLine.FlatAppearance.BorderSize = 0
        ORBitLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ORBitLine.Cursor = System.Windows.Forms.Cursors.Hand
        ORBitLine.Location = New System.Drawing.Point(posX, posY)
        ORBitLine.Name = "ORPictureCheckBox" + CStr(numy)
        ORBitLine.Size = New System.Drawing.Size(15, 15)
        ORBitLine.TabIndex = numy
        ORBitLine.TabStop = False
        'Me.ToolTip1.SetToolTip(ORBitLine, "Off")


        '
        'colorINK
        '
        colorINKLine.BackColor = System.Drawing.Color.White
        colorINKLine.FlatAppearance.BorderSize = 0
        colorINKLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        colorINKLine.Cursor = System.Windows.Forms.Cursors.Hand
        colorINKLine.Location = New System.Drawing.Point(posX + 16, posY)
        colorINKLine.Name = "colorINKLine" + CStr(numy)
        colorINKLine.Size = New System.Drawing.Size(15, 15)
        colorINKLine.TabIndex = numy
        colorINKLine.TabStop = False
        Me.ToolTip1.SetToolTip(colorINKLine, "0")

        Me.Controls.Add(ORBitLine)
        Me.Controls.Add(colorINKLine)

        AddHandler ORBitLine.Click, AddressOf Me.ORBitLine_Click
        AddHandler colorINKLine.Click, AddressOf Me.colorINKLine_Click

        'Me.ResumeLayout(False)

        Me.orPic(numy) = ORBitLine
        Me.colorPic(numy) = colorINKLine

    End Sub



    Overridable Sub ShowSprite()
        If Me.ENDinit And Not Me._Palette Is Nothing Then
            ShowSpritePreview()
            'Application.DoEvents()
            ShowSpriteZoomPanel()
            'Application.DoEvents()
        End If

        If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
            Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
            Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)
        End If
    End Sub



    ''' <summary>
    ''' Genera la matriz del editor con el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowSpriteZoomPanel()

        'Dim contador As Integer = 0

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                putPixelZoom(x, y, Me.spriteLines.Item(y)(x))
            Next
        Next

        'Application.DoEvents()

    End Sub



    ''' <summary>
    ''' Genera la vista previa a partir de los datos del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowSpritePreview()

        'Dim contador As Integer = 0

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                putPixelPreview(x, y, Me.spriteLines.Item(y)(x))
                'putPixelPreview(x, y, pixelData(contador))
                'contador += 1
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
    ''' <param name="colorID"></param>
    ''' <remarks></remarks>
    Public Sub changeInkColor(ByVal colorID As Integer) Implements ISpriteContainer.changeInkColor

        Me.InkColor = colorID

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Cambia el color de fondo.
    ''' </summary>
    ''' <param name="colorID"></param>
    ''' <remarks></remarks>
    Public Sub changeBGColor(ByVal colorID As Integer) Implements ISpriteContainer.changeBGColor

        Me.BackgroundColor = colorID

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Visualiza en el editor los datos proporcionados desde un objeto SpriteMSX.
    ''' </summary>
    ''' <param name="spriteData"></param>
    ''' <remarks></remarks>
    Overridable Sub SetSprite(ByVal spriteData As SpriteMSX) Implements ISpriteContainer.SetSprite

        Dim TempValue As Byte = 0

        Me._WorkSprite = New SpriteMSX


        ClearUndo()


        Me.spriteLines.Clear()


        ' adapta el sprite de la entrada al modo que esta trabajando el editor
        If Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8 Or spriteData.Size = SpriteMSX.SPRITE_SIZE.SIZE8 Then

            For y As Integer = 0 To 7
                TempValue = spriteData.patternData(y)
                For x As Integer = 0 To 7
                    'TempValue = spriteData.patternData(y) And Me.bitMASKi(x)

                    If ((TempValue >> x) And 1) = 1 Then 'TempValue = Me.bitMASKi(x) Then
                        Me.spriteLines.Item(y)(7 - x) = True
                    Else
                        Me.spriteLines.Item(y)(7 - x) = False
                    End If
                Next
            Next

        Else

            For y As Integer = 0 To 15
                TempValue = spriteData.patternData(y)
                For x As Integer = 0 To 7
                    'TempValue = spriteData.patternData(y) And Me.bitMASKi(x)

                    If ((TempValue >> x) And 1) = 1 Then 'Me.bitMASKi(x) Then
                        Me.spriteLines.Item(y)(7 - x) = True
                    Else
                        Me.spriteLines.Item(y)(7 - x) = False
                    End If
                Next

                TempValue = spriteData.patternData(y + 16)
                For x As Integer = 0 To 7 '8 To 15
                    'TempValue = spriteData.patternData(y + 16) And Me.bitMASKi(x - 8)

                    If ((TempValue >> x) And 1) = 1 Then 'TempValue = Me.bitMASKi(x - 8) Then
                        spriteLines.Item(y)(15 - x) = True
                    Else
                        spriteLines.Item(y)(15 - x) = False
                    End If
                Next
            Next

        End If

        Me.InkColor = spriteData.InkColor
        Me.BackgroundColor = spriteData.BackgroundColor

        Me.SpriteName = spriteData.Name
        Me.PatternNumber = spriteData.Index

        Me._WorkSprite.Name = spriteData.Name
        Me._WorkSprite.Index = spriteData.Index
        Me._WorkSprite.Size = Me.SpriteSize
        Me._WorkSprite.Mode = Me.SpriteMode
        Me._WorkSprite.InkColor = spriteData.InkColor
        Me._WorkSprite.BackgroundColor = spriteData.BackgroundColor
        Me._WorkSprite.Palette = Me._Palette
        'Me._WorkSprite.refresh()

        'Me.Refresh()
        Me.ShowSprite()
        'Application.DoEvents()

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



    '''' <summary>
    '''' Inicializa un sprite eliminado toda la información del editor.
    '''' </summary>
    '''' <remarks></remarks>
    'Public Sub NewSprite() Implements ISpriteContainer.NewSprite

    '    Me.inkColor = 15
    '    Me.bgColor = 0

    '    Me.spriteLines.Clear()

    '    Me.PatternNumber = 0
    '    Me.SpriteName = ""
    '    Me._WorkSprite = Nothing

    '    'ClearUndo()

    '    RaiseEvent SpriteInfoChanged(Me.SpriteName, Me.PatternNumber)

    'End Sub



    ''' <summary>
    ''' Borra el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub ClearSprite() Implements ISpriteContainer.ClearSprite

        Me.spriteLines.Clear()

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Voltear horizontalmente el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub FlipHorizontal() Implements ISpriteContainer.FlipHorizontal

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        'Dim tempPixelData(_matrixdataSize) As Boolean
        'Dim tsize As Integer = _HIGH + 1

        AddUndo()

        'tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                'pixelData(y * tsize + x) = tempPixelData(y * tsize + (_WIDTH - x))
                Me.spriteLines.Item(y)(x) = tempPixelData.Item(y)(_WIDTH - x)
            Next

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Voltear verticalmente el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub FlipVertical() Implements ISpriteContainer.FlipVertical

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        For y As Integer = 0 To _HIGH
            Me.spriteLines.Item(y) = tempPixelData.Item(_HIGH - y)   '.Clone()    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO no permite hacer un clone. Desconozco si al ser un Array realiza una copia automatica o pasa una referencia ???
            'For x As Integer = 0 To _WIDTH
            '    pixelData(y * tsize + x) = tempPixelData((_HIGH - y) * tsize + x)
            'Next
        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Rotacion a la derecha del grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub RotateRight() Implements ISpriteContainer.RotateRight

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        AddUndo()

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                'pixelData(x * tsize + y) = tempPixelData((_HIGH - y) * tsize + x)
                Me.spriteLines.Item(y)(x) = tempPixelData.Item(_WIDTH - x)(y)
            Next

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Rotacion a la izquierda del grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub RotateLeft() Implements ISpriteContainer.RotateLeft

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        AddUndo()

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                'pixelData(x * tsize + y) = tempPixelData(y * tsize + (_WIDTH - x))
                Me.spriteLines.Item(y)(x) = tempPixelData.Item(x)(_HIGH - y)
            Next

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Desplaza un punto a la izquierda, el grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub MoveLeft(ByVal rotate As Boolean) Implements ISpriteContainer.MoveLeft

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        Dim CarryFlag As Boolean = False

        AddUndo()

        For y As Integer = 0 To _HIGH

            If rotate = True Then
                CarryFlag = Me.spriteLines.Item(y)(0)
            End If

            For x As Integer = 0 To _WIDTH - 1
                'pixelData(y * tsize + x) = tempPixelData(y * tsize + x + 1)
                Me.spriteLines.Item(y)(x) = tempPixelData.Item(y)(x + 1)
            Next
            Me.spriteLines.Item(y)(_WIDTH) = CarryFlag

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Desplaza un punto a la derecha, el grafico del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub MoveRight(ByVal rotate As Boolean) Implements ISpriteContainer.MoveRight

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        Dim CarryFlag As Boolean = False

        AddUndo()

        For y As Integer = 0 To _HIGH

            If rotate = True Then
                CarryFlag = Me.spriteLines.Item(y)(_WIDTH)
            End If

            For x As Integer = 0 To _WIDTH - 1
                Me.spriteLines.Item(y)(x + 1) = tempPixelData.Item(y)(x)
            Next
            Me.spriteLines.Item(y)(0) = CarryFlag

        Next

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Desplaza un punto hacia arriba el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub MoveUp(ByVal rotate As Boolean) Implements ISpriteContainer.MoveUp

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        Dim rotateLine As Boolean() = tempPixelData.Item(0)

        For y As Integer = 0 To _HIGH - 1
            Me.spriteLines.Item(y) = tempPixelData.Item(y + 1)   '.Clone()
        Next

        If rotate = True Then
            Me.spriteLines.Item(_HIGH) = rotateLine
        Else
            ' clear the last line
            For x As Integer = 0 To _WIDTH
                Me.spriteLines.Item(_HIGH)(x) = False
            Next
        End If

        ShowSprite()

    End Sub



    ''' <summary>
    ''' Desplaza un punto hacia abajo el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub MoveDown(ByVal rotate As Boolean) Implements ISpriteContainer.MoveDown

        Dim tempPixelData As MatrixData = Me.spriteLines.Clone()

        Dim rotateLine As Boolean() = tempPixelData.Item(_HIGH)

        For y As Integer = 0 To _HIGH - 1
            Me.spriteLines.Item(y + 1) = tempPixelData.Item(y)   '.Clone()
        Next

        If rotate = True Then
            Me.spriteLines.Item(0) = rotateLine
        Else
            ' clear first line
            For x As Integer = 0 To _WIDTH
                Me.spriteLines.Item(0)(x) = False
            Next
        End If

        ShowSprite()

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


        Dim ink As Boolean = True

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
                SetPixel(posX, posY, ink, True) 'pinta/draw


            Case STATE_TOOL.LINE

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    Me.putPixelZoom(posX, posY, ink)
                End If

            Case STATE_TOOL.RECTANGLE

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    Me.putPixelZoom(posX, posY, ink)
                End If

            Case STATE_TOOL.RECTANGLE_FILL

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    Me.putPixelZoom(posX, posY, ink)
                End If


            Case STATE_TOOL.ELLIPSE

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    Me.putPixelZoom(posX, posY, ink)
                End If

            Case STATE_TOOL.ELLIPSE_FILL

                If _step = 0 Then
                    AddUndo()
                    _step = 1
                    _step0_posX = posX
                    _step0_posY = posY
                    Me.putPixelZoom(posX, posY, ink)
                End If


        End Select

        Application.DoEvents()
        'Me.spritePicture.Refresh()

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

        If posX = old_posX And posY = old_posY Then
            Exit Sub
        End If

        old_posX = posX
        old_posY = posY


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

        Dim ink As Boolean = True

        showCoordinates(posX, posY)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            ink = True 'pinta/draw
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ink = False 'borra/erase
        Else
            Exit Sub
        End If



        'If Me._state = STATE_TOOL.DRAW Then
        '    If e.Button = Windows.Forms.MouseButtons.Left Then
        '        SetPixel(posX, posY, True, True) 'pinta/draw
        '    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
        '        SetPixel(posX, posY, False, True) 'borra/erase
        '    End If
        'End If


        Select Case Me._state
            Case STATE_TOOL.DRAW
                SetPixel(posX, posY, ink, True) 'pinta/draw


            Case STATE_TOOL.LINE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    DrawLine(_step0_posX, _step0_posY, posX, posY, ink, False)
                End If


            Case STATE_TOOL.RECTANGLE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    DrawRectangle(_step0_posX, _step0_posY, posX, posY, ink, False)
                End If


            Case STATE_TOOL.RECTANGLE_FILL

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    DrawRectangleFill(_step0_posX, _step0_posY, posX, posY, ink, False)
                End If


            Case STATE_TOOL.ELLIPSE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    DrawEllipse(_step0_posX, _step0_posY, posX, posY, False, ink, False)
                End If


            Case STATE_TOOL.ELLIPSE_FILL

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    DrawEllipse(_step0_posX, _step0_posY, posX, posY, True, ink, False)
                End If

        End Select

        Application.DoEvents()
        'Me.SpriteContainerPanel.Refresh()

    End Sub



    Public Sub SpriteContainerPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SpriteContainerPanel.MouseUp
        Dim posX As Integer = Int(e.X / 16)
        Dim posY As Integer = Int(e.Y / 16)

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


        Dim ink As Boolean = True

        If e.Button = Windows.Forms.MouseButtons.Left Then
            ink = True 'pinta/draw
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ink = False 'borra/erase
        Else
            Exit Sub
        End If

        Select Case Me._state
            'Case STATE_TOOL.DRAW
            '    AddUndo()
            '    SetPixel(posX, posY, ink, True) 'pinta/draw


            Case STATE_TOOL.LINE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    _step = 0
                    DrawLine(_step0_posX, _step0_posY, posX, posY, ink, True)
                End If


            Case STATE_TOOL.RECTANGLE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    _step = 0
                    DrawRectangle(_step0_posX, _step0_posY, posX, posY, ink, True)
                End If


            Case STATE_TOOL.RECTANGLE_FILL

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    _step = 0
                    DrawRectangleFill(_step0_posX, _step0_posY, posX, posY, ink, True)
                End If


            Case STATE_TOOL.ELLIPSE

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    _step = 0
                    DrawEllipse(_step0_posX, _step0_posY, posX, posY, False, ink, True)
                End If


            Case STATE_TOOL.ELLIPSE_FILL

                If _step = 1 Then
                    ShowSpriteZoomPanel()
                    _step = 0
                    DrawEllipse(_step0_posX, _step0_posY, posX, posY, True, ink, True)
                End If


            Case STATE_TOOL.FILL
                AddUndo()
                Fill(posX, posY, ink)


        End Select

    End Sub



    'Public Function calRadio(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer) As Integer
    '    ' get a radio (thanks to JamQue) 
    '    ' Pythagoras' Theorem hypotenuse calc
    '    Dim radio As Integer
    '    Dim squareA As Integer = Math.Abs(x0 - x1)
    '    Dim squareB As Integer = Math.Abs(y0 - y1)
    '    radio = CInt(Math.Sqrt((squareA * squareA) + (squareB * squareB)))
    '    Return radio
    'End Function



    Public Sub DrawLine(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal ink As Boolean, ByVal write As Boolean)
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
                SetPixel(y0, posX, ink, write)
            Else
                SetPixel(posX, y0, ink, write)
            End If

            err -= dy
            If err < 0 Then
                y0 += ystep
                err += dx
            End If

        Next

    End Sub



    Public Sub DrawRectangle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean, ByVal write As Boolean)

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
            SetPixel(i, posY0, ink, write)
            SetPixel(i, posY0 + high, ink, write)
        Next

        For i = posY0 To posY0 + high
            SetPixel(posX0, i, ink, write)
            SetPixel(posX0 + width, i, ink, write)
        Next

    End Sub



    Public Sub DrawRectangleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal posX1 As Integer, ByVal posY1 As Integer, ByVal ink As Boolean, ByVal write As Boolean)
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
                SetPixel(x, y, ink, write)
            Next
        Next

    End Sub






    Public Sub DrawEllipse(ByVal posX As Integer, ByVal posY As Integer, ByVal posX2 As Integer, ByVal posY2 As Integer, ByVal _fill As Boolean, ByVal ink As Boolean, ByVal write As Boolean)

        Dim aBitmap As Bitmap
        Dim aGraphics As Graphics

        Dim width As Integer = posX2 - posX
        Dim height As Integer = posY2 - posY

        If width = 0 Or height = 0 Then
            Exit Sub
        End If

        aBitmap = New Bitmap(_WIDTH + 1, _HIGH + 1)
        aGraphics = Graphics.FromImage(aBitmap)

        If width < 0 Then
            width *= -1
            posX = posX2
        End If

        If height < 0 Then
            height *= -1
            posY = posY2
        End If

        aGraphics.Clear(Color.Black)

        aGraphics.DrawEllipse(New Pen(Color.FromArgb(255, 255, 255, 255), 1), posX, posY, width, height)

        If _fill = True Then
            aGraphics.FillEllipse(New SolidBrush(Color.FromArgb(255, 255, 255, 255)), posX, posY, width, height)
        End If

        DrawShape(aBitmap, ink, write)

    End Sub



    Public Sub DrawShape(ByVal aBitmap As Bitmap, ByVal ink As Boolean, ByVal write As Boolean)

        Dim x As Integer
        Dim y As Integer

        For y = 0 To _HIGH
            For x = 0 To _WIDTH
                If Color.Equals(aBitmap.GetPixel(x, y), Color.FromArgb(255, 255, 255, 255)) Then
                    SetPixel(x, y, ink, write)
                End If
            Next
        Next

    End Sub




    'Public Sub DrawCircle(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    Dim f As Integer = 1 - radio
    '    Dim ddF_x As Integer = 1
    '    Dim ddF_y As Integer = -2 * radio
    '    Dim x As Integer = 0
    '    Dim y As Integer = radio

    '    SetPixel(posX0, posY0 + radio, ink, write)
    '    SetPixel(posX0, posY0 - radio, ink, write)
    '    SetPixel(posX0 + radio, posY0, ink, write)
    '    SetPixel(posX0 - radio, posY0, ink, write)

    '    Do While x < y
    '        If f >= 0 Then
    '            y -= 1
    '            ddF_y += 2
    '            f += ddF_y
    '        End If

    '        x += 1
    '        ddF_x += 2
    '        f += ddF_x

    '        SetPixel(posX0 + x, posY0 + y, ink, write)
    '        SetPixel(posX0 - x, posY0 + y, ink, write)
    '        SetPixel(posX0 + x, posY0 - y, ink, write)
    '        SetPixel(posX0 - x, posY0 - y, ink, write)

    '        SetPixel(posX0 + y, posY0 + x, ink, write)
    '        SetPixel(posX0 - y, posY0 + x, ink, write)
    '        SetPixel(posX0 + y, posY0 - x, ink, write)
    '        SetPixel(posX0 - y, posY0 - x, ink, write)
    '    Loop

    'End Sub



    'Public Sub DrawCircleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal radio As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    Dim f As Integer = 1 - radio
    '    Dim ddF_x As Integer = 1
    '    Dim ddF_y As Integer = -2 * radio
    '    Dim x As Integer = 0
    '    Dim y As Integer = radio

    '    Dim i As Integer

    '    For i = posY0 - radio To posY0 + radio
    '        SetPixel(posX0, i, ink, write)
    '    Next


    '    Do While x < y
    '        If f >= 0 Then
    '            y -= 1
    '            ddF_y += 2
    '            f += ddF_y
    '        End If

    '        x += 1
    '        ddF_x += 2
    '        f += ddF_x

    '        For i = posY0 - y To posY0 + y
    '            SetPixel(posX0 + x, i, ink, write)
    '            SetPixel(posX0 - x, i, ink, write)
    '        Next

    '        For i = posY0 - x To posY0 + x
    '            SetPixel(posX0 + y, i, ink, write)
    '            SetPixel(posX0 - y, i, ink, write)
    '        Next

    '    Loop

    'End Sub



    'Public Sub DrawEllipse(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    If width = 0 Or height = 0 Then
    '        Exit Sub
    '    End If

    '    Dim incc As Decimal = (width / 2) / (height / 2)
    '    Dim lineSize As Decimal = width / incc

    '    For y As Integer = 1 To Fix(height / 2)

    '        For xp = 0 To Fix(lineSize)
    '            SetPixel(xp, y - 1, ink, write)
    '        Next
    '        incc += (width / 2) / y
    '        lineSize += incc

    '    Next

    'End Sub



    'https://sites.google.com/site/ruslancray/lab/projects/bresenhamscircleellipsedrawingalgorithm/bresenham-s-circle-ellipse-drawing-algorithm
    'Public Sub DrawEllipse(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)
    'Dim a2 As Integer = width * width
    'Dim b2 As Integer = height * height
    'Dim fa2 As Integer = 4 * a2
    'Dim fb2 As Integer = 4 * b2
    'Dim x As Integer
    'Dim y As Integer
    'Dim sigma As Integer

    '/* first half */
    'y = height
    'sigma = 2 * b2 + a2 * (1 - 2 * height)
    'x = 0
    'Do While b2 * x <= a2 * y
    '    SetPixel(posX + x, posY + y, ink, write)
    '    SetPixel(posX - x, posY + y, ink, write)

    '    SetPixel(posX + x, posY - y, ink, write)
    '    SetPixel(posX - x, posY - y, ink, write)

    '    If (sigma >= 0) Then
    '        sigma += fa2 * (1 - y)
    '        y -= 1
    '    End If

    '    sigma += b2 * ((4 * x) + 6)
    '    x += 1
    'Loop


    ''/* second half */
    'x = width
    'sigma = 2 * a2 + b2 * (1 - 2 * width)
    'y = 0
    'Do While a2 * y <= b2 * x
    '    SetPixel(posX + x, posY + y, ink, write)
    '    SetPixel(posX - x, posY + y, ink, write)

    '    SetPixel(posX + x, posY - y, ink, write)
    '    SetPixel(posX - x, posY - y, ink, write)

    '    If (sigma >= 0) Then
    '        sigma += fb2 * (1 - x)
    '        x -= 1
    '    End If

    '    sigma += a2 * ((4 * y) + 6)
    '    y += 1
    'Loop

    'End Sub






    'Public Sub DrawEllipseFill2(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)
    'Dim a2 As Integer = width * width
    'Dim b2 As Integer = height * height
    'Dim fa2 As Integer = 4 * a2
    'Dim fb2 As Integer = 4 * b2
    'Dim x As Integer
    'Dim y As Integer
    'Dim sigma As Integer
    'Dim xp As Integer


    '/* first half */
    'y = height
    'sigma = 2 * b2 + a2 * (1 - 2 * height)
    'x = 0
    'Do While b2 * x <= a2 * y
    '    For xp = posX - x To posX + x
    '        SetPixel(xp, posY + y, ink, write)
    '        SetPixel(xp, posY - y, ink, write)
    '    Next

    '    If (sigma >= 0) Then
    '        sigma += fa2 * (1 - y)
    '        y -= 1
    '    End If

    '    sigma += b2 * ((4 * x) + 6)
    '    x += 1
    'Loop


    ''/* second half */
    'x = width
    'sigma = 2 * a2 + b2 * (1 - 2 * width)
    'y = 0
    'Do While a2 * y <= b2 * x
    '    For xp = posX - x To posX + x
    '        SetPixel(xp, posY + y, ink, write)
    '        SetPixel(xp, posY - y, ink, write)
    '    Next

    '    If (sigma >= 0) Then
    '        sigma += fb2 * (1 - x)
    '        x -= 1
    '    End If

    '    sigma += a2 * ((4 * y) + 6)
    '    y += 1
    'Loop

    'End Sub



    ' http://www.pracspedia.com/CG/midpointellipse.html
    'Public Sub DrawEllipse02(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    ' ellipse positio
    '    Dim xc As Integer = posX
    '    Dim yc As Integer = posY

    '    Dim x, y As Integer
    '    Dim p As Double


    '    ' ellipse radius
    '    Dim rx As Integer = Math.Floor(width / 2)
    '    Dim ry As Integer = Math.Floor(height / 2)


    '    'Region 1
    '    p = ry * ry - rx * rx * ry + rx * rx / 4
    '    x = 0
    '    y = ry
    '    While 2.0 * ry * ry * x <= 2.0 * rx * rx * y

    '        If (p < 0) Then
    '            x += 1
    '            p = p + 2 * ry * ry * x + ry * ry
    '        Else
    '            x += 1
    '            y -= 1
    '            p = p + 2 * ry * ry * x - 2 * rx * rx * y - ry * ry
    '        End If
    '        SetPixel(xc + x, yc + y, ink, write)
    '        SetPixel(xc + x, yc - y, ink, write)
    '        SetPixel(xc - x, yc + y, ink, write)
    '        SetPixel(xc - x, yc - y, ink, write)
    '    End While

    '    'Region 2
    '    p = ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - rx * rx * ry * ry

    '    While y > 0

    '        If (p <= 0) Then
    '            x += 1
    '            y -= 1
    '            p = p + 2 * ry * ry * x - 2 * rx * rx * y + rx * rx
    '        Else
    '            y -= 1
    '            p = p - 2 * rx * rx * y + rx * rx
    '        End If
    '        SetPixel(xc + x, yc + y, ink, write)
    '        SetPixel(xc + x, yc - y, ink, write)
    '        SetPixel(xc - x, yc + y, ink, write)
    '        SetPixel(xc - x, yc - y, ink, write)
    '    End While

    'End Sub




    ' http://groups.csail.mit.edu/graphics/classes/6.837/F98/Lecture6/circle.html
    'Public Sub DrawEllipseFillSize(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    Dim dx As Double = 0
    '    Dim dy As Double = 0
    '    Dim x As Integer
    '    Dim y As Integer

    '    Dim wsize As Integer
    '    Dim i As Integer

    '    Dim radioH As Integer = Math.Floor(width / 2)
    '    Dim radioV As Integer = Math.Floor(height / 2)

    '    posX = posX + radioH
    '    posY = posY + radioV

    '    For y = 0 To radioV
    '        For x = 0 To radioH
    '            dx = x / (width / 2)
    '            dy = y / (height / 2)
    '            If dx * dx + dy * dy <= 1 Then
    '                SetPixel(posX + x, posY + y, ink, write)
    '                SetPixel(posX + x, posY - y, ink, write)
    '                SetPixel(posX - x, posY + y, ink, write)
    '                SetPixel(posX - x, posY - y, ink, write)
    '            End If
    '        Next
    '    Next


    '    'If width > 0 And height > 0 Then
    '    '    For y = 1 To height + 1
    '    '        wsize = Math.Ceiling(Math.Sin((Math.PI / 180) * ((180 / (height + 2)) * y)) * width)
    '    '        x = posX + Math.Floor(width / 2) - Math.Floor(wsize / 2)
    '    '        For i = 0 To wsize
    '    '            SetPixel(x + i, posY + y - 1, ink, write)
    '    '        Next
    '    '    Next
    '    'End If

    '    'for(int y=-height; y<=height; y++) {
    '    '    for(int x=-width; x<=width; x++) {
    '    '        double dx = (double)x / (double)width;
    '    '        double dy = (double)y / (double)height;
    '    '                If (dx * dx + dy * dy <= 1) Then
    '    '            setpixel(origin.x+x, origin.y+y);
    '    '    }
    '    '}


    'End Sub



    'Public Sub DrawCircleFill(ByVal posX0 As Integer, ByVal posY0 As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ink As Boolean, ByVal write As Boolean)

    '    Dim hh As Integer = height * height
    '    Dim ww As Integer = width * width
    '    Dim hhww As Integer = hh * ww
    '    Dim x0 As Integer = width
    '    Dim dx As Integer = 0
    '    Dim x As Integer
    '    Dim y As Integer
    '    Dim x1 As Integer

    '    ' do the horizontal diameter
    '    For x = -width To x <= width
    '        SetPixel(posX0 + x, posY0, ink, write)
    '    Next


    '    '// now do both halves at the same time, away from the diameter
    '    'for (int y = 1; y <= height; y++)
    '    For y = 1 To y <= height
    '        x1 = x0 - (dx - 1) ' try slopes of dx - 1 or more
    '        'for ( ; x1 > 0; x1--)
    '        '                    If (x1 * x1 * hh + y * y * ww <= hhww) Then
    '        '            break;
    '        dx = x0 - x1 ' current approximation of the slope
    '        x0 = x1

    '        For x = -x0 To x <= x0
    '            SetPixel(posX0 + x, posY0 - y, ink, write)
    '            SetPixel(posX0 - x, posY0 + y, ink, write)
    '        Next
    '    Next

    'End Sub



    Public Sub Fill(ByVal x As Integer, ByVal y As Integer, ByVal ink As Boolean)
        If GetPixel(x, y) = ink Then
            Return
        End If
        SetPixel(x, y, ink, True)
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

        'Dim tsize As Integer = _HIGH + 1

        AddUndo()

        For y As Integer = 0 To _HIGH
            For x As Integer = 0 To _WIDTH
                Me.spriteLines.Item(y)(x) = Not Me.spriteLines.Item(y)(x)
            Next
        Next

        'For y As Integer = 0 To _HIGH
        '    For x As Integer = 0 To _WIDTH
        '        pixelData(y * tsize + x) = Not pixelData(y * tsize + x)
        '    Next
        'Next

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
        RaiseEvent MatrixCoordinates(posX, posY)
    End Sub



    ''' <summary>
    ''' Pinta un punto.
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal state As Boolean, ByVal write As Boolean)

        'Dim tsize As Integer = _WIDTH + 1

        If x < 0 Or x > _WIDTH Or y < 0 Or y > _HIGH Then
            Exit Sub
        End If

        If write = True Then
            'Me.pixelData(cY * tsize + cX) = state
            Me.spriteLines.Item(y)(x) = state
            Me.ShowPixel(x, y, state)
        Else
            Me.putPixelZoom(x, y, state)
        End If

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub



    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Boolean
        'Dim tsize As Integer = _WIDTH + 1
        Return Me.spriteLines.Item(y)(x)
        'Return Me.pixelData(cY * tsize + cX)
    End Function



    Private Sub ShowPixel(ByVal x As Integer, ByVal y As Integer, ByVal state As Boolean)
        putPixelZoom(x, y, state)
        putPixelPreview(x, y, state)
    End Sub



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
            'Dim aColor As ColorMSX
            Dim aColor As Byte

            Dim cX As Integer = Xpos * 16 + 1
            Dim cY As Integer = Ypos * 16 + 1

            If value Then
                If SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                    aColor = Me.colorValues(Ypos)
                    'aColor = Me.PaletteData.GetColor(Me.colorValues(Ypos))
                Else
                    aColor = Me._inkColor
                End If
            Else
                aColor = Me._bgColor
            End If

            Me.panelGraphics.FillRectangle(New SolidBrush(Me._Palette.GetRGBColor(aColor)), cX, cY, 15, 15)

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

        Dim aColorID As Integer
        Dim tmpColor As Color

        If state Then
            If SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                aColorID = Me.colorValues(Ypos)
            Else
                aColorID = Me._inkColor
            End If
        Else
            aColorID = Me._bgColor
        End If

        Xpos *= 2
        Ypos *= 2

        tmpColor = Me._Palette.GetRGBColor(aColorID)
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

        'If state Then
        '    ORselectedButton.BackColor = System.Drawing.Color.PaleGreen
        'Else
        '    ORselectedButton.BackColor = System.Drawing.Color.Gainsboro
        'End If

        For i As Integer = 0 To Me._HIGH
            ORvalues(i) = state
        Next

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
                Me.orPic(i).BackColor = System.Drawing.Color.DarkGray
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
    Public Sub ShowColorLines()
        Dim colorIndex As Integer

        For i As Integer = 0 To _HIGH
            colorIndex = Me.colorValues(i)
            Me.colorPic(i).BackColor = Me._Palette.GetRGBColor(colorIndex)
            Me.ToolTip1.SetToolTip(Me.colorPic(i), CStr(colorIndex))
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

        Dim colorItem As Button = CType(sender, Button)
        Dim newPoint As Point = colorItem.Parent.PointToScreen(colorItem.Location)

        If aColorSelector.ShowDialog(Me._Palette, newPoint) = DialogResult.OK Then
            colorINKPictureBox.BackColor = Me._Palette.GetRGBColor(aColorSelector.ColorSelected)
            Me.InkColor = aColorSelector.ColorSelected

            If SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                For Each aPic As System.Windows.Forms.Button In Me.colorPic
                    aPic.BackColor = Me._Palette.GetRGBColor(Me.InkColor)
                    Me.colorValues(aPic.TabIndex) = Me.InkColor
                    Me.ToolTip1.SetToolTip(aPic, CStr(Me.InkColor))
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

        Dim colorItem As Button = CType(sender, Button)
        Dim newPoint As Point = colorItem.Parent.PointToScreen(colorItem.Location)

        If aColorSelector.ShowDialog(Me._Palette, newPoint) = DialogResult.OK Then
            colorBGPictureBox.BackColor = Me._Palette.GetRGBColor(aColorSelector.ColorSelected)
            changeBGColor(aColorSelector.ColorSelected)
            'Me.spritePicture.Refresh()
        End If
    End Sub



    ' crea una copia del sprite del editor con un nuevo ID

    'Public Sub Copy() Implements ISpriteContainer.Copy
    '    If Not Me.Sprite Is Nothing Then
    '        Me.Sprite = Me.Sprite.copy()
    '    End If
    'End Sub


    Public Sub SetState(ByVal newState As Integer) Implements ISpriteContainer.SetState
        Me._state = newState
        _step = 0
    End Sub



    ''' <summary>
    ''' For test purposes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub TestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetTest()
    End Sub



    Overridable Sub SetTest()
        Dim testSprite() As Byte = New Byte() {&HF0, &HF0, &HF0, &HF0, &HF, &HF, &HF, &HF, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF}
        Dim demoSprite As New SpriteMSX
        demoSprite.patternData = testSprite

        demoSprite.InkColor = 15
        demoSprite.BackgroundColor = 0

        demoSprite.Name = "TEST"

        Me.SetSprite(demoSprite)
    End Sub


    Public Sub TestButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Application.DoEvents() ' truco para solucionar el problema en el redibujado del control cuando la ventana recupera el foco
    End Sub




    ''' <summary>
    ''' Modifica el estado del bit de OR, en una linea.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ORBitLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim anORitem As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)

        If Me.ORvalues(anORitem.TabIndex) Then
            anORitem.BackColor = System.Drawing.Color.DarkGray
        Else
            anORitem.BackColor = System.Drawing.Color.PaleGreen
        End If

        Me.ORvalues(anORitem.TabIndex) = Not Me.ORvalues(anORitem.TabIndex)

    End Sub



    ''' <summary>
    ''' Selección del color de tinta de una linea.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorINKLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim colorItem As Button = CType(sender, Button)
        Dim newPoint As Point = colorItem.Parent.PointToScreen(colorItem.Location)

        If aColorSelector.ShowDialog(Me._Palette, newPoint) = DialogResult.OK Then
            sender.BackColor = Me._Palette.GetRGBColor(aColorSelector.ColorSelected)
            Me.colorValues(sender.TabIndex) = aColorSelector.ColorSelected
            ShowSprite()
        End If

    End Sub



    Public Sub ClearUndo()
        undo.Clear()
        redo.Clear()
    End Sub



    Public Sub AddUndo() Implements ISpriteContainer.AddUndo
        undo.Push(New UndoItem(Me.spriteLines, Me.colorValues, Me.ORvalues))
    End Sub



    Public Sub AddRedo()
        redo.Push(New UndoItem(Me.spriteLines, Me.colorValues, Me.ORvalues))
    End Sub



    Public Sub SetUndo() Implements ISpriteContainer.SetUndo
        Dim tmpUndoItem As UndoItem
        If undo.Count > 0 Then
            AddRedo()
            tmpUndoItem = undo.Pop
            Me.spriteLines = tmpUndoItem.spriteLines
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
            Me.spriteLines = tmpUndoItem.spriteLines
            Me.colorValues = tmpUndoItem.colorValues
            Me.ORvalues = tmpUndoItem.ORvalues
            ShowSprite()
        End If
    End Sub


End Class
