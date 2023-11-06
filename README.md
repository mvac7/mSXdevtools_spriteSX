# spriteSX devtool

```
Short:        Tool to create a collection of sprites for TMS9918 & V9938 Video Display Processors           
Architecture: Microsoft .Net Framework 4.0
Language:     Visual BASIC .net
License:      GNU General Public License v3   
```

---
## Description

Tool to create a collection of sprites, for TMS9918 & V9938 video processors (MSX, colecovision, etc...), 
which provides the source code for Assembler, C and Basic.

The author's purpose is to provide to the community of developers, a utility to simplify the work of 
creating and editing sprites, and the possibility to  
enhance and add functionality, using the code provided on project website.
   
This application is designed for agile and intuitive handling, but always can be improved. 
We are working on it. We are waiting your suggestions. 

This software is developed with Microsoft Visual Studio Community 2019.
   


---
## License

Copyright (C) 2023 mvac7 (aka AOrante)
   
```
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
   See the GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
```


    
---
## Requirements 
 
- Computer with Microsoft Windows OS and Framework 4.0
- Display with minimum resolution: XVGA (1024x768)



---
## Features

- Projects with different types of sprites. (8x8, 16x16, mono or multicolor)
- Load or Save projects, including the color palette.
- Load or Save Bitmap format (PNG)
- Load or Save MSX BASIC binary (SCn).
- Edit line color and the OR bit in multicolor mode (V9938).
- Copy or Swap sprites in spriteSet UI control.
- Tools Cut, Copy and Paste the current sprite from the editor.
- Up to 255 sprites of 8x8 size and 64 sprites of 16x16 size, per project (spriteSet).
- Edit the color palette (V9938). Allows reading or save the palette independently.
- Code Generation Window. Provides assembly code, formatted Assembler, C and BASIC.
- Project info window. Editing project information: name, version, author, group and description.
- Paint functions: Draw, Lines, Rectangles, Fill rectangles, Circles, Fill circles and Fill. Positive or negative (right mouse button).
- Tools for Clear, inverse, move, rotate and flip sprite.
- Undo and redo. 16 steps.
- Shortcuts keys. 



---
## History

### v1.0b
- New project file format with back compatibility.
- New GUI. Tileset selector. piXelST style. New cursor icon in the editor.
- Shows the name and mode of the selected spriteset in the status bar.
- pixel-wrap - Copy the pixel that disappears in the scroll tools.
- Copy/Paste current sprite from editor. From UI buttons or keyboard shortcuts.
- Cut current sprite form editor. Keyboard shortcut Ctrl+X


### v0.9.4b (August 2014)
- Paint functions: Draw, Lines, Rectangles, Fill rectangles, Circles, Fill circles and Fill. Positive or negative (right mouse button).
- Undo and redo. 16 steps.
- Shortcuts keys.
- (GUIcontrols.ProjectPropertiesWin) Show project file name.   
- Bug corrected. (MSXLibrary.palette512Dialog) Palette edit window. Tools to copy and exchange colors don't work.
- Bug corrected. (MSXLibrary.ColorSelector). Don't show in taskbar.
- Add Assembler examples.
- Update SP16C_OR.BAS with improvement in bounce function.    
  
  
### v0.9.3b (july 2014)
- Load or Save Bitmap window.
- Progress window.
- Fixed Bug in redrawing the lines 8x8 in the editor matrix. 
- Removed License.dll Functionality included in the executable.
- Project info window.
- Improvements in the graphic design of some components.
- Add Basic examples for SC2 binary files test.    



### v0.9b (march 2014)
*  First version.
  


