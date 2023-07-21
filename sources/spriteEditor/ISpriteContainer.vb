﻿Public Delegate Sub spriteDelegate()

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

    
    Property Palette() As iPaletteMSX

    Property InkColor() As Integer
    Property BackgroundColor() As Integer


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
    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveUp()
    Sub MoveDown()

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