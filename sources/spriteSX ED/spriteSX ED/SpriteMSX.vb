Public Class SpriteMSX

    Public ID As Integer
    Public order As Byte = 0
    Public name As String
    Public aBitmap As Bitmap

    Public size As SPRITE_SIZE ' 1 = 8x8,  2 = 16x16
    Public mode As SPRITE_MODE ' 1 = mono, 2 = color (MSX2)

    Public gfxData As Byte()
    Public colorData As Byte()
    Public ORbitData As Boolean()

    Public PaletteData As MSXpalette

    Public InkColor As Integer
    Public BGcolor As Integer
    'Public posX As Integer
    'Public posY As Integer
    'Public plane As Integer

    Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

    'Public Const MAX_8xSPRITES As Integer = 255
    'Public Const MAX_16xSPRITES As Integer = 63



    Public Shadows Enum SPRITE_SIZE As Integer
        INIT
        SIZE8
        SIZE16
    End Enum


    Public Shadows Enum SPRITE_MODE As Integer
        MONO = 1
        COLOR = 2
    End Enum


    Public Sub New()

    End Sub



    ''' <summary>
    ''' for mode 1 MSX1 with bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_bitmap"></param>
    ''' <param name="_size"></param>
    ''' <param name="_inkColor"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_gfx"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _name As String, ByVal _bitmap As Bitmap, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfx As Byte(), ByVal _PaletteData As MSXpalette)
        Me.ID = GetHashCode()

        Me.name = _name
        Me.aBitmap = _bitmap.Clone
        Me.size = _size
        Me.mode = SPRITE_MODE.MONO

        Me.InkColor = _inkColor
        Me.BGcolor = _bgColor

        Me.gfxData = _gfx.Clone

        Me.PaletteData = _PaletteData
    End Sub


    ''' <summary>
    ''' for mode 2 MSX2 with bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_bitmap"></param>
    ''' <param name="_size"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_gfx"></param>
    ''' <param name="_color"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _name As String, ByVal _bitmap As Bitmap, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfx As Byte(), ByVal _color As Byte(), ByVal _ORdata As Boolean(), ByVal _PaletteData As MSXpalette)

        Me.ID = GetHashCode()

        Me.name = _name
        Me.size = _size
        Me.mode = SPRITE_MODE.COLOR

        Me.aBitmap = _bitmap.Clone

        Me.InkColor = _inkColor
        Me.BGcolor = _bgColor

        Me.gfxData = _gfx.Clone
        Me.colorData = _color.Clone
        Me.ORbitData = _ORdata.Clone

        Me.PaletteData = _PaletteData

    End Sub



    ''' <summary>
    ''' for mode 1 MSX1 without bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_size"></param>
    ''' <param name="_inkColor"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_gfx"></param>
    ''' <param name="_PaletteData"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _name As String, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfx As Byte(), ByVal _PaletteData As MSXpalette)

        Me.ID = GetHashCode()

        Me.name = _name

        Me.size = _size
        Me.mode = SPRITE_MODE.MONO

        Me.InkColor = _inkColor
        Me.BGcolor = _bgColor

        Me.gfxData = _gfx.Clone

        Me.PaletteData = _PaletteData

        refresh()

    End Sub


    
    'Public Sub New(ByVal _name As String, ByVal _size As SPRITE_SIZE, ByVal _mode As SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _PaletteData As PaletteMSX)
    '    Dim newColorData() As Byte
    '    Dim newORdata() As Boolean
    '    'Dim aByte As Byte
    '    Dim itemssize As Integer = 0
    '    Dim i As Integer

    '    If _size = SPRITE_SIZE.SIZE8 Then
    '        itemssize = 7
    '    Else
    '        itemssize = 15
    '    End If

    '    ReDim newColorData(itemssize)
    '    ReDim newORdata(itemssize)

    '    Me.ID = GetHashCode()

    '    Me.name = _name

    '    Me.size = _size
    '    Me.mode = _mode

    '    Me.InkColor = _inkColor
    '    Me.BGcolor = _bgColor

    '    For i = 0 To 31
    '        Me.gfxData(i) = 0
    '    Next

    '    For i = 0 To itemssize
    '        newORdata(i) = False
    '        newColorData(i) = 15
    '    Next

    '    Me.colorData = newColorData
    '    Me.ORbitData = newORdata

    '    Me.PaletteData = _PaletteData

    '    Me.refresh()

    'End Sub


    ''' <summary>
    ''' Instancia universal (para todos los tipos) sin bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_size"></param>
    ''' <param name="_inkColor"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_PaletteData"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _name As String, ByVal _size As SPRITE_SIZE, ByVal _mode As SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfxData As Byte(), ByVal _colorData As Byte(), ByVal _PaletteData As MSXpalette)
        Dim newColorData() As Byte
        Dim newORdata() As Boolean
        Dim aByte As Byte
        Dim itemssize As Integer = 15
        Dim i As Integer = 0

        'If _size = SPRITE_SIZE.SIZE8 Then
        '    itemssize = 7
        'Else
        '    itemssize = 15
        'End If

        'ReDim newColorData(itemssize)
        'ReDim newORdata(itemssize)

        If _mode = SPRITE_MODE.COLOR Then
            ReDim newColorData(itemssize)
            ReDim newORdata(itemssize)

            For Each aByte In _colorData
                If (aByte And bite_MASKs(6)) = 64 Then '  Or (aByte And bite_MASKs(4)) = 16 >>>> 16 correccion temporal QUITAR en proxima vers.
                    newORdata(i) = True
                    newColorData(i) = aByte And 15
                Else
                    newORdata(i) = False
                    newColorData(i) = aByte And 15
                End If
                i += 1
            Next

            'For i As Integer = 0 To itemssize
            '    aByte = _colorData(i)
            '    If (aByte And bite_MASKs(6)) = 64 Then '  Or (aByte And bite_MASKs(4)) = 16 >>>> 16 correccion temporal QUITAR en proxima vers.
            '        newORdata(i) = True
            '        newColorData(i) = aByte And 15
            '    Else
            '        newORdata(i) = False
            '        newColorData(i) = aByte And 15
            '    End If
            'Next

            Me.colorData = newColorData
            Me.ORbitData = newORdata

        End If



        Me.ID = GetHashCode()

        Me.name = _name

        Me.size = _size
        Me.mode = _mode

        Me.InkColor = _inkColor
        Me.BGcolor = _bgColor

        Me.gfxData = _gfxData.Clone



        Me.PaletteData = _PaletteData

        Me.refresh()

    End Sub





    ''' <summary>
    ''' Proporciona una copia del objeto con el mismo ID ¿tiene sentido?
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function clone() As SpriteMSX
        Dim sprite As New SpriteMSX

        sprite.ID = Me.ID
        sprite.name = Me.name
        sprite.order = Me.order

        sprite.size = Me.size
        sprite.mode = Me.mode
        sprite.InkColor = Me.InkColor
        sprite.BGcolor = Me.BGcolor

        sprite.aBitmap = Me.aBitmap

        sprite.gfxData = Me.gfxData
        sprite.colorData = Me.colorData
        sprite.ORbitData = Me.ORbitData
        sprite.PaletteData = Me.PaletteData

        Return sprite
    End Function


    ''' <summary>
    ''' Proporciona una copia del objeto con ID propio
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function copy() As SpriteMSX
        Dim sprite As New SpriteMSX

        sprite.ID = sprite.GetHashCode()
        sprite.name = Me.name
        'sprite.order = Me.order

        sprite.size = Me.size
        sprite.mode = Me.mode
        sprite.InkColor = Me.InkColor
        sprite.BGcolor = Me.BGcolor

        sprite.aBitmap = Me.aBitmap

        sprite.gfxData = Me.gfxData
        sprite.colorData = Me.colorData
        sprite.ORbitData = Me.ORbitData
        sprite.PaletteData = Me.PaletteData

        Return sprite
    End Function


    ''' <summary>
    ''' Redibuja el bitmap del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub refresh()

        If Me.size = SPRITE_SIZE.SIZE8 Then
            Me.genBitmap8()

            'If mode = SPRITE_MODE.MONO Then
            '    Me.genBitmap8()
            'Else
            '    Me.genBitmap8mode2()
            'End If

        Else
            Me.genBitmap16()

            'If Me.mode = SPRITE_MODE.MONO Then
            '    Me.genBitmap16()
            'Else
            '    Me.genBitmap16mode2()
            'End If

        End If

    End Sub


    ''' <summary>
    ''' Genera el bitmap de un sprite de 8x8, a partir de los valores del objeto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub genBitmap8()
        Dim TempValue As Byte = 0
        Dim tmpColor As MSXcolor

        Me.aBitmap = New Bitmap(32, 32)

        If Not gfxData Is Nothing Then


            'Dim aPixel As SpritePixel

            For y As Integer = 0 To 7

                TempValue = 0
                For x As Integer = 0 To 7

                    TempValue = gfxData(y) And Me.bite_MASKs(x)

                    If TempValue = Me.bite_MASKs(x) Then
                        If Me.mode = SPRITE_MODE.MONO Then
                            tmpColor = Me.PaletteData.GetColor(Me.InkColor)
                        Else
                            tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
                        End If
                    Else
                        tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
                    End If
                    putPixel(7 - x, y, PaletteData.getRGB(tmpColor))

                Next

            Next

        End If
    End Sub


    ''' <summary>
    ''' genera el bitmap de un sprite de 16x16, a partir de los valores del objeto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub genBitmap16()
        Dim TempValue As Byte = 0
        Dim tmpColor As MSXcolor

        Me.aBitmap = New Bitmap(32, 32)

        If Not gfxData Is Nothing Then


            'Dim aPixel As SpritePixel

            For y As Integer = 0 To 15


                TempValue = 0
                For x As Integer = 0 To 7

                    TempValue = gfxData(y) And Me.bite_MASKs(x)

                    If TempValue = Me.bite_MASKs(x) Then
                        If Me.mode = SPRITE_MODE.MONO Then
                            tmpColor = Me.PaletteData.GetColor(Me.InkColor)
                        Else
                            tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
                        End If
                    Else
                        tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
                    End If
                    putPixel(7 - x, y, PaletteData.getRGB(tmpColor))
                Next


                TempValue = 0
                For x As Integer = 0 To 7

                    TempValue = gfxData(y + 16) And Me.bite_MASKs(x)

                    If TempValue = Me.bite_MASKs(x) Then
                        If Me.mode = SPRITE_MODE.MONO Then
                            tmpColor = Me.PaletteData.GetColor(Me.InkColor)
                        Else
                            tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
                        End If
                    Else
                        tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
                    End If
                    putPixel(15 - x, y, PaletteData.getRGB(tmpColor))
                Next


                'TempValue = 0
                'For x As Integer = 8 To 15

                '    TempValue = gfxData(y) And Me.bite_MASKs(x - 8)

                '    If TempValue = Me.bite_MASKs(x - 8) Then
                '        If Me.mode = SPRITE_MODE.MONO Then
                '            tmpColor = Me.PaletteData.GetColor(Me.InkColor)
                '        Else
                '            tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
                '        End If
                '    Else
                '        tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
                '    End If
                '    putPixel(15 - x, y, tmpColor.RGBColor)
                'Next

                'TempValue = 0
                'For x As Integer = 0 To 7

                '    TempValue = gfxData(y + 16) And Me.bite_MASKs(x)

                '    If TempValue = Me.bite_MASKs(x) Then
                '        If Me.mode = SPRITE_MODE.MONO Then
                '            tmpColor = Me.PaletteData.GetColor(Me.InkColor)
                '        Else
                '            tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
                '        End If
                '    Else
                '        tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
                '    End If
                '    putPixel(15 - x, y, tmpColor.RGBColor)
                'Next
            Next

        End If
    End Sub



    'Private Sub genBitmap8mode2()
    '    Dim TempValue As Byte = 0
    '    Dim tmpColor As MSXcolor

    '    Me.aBitmap = New Bitmap(32, 32)

    '    If Not gfxData Is Nothing Then


    '        'Dim aPixel As SpritePixel

    '        For y As Integer = 0 To 7

    '            TempValue = 0
    '            For x As Integer = 0 To 7

    '                TempValue = gfxData(y) And Me.bite_MASKs(x)

    '                If TempValue = Me.bite_MASKs(x) Then
    '                    tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
    '                Else
    '                    tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
    '                End If
    '                putPixel(x, y, tmpColor.RGBColor)

    '            Next

    '        Next

    '    End If
    'End Sub


    'Private Sub genBitmap16mode2()
    '    Dim TempValue As Byte = 0
    '    Dim tmpColor As MSXcolor

    '    Me.aBitmap = New Bitmap(32, 32)

    '    If Not gfxData Is Nothing Then


    '        'Dim aPixel As SpritePixel

    '        For y As Integer = 0 To 15

    '            TempValue = 0
    '            For x As Integer = 0 To 7

    '                TempValue = Me.gfxData(y + 16) And Me.bite_MASKs(x)

    '                If TempValue = Me.bite_MASKs(x) Then
    '                    tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
    '                Else
    '                    tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
    '                End If
    '                putPixel(15 - x, y, tmpColor.RGBColor)

    '            Next

    '            TempValue = 0
    '            For x As Integer = 8 To 15

    '                TempValue = gfxData(y) And Me.bite_MASKs(x - 8)

    '                If TempValue = Me.bite_MASKs(x - 8) Then
    '                    tmpColor = Me.PaletteData.GetColor(Me.colorData(y))
    '                Else
    '                    tmpColor = Me.PaletteData.GetColor(Me.BGcolor)
    '                End If
    '                putPixel(15 - x, y, tmpColor.RGBColor)

    '            Next

    '        Next

    '    End If
    'End Sub


    Private Sub putPixel(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal _color As Color)

        Xpos *= 2
        Ypos *= 2

        Me.aBitmap.SetPixel(Xpos, Ypos, _color)
        Me.aBitmap.SetPixel(Xpos + 1, Ypos, _color)
        Me.aBitmap.SetPixel(Xpos, Ypos + 1, _color)
        Me.aBitmap.SetPixel(Xpos + 1, Ypos + 1, _color)

    End Sub


End Class
