Public Class _SpritePanel16mode2
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

    Private colorPic(15) As PictureBox
    Private orPic(15) As PictureBox
    Private colorValues(15) As Byte

    Private SpriteBitmap As Bitmap
    Private panelGraphics As Graphics

    Private _ORselected As Boolean = False

    Private _state As STATE_TOOL

    Private _step As Integer

    Private _step0_posX As Integer
    Private _step0_posY As Integer

    Dim undo As New SizedStack(16)
    Dim redo As New SizedStack(16)

    Private _WIDTH As Integer = 15
    Private _HIGH As Integer = 15

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


    'Public Property WorkSprite() As SpriteMSX Implements ISpriteContainer.WorkSprite
    '    Get
    '        Return Me._WorkSprite
    '    End Get
    '    Set(ByVal value As SpriteMSX)
    '        Me._WorkSprite = value
    '    End Set
    'End Property



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
                Me.ToolTip1.SetToolTip(colorINKPictureBox, "Ink color for all lines: " + CStr(value.id))
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
                For i As Integer = 0 To 15
                    Me.colorPic(i).BackColor = _PaletteData.getRGB(Me.colorValues(i))
                Next
                ShowSprite()
            End If
        End Set
    End Property



    Public Sub New()

        Dim i As Integer

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.inkColor = New MSXcolor(15, 7, 7, 7)
        Me.bgColor = New MSXcolor(0, 0, 0, 0)

        Me.bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

        Me.panelGraphics = Me.SpriteContainerPanel.CreateGraphics

        Me.SpriteBitmap = New Bitmap((_WIDTH + 1) * 2, (_HIGH + 1) * 2)

        _matrixdataSize = ((_WIDTH + 1) * (_HIGH + 1)) - 1
        ReDim pixelData(_matrixdataSize)

        For i = 0 To _HIGH
            GenerateColorLine(i)
        Next

        Me.NewSprite()

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub



    Private Sub SpritePanel16mode2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SpriteContainerPanel.Refresh()
        'Me._WorkSprite = GetSprite()
        Application.DoEvents()
    End Sub



    Private Sub SpritePanel16_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        ShowSprite()

        Me.panelGraphics.DrawLine(Pens.Orange, 128, 0, 128, 256)
        Me.panelGraphics.DrawLine(Pens.Orange, 0, 128, 256, 128)

        'Application.DoEvents()

    End Sub



    Private Sub ShowSprite()

        If Not Me.PaletteData Is Nothing Then
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

        'Dim aPixel As SpritePixel
        Me._WorkSprite = spriteData.clone()

        For y As Integer = 0 To 15

            TempValue = 0
            For x As Integer = 0 To 7
                contador = (y * 16) + (15 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)

                TempValue = spriteData.gfxData(y + 16) And Me.bite_MASKs(x)

                If TempValue = Me.bite_MASKs(x) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next

            TempValue = 0
            For x As Integer = 8 To 15
                contador = (y * 16) + (15 - x)
                'aBit = (pixelsData(Counter).tabStop)?(0:1)


                TempValue = spriteData.gfxData(y) And Me.bite_MASKs(x - 8)

                If TempValue = Me.bite_MASKs(x - 8) Then
                    pixelData(contador) = True
                Else
                    pixelData(contador) = False
                End If

            Next


            'tmpData(y) = TempValue
        Next


        ' actualiza los colores
        Me.inkColor = Me.PaletteData.GetColor(spriteData.InkColor)
        Me.changeBGColor(Me.PaletteData.GetColor(spriteData.BGcolor))

        Me.colorValues = spriteData.colorData.Clone

        For i As Integer = 0 To 15
            'Me.colorPic(i).BackColor = _PaletteData.getRGB(_PaletteData.GetColor(spriteData.colorData(i)))
            Me.colorPic(i).BackColor = _PaletteData.getRGB(spriteData.colorData(i))
            orPic(i).TabStop = spriteData.ORbitData(i)
        Next
        ' end colores


        ' actualiza y visualiza los datos del campo OR de linea
        If spriteData.ORbitData Is Nothing Then
            For i As Integer = 0 To 15
                orPic(i).TabStop = False
            Next
        Else
            For i As Integer = 0 To 15
                orPic(i).TabStop = spriteData.ORbitData(i)
            Next
        End If

        Me.showORstates()

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
        'Dim newSprite As SpriteMSX

        Dim tmpData(31) As Byte
        'ReDim tmpData(31)

        Dim tmpORData(15) As Boolean

        Dim aBit As Byte
        Dim TempValue As Byte = 0
        Dim Counter As Integer = 0
        Dim byteCounter As Integer = 0

        'Dim aPixel As SpritePixel

        For y As Integer = 0 To 15
            TempValue = 0
            For x As Integer = 8 To 15
                Counter = (y * 16) + (15 - x)

                If pixelData(Counter) Then
                    aBit = 1
                Else
                    aBit = 0
                End If

                TempValue = TempValue + aBit * 2 ^ (x - 8)
            Next
            tmpData(byteCounter) = TempValue
            byteCounter += 1
        Next

        For y As Integer = 0 To 15
            TempValue = 0
            For x As Integer = 0 To 7
                Counter = (y * 16) + (15 - x)

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

        For y As Integer = 0 To 15
            tmpORData(y) = orPic(y).TabStop
        Next

        If Me._WorkSprite Is Nothing Then
            Me._WorkSprite = New SpriteMSX(Me.SpriteName, SpriteBitmap.Clone, SpriteMSX.SPRITE_SIZE.SIZE16, Me.inkColor.id, Me.bgColor.id, tmpData.Clone(), colorValues.Clone(), tmpORData.Clone(), Me.PaletteData)
        Else
            Me._WorkSprite.name = Me.SpriteName

            Me._WorkSprite.size = SpriteMSX.SPRITE_SIZE.SIZE16
            Me._WorkSprite.mode = SpriteMSX.SPRITE_MODE.COLOR

            Me._WorkSprite.gfxData = tmpData.Clone
            Me._WorkSprite.colorData = colorValues.Clone
            Me._WorkSprite.ORbitData = tmpORData.Clone

            Me._WorkSprite.aBitmap = SpriteBitmap.Clone

            Me._WorkSprite.InkColor = Me.inkColor.id
            Me._WorkSprite.BGcolor = Me.bgColor.id

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
    ''' Borra el dibujo del sprite y la información de color y bit de OR.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSprite() Implements ISpriteContainer.ClearSprite

        AddUndo()

        _step = 0

        For i As Integer = 0 To _matrixdataSize
            pixelData(i) = False
        Next

        For Each aPic As PictureBox In Me.colorPic
            aPic.BackColor = _PaletteData.getRGB(Me.inkColor)
            Me.colorValues(aPic.TabIndex) = Me.inkColor.id
            'orPic(aPic.TabIndex).TabStop = False
        Next

        SetORstate(False)

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
        Dim tempORData(_HIGH) As Boolean
        Dim tempColorData(_HIGH) As Byte
        Dim tsize As Integer = _HIGH + 1

        AddUndo()

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To _HIGH

            For x As Integer = 0 To _WIDTH
                pixelData(y * tsize + x) = tempPixelData((_HIGH - y) * tsize + x)
            Next

        Next

        tempColorData = Me.colorValues.Clone
        For i As Integer = 0 To _WIDTH
            Me.colorValues(i) = tempColorData(_WIDTH - i)
        Next

        For i As Integer = 0 To _HIGH
            tempORData(i) = Me.orPic(_WIDTH - i).TabStop
        Next
        For i As Integer = 0 To 15
            Me.orPic(i).TabStop = tempORData(i)
        Next

        Me.showORstates()
        Me.showColorLines()

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
        Dim tempPixelData(256) As Boolean

        tempPixelData = pixelData.Clone

        For y As Integer = 0 To 15

            For x As Integer = 0 To 14
                pixelData(y * 16 + x + 1) = tempPixelData(y * 16 + x)
            Next
            pixelData(y * 16 + 0) = False

        Next

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto hacia arriba el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveUp() Implements ISpriteContainer.MoveUp
        Dim tempPixelData(256) As Boolean
        Dim tmpORData(15) As Boolean
        Dim tmpColorData(15) As Byte

        tempPixelData = pixelData.Clone

        For x As Integer = 0 To 15

            For y As Integer = 0 To 14
                pixelData(y * 16 + x) = tempPixelData((y + 1) * 16 + x)
            Next
            pixelData(15 * 16 + x) = False

        Next

        For i As Integer = 0 To 15
            tmpORData(i) = Me.orPic(i).TabStop
        Next
        For i As Integer = 0 To 14
            Me.orPic(i).TabStop = tmpORData(i + 1)
        Next
        Me.orPic(15).TabStop = Me._ORselected

        tmpColorData = Me.colorValues.Clone
        For i As Integer = 0 To 14
            Me.colorValues(i) = tmpColorData(i + 1)
        Next
        Me.colorValues(15) = Me.inkColor.id

        Me.showORstates()
        Me.showColorLines()

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Desplaza un punto hacia abajo el sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MoveDown() Implements ISpriteContainer.MoveDown
        Dim tempPixelData(256) As Boolean
        Dim tmpORData(15) As Boolean
        Dim tmpColorData(15) As Byte

        tempPixelData = pixelData.Clone

        For x As Integer = 0 To 15

            For y As Integer = 0 To 14
                pixelData((y + 1) * 16 + x) = tempPixelData(y * 16 + x)
            Next
            pixelData(x) = False

        Next

        For i As Integer = 0 To 15
            tmpORData(i) = Me.orPic(i).TabStop
        Next
        For i As Integer = 1 To 15
            Me.orPic(i).TabStop = tmpORData(i - 1)
        Next
        Me.orPic(0).TabStop = Me._ORselected

        tmpColorData = Me.colorValues.Clone
        For i As Integer = 1 To 15
            Me.colorValues(i) = tmpColorData(i - 1)
        Next
        Me.colorValues(0) = Me.inkColor.id

        Me.showORstates()
        Me.showColorLines()

        ShowSprite()

    End Sub


    ''' <summary>
    ''' Crea los controles graficos para color y bit de OR de una linea determinada.
    ''' </summary>
    ''' <param name="numy"></param>
    ''' <remarks></remarks>
    Private Sub GenerateColorLine(ByVal numy As Integer)

        Dim y As Integer = numy * 16 + 47 '24
        Dim x As Integer = 276

        Dim ORBitLine As PictureBox = New PictureBox
        Dim colorINKLine As PictureBox = New PictureBox

        Me.SuspendLayout()

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

        Me.ResumeLayout(False)

        Me.orPic(numy) = ORBitLine
        Me.colorPic(numy) = colorINKLine

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


    ''' <summary>
    ''' Modifica el estado del bit de OR, en una linea.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ORBitLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender.TabStop Then
            sender.BackColor = System.Drawing.Color.DimGray
        Else
            sender.BackColor = System.Drawing.Color.PaleGreen
        End If

        sender.TabStop = Not sender.TabStop

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

        showCoordinates(posX, posY)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            SetPixel(posX, posY, True) 'pinta/draw
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            SetPixel(posX, posY, False) 'borra/erase
        End If

        'Me.spritePicture.Refresh()

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

        If e.Button = Windows.Forms.MouseButtons.Left Then
            SetPixel(posX, posY, True) 'pinta/draw
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            SetPixel(posX, posY, False) 'borra/erase
        End If

        'Me.spritePicture.Refresh()

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
        ElseIf posX > 15 Then
            posX = 15
        End If

        If posY < 0 Then
            posY = 0
        ElseIf posY > 15 Then
            posY = 15
        End If

        RaiseEvent MatrixCoordinates(posX, posY)
    End Sub


    ''' <summary>
    ''' Pinta un punto.
    ''' </summary>
    ''' <param name="cX"></param>
    ''' <param name="cY"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub SetPixel(ByVal cX As Integer, ByVal cY As Integer, ByVal value As Boolean)

        If cX < 0 Or cX > 15 Or cY < 0 Or cY > 15 Then
            Exit Sub
        End If

        Me.pixelData(cY * 16 + cX) = value

        Me.putPixelZoom(cX, cY, value)
        Me.putPixelPreview(cX, cY, value)

        RaiseEvent SpriteBitmapChanged(Me.SpriteBitmap)

    End Sub


    ''' <summary>
    ''' Pinta un punto en el editor.
    ''' </summary>
    ''' <param name="Xpos"></param>
    ''' <param name="Ypos"></param>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub putPixelZoom(ByVal Xpos As Integer, ByVal Ypos As Integer, ByVal state As Boolean)
        Try
            'If cX < 0 Or cX > 15 Or cY < 0 Or cY > 15 Then
            '    Exit Sub
            'End If
            Dim aColor As MSXcolor

            Dim cX As Integer = Xpos * 16 + 1
            Dim cY As Integer = Ypos * 16 + 1

            If state Then
                If PaletteData Is Nothing Then
                    aColor = Me._inkColor
                Else
                    aColor = Me.PaletteData.GetColor(Me.colorValues(Ypos))
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
    Private Sub putPixelPreview(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal state As Boolean)
        Try

            Dim aColor As MSXcolor
            Dim tmpColor As Color

            If state Then
                If PaletteData Is Nothing Then
                    aColor = Me._inkColor
                Else
                    aColor = _PaletteData.GetColor(Me.colorValues(Ypos))
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

        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' Muestra el estado del bit de OR de cada linea, en cada indicador/boton.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showORstates()
        For Each aPic As PictureBox In Me.orPic
            If aPic.TabStop Then
                aPic.BackColor = System.Drawing.Color.PaleGreen
            Else
                aPic.BackColor = System.Drawing.Color.DimGray
            End If
        Next
    End Sub


    ''' <summary>
    ''' Muestra el color el color de cada linea, en cada indicador/boton.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showColorLines()
        For i As Integer = 0 To 15
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

        For Each aPic As PictureBox In Me.orPic
            aPic.TabStop = state
        Next

        showORstates()

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
    ''' Muestra un dialogo para la seleccion del color de tinta. Modifica el color de todas las lineas.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorINKPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colorINKPictureBox.Click
        Dim result As DialogResult
        result = aColorSelector.ShowWinDialog(Me.PaletteData, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            colorINKPictureBox.BackColor = _PaletteData.getRGB(aColorSelector.ColorSelected)
            Me.inkColor = aColorSelector.ColorSelected

            For Each aPic As PictureBox In Me.colorPic
                aPic.BackColor = _PaletteData.getRGB(Me.inkColor)
                Me.colorValues(aPic.TabIndex) = Me.inkColor.id
            Next

            ShowSprite()

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


    ''' <summary>
    ''' Herramienta que invierte el dibujo del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Invert() Implements ISpriteContainer.Invert
        'Dim tempPixelData(256) As Boolean

        'tempPixelData = pixelData.Clone

        For y As Integer = 0 To 15

            For x As Integer = 0 To 15
                pixelData(y * 16 + x) = Not pixelData(y * 16 + x)
            Next

        Next

        ShowSprite()
    End Sub



    Public Sub SetState(ByVal newState As Integer) Implements ISpriteContainer.SetState
        Me._state = newState
        _step = 0
    End Sub




    'Private Sub SpriteNameTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SpriteNameTextBox.KeyDown
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testButton.Click

        Dim gfxDataSprite() As Byte = New Byte() {&HF0, &HF0, &HF0, &HF0, &HF, &HF, &HF, &HF, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H80, &H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF, &HFF}
        Dim colorDataSprite() As Byte = New Byte() {12, 12, 2, 2, 3, 3, 3, 3, 4, 4, 5, 5, 7, 6, 8, 9}
        Dim orDataSprite() As Boolean = New Boolean() {False, True, False, True, False, True, False, True, False, True, False, True, False, True, False, True}
        Dim demoSprite As New SpriteMSX

        demoSprite.gfxData = gfxDataSprite
        demoSprite.colorData = colorDataSprite
        demoSprite.ORbitData = orDataSprite

        demoSprite.InkColor = 15
        demoSprite.BGcolor = 0

        demoSprite.name = "TEST"

        Me.SetSprite(demoSprite)

    End Sub



    Private Sub SpritePanel16mode2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Application.DoEvents() ' truco para solucionar el problema en el redibujado del control cuando la ventana recupera el foco
    End Sub


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
