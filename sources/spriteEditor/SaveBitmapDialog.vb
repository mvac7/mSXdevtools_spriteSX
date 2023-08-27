Imports System.IO


Public Class SaveBitmapDialog

    Private AppConfig As Config

    'Private myBitmapImage As Bitmap
    'Public Path_SC2 As String = ""

    Private ProjectPath As String
    Private _projectName As String  '= ""
    Private _projectSize As SpriteMSX.SPRITE_SIZE  ' 0=8x8,  1=16x16 
    Private _projectMode As SpriteMSX.SPRITE_MODE  ' 1=MSX1, 2=MSX2

    'Public Sprites As SpritesetMSX

    Private _spriteProject As SpriteProject
    Private Palettes As PaletteProject

    Private spritesetID As Integer

    Private BitmapFilePath As String

    Private bankLetters() As String = {"A", "B", "C"}

    'Private mode As BITMAPDIALOG_MODE = BITMAPDIALOG_MODE.LOAD



    Private bakVRAM(16383) As Byte ' 16k de memoria de video
    'Private hasBitmap As Boolean = False


    'Private isLoadMode As Boolean = False


    'Public Property PaletteMSX() As iPaletteMSX
    '    Get
    '        Return screen2.Palette
    '    End Get
    '    Set(ByVal value As iPaletteMSX)
    '        screen2.Palette = value
    '    End Set
    'End Property





    Public Property ProjectName() As String
        Get
            Return _projectName
        End Get
        Set(ByVal value As String)
            Me._projectName = value
            Me.NameTextBox.Text = Me._projectName
        End Set
    End Property



    'Public Property ProjectSize() As SpriteMSX.SPRITE_SIZE
    '    Get
    '        Return Me.SizeComboBox.SelectedIndex + 1 '_ProjectSize
    '    End Get
    '    Set(ByVal value As SpriteMSX.SPRITE_SIZE)
    '        Me._ProjectSize = value
    '        SizeComboBox.SelectedIndex = value - 1
    '        'If value = SpriteMSX.SPRITE_SIZE.SIZE8 Then
    '        '    sizeTextBox.Text = "8x8"
    '        'Else
    '        '    sizeTextBox.Text = "16x16"
    '        'End If
    '    End Set
    'End Property



    'Public Property ProjectMode() As SpriteMSX.SPRITE_MODE
    '    Get
    '        Return Me.ModeComboBox.SelectedIndex + 1 '_ProjectMode
    '    End Get
    '    Set(ByVal value As SpriteMSX.SPRITE_MODE)
    '        _ProjectMode = value
    '        ModeComboBox.SelectedIndex = value - 1
    '        'If value = SpriteMSX.SPRITE_MODE.MONO Then
    '        '    colorTextBox.Text = "mono"
    '        'Else
    '        '    colorTextBox.Text = "color"
    '        'End If
    '    End Set
    'End Property





    Public Sub New(ByVal _config As Config, ByVal _spritePrj As SpriteProject, ByVal palettePrj As PaletteProject, ByVal prjName As String, ByVal prjPath As String, _spritesetID As Integer) ', ByVal _pathSC2 As String, ByVal _pathBitmap As String

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        'Me.mode = BITMAPDIALOG_MODE.SAVE

        Me.Palettes = palettePrj
        Me._spriteProject = _spritePrj

        Me.ProjectName = prjName
        Me.ProjectPath = prjPath

        Me.spritesetID = _spritesetID

    End Sub




    'Public Sub New(ByVal _config As Config, ByVal palettePrj As PaletteProject, loadPath As String) ', ByVal _pathSC2 As String, ByVal _pathBitmap As String

    '    ' Llamada necesaria para el Diseñador de Windows Forms.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    Me.AppConfig = _config

    '    Me.mode = BITMAPDIALOG_MODE.LOAD

    '    Me._loadPath = loadPath

    '    Me.ProjectName = "new_spriteset"
    '    Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16
    '    Me.ProjectMode = SpriteMSX.SPRITE_MODE.MONO
    '    'Me.Sprites = _spriteset

    '    'screen2.Palette = palettePrj.GetPalette(0)

    '    'default colors
    '    Me.TMS9918Aviewer.InkColor = 15
    '    Me.TMS9918Aviewer.BackgroundColor = 1

    '    Me.Palettes = palettePrj

    'End Sub






    Private Sub BitmapWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RefreshPaletteSelector()
        Me.PaletteComboBox.SelectedIndex = 0 'Me._paletteProject.GetIndexFromID(Me.Sprites.Palette.ID)
        Me.TMS9918Aviewer.Palette = Me.Palettes.GetPalette(0) ' TMS9918A palette


        'If Me.mode = BITMAPDIALOG_MODE.LOAD Then
        '    'Load
        '    Me.Text = "Load Bitmap"

        '    BankALabel.Text = "Select Bank"
        '    ToolTip1.SetToolTip(Me.BankComboBox, "Select Bank from Bitmap")

        '    OkButton.Visible = False
        '    BankBLabel.Visible = False
        '    BankBComboBox.Visible = False
        '    BankCLabel.Visible = False
        '    BankCComboBox.Visible = False

        '    BankComboBox.SelectedIndex = 0

        '    If System.IO.File.Exists(Me._loadPath) Then
        '        LoadBitmap(Me._loadPath)
        '    End If

        'Else
        'Save
        'Me.Text = "Save Bitmap"
        'Me.OkButton.Text = "Save"


        RefreshSelector(Me.BankComboBox)
        RefreshSelector(Me.BankBComboBox)
        RefreshSelector(Me.BankCComboBox)

        Me.BankComboBox.SelectedIndex = Me._spriteProject.GetIndexFromID(Me.spritesetID) + 1
        Me.BankBComboBox.SelectedIndex = 0
        Me.BankCComboBox.SelectedIndex = 0

        ShowSpriteSets()


        'End If

        AddHandler Me.BankComboBox.SelectedIndexChanged, AddressOf Me.BankComboBox_SelectedIndexChanged
        AddHandler Me.BankBComboBox.SelectedIndexChanged, AddressOf Me.BankBComboBox_SelectedIndexChanged
        AddHandler Me.BankCComboBox.SelectedIndexChanged, AddressOf Me.BankCComboBox_SelectedIndexChanged

        'AddHandler Me.SizeComboBox.SelectedIndexChanged, AddressOf Me.SizeComboBox_SelectedIndexChanged
        'AddHandler Me.ModeComboBox.SelectedIndexChanged, AddressOf Me.ModeComboBox_SelectedIndexChanged
        AddHandler Me.PaletteComboBox.SelectedIndexChanged, AddressOf Me.PaletteComboBox_SelectedIndexChanged


        'Me.screen2.RefreshScreen()

    End Sub




    Private Sub RefreshSelector(aCombobox As System.Windows.Forms.ComboBox)

        Dim counter As Integer = 1
        aCombobox.Items.Clear()
        aCombobox.Items.Add("0 - Nothing")
        If Me._spriteProject.Count > 0 Then
            For Each aName As String In Me._spriteProject.GetNameList
                aCombobox.Items.Add(CStr(counter) + " - " + aName)
                counter += 1
            Next
        End If
    End Sub



    Private Sub ShowSpriteSets()

        Dim set0 As Integer = Me.BankComboBox.SelectedIndex
        Dim set1 As Integer = Me.BankBComboBox.SelectedIndex
        Dim set2 As Integer = Me.BankCComboBox.SelectedIndex

        If set0 = 0 Then
            ClearBank(0)
        Else
            ShowSpriteSet(0, Me._spriteProject.GetSpriteset(set0 - 1))
        End If

        If set1 = 0 Then
            ClearBank(1)
        Else
            ShowSpriteSet(1, Me._spriteProject.GetSpriteset(set1 - 1))
        End If

        If set2 = 0 Then
            ClearBank(2)
        Else
            ShowSpriteSet(2, Me._spriteProject.GetSpriteset(set2 - 1))
        End If

        Me.TMS9918Aviewer.RefreshScreen()

    End Sub



    Private Sub ClearBank(nbank As Integer)
        Dim vaddr As Integer
        Dim vaddrCOL As Integer

        vaddr = iVDP.TableBase.GRPCGP + (nbank * &H800)
        vaddrCOL = iVDP.TableBase.GRPCOL + (nbank * &H800)

        Me.TMS9918Aviewer.FillVRAM(vaddr, &H800, 0)
        Me.TMS9918Aviewer.FillVRAM(vaddrCOL, &H800, 0)

    End Sub



    Private Sub ShowSpriteSet(nbank As Integer, sprites As SpritesetMSX)

        Dim vaddr As Integer
        Dim vaddrCOL As Integer
        Dim i As Integer
        Dim dataLength As Integer
        Dim aSprite As SpriteMSX
        Dim tmpColor As Integer


        If Not sprites Is Nothing Then

            vaddr = iVDP.TableBase.GRPCGP + (nbank * &H800)
            vaddrCOL = iVDP.TableBase.GRPCOL + (nbank * &H800)

            If sprites.Size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                dataLength = 7
                'Me.screen2.OrderMap()
                setSprites8Map(nbank)
            Else
                dataLength = 31
                setSprites16Map(nbank)
            End If

            For nSprite As Integer = 0 To sprites.TotalSprites()
                aSprite = sprites.GetSprite(nSprite) ' get sprite in order
                For i = 0 To dataLength
                    TMS9918Aviewer.VPOKE(vaddr, aSprite.patternData(i))

                    If sprites.Mode = SpriteMSX.SPRITE_MODE.MONO Then
                        tmpColor = aSprite.InkColor
                    Else
                        If i < 16 Then
                            tmpColor = aSprite.ColorData(i)
                        Else
                            tmpColor = aSprite.ColorData(i - 16)
                        End If
                    End If
                    If tmpColor < 2 Then
                        tmpColor = 15
                    End If
                    TMS9918Aviewer.VPOKE(vaddrCOL, tmpColor * 16)

                    vaddr += 1
                    vaddrCOL += 1
                Next
            Next

            ' color
            'aScreen2.fillVRAM(screen2.TableBase.GRPCOL, &H800, &HF1)

            ' copy sprites to patterns
            'screen2.CopyVRAM(TMS9918A.TableBase.GRPCGP, TMS9918A.TableBase.GRPPAT, &H801)
        End If

    End Sub



    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()

    '    Me._ProjectSize = Me.SizeComboBox.SelectedIndex + 1
    '    Me._ProjectMode = Me.ModeComboBox.SelectedIndex + 1

    'End Sub



    'Public Function GetSpriteset() As SpritesetMSX
    '    'Public Function getSpritesData() As SortedList

    '    Dim vaddr As Integer = iVDP.TableBase.GRPPAT
    '    Dim vaddrCOL As Integer = iVDP.TableBase.GRPCOL
    '    'Dim tmpsprites As New SortedList
    '    Dim order As Integer = 0
    '    Dim gfxData As Byte()
    '    Dim colorData As Byte()
    '    Dim InkColor As Integer = 15
    '    Dim dataLength As Integer
    '    Dim datasize As Integer
    '    Dim colorsize As Integer
    '    Dim aSpriteset As SpritesetMSX
    '    aSpriteset = New SpritesetMSX(Me.NameTextBox.Text, Me.ProjectSize, Me.ProjectMode, 15, 0, TMS9918Aviewer.Palette)

    '    If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
    '        dataLength = 255
    '        colorsize = 7
    '        datasize = 7
    '    Else
    '        dataLength = 63
    '        datasize = 31
    '        colorsize = 15
    '    End If

    '    ReDim gfxData(datasize)
    '    ReDim colorData(colorsize)

    '    For i As Integer = 0 To dataLength

    '        'cheksum = 0
    '        For o As Integer = 0 To datasize
    '            gfxData(o) = TMS9918Aviewer.VPEEK(vaddr)
    '            'cheksum += gfxData(o)
    '            vaddr += 1
    '        Next

    '        For o As Integer = 0 To colorsize
    '            colorData(o) = (TMS9918Aviewer.VPEEK(vaddrCOL) And 240) / 16
    '            vaddrCOL += 1
    '        Next
    '        InkColor = getColor(colorData)

    '        If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
    '            vaddrCOL += 16
    '        End If

    '        aSpriteset.SetSprite(New SpriteMSX(order, "SPR_" + order.ToString, Me.ProjectSize, Me.ProjectMode, InkColor, 0, gfxData, colorData, TMS9918Aviewer.Palette))
    '        order += 1

    '    Next
    '    'Loop While order < dataLength

    '    'Return tmpsprites
    '    Return aSpriteset

    'End Function




    'Private Function getColor(ByVal vram As Integer, ByVal size As Integer) As Byte
    '    '1536
    '    Dim Alicia As New SortedList()

    '    Dim aColor As Byte
    '    Dim count As Integer = 0

    '    For i = 0 To size
    '        aColor = (TMS9918Aviewer.VPEEK(vram + i) And 240) / 16
    '        If TMS9918Aviewer.VPEEK(vram - iVDP.TableBase.GRPCOL + i) > 0 Then
    '            If Alicia.ContainsKey(aColor) Then
    '                Alicia.Item(aColor) = Alicia.Item(aColor) + 1
    '            Else
    '                Alicia.Add(aColor, 1)
    '            End If
    '        End If

    '    Next


    '    For Each key As Byte In Alicia.Keys
    '        If Alicia(key) > count Then
    '            aColor = key
    '            count = Alicia(key)
    '        End If
    '    Next

    '    Return aColor
    'End Function



    'Private Function getColor(ByVal data() As Byte) As Byte
    '    Dim Alicia As New SortedList()
    '    Dim aColor As Byte
    '    Dim count As Integer = 0

    '    For Each aColor In data
    '        If Alicia.ContainsKey(aColor) Then
    '            Alicia.Item(aColor) = Alicia.Item(aColor) + 1
    '        Else
    '            Alicia.Add(aColor, 1)
    '        End If
    '    Next

    '    For Each key As Byte In Alicia.Keys
    '        If Alicia(key) > count Then
    '            aColor = key
    '            count = Alicia(key)
    '        End If
    '    Next

    '    Return aColor
    'End Function




    ' convierte los patrones/colores graficos a sprites
    ' copia los datos de patrones al area de sprites en el formato adecuado
    ' representa los sprites como graficos (cambiar cuando el control TMS9918 permita representar sprites multicolores del v9938)

    'Private Sub genSpritesPic(ByVal nbank As Integer)

    '    Dim vaddrCOL As Short = iVDP.TableBase.GRPCOL
    '    Dim InkColor As Integer

    '    Dim i As Integer
    '    Dim o As Integer

    '    Dim _size As SpriteMSX.SPRITE_SIZE = SizeComboBox.SelectedIndex + 1
    '    Dim _mode As SpriteMSX.SPRITE_MODE = ModeComboBox.SelectedIndex + 1


    '    Me.NameTextBox.Text = Me._projectName + "_" + bankLetters(nbank)

    '    Me.TMS9918Aviewer.SetBlock(0, Me.bakVRAM)


    '    If nbank > 0 Then
    '        Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPCGP + (nbank * &H800), iVDP.TableBase.GRPCGP, &H800)
    '        Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPCOL + (nbank * &H800), iVDP.TableBase.GRPCOL, &H800)
    '    End If
    '    'Me.screen2.Clear()

    '    'Me.screen2.SetView(TMS9918.VIEW_MODE.SPRITES_PATTERNS) ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TEST

    '    If _size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
    '        '8x8 
    '        Me.TMS9918Aviewer.OrderMap()
    '        Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPCGP, iVDP.TableBase.GRPPAT, &H800) 'copy graphics to sprites vram

    '        ' show sprite colors
    '        If _mode = SpriteMSX.SPRITE_MODE.MONO Then
    '            For i = 0 To 255
    '                InkColor = getColor(vaddrCOL, 7) * 16
    '                For o = 0 To 7
    '                    Me.TMS9918Aviewer.VPOKE(vaddrCOL, InkColor)
    '                    vaddrCOL += 1
    '                Next
    '            Next
    '        Else
    '            For i = 0 To 2047
    '                InkColor = TMS9918Aviewer.VPEEK(vaddrCOL) And 240
    '                Me.TMS9918Aviewer.VPOKE(vaddrCOL, InkColor)
    '                vaddrCOL += 1
    '            Next
    '        End If

    '    Else
    '        '16x16
    '        Dim vaddr As Short = iVDP.TableBase.GRPNAM
    '        Dim vaddrPAT As Short = iVDP.TableBase.GRPCGP
    '        Dim vaddrSPR As Short = iVDP.TableBase.GRPPAT
    '        Dim vaddrCOLcopy As Integer = vaddrCOL + &H800

    '        If Me.TMS9918Aviewer.VPEEK(vaddr) = 0 And Me.TMS9918Aviewer.VPEEK(vaddr + 1) = 1 And Me.TMS9918Aviewer.VPEEK(vaddr + 2) = 2 Then
    '            ' si el mapa esta ordenado procesa los graficos
    '            For i = 0 To 3
    '                For o = 0 To 15
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrPAT, vaddrSPR, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrPAT + (32 * 8), vaddrSPR + 8, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrPAT + 8, vaddrSPR + 16, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrPAT + (33 * 8), vaddrSPR + 24, 7)
    '                    vaddrPAT += 16
    '                    vaddrSPR += 32

    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrCOL, vaddrCOLcopy, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrCOL + (32 * 8), vaddrCOLcopy + 8, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrCOL, vaddrCOLcopy + 16, 7)
    '                    Me.TMS9918Aviewer.CopyVRAM(vaddrCOL + (32 * 8), vaddrCOLcopy + 24, 7)
    '                    vaddrCOL += 16
    '                    vaddrCOLcopy += 32
    '                Next
    '                vaddrPAT += 256
    '                vaddrCOL += 256
    '            Next

    '            Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPPAT, iVDP.TableBase.GRPCGP, &H800)
    '            Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPCOL + &H800, iVDP.TableBase.GRPCOL, &H800)
    '            setSprites16Map(0)

    '        Else
    '            ' si esta desordenado cree que es un SC2 ya procesado con la estructura de los sprites.
    '            ' producido por la conversion de spriteSX
    '            Me.TMS9918Aviewer.CopyVRAM(iVDP.TableBase.GRPCGP, iVDP.TableBase.GRPPAT, &H800) 'copy graphics to sprites vram
    '        End If

    '        vaddrCOL = iVDP.TableBase.GRPCOL ' + &H800

    '        If _mode = SpriteMSX.SPRITE_MODE.MONO Then
    '            ' rellena el area de color  
    '            For i = 0 To 63
    '                InkColor = getColor(vaddrCOL, 15) * 16
    '                For o = 0 To 31
    '                    Me.TMS9918Aviewer.VPOKE(vaddrCOL, InkColor)
    '                    vaddrCOL += 1
    '                Next
    '            Next
    '        Else
    '            ' sprites multicolor v9938
    '            For i = 0 To 63
    '                vaddrCOL = iVDP.TableBase.GRPCOL + (i * 32)
    '                For o = 0 To 15
    '                    InkColor = TMS9918Aviewer.VPEEK(vaddrCOL) And 240
    '                    Me.TMS9918Aviewer.VPOKE(vaddrCOL, InkColor)
    '                    Me.TMS9918Aviewer.VPOKE(vaddrCOL + 16, InkColor) ' copia los colores del lado izquierdo en el derecho
    '                    vaddrCOL += 1
    '                Next
    '            Next
    '        End If

    '    End If ' END 16x16


    '    ' clear 1 & 2 bank
    '    Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPCGP + &H800, &HFFF, 0)
    '    Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPCOL + &H800, &HFFF, 0)

    '    Me.TMS9918Aviewer.RefreshScreen()

    'End Sub



    'Private Sub setSpritesToPattern()

    '    'Me.aScreen2.clear()
    '    Me.screen2.CopyVRAM(TMS9918A.TableBase.GRPPAT, TMS9918A.TableBase.GRPCGP, &H800) 'copy sprites to pattern vram
    '    Me.screen2.FillVRAM(TMS9918A.TableBase.GRPCOL, &H800, &HF0)

    '    If Me.ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
    '        Me.screen2.OrderMap()
    '    Else
    '        setSprites16Map()
    '    End If


    '    ' clear 1 & 2 bank
    '    Me.screen2.FillVRAM(TMS9918A.TableBase.GRPCGP + &H800, &HFFF, 0)
    '    Me.screen2.FillVRAM(TMS9918A.TableBase.GRPCOL + &H800, &HFFF, 0)

    '    Me.screen2.RefreshScreen()

    'End Sub



    Private Sub setSprites16Map(nbank As Integer)

        Dim vaddr As Short
        Dim tile As Integer = 0

        vaddr = iVDP.TableBase.GRPNAM + (nbank * 256)

        'For bank As Integer = 0 To 2
        tile = 0
        For i As Integer = 0 To 3
            For o As Integer = 0 To 15
                TMS9918Aviewer.VPOKE(vaddr, tile)
                TMS9918Aviewer.VPOKE(vaddr + 1, tile + 2)
                TMS9918Aviewer.VPOKE(vaddr + 32, tile + 1)
                TMS9918Aviewer.VPOKE(vaddr + 33, tile + 3)
                vaddr += 2
                tile += 4
            Next
            vaddr += 32
        Next
        'Next

        'screen2.RefreshScreen()

    End Sub



    Private Sub setSprites8Map(nbank As Integer)

        Dim vaddr As Short = iVDP.TableBase.GRPNAM + (nbank * 256)

        For i As Integer = 0 To 255
            TMS9918Aviewer.VPOKE(vaddr + i, i)
        Next

        'screen2.RefreshScreen()

    End Sub




    'Private Sub loadSC2(ByVal filePath As String)
    '    If Me.screen2.BLOAD(filePath) = True Then
    '        'Me.BitmapFilePath = Path.GetFileNameWithoutExtension(filePath)

    '        Me.BankComboBox.Enabled = False
    '        Me.bakVRAM = Me.screen2.GetVRAM()
    '        BankComboBox.SelectedIndex = 0
    '        Me.BankComboBox.Enabled = True

    '        genSpritesPic(0)

    '        'Me.aScreen2.SetVRAMPalette()

    '        OkButton.Enabled = True  ' ya hay algo que transpasar

    '        Me.ProjectName = Path.GetFileNameWithoutExtension(filePath)
    '    Else
    '        MsgBox("The file format is not SC2.", MsgBoxStyle.Critical, "Error")
    '    End If
    'End Sub



    'Private Sub LoadBitmap()
    '    OpenFileDialog1.FileName = ""
    '    OpenFileDialog1.DefaultExt = ".png"
    '    OpenFileDialog1.Filter = "PNG documents (.PNG)|*.png|GIF documents (.GIF)|*.gif"

    '    If Me.AppConfig.PathItemBitmap.Path = "" Then
    '        Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
    '    Else
    '        Me.OpenFileDialog1.InitialDirectory = Me.AppConfig.PathItemBitmap.Path
    '    End If

    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        loadBitmap(OpenFileDialog1.FileName)
    '        'Me.Path_Bitmap = Path.GetDirectoryName(OpenFileDialog1.FileName)
    '        Me.AppConfig.PathItemBitmap.UpdateLastPath(Path.GetDirectoryName(OpenFileDialog1.FileName))
    '    End If

    'End Sub



    'Private Sub loadBitmap(ByVal filePath As String)

    '    Dim VRAM As Byte()
    '    Dim aBitmapConverter As New SimpleBitmapConverter

    '    Dim myBitmapImage As Bitmap
    '    Dim newImage As Image = Image.FromFile(filePath)

    '    myBitmapImage = New Bitmap(newImage, 256, 192)
    '    newImage.Dispose() 'para que no bloquee el fichero

    '    Me.BitmapFilePath = filePath
    '    'FilenameTextBox.Text = Path.GetFileName(filePath)

    '    Me.TMS9918Aviewer.Initialize()

    '    VRAM = aBitmapConverter.GetScreenFromBitmap(myBitmapImage, 1)
    '    Me.TMS9918Aviewer.SetBlock(0, VRAM)
    '    Me.TMS9918Aviewer.Optimize()
    '    'Me.TMS9918Aviewer.setScreenFromBitmap(myBitmapImage)

    '    Me.BankComboBox.Enabled = False
    '    Me.bakVRAM = Me.TMS9918Aviewer.GetVRAM()

    '    Me.ProjectName = Path.GetFileNameWithoutExtension(Me.BitmapFilePath)
    '    Me.PaletteComboBox.SelectedIndex = 0

    '    genSpritesPic(0)

    '    'screen2.Palette = Me._paletteProject.GetPalette(Me.PaletteComboBox.SelectedIndex)

    '    'If Not isLoadMode Then
    '    'Me.isLoadMode = True
    '    Me.OkButton.Visible = True  ' ya hay algo que transpasar
    '    Me.BankComboBox.SelectedIndex = 0
    '    Me.BankComboBox.Enabled = True
    '    Me.SizeComboBox.Visible = True
    '    Me.ModeComboBox.Visible = True
    '    'End If

    'End Sub




    Private Sub SaveBitmap()

        Me.SaveFileDialog1.DefaultExt = "png"
        Me.SaveFileDialog1.Filter = "PNG file|*.png"

        If Me.ProjectPath = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.ProjectPath)
        End If

        Me.SaveFileDialog1.FileName = Me.NameTextBox.Text

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.TMS9918Aviewer.SaveScreenPNG(SaveFileDialog1.FileName)
            'Me.AppConfig.PathItemBitmap.UpdateLastPath(Path.GetDirectoryName(SaveFileDialog1.FileName))
        End If

    End Sub



    'Private Sub SaveSC2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Me.SaveFileDialog1.DefaultExt = "sc2"
    '    Me.SaveFileDialog1.Filter = "Screen2 bin file|*.sc2"

    '    If Me.Path_SC2 = "" Then
    '        Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
    '    Else
    '        Me.SaveFileDialog1.InitialDirectory = Me.Path_SC2
    '    End If

    '    Me.SaveFileDialog1.FileName = Me.ProjectName

    '    If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.screen2.SaveSC2(SaveFileDialog1.FileName)
    '        Me.Path_SC2 = Path.GetDirectoryName(SaveFileDialog1.FileName)
    '    End If

    'End Sub






    'Private Sub LoadSC2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Me.OpenFileDialog1.FileName = ""
    '    Me.OpenFileDialog1.DefaultExt = "sc2"
    '    Me.OpenFileDialog1.Filter = "Screen2 bin file|*.sc2|Msx bin file|*.bin|All files|*.*"

    '    If Me.Path_SC2 = "" Then
    '        Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
    '    Else
    '        Me.OpenFileDialog1.InitialDirectory = Me.Path_SC2
    '    End If

    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        loadSC2(OpenFileDialog1.FileName)
    '        Me.Path_SC2 = Path.GetDirectoryName(OpenFileDialog1.FileName)
    '    End If

    'End Sub






    'Private Sub mainWindow_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
    '    Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
    '    Dim tmpFilePath As String = tmpstr(0)
    '    Dim extension As String = Path.GetExtension(tmpFilePath).ToLower

    '    If extension = ".gif" Or extension = ".png" Then
    '        loadBitmap(tmpFilePath)
    '        'ElseIf extension = ".sc2" Then
    '        '    loadSC2(tmpFilePath)
    '    End If
    'End Sub



    'Private Sub mainWindow_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
    '    If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub



    'Private Sub setTMS9918paletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.screen2.PaletteType = TMS9918.MSXVDP.TMS9918
    '    Me.screen2.RefreshScreen()
    'End Sub



    Private Sub BankComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles BankComboBox.SelectedIndexChanged
        Dim nbank As Integer = Me.BankComboBox.SelectedIndex

        If nbank = 0 Then
            ClearBank(0)
        Else
            ShowSpriteSet(0, Me._spriteProject.GetSpriteset(nbank - 1))
        End If

        Me.TMS9918Aviewer.RefreshScreen()

    End Sub



    Private Sub BankBComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) ' Handles BankBComboBox.SelectedIndexChanged
        Dim nbank As Integer = Me.BankBComboBox.SelectedIndex
        If nbank = 0 Then
            ClearBank(1)
        Else
            ShowSpriteSet(1, Me._spriteProject.GetSpriteset(nbank - 1))
        End If
        Me.TMS9918Aviewer.RefreshScreen()
    End Sub



    Private Sub BankCComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) ' Handles BankCComboBox.SelectedIndexChanged
        Dim nbank As Integer = Me.BankCComboBox.SelectedIndex
        If nbank = 0 Then
            ClearBank(2)
        Else
            ShowSpriteSet(2, Me._spriteProject.GetSpriteset(nbank - 1))
        End If
        Me.TMS9918Aviewer.RefreshScreen()
    End Sub



    Private Sub PaletteComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) ' Handles PaletteComboBox.SelectedIndexChanged

        'Dim selectedPalette As iPaletteMSX = Me._paletteProject.GetPalette(Me.PaletteComboBox.SelectedIndex)
        Me.TMS9918Aviewer.Palette = Me.Palettes.GetPalette(Me.PaletteComboBox.SelectedIndex)
        Me.TMS9918Aviewer.RefreshScreen()

    End Sub



    Private Sub RefreshPaletteSelector()
        Dim counter As Integer = 1
        Me.PaletteComboBox.Items.Clear()
        Me.PaletteComboBox.Items.Add("0 - " + Me.Palettes.GetPaletteByID(0).Name)
        If Me.Palettes.Count > 0 Then
            For Each aName As String In Me.Palettes.GetNameList()
                Me.PaletteComboBox.Items.Add(CStr(counter) + " - " + aName)
                counter += 1
            Next
        End If
    End Sub



    Private Sub Ok_Button_Click(sender As Object, e As EventArgs) Handles Ok_Button.Click
        SaveBitmap()
    End Sub



End Class