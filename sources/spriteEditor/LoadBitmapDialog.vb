Imports System.IO


Public Class LoadBitmapDialog

    Private AppConfig As Config

    'Public Path_SC2 As String = ""
    'Public Path_Bitmap As String = ""

    Private FileName As String
    Private FilePath As String

    Private VRAM(&H3FFF) As Byte ' 16k de memoria de video

    Private spritePatternsBitmap As Bitmap  ' <<< ---------------------- change to tilesetBitmap #######################################

    Private myBitmapImage As Bitmap

    'Private ColorPalette As iPaletteMSX
    Private Palettes As PaletteProject



    Public Sub New(ByVal _config As Config, ByRef colorPalettes As PaletteProject, ByVal filePath As String) ', ByVal _pathSC2 As String, ByVal _pathBitmap As String

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.FileName = "newTileset"
        Me.FilePath = filePath

        Me.Palettes = colorPalettes

        'Me.Path_SC2 = Me.AppConfig.PathItemBinary.Path '_pathSC2
        'Me.Path_Bitmap = Me.AppConfig.PathItemBitmap.Path '_pathBitmap

    End Sub




    Private Sub BitmapWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.spritePatternsBitmap = New Bitmap(256, 64)
        Me.patternsPictureBox.Image = Me.spritePatternsBitmap

        Me.SizeComboBox.SelectedIndex = 1
        Me.ModeComboBox.SelectedIndex = 0
        Me.BankComboBox.SelectedIndex = 0

        Me.BGColorButton.Palette = Palettes.GetPalette(0)
        Me.BGColorButton.SetColor(0)

        'Me.InkColorLabel.Enabled = False
        'Me.InkColorButton.Enabled = False

        If System.IO.File.Exists(Me.FilePath) Then
            LoadBitmap(Me.FilePath)
        End If

        AddHandler ModeComboBox.SelectedIndexChanged, AddressOf ModeComboBox_SelectedIndexChanged
        AddHandler SizeComboBox.SelectedIndexChanged, AddressOf SizeComboBox_SelectedIndexChanged
        AddHandler BankComboBox.SelectedIndexChanged, AddressOf BankComboBox_SelectedIndexChanged

    End Sub



    Private Sub LoadBitmap(ByVal newPath As String)

        Dim newImage As Image = Image.FromFile(FilePath)
        Me.myBitmapImage = New Bitmap(newImage, 256, 192)
        newImage.Dispose() 'para que no bloquee el fichero


        Me.FilePath = newPath
        Me.FileName = Path.GetFileNameWithoutExtension(newPath)

        ConvertBitmap()

        Me.BankComboBox.Enabled = True
        Me.Ok_Button.Enabled = True  ' ya hay algo que transpasar

        If Me.BankComboBox.SelectedIndex = 0 Then
            SetBank(0)
        Else
            Me.BankComboBox.SelectedIndex = 0
        End If

        Me.NameTextBox.Text = Me.FileName + "_SSET"

    End Sub



    Private Sub ConvertBitmap()

        Dim aBitmapConverter As New SimpleBitmapConverter
        Dim BGcolor As Byte = aBitmapConverter.GetMostUsedColor(Me.myBitmapImage)
        Me.VRAM = aBitmapConverter.GetScreenFromBitmap(Me.myBitmapImage, BGcolor) ', Me.BGColorButton.SelectedColor)

        'Me.TMS9918Aviewer.Optimize()

    End Sub



    Public Function GetSpriteset() As SpritesetMSX

        Dim spriteSET As SpritesetMSX
        Dim nBank As Integer = Me.BankComboBox.SelectedIndex

        If Me.SizeComboBox.SelectedIndex = 0 Then
            spriteSET = GetSpriteset8(nBank)
        Else
            spriteSET = GetSpriteset16(nBank)
        End If

        Return spriteSET

    End Function



    Public Function GetSpriteset8(ByVal nBank As Integer) As SpritesetMSX

        Dim spriteSET As SpritesetMSX
        Dim sprite As SpriteMSX

        Dim patternData(7) As Byte
        Dim colorData(7) As Byte

        Dim npattern As Short = 0

        Dim x As Byte
        Dim y As Byte

        Dim i As Byte

        Dim colorInk As Byte
        Dim lastColor As Byte
        Dim BGcolorUsedInPicture = Me.BGColorButton.SelectedColor

        Dim patternVRAMaddr As Short

        Dim tilesetName As String = Me.NameTextBox.Text
        'If tilesetName = "" Then
        '    tilesetName = "TSET_B" + CStr(nBank)
        'End If

        spriteSET = New SpritesetMSX(tilesetName, SpriteMSX.SPRITE_SIZE.SIZE8, Me.ModeComboBox.SelectedIndex + 1, 15, 0, Me.Palettes.GetPalette(0))

        patternVRAMaddr = iVDP.TableBase.GRPCGP + (&H800 * nBank)

        For y = 0 To 7
            For x = 0 To 31

                Array.Copy(Me.VRAM, patternVRAMaddr, patternData, 0, 8)


                'make a list of the colors of each line
                lastColor = BGcolorUsedInPicture
                For i = 0 To 7
                    colorInk = Me.VRAM(iVDP.TableBase.GRPCOL + patternVRAMaddr + i) 'the value contains the ink color and the background color
                    colorInk = colorInk >> 4 'get ink color
                    If colorInk = BGcolorUsedInPicture Then
                        colorInk = lastColor
                    Else
                        lastColor = colorInk
                    End If
                    colorData(i) = colorInk
                Next


                colorInk = GetMostUsedColor(colorData, BGcolorUsedInPicture)

                'If Me.ModeComboBox.SelectedIndex = 0 Then
                '    ' Sprites mode 0 (monocolor) TMS9918A
                '    For i = 0 To 7
                '        colorData(i) = colorInk
                '    Next
                'End If

                ' Fill the first empty color lines with the most used color. Enhance compression using RLE.
                For i = 0 To 7
                    If colorData(i) = BGcolorUsedInPicture Then
                        colorData(i) = colorInk
                    End If
                Next


                sprite = New SpriteMSX(npattern, "sprite_" + CStr(npattern), SpriteMSX.SPRITE_SIZE.SIZE8, Me.ModeComboBox.SelectedIndex + 1, colorInk, BGcolorUsedInPicture, patternData, colorData, Me.Palettes.GetPalette(0))

                spriteSET.SetSprite(sprite)

                patternVRAMaddr += 8

                npattern += 1
            Next

        Next

        Return spriteSET

    End Function



    Public Function GetSpriteset16(ByVal nBank As Integer) As SpritesetMSX

        Dim spriteSET As SpritesetMSX
        Dim sprite As SpriteMSX

        Dim patternData(31) As Byte
        Dim colorData(15) As Byte

        Dim npattern As Short = 0

        Dim x As Byte
        Dim y As Byte

        Dim i As Byte

        Dim colorSprite As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte
        Dim lastColor As Byte
        Dim BGcolorUsedInPicture = Me.BGColorButton.SelectedColor

        Dim colorLine As Short

        Dim patternVRAMaddr As Short

        Dim tilesetName As String = Me.NameTextBox.Text
        'If tilesetName = "" Then
        '    tilesetName = "new_TSET"
        'End If

        spriteSET = New SpritesetMSX(tilesetName, SpriteMSX.SPRITE_SIZE.SIZE16, Me.ModeComboBox.SelectedIndex + 1, 15, 0, Me.Palettes.GetPalette(0))

        patternVRAMaddr = iVDP.TableBase.GRPCGP + (&H800 * nBank)

        ' convert a tileset G2 to spriteset
        For y = 0 To 3
            For x = 0 To 15

                Array.Copy(Me.VRAM, patternVRAMaddr, patternData, 0, 8)
                Array.Copy(Me.VRAM, patternVRAMaddr + 256, patternData, 8, 8)
                Array.Copy(Me.VRAM, patternVRAMaddr + 8, patternData, 16, 8)
                Array.Copy(Me.VRAM, patternVRAMaddr + 256 + 8, patternData, 24, 8)

                'make a list of the colors of each line
                colorLine = 0
                lastColor = BGcolorUsedInPicture
                For i = 0 To 15
                    colorInk = Me.VRAM(iVDP.TableBase.GRPCOL + patternVRAMaddr + colorLine) 'the value contains the ink color and the background color
                    colorBG = colorInk And 15 ' Background color
                    colorInk = colorInk >> 4 'get ink color

                    If colorInk = colorBG Then
                        'If nothing is painted in this 8x8 block, the color of the right block is used.
                        colorInk = Me.VRAM(iVDP.TableBase.GRPCOL + patternVRAMaddr + colorLine + 8)
                        'colorBG = colorInk And 15 ' Background color
                        colorInk = colorInk >> 4 'get ink color
                    End If

                    If colorInk = BGcolorUsedInPicture Then
                        colorInk = lastColor
                    Else
                        lastColor = colorInk
                    End If

                    'If colorInk = BGcolorUsedInPicture Then
                    '    colorInk = colorBG
                    '    patternData(i) = Not patternData(i)
                    '    patternData(i + 16) = Not patternData(i + 16)
                    'End If

                    'If colorInk = 1 Then
                    '    colorInk = 0         ' <<<<<<<<<<<<< ?? mirar que en la conversion proporcione 1 en vez de 0
                    'End If

                    ' If patternData(i)=0 colorInk ?????

                    colorData(i) = colorInk
                    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  MEJORAR


                    colorLine += 1
                    If colorLine = 8 Then
                        colorLine = 256  'jump to down tile color data
                    End If
                Next


                colorSprite = GetMostUsedColor(colorData, BGcolorUsedInPicture)

                ' Fill the first empty color lines with the most used color. Enhance compression using RLE.
                For i = 0 To 15
                    If colorData(i) = BGcolorUsedInPicture Then
                        colorData(i) = colorSprite
                    End If
                Next


                'If Me.ModeComboBox.SelectedIndex = 0 Then
                '    ' Sprites mode 0 (monocolor) TMS9918A
                '    For i = 0 To 15
                '        colorData(i) = colorInk
                '    Next
                'End If


                sprite = New SpriteMSX(npattern, "", SpriteMSX.SPRITE_SIZE.SIZE16, Me.ModeComboBox.SelectedIndex + 1, colorSprite, BGcolorUsedInPicture, patternData, colorData, Me.Palettes.GetPalette(0))
                spriteSET.SetSprite(sprite)

                patternVRAMaddr += 16

                npattern += 1
            Next

            patternVRAMaddr += 256

        Next

        Return spriteSET

    End Function



    Private Sub SetBank(ByVal nBank As Integer)

        If Me.SizeComboBox.SelectedIndex = 0 Then
            'sprites 8x8
            drawSpriteset8(nBank)
        Else
            'sprites 16x16
            drawSpriteset16(nBank)
        End If

    End Sub



    Private Function GetMostUsedColor(ByVal colorData As Byte(), ByVal BGcolor As Byte) As Byte

        Dim value As Integer = 0
        Dim aColor As Byte
        Dim aColorList As New SortedList()
        Dim tmpColor As Byte


        For i = 0 To colorData.Length - 1
            aColor = colorData(i)
            If aColorList.ContainsKey(aColor) Then
                aColorList.Item(aColor) = aColorList.Item(aColor) + 1
            Else
                aColorList.Add(aColor, 1)
            End If
        Next


        aColor = BGcolor

        For Each itemKey As Byte In aColorList.Keys
            tmpColor = aColorList.Item(itemKey)
            If tmpColor > value And Not itemKey = BGcolor Then
                value = aColorList.Item(itemKey)
                aColor = itemKey
            End If
        Next

        Return aColor

    End Function



    Private Sub drawSpriteset8(ByVal nBank As Integer)

        Dim spriteSET As SpritesetMSX
        Dim sprite As SpriteMSX

        Dim npattern As Short = 0

        Dim spriteBitmap As Bitmap

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)
        aGraphics.Clear(Me.Palettes.GetPalette(0).GetRGBColor(Me.BGColorButton.SelectedColor))

        Dim x As Byte
        Dim y As Byte

        spriteSET = GetSpriteset8(nBank)

        For y = 0 To 7
            For x = 0 To 31
                sprite = spriteSET.GetSprite(npattern)

                spriteBitmap = sprite.GetBitmapX1()

                aGraphics.DrawImage(spriteBitmap, (x * 8), (y * 8))
                aGraphics.Flush()

                npattern += 1
            Next
        Next

        Me.patternsPictureBox.Refresh()

    End Sub



    Private Sub drawSpriteset16(ByVal nBank As Integer)

        Dim spriteSET As SpritesetMSX
        Dim sprite As SpriteMSX

        Dim npattern As Short = 0

        Dim x As Byte
        Dim y As Byte

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)
        aGraphics.Clear(Me.Palettes.GetPalette(0).GetRGBColor(Me.BGColorButton.SelectedColor))

        spriteSET = GetSpriteset16(nBank)

        ' convert a tileset G2 to spriteset
        For y = 0 To 3
            For x = 0 To 15
                sprite = spriteSET.GetSprite(npattern)

                aGraphics.DrawImage(sprite.GetBitmapX1(), (x * 16), (y * 16))
                aGraphics.Flush()

                npattern += 1
            Next
        Next

        Me.patternsPictureBox.Refresh()

    End Sub



    'Private Function GetBitmap8(ByVal patternData() As Byte, ByVal colorData() As Byte) As Bitmap

    '    Dim TempValue As Byte = 0
    '    Dim colorPixel As Byte
    '    Dim colorBG As Byte = Me.BGColorButton.SelectedColor
    '    Dim tileBitmap As Bitmap

    '    tileBitmap = New Bitmap(8, 8)

    '    For y As Integer = 0 To 7

    '        TempValue = patternData(y)
    '        For x As Integer = 0 To 7
    '            If ((TempValue >> x) And 1) = 1 Then
    '                ' Ink Color
    '                colorPixel = colorData(y)
    '            Else
    '                ' BackGround Color
    '                colorPixel = colorBG
    '            End If

    '            tileBitmap.SetPixel(7 - x, y, Palettes.GetPalette(0).GetRGBColor(colorPixel))

    '        Next

    '    Next

    '    Return tileBitmap

    'End Function



    'Private Function GetBitmap16(ByVal patternData() As Byte, ByVal colorData() As Byte) As Bitmap

    '    Dim TempValue As Byte = 0
    '    Dim colorPixel As Byte
    '    Dim colorBG As Byte = Me.BGColorButton.SelectedColor
    '    Dim tileBitmap As Bitmap

    '    Dim patternPointer As Short = 0

    '    tileBitmap = New Bitmap(16, 16)

    '    For y As Integer = 0 To 15

    '        TempValue = patternData(patternPointer)
    '        For x As Integer = 0 To 7
    '            If ((TempValue >> x) And 1) = 1 Then
    '                ' Ink Color
    '                colorPixel = colorData(y)
    '            Else
    '                ' BackGround Color
    '                colorPixel = colorBG
    '            End If

    '            tileBitmap.SetPixel(7 - x, y, Palettes.GetPalette(0).GetRGBColor(colorPixel))

    '        Next

    '        TempValue = patternData(patternPointer + 8)
    '        For x As Integer = 0 To 7
    '            If ((TempValue >> x) And 1) = 1 Then
    '                ' Ink Color
    '                colorPixel = colorData(y)
    '            Else
    '                ' BackGround Color
    '                colorPixel = colorBG
    '            End If

    '            tileBitmap.SetPixel(8 + (7 - x), y, Palettes.GetPalette(0).GetRGBColor(colorPixel))

    '        Next

    '        patternPointer += 1
    '        If patternPointer = 8 Then
    '            patternPointer = 16
    '        End If

    '    Next

    '    Return tileBitmap

    'End Function






    ' Events ####
#Region "Events"


    'Private Sub LoadBitmapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadBitmapButton.Click
    '    OpenFileDialog1.FileName = ""
    '    OpenFileDialog1.DefaultExt = ".png"
    '    OpenFileDialog1.Filter = "PNG documents (.PNG)|*.png|GIF documents (.GIF)|*.gif"

    '    If Me.FilePath = "" Then
    '        Me.OpenFileDialog1.InitialDirectory = Application.StartupPath 'Me.AppConfig.PathItemBitmap.Path
    '    Else
    '        Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.FilePath)
    '    End If

    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        LoadBitmap(Me.OpenFileDialog1.FileName)
    '        'Me.AppConfig.PathItemBitmap.UpdateLastPath(Path.GetDirectoryName(Me.Path_Bitmap))
    '    End If

    'End Sub



    'Private Sub mainWindow_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
    '    Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
    '    Dim tmpFilePath As String = tmpstr(0)
    '    Dim extension As String = Path.GetExtension(tmpFilePath).ToLower

    '    If extension = ".gif" Or extension = ".png" Then
    '        LoadBitmap(tmpFilePath)
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



    Private Sub BankComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetBank(Me.BankComboBox.SelectedIndex)
    End Sub



    Private Sub ModeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetBank(BankComboBox.SelectedIndex)
    End Sub



    Private Sub SizeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles SizeComboBox.SelectedIndexChanged
        SetBank(BankComboBox.SelectedIndex)
    End Sub




    Private Sub BGColorButton_Changed(color As System.Byte) Handles BGColorButton.ColorChanged

        If Not Me.myBitmapImage Is Nothing Then
            ConvertBitmap()
            SetBank(Me.BankComboBox.SelectedIndex)
        End If

    End Sub



    Private Sub InkColorButton_ColorChanged(color As Byte)
        If Not Me.myBitmapImage Is Nothing Then
            ConvertBitmap()
            SetBank(Me.BankComboBox.SelectedIndex)
        End If
    End Sub



#End Region




End Class