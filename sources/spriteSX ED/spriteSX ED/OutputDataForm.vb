Public Class OutputDataForm

    Public Sprites As SpriteList
    Public PaletteColors As MSXpalette

    Private _ProjectName As String  '= ""
    Private _ProjectSize As SpriteMSX.SPRITE_SIZE  ' 0=8x8,  1=16x16 
    Private _ProjectMode As SpriteMSX.SPRITE_MODE  ' 1=MSX1, 2=MSX2


    'Public Shadows Enum DataLanguage As Byte
    '    BASIC = 0
    '    C = 1
    '    ASSEMBLER = 2
    '    ASM_SDCC = 3
    'End Enum


    Public Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            Me._ProjectName = value
        End Set
    End Property

    Public Property ProjectSize() As Integer
        Get
            Return Me._ProjectSize
        End Get
        Set(ByVal value As Integer)
            Me._ProjectSize = value
        End Set
    End Property


    Public Property ProjectMode() As Integer
        Get
            Return _ProjectMode
        End Get
        Set(ByVal value As Integer)
            Me._ProjectMode = value
            If value = 2 Then
                Me.ColorDataCheck.Enabled = True
                Me.ColorDataSizeCombo.Enabled = True
                Me.ColorNumCombo.Enabled = True
                If _ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                    Me.ColorSizeValuesCombo.SelectedIndex = 1
                    Me.ColorSizeValuesCombo.Enabled = True
                Else
                    Me.ColorSizeValuesCombo.SelectedIndex = 1
                    Me.ColorSizeValuesCombo.Enabled = False
                End If
            Else
                Me.ColorDataCheck.Enabled = False
                Me.ColorDataSizeCombo.Enabled = False
                Me.ColorNumCombo.Enabled = False
                Me.ColorSizeValuesCombo.Enabled = False
            End If
        End Set
    End Property


    Private aMSXDataFormat As New MSXDataFormat

    Private dataSize As Integer
    Private colorSize As Integer
    Private paletteSize As Integer

    Private LineNumber As Integer
    Private Interval As Integer


    Public Sub New() 'ByVal _projectName As String, ByVal _sprites As SortedList, ByVal _PaletteColors As PaletteMSX, ByVal _projectMode As Integer, ByVal _projectType As Integer

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.LanguageComboBox.SelectedIndex = MSXDataFormat.OutputFormat.ASM
        Me.AllNumCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

        'Me.SpriteNumCombo.SelectedIndex = 1
        'Me.ColorNumCombo.SelectedIndex = 1
        'Me.PaletteNumCombo.SelectedIndex = 0

        'Me.sprites = _sprites
        'Me.PaletteColors = _PaletteColors
        'Me.ProjectName = _projectName
        'Me.ProjectMode = _projectMode
        'Me.ProjectType = _projectType

        'If Not Me.ProjectMode = 2 Then
        '    Me.ColorDataCheck.Enabled = False
        '    Me.ColorDataSizeCombo.Enabled = False
        'End If

        reset()

    End Sub


    Private Sub OutputDataForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ValidateToSpriteValue()

    End Sub


    Public Sub reset()

        Me.SpriteSizeCombo.SelectedIndex = 2
        Me.ColorDataSizeCombo.SelectedIndex = 2
        Me.PaletteSizeCombo.SelectedIndex = 0

        If Me.ProjectMode = 2 Then
            Me.PaletteCheck.Checked = True
        Else
            Me.PaletteCheck.Checked = False
        End If

        Me.OutputText.Clear()

        'me.LineNumberText.Text = "10000"
        'Me.IntervalText.Text = "10"

    End Sub


    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub GetDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDataButton.Click

        SetParameters()

        Select Case Me.LanguageComboBox.SelectedIndex
            Case MSXDataFormat.OutputFormat.BASIC
                GenBASICData()
            Case MSXDataFormat.OutputFormat.C
                GenCData()
            Case MSXDataFormat.OutputFormat.ASM
                GenASMData()
            Case MSXDataFormat.OutputFormat.ASM_SDCC
                GenAsmSDCCData()
        End Select


    End Sub


    Private Sub SetParameters()

        dataSize = CInt(Me.SpriteSizeCombo.SelectedItem)
        colorSize = CInt(Me.ColorDataSizeCombo.SelectedItem)
        paletteSize = CInt(Me.PaletteSizeCombo.SelectedItem)


        If IsNumeric(Me.LineNumberText.Text) Then
            Me.LineNumber = CInt(Me.LineNumberText.Text)
            If Me.LineNumber < 1 Or Me.LineNumber > 60000 Then
                Me.LineNumber = 10000
            End If

        Else
            Me.LineNumber = 10000
        End If

        If IsNumeric(Me.IntervalText.Text) Then
            Me.Interval = CInt(Me.IntervalText.Text)
            If Me.Interval < 1 Or Me.Interval > 255 Then
                Me.Interval = 10
            End If

        Else
            Me.Interval = 10
        End If


    End Sub


    Private Sub GenBASICData()
        Dim anOutput As String = ""
        Dim colorLineSize As Integer = 4

        anOutput = CStr(Me.LineNumber) + " REM " + Me.ProjectName + vbNewLine

        Me.LineNumber += Me.Interval

        Me.aMSXDataFormat.lastLineNumber = Me.LineNumber

        If Me.SpriteCheck.Checked Then
            'anOutput = "// SPRITE DATA" + vbNewLine
            Dim comments As New ArrayList
            comments.Add("SPRITE DATA")
            anOutput += aMSXDataFormat.BasicMSX_codeGen(getSpritesData(), dataSize, Me.SpriteNumCombo.SelectedIndex, Me.RemoveZerosCheck.Checked, Me.LineNumber, Me.Interval, comments)
        End If

        anOutput += vbNewLine

        ' colores de los sprites en modo 2

        If Me.ProjectMode = 2 Then
            If Me.ColorDataCheck.Checked Then
                Dim comments As New ArrayList
                comments.Add("COLOR MODE2 DATA")
                anOutput += aMSXDataFormat.BasicMSX_codeGen(getColorsData(), colorSize, Me.ColorNumCombo.SelectedIndex, Me.RemoveZerosCheck.Checked, aMSXDataFormat.lastLineNumber, Me.Interval, comments)
            End If
        End If


        If Me.ColorDataCheck.Checked And Me.PaletteCheck.Checked Then
            anOutput += vbNewLine
        End If

        If Me.PaletteCheck.Checked Then
            '; RB,G
            If Not PaletteColors Is Nothing Then
                Dim comments As New ArrayList
                comments.Add(PaletteColors.name)
                'If Me.IncludeIndexCheck.Checked Then
                '    comments.Add("Num color, Red, Green, Blue")
                'Else
                comments.Add("Red, Green, Blue")
                colorLineSize = 3
                'End If

                anOutput += aMSXDataFormat.BasicMSX_codeGen(PaletteColors.getDataBasic(), colorLineSize, Me.PaletteNumCombo.SelectedIndex, Me.RemoveZerosCheck.Checked, aMSXDataFormat.lastLineNumber, Me.Interval, comments)
            End If
        End If

        OutputText.Text = anOutput

    End Sub


    Private Sub GenASMData()
        Dim anOutput As String = ""
        Dim aSprite As SpriteMSX

        Dim initSprite As Integer
        Dim endSprite As Integer

        ' recoge los valores del rango de sprites a generar codigo
        If RangeCheck.Checked Then
            initSprite = CInt(Me.fromTextBox.Text)
            endSprite = CInt(Me.toTextBox.Text)
        Else
            initSprite = 0
            endSprite = Me.Sprites.Count - 1
        End If

        anOutput = "; " + Me.ProjectName + vbNewLine + vbNewLine

        If Me.SpriteCheck.Checked Then
            anOutput += "SPRITE_DATA:" + vbNewLine

            'For i = 0 To Me.Sprites.Count - 1
            For i = initSprite To endSprite
                aSprite = Me.Sprites.GetSpriteByIndex(i)
                Dim comments As New ArrayList
                comments.Add(CStr(aSprite.order) + "-" + aSprite.name)
                anOutput += aMSXDataFormat.Asm_codeGen(aSprite.gfxData, dataSize, Me.SpriteNumCombo.SelectedIndex, "", comments, "db")
            Next

            'For Each aSprite As SpriteMSX In sprites.Values
            '    Dim comments As New ArrayList
            '    comments.Add(aSprite.name)
            '    anOutput += aMSXDataFormat.AsMSX_codeGen(aSprite.gfxData, dataSize, Me.SpriteNumCombo.SelectedIndex, "", comments)
            'Next

        End If

        anOutput += vbNewLine + vbNewLine

        If Me.ProjectMode = 2 Then
            If Me.ColorDataCheck.Checked Then
                anOutput += "COLOR_DATA:" + vbNewLine
                'For i = 0 To Me.Sprites.Count - 1
                For i = initSprite To endSprite
                    aSprite = Me.Sprites.GetSpriteByIndex(i)
                    Dim comments As New ArrayList
                    comments.Add(CStr(aSprite.order) + "-" + aSprite.name)
                    anOutput += aMSXDataFormat.Asm_codeGen(getSpriteColorData(aSprite), colorSize, Me.ColorNumCombo.SelectedIndex, "", comments, "db")
                Next
            End If

            If Me.ColorDataCheck.Checked And Me.PaletteCheck.Checked Then
                anOutput += vbNewLine + vbNewLine
            End If
        End If

        If Me.PaletteCheck.Checked Then
            '; RB,G
            anOutput += "; " + PaletteColors.name + vbNewLine
            If Not PaletteColors Is Nothing Then
                Dim comments As New ArrayList
                comments.Add("RB,G")
                anOutput += aMSXDataFormat.Asm_codeGen(PaletteColors.getData(), paletteSize, Me.PaletteNumCombo.SelectedIndex, "PALETTE_DATA", comments, "db")
            End If
        End If

        OutputText.Text = anOutput

    End Sub


    Private Sub GenAsmSDCCData()
        Dim anOutput As String = ""
        Dim aSprite As SpriteMSX

        Dim initSprite As Integer
        Dim endSprite As Integer

        ' recoge los valores del rango de sprites a generar codigo
        If RangeCheck.Checked Then
            initSprite = CInt(Me.fromTextBox.Text)
            endSprite = CInt(Me.toTextBox.Text)
        Else
            initSprite = 0
            endSprite = Me.Sprites.Count - 1
        End If

        anOutput = "; " + Me.ProjectName + vbNewLine + vbNewLine

        If Me.SpriteCheck.Checked Then
            anOutput += "SPRITE_DATA:" + vbNewLine
            'For i = 0 To Me.Sprites.Count - 1
            For i = initSprite To endSprite
                aSprite = Me.Sprites.GetSpriteByIndex(i)
                Dim comments As New ArrayList
                comments.Add(CStr(aSprite.order) + "-" + aSprite.name)
                anOutput += aMSXDataFormat.Asm_codeGen(aSprite.gfxData, dataSize, Me.SpriteNumCombo.SelectedIndex, "", comments, ".db")
            Next
        End If

        anOutput += vbNewLine + vbNewLine

        If Me.ProjectMode = 2 Then
            If Me.ColorDataCheck.Checked Then
                anOutput += "COLOR_DATA:" + vbNewLine
                'For i = 0 To Me.Sprites.Count - 1
                For i = initSprite To endSprite
                    aSprite = Me.Sprites.GetSpriteByIndex(i)
                    Dim comments As New ArrayList
                    comments.Add(CStr(aSprite.order) + "-" + aSprite.name)
                    anOutput += aMSXDataFormat.Asm_codeGen(getSpriteColorData(aSprite), Me.colorSize, Me.ColorNumCombo.SelectedIndex, "", comments, ".db")
                Next
            End If

            If Me.ColorDataCheck.Checked And Me.PaletteCheck.Checked Then
                anOutput += vbNewLine + vbNewLine
            End If
        End If

        If Me.PaletteCheck.Checked Then
            '; RB,G
            anOutput += "; " + PaletteColors.name + vbNewLine
            If Not PaletteColors Is Nothing Then
                Dim comments As New ArrayList
                comments.Add("RB,G")
                anOutput += aMSXDataFormat.Asm_codeGen(PaletteColors.getData(), paletteSize, Me.PaletteNumCombo.SelectedIndex, "PALETTE_DATA", comments, ".db")
            End If
        End If

        OutputText.Text = anOutput

    End Sub



    Private Sub GenCData()
        Dim anOutput As String = ""
        'Dim tmpData As Byte()

        'Dim counter As Integer = 0

        anOutput = "// " + Me.ProjectName + vbNewLine + vbNewLine


        If Me.SpriteCheck.Checked Then
            Dim comments As New ArrayList
            comments.Add("SPRITE DATA")
            anOutput += aMSXDataFormat.C_codeGen(getSpritesData(), dataSize, Me.SpriteNumCombo.SelectedIndex, "SPRITE_DATA", comments)
        End If

        anOutput += vbNewLine + vbNewLine

        If Me.ProjectMode = 2 Then
            If Me.ColorDataCheck.Checked Then
                Dim comments As New ArrayList
                comments.Add("SPRITE COLORS")
                anOutput += aMSXDataFormat.C_codeGen(Me.getColorsData(), Me.colorSize, Me.ColorNumCombo.SelectedIndex, "COLOR_DATA", comments)
            End If

            If Me.ColorDataCheck.Checked And Me.PaletteCheck.Checked Then
                anOutput += vbNewLine + vbNewLine
            End If
        End If

        If Me.PaletteCheck.Checked Then
            '; RB,G
            If Not PaletteColors Is Nothing Then
                Dim comments As New ArrayList
                comments.Add(PaletteColors.name)
                anOutput += aMSXDataFormat.C_codeGen(PaletteColors.getData(), paletteSize, Me.PaletteNumCombo.SelectedIndex, PaletteColors.name, comments)
            End If
        End If

        OutputText.Text = anOutput

    End Sub


    ''' <summary>
    ''' Junta todos los datos de los graficos de los sprites en un unico array
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getSpritesData() As Byte()
        Dim tmpData As Byte()
        Dim counter As Integer = 0
        Dim size As Integer
        Dim aSprite As SpriteMSX

        Dim initSprite As Integer
        Dim endSprite As Integer

        Dim dataLength As Integer
        If Me._ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            dataLength = 8
        Else
            dataLength = 32
        End If

        ' recoge los valores del rango de sprites a generar codigo
        If RangeCheck.Checked Then
            initSprite = CInt(Me.fromTextBox.Text)
            endSprite = CInt(Me.toTextBox.Text)
        Else
            initSprite = 0
            endSprite = Me.Sprites.Count - 1
        End If



        size = ((endSprite - initSprite + 1) * dataLength) - 1
        ReDim tmpData(size)

        'For i = 0 To Me.Sprites.Count - 1
        For i = initSprite To endSprite
            aSprite = Me.Sprites.GetSpriteByIndex(i)
            aSprite.gfxData.CopyTo(tmpData, counter * dataLength) '32
            counter += 1
        Next

        Return tmpData

    End Function


    ''' <summary>
    ''' Junta todos los datos de los colores de los sprites en un unico array
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColorsData() As Byte()
        Dim tmpData As Byte()
        Dim counter As Integer = 0
        Dim size As Integer
        Dim i As Integer
        Dim o As Integer
        Dim aSprite As SpriteMSX

        Dim dataLength As Integer

        Dim initSprite As Integer
        Dim endSprite As Integer

        ' recoge los valores del rango de sprites a generar codigo
        If RangeCheck.Checked Then
            initSprite = CInt(Me.fromTextBox.Text)
            endSprite = CInt(Me.toTextBox.Text)
        Else
            initSprite = 0
            endSprite = Me.Sprites.Count - 1
        End If

        'If Me._ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 And Me._ProjectMode = SpriteMSX.SPRITE_MODE.MONO Then
        If Me.ColorSizeValuesCombo.SelectedIndex = 0 Then
            dataLength = 7
        Else
            dataLength = 15
        End If
        'ReDim tmpData(dataLength)

        'size = (Sprites.Count * (dataLength + 1)) - 1
        size = ((endSprite - initSprite + 1) * (dataLength + 1)) - 1
        ReDim tmpData(size)

        'For i = 0 To Me.Sprites.Count - 1
        For i = initSprite To endSprite
            aSprite = Me.Sprites.GetSpriteByIndex(i)
            'aSprite.colorData.CopyTo(tmpData, counter * 16)
            'counter += 1
            For o = 0 To dataLength
                tmpData(counter) = aSprite.colorData(o) + getORBitValue(aSprite.ORbitData(o))
                counter += 1
            Next
        Next

        Return tmpData

    End Function


    Private Function getSpriteColorData(ByVal aSprite As SpriteMSX) As Byte()
        Dim tmpData As Byte()
        Dim dataLength As Integer

        'If Me._ProjectSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
        If Me.ColorSizeValuesCombo.SelectedIndex = 0 Then
            dataLength = 7
        Else
            dataLength = 15
        End If
        ReDim tmpData(dataLength)

        For i As Integer = 0 To dataLength
            tmpData(i) = aSprite.colorData(i) + getORBitValue(aSprite.ORbitData(i))
        Next

        Return tmpData

    End Function


    Private Function getORBitValue(ByVal value As Boolean) As Byte
        Dim result As Byte = 0
        If value = True Then
            result = 64
        End If
        Return result
    End Function


    '''' <summary>
    '''' Genera un array con los datos de la paleta de colores
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function getPaletteData() As Byte()
    '    Dim tmpData(31) As Byte
    '    Dim counter As Integer = 0

    '    For Each aColor As ColorMSX In PaletteColors.Colors.Values
    '        tmpData(counter) = CByte(aColor.Red * 16 + aColor.Blue)
    '        counter += 1
    '        tmpData(counter) = aColor.Green
    '        counter += 1
    '    Next

    '    Return tmpData

    'End Function



    Private Sub saveCode(ByVal filePath As String)
        Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        aStreamWriterFile.WriteLine(Me.OutputText.Text)
        aStreamWriterFile.Close()
    End Sub



    Private Sub CopyAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllButton.Click

        If Me.OutputText.Text = "" Then
            MsgBox("Nothing to copy for you.", MsgBoxStyle.Exclamation, "Alert")
        Else
            My.Computer.Clipboard.SetText(Me.OutputText.Text)
        End If

    End Sub


    ''' <summary>
    ''' Muestra el dialogo para guardar un fichero. Lo prepara para el lenguaje seleccionado.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataButton.Click
        Dim resultado As System.Windows.Forms.DialogResult

        If Me.OutputText.Text = "" Then
            MsgBox("Nothing to save for you.", MsgBoxStyle.Exclamation, "Alert")

        Else

            Me.SaveFileDialog1.FileName = Me._ProjectName

            Select Case LanguageComboBox.SelectedIndex
                Case MSXDataFormat.OutputFormat.BASIC
                    Me.SaveFileDialog1.DefaultExt = "BAS"
                    Me.SaveFileDialog1.Filter = "BASIC file|*.BAS"
                Case MSXDataFormat.OutputFormat.C
                    Me.SaveFileDialog1.DefaultExt = "c"
                    Me.SaveFileDialog1.Filter = "C file|*.c"
                Case MSXDataFormat.OutputFormat.ASM
                    Me.SaveFileDialog1.DefaultExt = "asm"
                    Me.SaveFileDialog1.Filter = "ASM file|*.asm"
                Case MSXDataFormat.OutputFormat.ASM_SDCC
                    Me.SaveFileDialog1.DefaultExt = "s"
                    Me.SaveFileDialog1.Filter = "ASM file|*.s"
            End Select

            'Me.SaveFileDialog1.Filter = "ASM file|*.asm|C file|*.c|BASIC file|*.bas"

            resultado = SaveFileDialog1.ShowDialog()

            If resultado = Windows.Forms.DialogResult.OK Then

                'Me.ProjectFilePath = SaveFileDialog1.FileName

                Me.saveCode(SaveFileDialog1.FileName)

            End If

        End If


    End Sub



    ''' <summary>
    ''' Cambia el estado de los controles segun tipo de lenguaje seleccionado. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LanguageComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LanguageComboBox.SelectedIndexChanged
        Select Case LanguageComboBox.SelectedIndex
            Case MSXDataFormat.OutputFormat.BASIC  'basic
                'Me.LineNumberLabel.Enabled = True
                'Me.LineNumberText.Enabled = True
                'Me.IntervalLabel.Enabled = True
                'Me.IntervalText.Enabled = True
                Me.BasicGroupBox.Enabled = True

                Me.RemoveZerosCheck.Enabled = True

                Me.PaletteSizeCombo.Visible = False
                'Me.IncludeIndexCheck.Enabled = True
                Me.PaletteNumCombo.SelectedIndex = 0

                Me.AllNumCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_nn


            Case MSXDataFormat.OutputFormat.C
                Me.BasicGroupBox.Enabled = False
                Me.PaletteSizeCombo.Visible = True
                Me.PaletteNumCombo.SelectedIndex = Me.AllNumCombo.SelectedIndex

                Me.AllNumCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn


            Case MSXDataFormat.OutputFormat.ASM
                Me.BasicGroupBox.Enabled = False
                Me.PaletteSizeCombo.Visible = True
                Me.PaletteNumCombo.SelectedIndex = Me.AllNumCombo.SelectedIndex

                Me.AllNumCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh


            Case MSXDataFormat.OutputFormat.ASM_SDCC
                Me.BasicGroupBox.Enabled = False
                Me.PaletteSizeCombo.Visible = True
                Me.PaletteNumCombo.SelectedIndex = Me.AllNumCombo.SelectedIndex

                Me.AllNumCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn


                'Case Else


        End Select
    End Sub




    Private Sub AllNumCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllNumCombo.SelectedIndexChanged
        Me.SpriteNumCombo.SelectedIndex = sender.SelectedIndex
        Me.ColorNumCombo.SelectedIndex = sender.SelectedIndex
        Me.PaletteNumCombo.SelectedIndex = sender.SelectedIndex
    End Sub


    Private Sub toTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles toTextBox.Validating
        ValidateToSpriteValue()
    End Sub


    Private Sub ValidateToSpriteValue()
        Dim endSprite As Integer = CInt(Me.toTextBox.Text)

        If endSprite > (Me.Sprites.Count - 1) Then
            Me.toTextBox.Text = CStr(Me.Sprites.Count - 1)
        End If
    End Sub


    Private Sub AllSpritesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllSpritesButton.Click
        Me.fromTextBox.Text = "0"
        Me.toTextBox.Text = CStr(Me.Sprites.Count - 1)
    End Sub

    Private Sub RangeCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangeCheck.CheckedChanged

        Dim value As Boolean = RangeCheck.Checked

        FromLabel.Enabled = value
        fromTextBox.Enabled = value
        ToLabel.Enabled = value
        toTextBox.Enabled = value
        AllSpritesButton.Enabled = value

    End Sub
End Class