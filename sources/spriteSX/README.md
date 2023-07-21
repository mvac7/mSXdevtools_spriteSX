# spriteSX devtool

```
Short:        Sprite Editor for TMS9918 and V9938 VDPs (tMSgfX devtool)
Author:       aorante (aka mvac7)
Last Release: v0.9.4b (August 2014)
Architecture: Microsoft .Net framework 4.0
License:      GNU GPL v2
IDE:          Microsoft Visual Studio Community 2019.
```

## Sorry! This text is pending correction of the English translation


---
## Description

Tool to create a collection of sprites, for TMS9918 & V9938 video processors 
(MSX, colecovision, etc...), which provides the source code for Assembler, C and Basic.


---
## License

Copyleft (C) 2020 mvac7

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

https://www.gnu.org/licenses/old-licenses/gpl-2.0.html
    
---
## Requirements 
 
* Windows OS with .net framework v4.0
* Display with minimum resolution: XVGA (1024x768)



---
## How to install 
 
Unpack and Copy spriteSX folder somewhere on your hard disk. 
   
For run, execute spriteSX 


---
## Uninstall

Just delete the folder that contains the application.

If you want to preserve the data files, remember to make a copy of these files.

**Note:** This application does not create system variables or temporary files outside its directory.



---
## Author's Notes

This application is free distribution. It has been developed informally 
(not professionally), so no guarantee is offered. The following points are 
contained within the GPL v2 license to which this application subscribes, but 
I want to highlight some of them so that it is not interpreted as something 
solely restrictive.

The project is open to the developer community on GitHub. You can create a 
personal version with the changes that fit your way of working and if you want 
you can share it with the world. You can also add in Issues, the errors that 
you detect and propose improvements and new functionalities, although I hope 
your understanding since I cannot guarantee that they will be solved, since 
they depend on various limitations that I am subject to. 

The sale of the application or any of its parts is not allowed, but you can 
include it in data storage media as a complement to magazines, books, or 
programming courses.

It is not allowed to modify the content of the package to add adware, software 
or documents, for promotional, lucrative purposes or that violate the user's 
privacy rights.

This application is part of the tMSgfX graphical development package. It can be 
found in a separate Release or within the Release of tMSgfX.

Only been tested on one Windows 10 computer.



---
## Release Notes

* Parts have been better structured in various libraries (DLLs): Launcher,  
Sprite Editor, Palette Editor, Data, Files, GUI and TMS9918A.
* New native project format (SXSPR) with v0.9.4b compatibility.
* Lets you read tMSgfX projects (SXSCP) with various content (tiles, maps, etc.), 
to edit or add sprites, and then save all content or just the sprite project.
* New project wizard removed. It has been replaced by the project information and configuration windows.  
* Project management of up to 16 spriteSets of different types (8x8 or 16x16, mono or multicolour).
* Change the sprite list management control. Now all the sprites of the Set are 
shown (256 sprites of 8x8 or 64 of 16x16), at the bottom of the main window. 
You can select, swap, or copy each item in the set.
* Added spriteSet work menu: New, Load, Clone, Configuration, Delete, Palette, 
Save SXSPR, binary or bitmap.
* Changes and improvements in the native file format (MSX Open Document). 
Backward compatible (v0.9.4b). Various spritesets. Does not save empty sprites.
* SpriteSet type conversion (size and color). 
* Copy/Paste of the sprite in progress. 
* New version of the color palette editor.
* The code output window allows you to extract the selected spriteSet or all of 
them. If you work in Assembler, it allows modifying the commands for data and 
generating an index with the labels of each set.
* Improved the display and refresh of the paint tools.




---
## Features

* Projects with different types of sprites. (8x8, 16x16, mono and multicolor)
* Load, Merge and Save projects, including the color palette.
* Edit line color and the OR bit in multicolor mode (V9938).
* Up to 255 sprites of 8x8 size and 64 sprites of 16x16 size, per spriteSet.
* Edit the color palette (V9938). Allows Load/Save the palette independently.
* Code Generation Window. Provides assembly code, Assembler, C and Basic.
* Load or Save Bitmap Window. Load/Save a bitmap PNG 
* Load/Save MSX Basic Graphics binary (SCn/SPR).
* Project info window. Editing project information: name, version, author, group and description.
* Paint tools: Draw, Lines, Rectangles, Fill rectangles, Ellipses, Fill Ellipses and Fill.
* Delete, move, rotate and flip sprite. 
* Negative (invert) tool.
* Undo and redo. 16 steps.
* Shortcuts keys.




---
## History

### v0.9.4b (August 2014)

* Paint functions: Draw, Lines, Rectangles, Fill rectangles, Circles, Fill circles and Fill. Positive or negative (right mouse button).
* Undo and redo. 16 steps.
* Shortcuts keys.
* (GUIcontrols.ProjectPropertiesWin) Show project file name.   
* Bug corrected. (MSXLibrary.palette512Dialog) Palette edit window. Tools to copy and exchange colors don't work.
* Bug corrected. (MSXLibrary.ColorSelector). Don't show in taskbar.
* Add Assembler examples.
* Update SP16C_OR.BAS with improvement in bounce function.    

  
  
### v0.9.3b (july 2014)

* Load or Save Bitmap window.
* Progress window.
* Fixed Bug in redrawing the lines 8x8 in the editor matrix. 
* Removed License.dll Functionality included in the executable.
* Project info window.
* Improvements in the graphic design of some components.
* Add Basic examples for SC2 binary files test.    



### v0.9b (march 2014)
First version.
  
           

---
## Acknowledgements

To all those who share knowledge.



---
## Components
```
   spriteSX.exe              v1.00b
   spriteEditor.dll
   DataStructures.dll
   FileDataTypes.dll
   GUIcontrols.dll           v1.4.0 (OLD v1.1.2)
   TMS9918A.dll
   V9938PaletteEditor.dll

   Projects_sprite\          Projects.
   Palettes\                 Palettes.
   code_examples\            Example codes.
   SC2\                      MSX Basic VRAM binary files.
   Bitmaps\                  PNG files.
```


---
## Code Examples

The package includes a few examples of sources in C (SDCC), Assembler (asMSX) 
and MSX BASIC, to test the data output and learning.
   
```
   File List: (code_examples\)
   
   *Assembler (ASM\)
    To assemble asMSX need. https://code.google.com/p/asmsx-license-gpl/
    sprite8_test\        <-- 8x8   monochrome MSX ROM 
    sprite16_test\       <-- 16x16 monochrome MSX ROM
    sprite8C_test\       <-- 8x8   multicolor MSX2 ROM 
    sprite16C_test\      <-- 16x16 multicolor MSX2 ROM
    
   *C (C\)
    Includes a Readme with notes for the compilation.      
    sprite8_test\        <-- 8x8   monochrome 16k MSX ROM 
    sprite16_test\       <-- 16x16 monochrome 16k MSX ROM
    sprite8C_test\       <-- 8x8   multicolor 16k MSX2 ROM
    sprite16C_test\      <-- 16x16 multicolor 16k MSX2 ROM
   
   *MSX BASIC (MSX_BASIC\)
    SP8.BAS              <-- 8x8   monochrome 
    SP16.BAS             <-- 16x16 monochrome
    SP8C.BAS             <-- 8x8   multicolor
    SP16C.BAS            <-- 16x16 multicolor
    SP16C_OR.BAS         <-- 16x16 multicolor OR (mixing of 2 sprites)
    
    LOADSPR.BAS          <-- test Sprites MSX Basic binary
    FRUTAS16.SC2         <-- for LOADSPR.BAS
    
    LOADSC2.BAS          <-- test SC2 output 
    LOADSC4.BAS          <-- test SC2 output with palette (V9938 or higher)
    FRUIT16C.SC2         <-- for LOADSC2.BAS and LOADSC4.BAS
    
    msx_spritesBASIC.dsk <-- Disk image with all examples in BASIC.
```



-------------------------------------------------------------------------------- 