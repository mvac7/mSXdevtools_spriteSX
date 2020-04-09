Imports System.IO


Public Class BitmapWin
    'Private myBitmapImage As Bitmap
    Public Path_SC2 As String = ""
    Public Path_Bitmap As String = ""

    Public _projectName As String  '= ""
    Public _ProjectSize As SpriteMSX.SPRITE_SIZE  ' 0=8x8,  1=16x16 
    Public _ProjectMode As SpriteMSX.SPRITE_MODE  ' 1=MSX1, 2=MSX2
    Public Sprites As SpriteList

    'Private _paletteMSX As New MSXpalette

    Private BitmapFilePath As String


    Public Property PaletteMSX() As MSXpalette
        Get
            Return screen2.GetPalette
        End Get
        Set(ByVal value As MSXpalette)
            screen2.SetPalette(value)
        End Set
    End Property


    Public Property ProjectName() As String
        Get
            Return _projectName
        End Get
        Set(ByVal value As String)
            _projectName = value
            Me.ProjectNameTextBox.Text = value
        End Set
    End Property


    Public Property ProjectSize() As SpriteMSX.SPRITE_SIZE
        Get
            Return _ProjectSize
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_SIZE)
            _ProjectSize = value
            If value = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                sizeTextBox.Text = "8x8"
            Else
                sizeTextBox.Text = "16x16"
            End If
        End Set
    End Property


    Public Property ProjectMode() As SpriteMSX.SPRITE_MODE
        Get
            Return _ProjectMode
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_MODE)
            _ProjectMode = value
            If value = SpriteMSX.SPRITE_MODE.MONO Then
                colorTextBox.Text = "mono"
            Else
                colorTextBox.Text = "color"
            End If
        End Set
    End Property


    Public Sub New(ByVal _name As String, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _mode As SpriteMSX.SPRITE_MODE, ByVal _sprites As SpriteList, ByVal _msxPalette As MSXpalette, ByVal _pathSC2 As String, ByVal _pathBitmap As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ProjectName = _name
        Me.ProjectSize = _size
        Me.ProjectMode = _mode
        Me.Sprites = _sprites

        Me.PaletteMSX = _msxPalette.clone

        Me.Path_SC2 = _pathSC2
        Me.Path_Bitmap = _pathBitmap


    End Sub



    Private Sub BitmapWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim vaddr As Integer = TMS9918.TableBase.GRPCGP
        Dim vaddrCOL As Integer = TMS9918.TableBase.GRPCOL
        'Dim vaddrMap As Integer = screen2.TableBase.GRPNAM
        'Dim tile As Integer
        Dim i As Integer
        Dim dataLength As Integer
        Dim aSprite As SpriteMSX
        Dim tmpColor As Integer

        'aScreen2.clear()


        If Not Me.Sprites Is Nothing Then

            If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                dataLength = 7
                Me.screen2.OrderMap()
            Else
                dataLength = 31
                Sprites16Map()
            End If

            For Each sprid As Integer In Me.Sprites.spritesIndex
                aSprite = Me.Sprites.Item(sprid)
                For i = 0 To dataLength
                    screen2.VPOKE(vaddr, aSprite.gfxData(i))

                    If Me.ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
                        tmpColor = aSprite.InkColor
                    Else
                        If i < 16 Then
                            tmpColor = aSprite.colorData(i)
                        Else
                            tmpColor = aSprite.colorData(i - 16)
                        End If
                    End If
                    'If tmpColor < 2 Then
                    '    tmpColor = 15
                    'End If
                    screen2.VPOKE(vaddrCOL, tmpColor * 16)

                    vaddr += 1
                    vaddrCOL += 1
                Next
            Next

            ' color
            'aScreen2.fillVRAM(screen2.TableBase.GRPCOL, &H800, &HF1)

            ' copy sprites to patterns
            screen2.CopyVRAM(TMS9918.TableBase.GRPCGP, TMS9918.TableBase.GRPPAT, &H801)
        End If


        Me.screen2.RefreshScreen()

    End Sub




    Public Function getSpritesData() As SortedList

        Dim vaddr As Integer = TMS9918.TableBase.GRPPAT
        Dim vaddrCOL As Integer = TMS9918.TableBase.GRPCOL
        Dim tmpsprites As New SortedList
        Dim order As Integer = 0
        Dim gfxData As Byte()
        Dim colorData As Byte()
        Dim InkColor As Integer = 15
        Dim dataLength As Integer
        Dim datasize As Integer
        Dim colorsize As Integer
        'Dim emptySprite As Integer = 0
        Dim cheksum As Integer

        If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            dataLength = 256
            colorsize = 7
            datasize = 7
        Else
            dataLength = 64
            datasize = 31
            colorsize = 15
        End If

        ReDim gfxData(datasize)
        ReDim colorData(colorsize)

        For i As Integer = 0 To dataLength

            cheksum = 0
            For o As Integer = 0 To datasize
                gfxData(o) = screen2.VPEEK(vaddr)
                cheksum += gfxData(o)
                vaddr += 1
            Next

            For o As Integer = 0 To colorsize
                colorData(o) = (screen2.VPEEK(vaddrCOL) And 240) / 16
                vaddrCOL += 1
            Next
            InkColor = getColor(colorData)

            If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                vaddrCOL += 16
            End If

            If emptySpritesCheckBox.Checked Then
                tmpsprites.Add(order, New SpriteMSX("SPR_" + order.ToString, Me.ProjectSize, Me.ProjectMode, InkColor, 1, gfxData, colorData, Me.PaletteMSX))
                order += 1
            ElseIf cheksum > 0 And cheksum < 8160 And InkColor > 1 Then
                '
                tmpsprites.Add(order, New SpriteMSX("SPR_" + order.ToString, Me.ProjectSize, Me.ProjectMode, InkColor, 1, gfxData, colorData, Me.PaletteMSX))
                order += 1

            End If

        Next
        'Loop While order < dataLength

        Return tmpsprites

    End Function



    Private Function getColor(ByVal vram As Integer, ByVal size As Integer) As Byte
        '1536
        Dim Alicia As New SortedList()

        Dim aColor As Byte
        Dim count As Integer = 0

        'If vaddr = screen2.TableBase.GRPCOL + 1536 Then
        '    vaddr = vaddr
        'End If

        'Dim data(colorsize) As Byte
        'For o As Integer = 0 To colorsize
        '    data(o) = (aScreen2.VPEEK(vaddr) And 240) / 16
        '    vaddr += 1
        'Next


        For i = 0 To size
            aColor = (screen2.VPEEK(vram + i) And 240) / 16
            If screen2.VPEEK(vram - TMS9918.TableBase.GRPCOL + i) > 0 Then
                If Alicia.ContainsKey(aColor) Then
                    Alicia.Item(aColor) = Alicia.Item(aColor) + 1
                Else
                    Alicia.Add(aColor, 1)
                End If
            End If

        Next


        For Each key As Byte In Alicia.Keys
            If Alicia(key) > count Then
                aColor = key
                count = Alicia(key)
            End If
        Next

        'If aColor = 5 Then
        '    Return 5
        'End If

        Return aColor
    End Function



    Private Function getColor(ByVal data() As Byte) As Byte
        Dim Alicia As New SortedList()
        Dim aColor As Byte
        Dim count As Integer = 0

        For Each aColor In data
            If Alicia.ContainsKey(aColor) Then
                Alicia.Item(aColor) = Alicia.Item(aColor) + 1
            Else
                Alicia.Add(aColor, 1)
            End If
        Next

        For Each key As Byte In Alicia.Keys
            If Alicia(key) > count Then
                aColor = key
                count = Alicia(key)
            End If
        Next

        Return aColor
    End Function




    Private Sub genSpritesPic()

        Dim vaddrCOL As Short = TMS9918.TableBase.GRPCOL
        'Dim colorsize As Integer
        Dim InkColor As Integer

        Dim i As Integer
        Dim o As Integer


        If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            Me.screen2.OrderMap()
            Me.screen2.CopyVRAM(TMS9918.TableBase.GRPCGP, TMS9918.TableBase.GRPPAT, &H800) 'copy graphics to sprites vram

            ' show sprite colors
            If Me.ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
                For i = 0 To 255
                    InkColor = getColor(vaddrCOL, 7) * 16
                    For o = 0 To 7
                        Me.screen2.VPOKE(vaddrCOL, InkColor)
                        vaddrCOL += 1
                    Next
                Next
            Else
                For i = 0 To 2047
                    InkColor = screen2.VPEEK(vaddrCOL) And 240
                    Me.screen2.VPOKE(vaddrCOL, InkColor)
                    vaddrCOL += 1
                Next
            End If

        Else
            '16x16
            Dim vaddr As Short = TMS9918.TableBase.GRPNAM
            Dim vaddrPAT As Short = TMS9918.TableBase.GRPCGP
            Dim vaddrSPR As Short = TMS9918.TableBase.GRPPAT
            Dim vaddrCOLcopy As Integer = vaddrCOL + &H800

            If Me.screen2.VPEEK(vaddr) = 0 And Me.screen2.VPEEK(vaddr + 1) = 1 And Me.screen2.VPEEK(vaddr + 2) = 2 Then
                ' si el mapa esta ordenado porcesa los graficos
                For i = 0 To 3
                    For o = 0 To 15
                        Me.screen2.CopyVRAM(vaddrPAT, vaddrSPR, 7)
                        Me.screen2.CopyVRAM(vaddrPAT + (32 * 8), vaddrSPR + 8, 7)
                        Me.screen2.CopyVRAM(vaddrPAT + 8, vaddrSPR + 16, 7)
                        Me.screen2.CopyVRAM(vaddrPAT + (33 * 8), vaddrSPR + 24, 7)
                        vaddrPAT += 16
                        vaddrSPR += 32

                        Me.screen2.CopyVRAM(vaddrCOL, vaddrCOLcopy, 7)
                        Me.screen2.CopyVRAM(vaddrCOL + (32 * 8), vaddrCOLcopy + 8, 7)
                        Me.screen2.CopyVRAM(vaddrCOL, vaddrCOLcopy + 16, 7)
                        Me.screen2.CopyVRAM(vaddrCOL + (32 * 8), vaddrCOLcopy + 24, 7)
                        vaddrCOL += 16
                        vaddrCOLcopy += 32
                    Next
                    vaddrPAT += 256
                    vaddrCOL += 256
                Next

                Me.screen2.CopyVRAM(TMS9918.TableBase.GRPPAT, TMS9918.TableBase.GRPCGP, &H800)
                Me.screen2.CopyVRAM(TMS9918.TableBase.GRPCOL + &H800, TMS9918.TableBase.GRPCOL, &H800)
                Sprites16Map()

            Else
                ' si esta desordenado cree que es un SC2 ya procesado con la estructura de los sprites.
                ' producido por la conversion de spriteSX
                Me.screen2.CopyVRAM(TMS9918.TableBase.GRPCGP, TMS9918.TableBase.GRPPAT, &H800) 'copy graphics to sprites vram
            End If

            vaddrCOL = TMS9918.TableBase.GRPCOL ' + &H800

            If Me.ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
                For i = 0 To 63
                    InkColor = getColor(vaddrCOL, 15) * 16
                    For o = 0 To 31
                        Me.screen2.VPOKE(vaddrCOL, InkColor)
                        vaddrCOL += 1
                    Next
                Next
            Else
                For i = 0 To 2047
                    InkColor = screen2.VPEEK(vaddrCOL) And 240
                    Me.screen2.VPOKE(vaddrCOL, InkColor)
                    vaddrCOL += 1
                Next
            End If



        End If

        ' clear 1 & 2 bank
        Me.screen2.FillVRAM(TMS9918.TableBase.GRPCGP + &H800, &HFFF, 0)
        Me.screen2.FillVRAM(TMS9918.TableBase.GRPCOL + &H800, &HFFF, 0)

        Me.screen2.RefreshScreen()

    End Sub



    Private Sub setSpritesToPattern()

        'Me.aScreen2.clear()

        Me.screen2.CopyVRAM(TMS9918.TableBase.GRPPAT, TMS9918.TableBase.GRPCGP, &H800) 'copy sprites to pattern vram
        Me.screen2.FillVRAM(TMS9918.TableBase.GRPCOL, &H800, &HF0)

        If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            Me.screen2.OrderMap()
        Else
            Sprites16Map()
        End If


        ' clear 1 & 2 bank
        Me.screen2.FillVRAM(TMS9918.TableBase.GRPCGP + &H800, &HFFF, 0)
        Me.screen2.FillVRAM(TMS9918.TableBase.GRPCOL + &H800, &HFFF, 0)

        Me.screen2.RefreshScreen()

    End Sub



    Public Sub Sprites16Map()

        Dim vaddr As Short = TMS9918.TableBase.GRPNAM
        Dim tile As Integer = 0

        For bank As Integer = 0 To 2
            tile = 0
            For i As Integer = 0 To 3
                For o As Integer = 0 To 15
                    screen2.VPOKE(vaddr, tile)
                    screen2.VPOKE(vaddr + 1, tile + 2)
                    screen2.VPOKE(vaddr + 32, tile + 1)
                    screen2.VPOKE(vaddr + 33, tile + 3)
                    vaddr += 2
                    tile += 4
                Next
                vaddr += 32
            Next
        Next

        screen2.RefreshScreen()

    End Sub



    Private Sub loadBitmap(ByVal filePath As String)

        Dim myBitmapImage As Bitmap
        Dim newImage As Image = Image.FromFile(filePath)
        myBitmapImage = New Bitmap(newImage, 256, 192)

        Me.BitmapFilePath = filePath
        'FilenameTextBox.Text = Path.GetFileName(filePath)

        newImage.Dispose() 'para que no bloquee el fichero


        Me.screen2.initialize()
        Me.screen2._msxPalette.VDPtype = MSXpalette.MSXVDP.TMS9918
        Me.screen2.setScreenFromBitmap(myBitmapImage)

        genSpritesPic()

        OkButton.Enabled = True  ' ya hay algo que transpasar
        Me.ProjectName = Path.GetFileNameWithoutExtension(Me.BitmapFilePath)

    End Sub



    Private Sub LoadBitmapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadBitmapButton.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.DefaultExt = ".png"
        OpenFileDialog1.Filter = "PNG documents (.PNG)|*.png|GIF documents (.GIF)|*.gif"

        If Me.Path_Bitmap = "" Then
            Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.OpenFileDialog1.InitialDirectory = Me.Path_Bitmap
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            loadBitmap(OpenFileDialog1.FileName)
            Me.Path_Bitmap = Path.GetDirectoryName(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub SaveBitmapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBitmapButton.Click

        Me.SaveFileDialog1.DefaultExt = "png"
        Me.SaveFileDialog1.Filter = "PNG file|*.png"

        If Me.Path_Bitmap = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Bitmap
        End If

        Me.SaveFileDialog1.FileName = Me.ProjectName

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.screen2.SaveTilesScreenPNG(SaveFileDialog1.FileName)
            Me.Path_Bitmap = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If

    End Sub



    Private Sub SaveSC2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSC2Button.Click

        Me.SaveFileDialog1.DefaultExt = "sc2"
        Me.SaveFileDialog1.Filter = "Screen2 bin file|*.sc2"

        If Me.Path_SC2 = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        Me.SaveFileDialog1.FileName = Me.ProjectName

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.screen2.SaveSC2(SaveFileDialog1.FileName)
            Me.Path_SC2 = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If

    End Sub



    Private Sub SaveSC2SPRsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSC2SPRsButton.Click

        Me.SaveFileDialog1.DefaultExt = "sc2"
        Me.SaveFileDialog1.Filter = "Screen2 bin file|*.sc2"

        If Me.Path_SC2 = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        Me.SaveFileDialog1.FileName = Me.ProjectName

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.screen2.BSAVE(SaveFileDialog1.FileName, TMS9918.TableBase.GRPPAT, &H3FFF)
            Me.Path_SC2 = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If

    End Sub



    Private Sub LoadSC2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSC2Button.Click

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.DefaultExt = "sc2"
        Me.OpenFileDialog1.Filter = "Screen2 bin file|*.sc2|Msx bin file|*.bin|All files|*.*"

        If Me.Path_SC2 = "" Then
            Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.OpenFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            loadSC2(OpenFileDialog1.FileName)
            Me.Path_SC2 = Path.GetDirectoryName(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Sub LoadSC2SPRsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSC2SPRsButton.Click

        Dim filePath As String

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.DefaultExt = "sc2"
        Me.OpenFileDialog1.Filter = "Screen2 bin file|*.sc2|Msx bin file|*.bin|All files|*.*"

        If Me.Path_SC2 = "" Then
            Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.OpenFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            filePath = OpenFileDialog1.FileName

            If Me.screen2.LoadSC2(filePath) = True Then
                Me.BitmapFilePath = Path.GetFileNameWithoutExtension(filePath)

                setSpritesToPattern()

                OkButton.Enabled = True  ' ya hay algo que transpasar
                Me.ProjectName = Path.GetFileNameWithoutExtension(filePath)
                Me.Path_SC2 = Path.GetDirectoryName(OpenFileDialog1.FileName)

            Else
                MsgBox("El fichero seleccionado no es de tipo SC2", MsgBoxStyle.Critical, "Error")
            End If

        End If

    End Sub



    Private Sub loadSC2(ByVal filePath As String)
        If Me.screen2.LoadSC2(filePath) = True Then
            Me.BitmapFilePath = Path.GetFileNameWithoutExtension(filePath)

            'Me.aScreen2.Optimize()
            genSpritesPic()

            'Me.aScreen2.SetVRAMPalette()

            OkButton.Enabled = True  ' ya hay algo que transpasar
            Me.ProjectName = Path.GetFileNameWithoutExtension(filePath)
        Else
            MsgBox("El fichero seleccionado no es de tipo SC2", MsgBoxStyle.Critical, "Error")
        End If
    End Sub



    Private Sub mainWindow_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
        Dim tmpFilePath As String = tmpstr(0)
        Dim extension As String = Path.GetExtension(tmpFilePath).ToLower

        If extension = ".gif" Or extension = ".png" Then
            loadBitmap(tmpFilePath)
        ElseIf extension = ".sc2" Then
            loadSC2(tmpFilePath)
        End If
    End Sub



    Private Sub mainWindow_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub setTMS9918paletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setTMS9918paletteButton.Click
        Me.screen2.VDPtype = MSXpalette.MSXVDP.TMS9918
        Me.screen2.RefreshScreen()
    End Sub



End Class