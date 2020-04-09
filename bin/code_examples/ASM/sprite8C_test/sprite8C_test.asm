; ==============================================================================
;   sprite16C_test.c
;   test 8x8 multicolor sprites MSX2 ROM (spriteSX)
;   Assemble with asMSX
; ==============================================================================



    .page	1
		.ROM
		;.SIZE 32
		
		;.SEARCH
		

VDPVRAM   EQU   $98 ;VRAM Data (Read/Write)
VDPSTATUS EQU   $99 ;VDP Status Registers

;system vars
MSXVER EQU $002D
FORCLR EQU $F3E9 ;Foreground colour
BAKCLR EQU $F3EA ;Background colour
BDRCLR EQU $F3EB ;Border colour
CLIKSW EQU $F3DB ;0 disabled / 1 enabled
RG1SAV EQU $F3E0 ;VDP REG 1
EXTVDP EQU $FFE7 ;

;BIOS (info by MSX Assembly Page)
;http://map.grauw.nl/resources/msxbios.php
DISSCR EQU $0041 ;inhibits the screen display
ENASCR EQU $0044 ;displays the screen
WRTVDP EQU $0047 ;write data in the VDP-register
RDVRM  EQU $004A ;Reads the content of VRAM
WRTVRM EQU $004D ;Writes data in VRAM
SETRD  EQU $0050 ;Enable VDP to read
SETWRT EQU $0053 ;Enable VDP to write
FILVRM EQU $0056 ;fill VRAM with value
LDIRMV EQU $0059 ;Block transfer to memory from VRAM
LDIRVM EQU $005C ;Block transfer to VRAM from memory
CHGMOD EQU $005F ;Switches to given screenmode
CHGCLR EQU $0062 ;Changes the screencolors
CLRSPR EQU $0069 ;Initialises all sprites
INITXT EQU $006C ;Switches to SCREEN 0 (text screen with 40 * 24 characters)
INIT32 EQU $006F ;Switches to SCREEN 1 (text screen with 32*24 characters)
INIGRP EQU $0072 ;Switches to SCREEN 2 (high resolution screen with 256*192 pixels)
INIMLT EQU $0075 ;Switches to SCREEN 3 (multi-color screen 64*48 pixels)
SETTXT EQU $0078 ;Switches to VDP in SCREEN 0 mode
SETT32 EQU $007B ;Switches VDP in SCREEN mode 1
SETGRP EQU $007E ;Switches VDP to SCREEN 2 mode
SETMLT EQU $0081 ;Switches VDP to SCREEN 3 mode
CALPAT EQU $0084 ;Returns the address of the sprite pattern table
CALATR EQU $0087 ;Returns the address of the sprite attribute table
GSPSIZ EQU $008A ;Returns current sprite size
GRPPRT EQU $008D ;Displays a character on the graphic screen

GICINI EQU $0090 ;Initialises PSG and sets initial value for the PLAY statement
WRTPSG EQU $0093 ;Writes data to PSG-register
RDPSG  EQU $0096 ;Reads value from PSG-register

; more BIOS functions
CHKRAM EQU $0000 ;Tests RAM and sets RAM slot for the system
ENASLT EQU $0024 ;Switches indicated slot at indicated page on perpetual
CHGET  EQU $009F ;One character input
POSIT  EQU $00C6
GTSTCK EQU $00D5 ;Returns the joystick status
GTTRIG EQU $00D8 ;Returns current trigger status
SNSMAT EQU $0141 ;Returns the value of the specified line from the keyboard matrix
KILBUF EQU $0156 ;Clear keyboard buffer




;screen 1
BASE5  EQU $1800 ;name table
BASE6  EQU $2000 ;color table
BASE7  EQU $0000 ;character pattern table

;screen 2
BASE10 EQU $1800 ;name table
BASE11 EQU $2000 ;color table
BASE12 EQU $0000 ;character pattern table
BASE13 EQU $1B00 ;sprite attribute table
BASE14 EQU $3800 ;sprite pattern table

BSATTR  EQU 0x1E00 ;sprite attribute table 
BSDATA  EQU 0x3800 ;sprite pattern table 
BSCOLOR EQU 0x1C00 ;sprite colours

MAIN:

  xor  A
  ld   [CLIKSW],A    ;keys click off

  ;color 15,1,1 
  ld   A,15
  ld   [FORCLR],A
  ld   A,1
  ld   [BAKCLR],A
  ld   A,1
  ld   [BDRCLR],A  
  call CHGCLR 
  
  ;screen 4
  ld   A,4
	call CHGMOD
    
  ;set sprite mode (16x16 nozoom)
  ld   DE,$0000
  call SETUPSPRITES

  ld   HL,PALETTE_DATA
	call SETPALETTE
    
  ld   HL,SPRITE_DATA
  ld   DE,BASE14  
  ld   BC,8*8
  call LDIRVM
  
  ;vuelca a VRAM buffer atributos sprites
  ld   HL,SPRITE_ATTRS
  ld   DE,BSATTR        ;BASE13  
  ld   BC,4*8
  call LDIRVM
  
  
  ; apply line colors of sprites
  ld   HL,COLOR_DATA
  ld   DE,BSCOLOR  
  ld   BC,16*8
  call LDIRVM
  
  call    PRESSBUT
  
  call    CHKRAM
  
  
  
PRESSBUT:
  halt
  
  ld	 A,0
	call GTTRIG
	bit	 7,A
	ret  NZ
	
  ; button 1, joy A
	ld	 A,1
	call GTTRIG
	bit	 7,A
	ret	 NZ

; button 1, joy B
	ld	 A,2
	call GTTRIG
	bit	 7,A
	ret  NZ
  	
	jp   PRESSBUT
  






  

; set size and zoom of the sprites
; D size -> 0=8x8, 1=16x16
; E zoom -> 1=x2
SETUPSPRITES:
 
  ;in A,(VDPSTATUS)
  
  ld B,0
  
  ld A,D
  cp 1
  jr NZ,STSP1
  set 1,b ; --- if 16x16 sprites => set bit 1

STSP1:
  ld A,E
  cp 1
  jr NZ,STSP2
  set 0,b ; --- if zoom sprites => set bit 0

STSP2:
  ld HL,RG1SAV ; --- read vdp(1) from mem
  ld A,[HL]
  and $fc
  or B
  
  ld  B,A
  ld  C,$01
  call  WRTVDP
  
  ret


//pausa en ciclos de VBLANK. PAL 1seg=50, NTSC 1seg=60. 
; BC = num cicles 
WAIT:
  dec BC
	ld A,B
	or C
	ret Z
	
	halt
  jr  WAIT
  
  



;paleta msx2
; HL - addr palette 
SETPALETTE:
 
  ld   A,[MSXVER]
  or   A
  ret  Z
  
  ;ld  HL,PALETTE00
  xor	A
	di
	out	 [VDPSTATUS],A
	ld	  A,144
	out	 [VDPSTATUS],A
	ld	  BC,$209A
	otir
	ei  
  
  ret





;SPRITE ATRIBUTE DATAS #########################################################
;Y,X,SPR,COLOR
;SPR*4 in 16x16 mode
SPRITE_ATTRS:
db 0,0,0,2
db 0,16,1,11
db 0,32,2,3
db 0,48,3,14
db 0,64,4,8
db 0,80,5,9
db 0,96,6,12             
db 0,112,7,10 

;END SPRITE ATRIBUTE DATAS #####################################################




SPRITE_DATA:
; 0-square face
db $00,$7E,$5A,$5A,$7E,$42,$7E,$00
; 1-TEST
db $3C,$42,$A5,$81,$A5,$99,$42,$3C
; 2-TEST
db $3C,$7E,$DB,$FF,$DB,$E7,$7E,$3C
; 3-TEST1
db $78,$FC,$D4,$D4,$FF,$BF,$C4,$FC
; 4-TEST3
db $3C,$7E,$DB,$DB,$FF,$C3,$66,$3C
; 5-TEST2
db $3C,$7E,$DB,$DB,$FF,$C3,$66,$3C
; 6-WHITE
db $3C,$7E,$DB,$DB,$FF,$DB,$66,$3C
; 7-green
db $C3,$7E,$5A,$5A,$7E,$42,$66,$7E
; 8-blue
db $38,$7C,$D6,$D6,$FE,$C6,$7C,$38


COLOR_DATA:
; 0-square face
db $0F,$03,$03,$03,$02,$02,$0C,$0F
db $00,$00,$00,$00,$00,$00,$00,$00
; 1-TEST
db $0C,$4C,$02,$42,$03,$43,$03,$43
db $00,$00,$00,$00,$00,$00,$00,$00
; 2-TEST
db $0C,$4C,$02,$42,$03,$43,$03,$43
db $00,$00,$00,$00,$00,$00,$00,$00
; 3-TEST1
db $06,$08,$09,$09,$08,$08,$08,$08
db $00,$00,$00,$00,$00,$00,$00,$00
; 4-TEST3
db $07,$47,$07,$47,$07,$47,$07,$47
db $00,$00,$00,$00,$00,$00,$00,$00
; 5-TEST2
db $0C,$4C,$02,$42,$03,$43,$03,$43
db $00,$00,$00,$00,$00,$00,$00,$00
; 6-WHITE
db $4F,$4F,$4E,$4E,$4F,$4F,$4F,$4F
db $00,$00,$00,$00,$00,$00,$00,$00
; 7-green
db $03,$03,$03,$03,$02,$02,$0C,$0C
db $00,$00,$00,$00,$00,$00,$00,$00
; 8-blue
db $0E,$07,$07,$07,$05,$05,$05,$04
db $00,$00,$00,$00,$00,$00,$00,$00


; MSX2_Palette
; RB,G
PALETTE_DATA:
db $00,$00
db $00,$00
db $11,$06
db $33,$07
db $25,$02
db $37,$03
db $61,$01
db $27,$06
db $70,$00
db $73,$03
db $63,$06
db $70,$07
db $00,$04
db $56,$01
db $66,$06
db $77,$07
  