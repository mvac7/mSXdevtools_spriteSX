Imports System.IO


Public Class MSXBASICGraphicsDialog

    Private AppConfig As Config
    Private Project As tMSgfXProject

    'Public Path_SC2 As String = ""

    Public Sprites As SpritesetMSX

    Private spritesetID As Integer

    Private BitmapFilePath As String

    Private spritePatternsBitmap As Bitmap

    Private _ProgressController As ProgressController

    Private LoadPath As String

    Private ProjectPath As String


    Public Mode As IO_MODE



    Public Enum IO_MODE As Short
        LOAD
        SAVE
    End Enum



    Public Sub New(ByRef devtoolConfig As Config, ByRef _project As tMSgfXProject, ByVal _spritesetID As Integer) ', ByVal _pathSC2 As String, ByVal _pathBitmap As String

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.AppConfig = devtoolConfig
        Me.Project = _project

        Me.spritesetID = _spritesetID

        'Me.Path_SC2 = AppConfig.PathItemBinary.Path

        Me.Mode = IO_MODE.SAVE

    End Sub



    Public Sub New(ByRef devtoolConfig As Config, ByRef _project As tMSgfXProject, ByVal filePath As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.AppConfig = devtoolConfig
        Me.Project = _project

        Me.spritesetID = -1

        'Me.Path_SC2 = AppConfig.PathItemBinary.Path

        Me.LoadPath = filePath

        Me.Mode = IO_MODE.LOAD

    End Sub




    Private Sub SaveBinaryWin_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me._ProgressController = New ProgressController(Me.Owner)

        Me.spritePatternsBitmap = New Bitmap(256, 64)
        Me.patternsPictureBox.Image = Me.spritePatternsBitmap

        If Me.Mode = IO_MODE.LOAD Then
            Me.Ok_Button.Text = "Load"
            Me.Ok_Button.ButtonType = piXelST_Button.Button_TYPES.Load
            Me.Sprites = LoadSpritePatterns(Me.LoadPath)
            drawSpritePatterns()
            SpritesetDataUC.Enabled = True
        Else
            Me.Ok_Button.Text = "Save"
            Me.Ok_Button.ButtonType = piXelST_Button.Button_TYPES.Save
            If Me.spritesetID > 0 Then
                Me.Sprites = Me.Project.SpriteSets.GetSpritesetByID(Me.spritesetID)
                drawSpritePatterns()
            End If
            SpritesetDataUC.Enabled = False
        End If

        SpritesetDataUC.Initialize(Me.AppConfig, Me.Project, Me.Sprites, False)
        AddHandler Me.SpritesetDataUC.DataChanged, AddressOf SpritesetDataUC_DataChanged

    End Sub



    Private Sub drawSpritePatterns()

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)
        aGraphics.Clear(Me.Sprites.ColorPalette.GetRGBColor(Me.Sprites.BackgroundColor))  'Color.FromArgb(255, 0, 0, 0))

        Me.Sprites.Refresh()

        If Me.Sprites.Size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            drawSprites8Patterns()
        Else
            drawSprites16Patterns()
        End If

        Me.patternsPictureBox.Refresh()

    End Sub



    Private Sub drawSprites8Patterns()

        Dim npattern As Integer = 0
        Dim aSprite As Bitmap

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)

        Dim x As Integer
        Dim y As Integer

        For y = 0 To 7
            For x = 0 To 31 ' sprite patterns
                aSprite = Me.Sprites.GetSprite((y * 8) + x).GetBitmapX1()
                aGraphics.DrawImage(aSprite, (x * 8), (y * 8))
                aGraphics.Flush()
                npattern += 1
            Next
        Next

    End Sub



    Private Sub drawSprites16Patterns()

        Dim npattern As Integer = 0
        Dim aSprite As Bitmap

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)

        Dim x As Integer
        Dim y As Integer

        For y = 0 To 3
            For x = 0 To 15 ' sprite patterns
                aSprite = Me.Sprites.GetSprite((y * 16) + x).GetBitmapX1()
                aGraphics.DrawImage(aSprite, (x * 16), (y * 16))
                aGraphics.Flush()
                npattern += 4
            Next
        Next

    End Sub



    Private Sub SaveDialog()
        Me.SaveFileDialog1.DefaultExt = "spr"
        Me.SaveFileDialog1.Filter = "MSX BASIC Graphics|*.spr;*.sc2"

        If Me.ProjectPath = "" Then
            Me.SaveFileDialog1.InitialDirectory = Application.StartupPath
        Else
            Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.ProjectPath)
        End If

        Me.SaveFileDialog1.FileName = Me.Sprites.Name

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveSpritePatterns(SaveFileDialog1.FileName)

            Me.Close()

        End If
    End Sub



    Private Sub SaveSpritePatterns(ByVal filePath As String)
        Dim MSXBasicGFile As New MSXBasicGraphicsFileIO
        'MSXBasicGFile.SpriteSize = Me.Sprites.Size
        MSXBasicGFile.BSAVE(filePath, iVDP.TableBase.GRPPAT, Me.Sprites.GetPatternBinaryBloq(), 0, Me.Sprites.Size, True)
    End Sub



    Private Function LoadSpritePatterns(ByVal filePath As String) As SpritesetMSX

        Dim MSXBasicGFile As New MSXBasicGraphicsFileIO
        Dim spriteSet As SpritesetMSX
        Dim aName As String
        Dim spriteSetData(iVDP.TableBaseSize.GRPPAT - 1) As Byte
        Dim loadData() As Byte
        Dim VRAM(16383) As Byte
        Dim bloqSize As Integer


        aName = Path.GetFileNameWithoutExtension(filePath)
        loadData = MSXBasicGFile.BLOAD(filePath)


        If Not loadData Is Nothing Then

            bloqSize = loadData.Length

            If MSXBasicGFile.VRAMaddress + bloqSize > 16384 Then
                bloqSize = 16384 - MSXBasicGFile.VRAMaddress
            End If

            Array.Copy(loadData, 0, VRAM, MSXBasicGFile.VRAMaddress, bloqSize)  'block.Length-1
            Array.Copy(VRAM, iVDP.TableBase.GRPPAT, spriteSetData, 0, iVDP.TableBaseSize.GRPPAT)

            'If MSXBasicGFile.VRAMaddress >= TMS9918A.TableBase.GRPPAT And (MSXBasicGFile.VRAMaddress + loadData.Length) <= (TMS9918A.TableBase.GRPPAT + TMS9918A.TableBaseSize.GRPPAT) Then
            '    spriteSetData.cop()
            'End If

            spriteSet = New SpritesetMSX(aName, MSXBasicGFile.SpriteSize, SpriteMSX.SPRITE_MODE.MONO, 15, 0, Me.Project.Palettes.GetPalette(0), spriteSetData, Nothing)

        Else

            spriteSet = Nothing

            Dim messageWin As New MessageDialog()
            messageWin.ShowDialog(Me, "Load MSX BASIC Graphics", "Disk I/O error!", MessageDialog.DIALOG_TYPE.ALERT)

        End If


        Return spriteSet

    End Function


    'Private Sub SaveSpriteColors(ByVal filePath As String)
    '    Dim MSXBasicGFile As New MSXBasicGraphicsFile
    '    MSXBasicGFile.SpriteSize = Me.Sprites.Size
    '    MSXBasicGFile.BSAVE(filePath, TMS9918A.TableBase.SP2COL, Me.Sprites.GetColorBinaryBloq())
    'End Sub






    Private Sub SpritesetDataUC_DataChanged() 'Handles SpritesetDataUC.DataChanged
        If Me.Mode = IO_MODE.LOAD Then

            If Not Me.Sprites.Size = SpritesetDataUC.SpriteSize Or Not Me.Sprites.Mode = SpritesetDataUC.SpriteMode Then
                Me.Sprites.SetColorPalette(Me.Project.Palettes.GetPaletteByID(SpritesetDataUC.PaletteID))
                Me.Sprites.ConvertSpriteType(SpritesetDataUC.SpriteSize, SpritesetDataUC.SpriteMode)
            ElseIf Not Me.Sprites.InkColor = SpritesetDataUC.InkColor Or Not Me.Sprites.BackgroundColor = SpritesetDataUC.BackgroundColor Then
                Me.Sprites.InkColor = SpritesetDataUC.InkColor
                Me.Sprites.BackgroundColor = SpritesetDataUC.BackgroundColor
                Me.Sprites.SetDefaultColor()
            Else
                Me.Sprites.SetColorPalette(Me.Project.Palettes.GetPaletteByID(SpritesetDataUC.PaletteID))
            End If

            drawSpritePatterns()

        End If

    End Sub



    Private Sub Ok_Button_Click(sender As Object, e As EventArgs) Handles Ok_Button.Click
        If Me.Mode = IO_MODE.LOAD Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            SaveDialog()
        End If
    End Sub




End Class