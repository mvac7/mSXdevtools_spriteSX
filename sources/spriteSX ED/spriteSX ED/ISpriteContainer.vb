Public Delegate Sub spriteDelegate()

Public Delegate Sub MatrixCoordinatesDelegate(ByVal xpos As Integer, ByVal ypos As Integer)

Public Delegate Sub SpriteBitmapChangedDelegate(ByVal spriteBitmap As Bitmap)

Public Delegate Sub SpriteInfoChangedDelegate(ByVal name As String, ByVal patternNumber As Integer)


Interface ISpriteContainer

    'Property inkColor() As MSXcolor
    'Property bgColor() As MSXcolor
    'Property PaletteData() As PaletteMSX


    Event updateSprite As spriteDelegate
    Event MatrixCoordinates As MatrixCoordinatesDelegate
    Event SpriteBitmapChanged As SpriteBitmapChangedDelegate
    Event SpriteInfoChanged As SpriteInfoChangedDelegate

    'Property WorkSprite() As SpriteMSX

    Property SpriteName() As String
    Property inkColor() As MSXcolor
    Property bgColor() As MSXcolor
    Property PaletteData() As MSXpalette
    Property Test() As Boolean

    'Sub ChanguePalette(ByVal newPalette As PaletteMSX)
    Sub changeInkColor(ByVal newColor As MSXcolor)
    Sub changeBGColor(ByVal newColor As MSXcolor)

    Sub SetSprite(ByVal spriteData As SpriteMSX)

    Sub NewSprite()
    Sub Copy()
    Sub ClearSprite()

    Sub FlipHorizontalSprite()
    Sub FlipVerticalSprite()
    Sub RotateRightSprite()
    Sub RotateLeftSprite()
    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveUp()
    Sub MoveDown()

    Sub Invert()

    Sub SetUndo()
    Sub SetRedo()

    Sub SetNameFocus()

    Sub SetState(ByVal state As Integer)
    'Sub Draw_State()
    'Sub Line_State()
    'Sub Rectangle_State()
    'Sub Circle_State()
    'Sub Paint_State()

    Function GetSprite() As SpriteMSX


End Interface
