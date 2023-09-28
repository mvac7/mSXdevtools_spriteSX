Public Delegate Sub spriteDelegate()

Public Delegate Sub MatrixCoordinatesDelegate(ByVal xpos As Integer, ByVal ypos As Integer)

Public Delegate Sub SpriteBitmapChangedDelegate(ByVal spriteBitmap As Bitmap)

Public Delegate Sub SpriteInfoChangedDelegate(ByVal name As String, ByVal patternNumber As Integer)


Public Interface ISpriteContainer

    Event updateSprite As spriteDelegate
    Event MatrixCoordinates As MatrixCoordinatesDelegate
    Event SpriteBitmapChanged As SpriteBitmapChangedDelegate
    'Event SpriteInfoChanged As SpriteInfoChangedDelegate

    Property Sprite() As SpriteMSX

    Property SpriteName() As String


    ReadOnly Property ColorPalette() As PaletteMSX

    Property InkColor() As Integer
    Property BackgroundColor() As Integer


    Sub SetColorPalette(ByRef aPalette As PaletteMSX)

    Sub RefreshSprite()

    Sub changeInkColor(ByVal colorID As Integer)
    Sub changeBGColor(ByVal colorID As Integer)

    Sub SetSprite(ByVal spriteData As SpriteMSX)

    'Sub NewSprite()
    'Sub Copy()
    Sub ClearSprite()

    Sub FlipHorizontal()
    Sub FlipVertical()
    Sub RotateRight()
    Sub RotateLeft()

    Sub MoveLeft(ByVal rotate As Boolean)
    Sub MoveRight(ByVal rotate As Boolean)
    Sub MoveUp(ByVal rotate As Boolean)
    Sub MoveDown(ByVal rotate As Boolean)

    Sub Invert()

    Sub AddUndo()

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
