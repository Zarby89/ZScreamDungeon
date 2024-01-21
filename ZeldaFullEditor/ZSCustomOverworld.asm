; ==============================================================================
; Hooks
; ==============================================================================

AnimatedTileGFXSet = $0FC0

org $008913
    Sound_LoadLightWorldSongBank:

org $00D394
    DecompOwAnimatedTiles:

org $00D4DB
    GetAnimatedSpriteTile:

org $00D4ED
    GetAnimatedSpriteTile_variable:

org $00DF4F
    Do3To4High16Bit:

org $00E19B
    InitTilesets:

org $00E556
    CopyFontToVram:


org $02ABBE
    Overworld_FinishTransGfx_firstHalf:

org $02AF19 
    Overworld_LoadSubscreenAndSilenceSFX1:

org $02FD0D
    LoadSubscreenOverlay:

org $02FD8A
    LoadGearPalettes_bunny:


org $099EFC
    Tagalong_Init:

org $09AF89
    Sprite_ReinitWarpVortex:

org $09C44E
    Sprite_ResetAll:

org $09C499
    Sprite_OverworldReloadAll:


org $0ED5A8
    Overworld_LoadPalettes:

org $0ED618
    Palette_SetOwBgColor_Long:


org $1BEC77
    Palette_SpriteAux3:

org $1BEC9E
    Palette_MainSpr:

org $1BECC5
    Palette_SpriteAux1:

org $1BECE4
    Palette_SpriteAux2:

org $1BED03
    Palette_Sword:

org $1BED29
    Palette_Shield:

org $1BED6E
    Palette_MiscSpr:

org $1BEDF9
    Palette_ArmorAndGloves:

org $1BEE52
    Palette_Hud:

org $1BEEC7
    Palette_OverworldBgMain:

; ==============================================================================
; Fixing old hooks:
; ==============================================================================

; Loads the transparent color under some load conditions
org $0BFEB6
    STA $7EC500

; Main Palette loading routine. 
org $0ED5E7
    JSL $1BEEA8 ;Palette_OverworldBgAux3

; After leaving special areas like Zora's and the Master Sword area.
org $02E94A
    JSL $0ED5A8 ; Overworld_LoadPalettes

; ==============================================================================
; Custom Functions and Data
; ==============================================================================

; Reserved ZS space.
; Avoid moving this at all costs. If you do, you will have to change where ZS saves this data as well and previous data will be lost or corrupted.
org $288000
Pool:
{
    .BGColorTable ; 0x140
    ; Valid values:
    ; 555 color value $0000 to $7FFF.

    ; LW
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ; DW
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ; SW
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    warnpc $288140

    org $288140 ; $140140
    .EnableTable ; 0x20
    ; Valid values:
    ; $00 - Disabled
    ; $FF - Enabled

    org $288140 ; $140140
    .EnableBGColor
    ;db $00

    org $288141 ; $140141
    .EnableMainPalette 
    ;db $00
    
    org $288142 ; $140142
    .EnableMosaic ; Unused for now.
    ;db $00

    org $288143 ; $140143
    .EnableAnimated
    ;db $00
    
    org $288144 ; $140144
    .EnableSubScreenOverlay
    ;db $00

    ; This is a reserved value that ZS will write to when it has applied the ASM.
    ; That way the next time ZS loads the ROM it knows to read the custom values
    ; instead of using the default ones.
    org $288145 ; $140145
    .ZSAppliedASM
    ;db $FF
    
    ; The rest of these are extra bytes that can be used for anything else later on.
    ;db $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    warnpc $288160

    org $288160 ; $140160
    .MainPaletteTable ; 0xA0
    ; Valid values:
    ; Main overworld palette index $00 to $05.
    ; $00 is the normal light world palette.
    ; $01 is the normal dark world palette.
    ; $02 is the normal light world death mountain palette.
    ; $03 is the normal dark world death mountain palette.
    ; $04 is the Triforce room palette.
    ; $05 is the title screen palette?

    ; LW
    ;db $00, $00, $00, $02, $00, $20, $00, $20
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ; DW
    ;db $01, $01, $01, $03, $01, $03, $01, $03
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ;db $01, $01, $01, $01, $01, $01, $01, $01
    ; SW
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $04, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    warnpc $288200
    
    org $288200 ; $140200
    .MosaicTable ; 0xA0
    ; Valid values:
    ; $01 to enable mosaic, $00 to disable.

    ; LW
    ;db $01, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ; DW
    ;db $01, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ; SW
    ;db $01, $01, $00, $00, $00, $00, $00, $00
    ;db $01, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    warnpc $2882A0

    org $2882A0 ; $1402A0
    .AnimatedTable ; 0xA0
    ; Valid values:
    ; GFX index $00 to $FF.
    ; In vanilla, $59 are the clouds and $5B are the regular water tiles.

    ; LW
    ;db $5B, $5B, $5B, $59, $5B, $59, $5B, $59
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ; DW
    ;db $5B, $5B, $5B, $59, $5B, $59, $5B, $59
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ; SW
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    ;db $5B, $5B, $5B, $5B, $5B, $5B, $5B, $5B
    warnpc $288340

    org $288340 ; $140340
    .OverlayTable ; 0x140
    ; Valid values:
    ; Can be any value $00 to $FF but is stored as 2 bytes instead of one to help the code out below.
    ; $FF is for no overlay area. 
    ; Hopefully no crazy person decides to expand their overworld to $FF areas.

    ; $0093 is the triforce room curtain overlay.
    ; $0094 is the under the bridge overlay.
    ; $0095 is the sky background overlay.
    ; $0096 is the pyramid background overlay.
    ; $0097 is the first fog overlay.

    ; $009C is the lava background overlay.
    ; $009D is the second fog overlay.
    ; $009E is the tree canopy overlay.
    ; $009F is the rain overlay.

    ;LW
    ;dw $009D, $00FF, $00FF, $0095, $00FF, $0095, $00FF, $0095
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;DW
    ;dw $009D, $00FF, $00FF, $009C, $00FF, $009C, $00FF, $009C
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $0096, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $009F, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;SP
    ;dw $0097, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $0093, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    ;dw $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF, $00FF
    warnpc $288480
}

; Debug addresses
; 00D8D5 ; W7 Animated tiles on warp.
!Func00D8D5 = $01 ; Disable
; 00DA63 ; W8 Enable/Disable subscreen.
!Func00DA63 = $01
; 00EEBC ; Zeros out the BG color when mirror warping to the pyramid area.
!Func00EEBC = $01 ; Disable
; 00FF7C ; W9 BG scrolling for HC and the pyramid area.
!Func00FF7C = $01

; 028027
; 029C0C
; 029D1E
; 029F82

; 0283EE ; E2 ; Changes the function that loads overworld properties when exiting a dungeon. Includes removing asm that plays music in certain areas and changing how animated tiles are loaded.
!Func0283EE = $01 ; Disable
; 028632 ; Changes a function that loads animated tiles under certain conditions.
!Func028632 = $01 ; Disable
; 029AA6 ; E1 ; Changes part of a function that changes the special BG color when leaving dungeons? not sure.
!Func029AA6 = $01 ; Disable
; 02AF58 ; T2 W2 Main subscreen loading function.
!Func02AF58 = $01
; 02B2D4 ; W1 turns on subscreen for pyramid.
!Func02B2D4 = $01
; 02B3A1 ; W6 Activate subscreen durring pyramid warp.
!Func02B3A1 = $01 
; 02BC44 ; Controls overworld vertical subscreen movement for the pyramid BG.
!Func02BC44 = $01
; 02C02D ; T4 Changes how the pyramid BG scrolls durring transition.
!Func02C02D = $01
; 02C692 ; W3 Main palette loading routine.
!Func02C692 = $01 
; 02A4CD ; Rain animation code.
!Func02A4CD = $01
; 02AADB ; T1 Mosaic
!Func02AADB = $01
; 02ABB8 ; T3 transition animated and main palette.
!Func02ABB8 = $01
; 0ABC5A ; Loads the animated tiles after the overworld map is closed.
!Func0ABC5A = $01 ; Disable
; 0AB8F5 ; Loads different animated tiles when returning from bird travel.
!Func0AB8F5 = $01 ; prob disable
; 0BFEC6 ; W5 Load overlay, fixed color, and BG color.
!Func0BFEC6 = $01
; 0ED627 ; W4 Transparent color durring warp.
!Func0ED627 = $01
; 0ED8AE ; Resets the area special color after the screen flashes.
!Func0ED8AE = $01 ; Disable

; Start of expanded space.
org $288480 ; $140480
pushpc

; ==============================================================================

if !Func00D8D5 = 1

; Replaces a function that decompresses animated tiles in certain mirror warp conditions.
org $00D8D5 ; $0058D5
{
    PHX

    ; Get the animated tiles value for this overworld area.
    LDX.b $8A
    LDA.l Pool_AnimatedTable, X 

    ; The decompression function increases it by 1 so subtract 1 here.
    DEC : TAY

    PLX

    JSL DecompOwAnimatedTiles
            
    RTL
}
warnpc $00D8EE

endif

; ==============================================================================

if !Func00DA63 = 1

; Sets the $1D Sub Screen Designation to either enable or disable BG for screens with special overlays.
org $00DA63 ; $005A63
{
    JSL ActivateSubScreen

    ; From this point on it is the vanilla function.
    PHB : PHK : PLB
        
    LDA.l $00D8F4, X : TAY
        
    LDA.w $D1B1, Y : STA.b $00
    LDA.w $D0D2, Y : STA.b $01
    LDA.w $CFF3, Y : STA.b $02
    STA.b $05
        
    PLB
        
    REP #$31 ; Set A, X, and Y in 16bit mode. +1 no idea
        
    ; source address is determined above, number of tiles is 0x0040, base target address is $7F0000
    LDX.w #$0000
    LDY.w #$0040
        
    LDA.b $00
        
    JSR Do3To4High16Bit
    
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    RTL
}
warnpc $00DABB

endif

pullpc
ActivateSubScreen:
{
    STZ $1D

    PHX

    REP #$20 ; Set A in 16bit mode

    LDA.b $8A : BNE .notForest
        ; Check if we have the master sword.
        LDA.l $7EF300 : AND.w #$0040 : BEQ .notForest
            ; The forest canopy overlay
            BRA .turnOn
    
    .notForest

    ; Check if we need to disable the rain in the misery mire
    LDA.b $8A : CMP.w #$0070 : BNE .notMire
        ; Has Misery Mire been triggered yet?
        LDA.l $7EF2F0 : AND.w #$0020 : BEQ .notMire
            BRA .turnOn
        
    .notMire

    ; Check if we are in the beginning phase, if not, no rain.
    ; If $7EF3C5 >= 0x02
    LDA.l $7EF3C5 : AND.w #$00FF : CMP.w #$0002 : BCS .noRain
        BRA .turnOn
        
    .noRain
    
    ; Get the overlay value for this overworld area
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : CMP.w #$00FF : BEQ .normal
        ; If not $FF, assume we want an overlay.

        .turnOn
        SEP #$20 ; Set A in 8bit mode

        ; Turn on BG1.
        LDA.b #$01 : STA.b $1D

    .normal

    SEP #$20 ; Set A in 8bit mode

    PLX

    RTL
}
pushpc

; ==============================================================================

if !Func00EEBC = 1

; Zeros out the BG color when mirror warping to the pyramid area.
org $00EEBC ; $006EBC
{
    ; TODO: probably not needed.
    ; Check if we are warping to an area with the pyramid BG.
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : CMP.w #$0096 : BNE .notHyruleCastle
        ; This is annoying but I just needed a little bit of extra space.
        JSL EraseBGColors

    .notHyruleCastle

    SEP #$20 ; Set A in 8bit mode
        
    LDA.b #$08 : STA.w $06BB
        
    STZ.w $06BA
        
    RTL
}
warnpc $00EEE0

endif

pullpc
EraseBGColors:
{
    LDA.w #$0000 : STA.l $7EC300 : STA.l $7EC340 : STA.l $7EC500 : STA.l $7EC540

    RTL
}
pushpc

; ==============================================================================

if !Func00FF7C = 1

; Controls the BG scrolling for HC and the pyramid area.
org $00FF7C ; $007F7C
{
    LDA.w $1C80 : ORA.w $1C90 : ORA.w $1CA0 : ORA.w $1CB0 : CMP.b $E2 : BNE .BRANCH_DELTA
        SEP #$30 ; Set A, X, and Y in 8bit mode.

        STZ.b $9B
        
        INC $B0
        
        JSL $0BFE70 ; $05FE70 IN ROM

        REP #$30 ; Set A, X, and Y in 16bit mode.

        ; Check if we are warping to an area with the pyramid BG.
        LDA.b $8A : ASL : TAX
        LDA.l Pool_OverlayTable, X : CMP.w #$0096 : BEQ .dont_align_bgs
            LDA.b $E2 : STA.b $E0 : STA.w $0120 : STA.w $011E
            LDA.b $E8 : STA.b $E6 : STA.w $0122 : STA.w $0124
        
        .dont_align_bgs
    .BRANCH_DELTA
    
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    RTL
}
warnpc $00FFC0 ; This end point also uses up a null block at the end of the function.

endif

; ==============================================================================

if !Func0283EE = 1

; Replaces a bunch of calls to a shared function.
; Intro_SetupScreen:
org $028027
    JSR PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

warnpc $02802B

; Dungeon_LoadSongBankIfNeeded:
org $029C0C
    JMP PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

warnpc $029C0F

; Mirror_LoadMusic:
org $029D1E
    JSR PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

warnpc $029D22

; GanonEmerges_LOadPyramidArea:
org $029F82
    JSR PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

warnpc $029F86

; Changes the function that loads overworld properties when exiting a dungeon.
; Includes removing asm that plays music in certain areas and changing how animated tiles are loaded.
; TODO: May need to add other funtionality here as well.
org $0283EE ; $0103EE
PreOverworld_LoadProperties_LoadMain:
{
    LDX.b #$F3

    ; If the volume was set to half, set it back to full.
    LDA.w $0132 : CMP.b #$F2 : BEQ .setToFull
        ; If we're in the dark world
        ; If area number is < 0x40 or >= 80 we are not in the dark world.
        LDA.b $8A : CMP.b #$40 : BCC .setNormalSong
                    CMP.b #$80 : BCS .setNormalSong
            ; Does Link have a moon pearl?
            LDA.l $7EF357 : BNE .setNormalSong
                ; If not, play the music that plays when you're a bunny in the Dark World.
                LDX.b #$04

                BRA .setToFull

        .setNormalSong

        LDX.b $8A
        LDA.l $7F5B00, X : AND.b #$0F : TAX
        
    .setToFull
    
    ; The value written here will take effect during NMI.
    STX.w $0132

    ; Set the ambient sound.
    ;LDX.b $8A
    ;LDA.l $7F5B00, X : LSR #4 : STA.w $012D
    
    ; Load the animated tiles the area needs.
    LDX.b $8A
    LDA.l Pool_AnimatedTable, X : DEC : TAY

    JSL DecompOwAnimatedTiles       ; $5394 IN ROM
    JSL InitTilesets                ; $619B IN ROM; Decompress all other graphics
    JSR Overworld_LoadAreaPalettes  ; $014692 IN ROM; Load palettes for overworld
        
    LDX.b $8A
        
    LDA.l $7EFD40, X : STA.b $00
        
    LDA.l $00FD1C, X
        
    JSL Overworld_LoadPalettes      ; $0755A8 IN ROM; Load some other palettes
    JSL Palette_SetOwBgColor_Long   ; $075618 IN ROM; Sets the background color (changes depending on area)
        
    LDA.b $10 : CMP.b #$08 : BNE .specialArea2
        ; $01465F IN ROM; Copies $7EC300[0x200] to $7EC500[0x200]
        JSR $C65F
        
        BRA .normalArea2
    
    .specialArea2
    
    ; apparently special overworld handles palettes a bit differently?
    JSR $C6EB ; $0146EB IN ROM
    
    .normalArea2
    
    JSL $0BFE70 ; $05FE70 IN ROM; Sets fixed colors and scroll values
        
    ; Something fixed color related
    LDA.b #$00 : STA.l $7EC017
        
    ; Sets up properties in the event a tagalong shows up
    JSL Tagalong_Init
        
    ; TODO: investigate this.
    LDA.b $8A : AND.b #$3F : BNE .notForestArea
        LDA.b #$1E
        
        JSL GetAnimatedSpriteTile_variable
    
    .notForestArea
    
    LDA.b #$09 : STA.w $010C
        
    JSL Sprite_OverworldReloadAll ;09C499
        
    ; Are we in the dark world? If so, there's no warp vortex there.
    LDA.b $8A : AND.b #$40 : BNE .noWarpVortex
        JSL Sprite_ReinitWarpVortex ; $04AF89 IN ROM
    
    .noWarpVortex
        
    ; Check if Blind disguised as a crystal maiden was following us when
    ; we left the dungeon area
    LDA.l $7EF3CC : CMP.b #$06 : BNE .notBlindGirl
        ; If it is Blind, kill her!
        LDA.b #$00 : STA.l $7EF3CC
    
    .notBlindGirl
    
    STZ $6C
    STZ $3A
    STZ $3C
    STZ $50
    STZ $5E
    STZ $0351
        
    ; Reinitialize many of Link's gameplay variables
    JSR $8B0C ; $010B0C IN ROM
        
    LDA.l $7EF357 : BNE .notBunny
    LDA.l $7EF3CA : BEQ .notBunny
        LDA.b #$01 : STA.w $02E0 : STA.b $56
        
        LDA.b #$17 : STA.b $5D
        
        JSL LoadGearPalettes_bunny
    
    .notBunny
    
    ; Set screen to mode 1 with BG3 priority.
    LDA.b #$09 : STA.b $94
        
    LDA.b #$00 : STA.l $7EC005
        
    STZ $046C
    STZ $EE
    STZ $0476
        
    INC $11
    INC $16
        
    STZ $0402 : STZ $0403

    ; Alternate entry point.
    .LoadMusicIfNeeded

    LDA.w $0136 : BEQ .no_music_load_needed
        SEI
        
        ; Shut down NMI until music loads
        STZ $4200
        
        ; Stop all HDMA
        STZ $420C
        
        STZ $0136
        
        LDA.b #$FF : STA.w $2140
        
        JSL Sound_LoadLightWorldSongBank
        
        ; Re-enable NMI and joypad
        LDA.b #$81 : STA.w $4200
    
    .no_music_load_needed

    ; PLACE CUSTOM GFX LOAD HERE!
    ;JSL CheckForChangeGraphicsNormalLoadCastle
    
    RTS
}
warnpc $02856A

endif

; ==============================================================================

if !Func028632 = 1

; Changes a function that loads animated tiles under certain conditions.
org $028632 ; $010632
{
    ; Load the animated tiles the area needs.
    LDX.b $8A
    LDA.l Pool_AnimatedTable, X : DEC : TAY
    
    JSL DecompOwAnimatedTiles ; $5394 IN ROM
        
    LDA.b $11 : LSR A : TAX
        
    LDA.l $0285E2, X : STA.w $0AA3
        
    LDA.l $0285F3, X : PHA
        
    JSL InitTilesets                ; $619B IN ROM
    JSR Overworld_LoadAreaPalettes  ; $014692 IN ROM ; Load Palettes
        
    PLA : STA.b $00
        
    LDX.b $8A
        
    LDA.l $00FD1C, X
        
    JSL Overworld_LoadPalettes ; $0755A8 IN ROM
        
    LDA.b #$01 : STA.w $0AB2
        
    JSL Palette_Hud ; $0DEE52 IN ROM
        
    LDA.l $11 : BNE .BRANCH_4
        JSL CopyFontToVram  ; $6556 IN ROM
    
    .BRANCH_4
    
    JSR $C65F   ; $01465F IN ROM
    JSL $0BFE70 ; $05FE70 IN ROM
        
    LDA.l $8A : CMP.b #$80 : BCC .BRANCH_5
        JSL Palette_SetOwBgColor_Long ; $075618 IN ROM
    
    .BRANCH_5
    
    LDA.b #$09 : STA.b $94
        
    INC $B0
        
    RTS
}
warnpc $028697

endif

; ==============================================================================

if !Func029AA6 = 1

; Changes part of a function that changes the special BG color when leaving dungeons? not sure.
org $029AA6 ; $011AA6
{
    ; Setup fixed color values based on area number
    LDX.w #$4C26
    LDY.w #$8C4C
        
    ; TODO: Wtf why is this 0x00?
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X

    ; Check for LW death mountain. 
    CMP.w #$0095 : BEQ .mountain
        LDX.w #$4A26 : LDY.w #$874A
        
        ; Check for DW death mountain. 
        CMP.w #$009C : BEQ .mountain
            BRA .other
    
    .mountain
    
    STX.b $9C : STY.b $9D
    
    .other
    
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    RTS
}
warnpc $029AD3

endif

; ==============================================================================

if !Func02AF58 = 1

; TODO: If something is broken, its probably here, this function is scuffed.
; Main subscreen overlay loading function. Changed so that they will load
; from a table. This does not change the event overlays like the lost woods 
; changing to the tree canopy, the master sword area or the misery mire rain. This also does not change
; the overlay for under the bridge because it shares an area with the master sword.
org $02AF58 ; $012F58
{
    ; $0182 is the exit room number used for getting to Zora's Domain.
    LDA.b $A0 : CMP.w #$0182 : BNE .notZoraFalls   
        SEP #$20 ; Set A in 8bit mode

        ; Play rain (waterfall) sound.
        LDA.b #$01 : STA.w $012D

        REP #$20 ; Set A in 16bit mode

    .notZoraFalls

    ; Check to see if we are in a SW overworld area.
    LDA.b $8A : CMP.w #$0080 : BCC .notExtendedArea
        ; Check for exit rooms (the faked way of getting from one overworld area to another).
        ; $0180 is the exit room number used for getting into the mastersword area.
        LDA.b $A0 : CMP.w #$0180 : BNE .notMasterSwordArea
            ; If the Master sword is retrieved, don't do the mist overlay.
            LDA.l $7EF300 : AND.w #$0040 : BNE .noSubscreenOverlay ; TODO: Write a patch to change what overlay is loaded here?
                .loadOverlayShortcut

                LDA.b $8A : ASL : TAX
                LDA.l Pool_OverlayTable, X : TAX

                ; Save the overlay for later
                PHX

                JMP .loadSubScreenOverlay
    
        .notMasterSwordArea
    
        ; $0189 is the exit room number used for getting to the Triforce room.
        CMP.w #$0189 : BEQ .loadOverlayShortcut
            ; The second mastersword/under the bridge area.
            LDX.w #$0094

            ; $0181 is the exit room number used for getting into the under the bridge area.
            LDA.b $A0 : CMP.w #$0181 : BEQ .loadOverlayShortcut
                .noSubscreenOverlay
                    
                SEP #$30 ; Set A, X, and Y in 8bit mode.
                    
                STZ $1D
                        
                INC $11
                        
                RTS
    
    .notExtendedArea

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : TAX
    
    LDA.b $8A : BNE .notForest
        ; Check if we have the master sword.
        LDA.l $7EF300 : AND.w #$0040 : BEQ .notForest
            ; TODO: Write a patch to change this?
            ; The forest canopy overlay
            LDX.w #$009E
    
    .notForest

    ; Check if we need to disable the rain in the misery mire
    LDA.b $8A : CMP.w #$0070 : BNE .notMire
        ; Has Misery Mire been triggered yet?
        LDA.l $7EF2F0 : AND.w #$0020 : BEQ .notMire
            ; The pyramid background
            LDX.w #$0096
        
    .notMire

    ; Check if we are in the beginning phase, if not, no rain.
    ; If $7EF3C5 >= 0x02
    LDA.l $7EF3C5 : AND.w #$00FF : CMP.w #$0002 : BCS .noRain
    
        ; The rain overlay
        ;LDX.w #$009F
        
    .noRain
    
    ; Store the overlay for later.
    PHX

    ; If the value is 0xFF that means we didn't set any overlay so load the pyramid one by default.
    CPX.w #$00FF : BNE .notFF
        ; The pyramid background
        LDX.w #$0096

    .notFF
    
    ; $01300B ALTERNATE ENTRY POINT ; TODO: Verify this. If it is an alternate entry I can't find where it is referenced anywhere.
    .loadSubScreenOverlay
    STY.b $84
        
    STX.b $8A : STX $8C
        
    LDA.b $84 : SEC : SBC.w #$0400 : AND.w #$0F80 : ASL A : XBA : STA.b $88
        
    LDA.b $84 : SEC : SBC.w #$0010 : AND.w #$003E : LSR A : STA.b $86
        
    STZ $0418 : STZ $0410 : STZ $0416
        
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    ; Color +/- buffered register.
    LDA.b #$82 : STA.b $99
        
    ; Puts OBJ, BG2, and BG3 on the main screen
    LDA.b #$16 : STA.b $1C
        
    ; Puts BG1 on the subscreen
    LDA.b #$01 : STA.b $1D

    ; Pull the 16 bit overlay from earlier and just discard the high byte.
    PLX : PLA
        
    ; One possible configuration for $2131 (CGADSUB)
    LDA.b #$72
        
    ; Comparing different screen types
    CPX.b #$97 : BEQ .loadOverlay ; Fog 1
    CPX.b #$94 : BEQ .loadOverlay ; Master sword/bridge 2
    CPX.b #$93 : BEQ .loadOverlay ; Triforce room 2
    CPX.b #$9D : BEQ .loadOverlay ; Fog 2
    CPX.b #$9E : BEQ .loadOverlay ; Tree canopy
    CPX.b #$9F : BEQ .loadOverlay ; Rain
        ; alternative setting for CGADSUB (only background is enabled on subscreen)
        LDA.b #$20 
        
        CPX.b #$95 : BEQ .loadOverlay ; Sky
        CPX.b #$9C : BEQ .loadOverlay ; Lava
    
            CPX.b #$96 : BEQ .loadOverlay ; Pyramid BG
                LDX.b $11
        
                CPX.b #$23 : BEQ .loadOverlay ; TODO: Investigate what these checks are for.
                CPX.b #$2C : BEQ .loadOverlay
    
            .disableSubscreen
    
            STZ $1D
    
    .loadOverlay
    
    ; apply the selected settings to CGADSUB's mirror ($9A)
    STA.b $9A
        
    JSR LoadSubscreenOverlay
        
    ; This is the "under the bridge" area.
    LDA.b $8C : CMP.b #$94 : BNE .notUnderBridge
        ; All this is doing is setting the X coordinate of BG1 to 0x0100
        ; Rather than 0x0000. (this area usees the second half of the data only, similar to the master sword area.
        LDA.b $E7 : ORA.b #$01 : STA.b $E7
    
    .notUnderBridge
    
    REP #$20 ; Set A in 16bit mode
        
    ; We were pretending to be in a different area to load the subscreen
    ; overlay, so we're restoring all those settings.
    LDA.l $7EC213 : STA.b $8A
    LDA.l $7EC215 : STA.b $84
    LDA.l $7EC217 : STA.b $88
    LDA.l $7EC219 : STA.b $86
        
    LDA.l $7EC21B : STA.w $0418
    LDA.l $7EC21D : STA.w $0410
    LDA.l $7EC21F : STA.w $0416
        
    SEP #$20 ; Set A in 8bit mode
        
    RTS
}
warnpc $02B0D2

endif

; ==============================================================================

if !Func02B2D4 = 1

; Turns on the subscreen if the pyramid is loaded.
org $02B2D4 ; $132D4
{
    JSR Overworld_LoadSubscreenAndSilenceSFX1 ; $012F19 IN ROM

    ; Just because we are a few bytes short. Actually jk I don't think this is needed at all.
    ; It seems to be handled elsewhere.
    ;JSL EnableSubScreenCheck

    RTL
}
warnpc $02B2E6

endif

pullpc
EnableSubScreenCheck:
{
    REP #$20 ; Set A in 16bit mode

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
        
    CMP.w #$0096 : BNE .notPyramidOrCastle
        SEP #$20 ; Set A in 8bit mode
        LDA.b #$01 : STA.b $1D
    
    .notPyramidOrCastle

    SEP #$20 ; Set A in 8bit mode

    RTL
}
pushpc

; ==============================================================================

if !Func02B3A1 = 1

; Handles activating the subscreen and special BG color when warping to an area with the pyramid BG.
org $02B3A1 ; $0133A1
{
    ; Oh look at that we can just use this same function lucky us.
    ; TODO: May not be needed anymore.
    JSL EnableSubScreenCheck
    
    REP #$20 ; Set A in 16bit mode.
        
    LDX.b #$00
        
    LDA.w #$7FFF
    
    .setBgPalettesToWhite
        STA.l $7EC540, X : STA.l $7EC560, X : STA.l $7EC580, X
        STA.l $7EC5A0, X : STA.l $7EC5C0, X : STA.l $7EC5E0, X
        
    INX #2 : CPX.b #$20 : BNE .setBgPalettesToWhite
        
    ; Also set the background color to white.
    STA.l $7EC500

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
        
    ; TODO: May not be needed anymore.
    CMP.w #$0096 : BNE .notPyramidOfPower
        LDA.w #$0000 : STA.l $7EC300 : STA.l $7EC340
    
    .notPyramidOfPower
    
    SEP #$20 ; Set A in 8bit mode
        
    JSL Sprite_ResetAll
    JSL Sprite_OverworldReloadAll
    JSL $07B107 ; $03B107 IN ROM
    JSR $8B0C   ; $010B0C IN ROM
        
    LDA.b #$14 : STA.b $5D
        
    LDA.b $8A : AND.b #$40 : BNE .darkWorld
        JSL Sprite_ReinitWarpVortex
    
    .darkWorld
    
    RTL
}
warnpc $02B40A

endif

; ==============================================================================

if !Func02BC44 = 1

; Controls overworld vertical subscreen movement for the pyramid BG.
org $02BC44 ; $013C44
{
    NOP : JSL ReadOverlayArray : CMP.w #$0096 : BNE .BRANCH_IOTA
        ; TODO: I think these comparison values will need to be calulated somehow
        ; depending on the area. Right now they are hardcoded to work with the
        ; castle of shadows area.

        JSL BGControl
        BRA .BRANCH_IOTA

        ; Don't let the BG scroll down further than the "top" of the bg when walking up.
        ;LDA.w #$0208 : CMP.b $E6 : BCC .BRANCH_NU ; #$0600 
            ;STA.b $E6
    
        ;.BRANCH_NU
    
        ; Don't let the BG scroll up further than the "bottom" of the bg when walking down.
        ;LDA.w #$02C0 : CMP.b $E6 : BCS .BRANCH_IOTA ;#$06C0 
           ; STA.b $E6
    
    warnpc $02BC60

    org $02BC60
    .BRANCH_IOTA
}
warnpc $02BC60

endif

pullpc
ReadOverlayArray:
{
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X

    RTL
}

BGControl:
{
    LDA.b $20 : CMP.w #$0180 : BCC .startShowingMountains
        ; Lock the position so that nothing shows through the trees
        LDA.w #$02C0 : STA.b $E6

        RTL

    .startShowingMountains

    ; Lock the position to just above right where the last tree block is based on
    ; the actual tile BG.
    LDA.b $E8 : CLC : ADC.w #$01A0 : STA.b $E6

    ; Don't let the BG scroll down further than the "top" of the bg when walking up.
    LDA.w #$0208 : CMP.b $E6 : BCC .dontLock ; #$0600 
        STA.b $E6
    
    .dontLock
    
    ; Don't let the BG scroll up further than the "bottom" of the bg when walking down.
    LDA.w #$02C0 : CMP.b $E6 : BCS .dontLock2 ;#$06C0 
        STA.b $E2

    .dontLock2

    RTL
}
pushpc

; ==============================================================================

if !Func02C02D = 1

; Changes how the pyramid BG scrolls durring transition.
org $02C02D ; $01402D
{
    PHA
    JSL ReadOverlayArray2
    PLA
    
    CPY.b #$96 : BEQ .dontMoveBg1  
        ; TODO: This may or not be needed.
        ; It shifts the BG over by a half small area's width. I think this is to line up the
        ; mountain with the tower in the distance at the appropriate location when coming into
        ; the pyramid area from the right.
        STA.b $E0, X 
    
    .dontMoveBg1
}
warnpc $02C039

endif

pullpc
ReadOverlayArray2:
{
    PHX

    ; A is already 16 bit here.
    REP #$10 ; Set X and Y in 16bit mode.

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
    TAY

    SEP #$10 ; Set X and Y in 8bit mode.

    PLX

    RTL
}
pushpc

; ==============================================================================

if !Func02C692 = 1

; Replaces a call to a shared function. Normally this is goes to .lightworld to change the main color palette manually but we change it here so that it just uses the same table as everything else.
org $02A07A ; $01207A
    JSR Overworld_LoadAreaPalettes

warnpc $02A07D

; The main overworld palette loading routine un-hardcoded to load the custom main palette.
org $02C692 ; $14692
Overworld_LoadAreaPalettes:
{
    LDX.b $8A
    LDA.l Pool_MainPaletteTable, X 
    
    ; $0AB3 = 0 - LW 1 - DW, 2 - LW death mountain, 3 - DW death mountain, 4 - triforce room
    STA.w $0AB3
        
    STZ $0AA9
        
    JSL Palette_MainSpr         ; $0DEC9E IN ROM; load SP1 through SP4
    JSL Palette_MiscSpr         ; $0DED6E IN ROM; load SP0 (2nd half) and SP6 (2nd half)
    JSL Palette_SpriteAux1      ; $0DECC5 IN ROM; load SP5 (1st half)
    JSL Palette_SpriteAux2      ; $0DECE4 IN ROM; load SP6 (1st half)
    JSL Palette_Sword           ; $0DED03 IN ROM; load SP5 (2nd half, 1st 3 colors), which is the sword palette
    JSL Palette_Shield          ; $0DED29 IN ROM; load SP5 (2nd half, next 4 colors), which is the shield
    JSL Palette_ArmorAndGloves  ; $0DEDF9 IN ROM; load SP7 (full) Link's whole palette, including Armor
        
    LDX.b #$01
        
    ; Changes the Palette_SpriteAux3 load depending on if we are in the LW or not. Will probably need it own custom table? not sure.
    LDA.l $7EF3CA : AND.b #$40 : BEQ .lightWorld2
        LDX.b #$03
    
    .lightWorld2
    
    STX.w $0AAC
        
    JSL Palette_SpriteAux3      ; $0DEC77 IN ROM; load SP0 (first half) (or SP7 (first half))
    JSL Palette_Hud             ; $0DEE52 IN ROM; load BP0 and BP1 (first halves)
    JSL Palette_OverworldBgMain ; $0DEEC7 IN ROM; load BP2 through BP5 (first halves)
        
    RTS
}
warnpc $02C6EB

endif

; ==============================================================================

if !Func02A4CD = 1

; Rain animation code. Just replaces a single check that checks for the
; misery mire to instead check the current overlay to see if it's rain.
org $02A4CD ; $0124CD
RainAnimation:
{
    LDA $8C : CMP.b #$9F : BEQ .rainOverlaySet
        ; Check the progress indicator
        LDA $7EF3C5 : CMP.b #$02 : BRA .skipMovement
            .rainOverlaySet

            ; If misery mire has been opened already, we're done.
            ;LDA $7EF2F0 : AND.b #$20 : BNE .skipMovement
                ; Check the frame counter.
                ; On the third frame do a flash of lightning.
                LDA $1A

                CMP.b #$03 : BEQ .lightning ; On the 0x03rd frame, cue the lightning.
                    CMP.b #$05 : BEQ .normalLight ; On the 0x05th frame, normal light level.
                        CMP.b #$24 : BEQ .thunder ; On the 0x24th frame, cue the thunder.
                            CMP.b #$2C : BEQ .normalLight ; On the 0x2Cth frame, normal light level.
                                CMP.b #$58 : BEQ .lightning ; On the 0x58th frame, cue the lightning.
                                    CMP.b #$5A : BNE .moveOverlay ; On the 0x5Ath frame, normal light level.

                .normalLight

                ; Keep the screen semi-dark.
                LDA.b #$72

                BRA .setBrightness

                .thunder

                ; Play the thunder sound when outdoors.
                LDX.b #$36 : STX $012E

                .lightning

                LDA.b #$32 ; Make the screen flash with lightning.

                .setBrightness

                STA $9A

                .moveOverlay

                ; Overlay is only moved every 4th frame.
                LDA $1A : AND.b #$03 : BNE .skipMovement
                    LDA $0494 : INC A : AND.b #$03 : STA $0494 : TAX

                    LDA $E1 : CLC : ADC.l $02A46D, X : STA $E1
                    LDA $E7 : CLC : ADC.l $02A471, X : STA $E7

    .skipMovement

    RTL
}
warnpc $02A52D

endif

; ==============================================================================

if !Func02AADB = 1

; Main Mosaic Hook. Changes it to use a table instead of hardcoded to the woods areas.
org $02AADB ; $012ADB
    JML MosaicAreaCheck

warnpc $02AADF

endif

pullpc
MosaicAreaCheck:
{
    PHB : PHK : PLB

    ; Check if the area we are in needs a mosaic.
    TAX
    LDA.w Pool_MosaicTable, X

    BEQ .noMosaic1
        PLB
        JML $02AAE5

    .noMosaic1

    ; Check if the area we are going to needs a mosaic.
    LDX.b $8A
    LDA.w Pool_MosaicTable, X

    BEQ .noMosaic2
        PLB
        JML $02AAE5

    .noMosaic2

    PLB
    JML $02AAF4
}
pushpc

; ==============================================================================

if !Func02ABB8 = 1

org $02ABB8 ; $012BB8
    JML CheckForChangeGraphicsTransitionLoad

warnpc $02ABBC

endif

; Loads the animated tiles after most of the transition gfx changes take place.
pullpc
CheckForChangeGraphicsTransitionLoad:
{
    PHB : PHK : PLB

    ; Are we currently in a mosaic?
    LDA $11 : CMP.b #$0F : BEQ .mosaic
        ; Are we entering a special area?
        CMP.b #$1A : BEQ .mosaic
            ; Are we leaving a special area?
            CMP.b #$26 : BEQ .mosaic
                ; Just a normal transition, Not a mosaic.
                LDA.w Pool_EnableAnimated : BEQ .dontUpdateAnimated1
                    ; Check to see if we need to update the animated tiles by checking what was previously loaded.
                    LDX.b $8A
                    LDA.w Pool_AnimatedTable, X : CMP.w AnimatedTileGFXSet : BEQ .dontUpdateAnimated1
                        STA.w AnimatedTileGFXSet : DEC : TAY

                        JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.

                .dontUpdateAnimated1

                LDA.w Pool_EnableMainPalette : BEQ .dontUpdateMain1
                    ; Check to see if we need to update the main palette by checking
                    ; what was previously loaded.
                    LDX.b $8A
                    LDA.w Pool_MainPaletteTable, X : CMP.w $0AB3 : BEQ .dontUpdateMain1
                        STA.w $0AB3

                        ; Run the modified routine that loads the buffer and normal color ram.
                        JSL Palette_OverworldBgMain2

                .dontUpdateMain1

                LDA.w Pool_EnableBGColor : BEQ .dontUpdateBGColor1
                    REP #$30 ; Set A, X, and Y in 16bit mode.

                    LDA $8A : ASL : TAX ; Get area code and times it by 2

                    LDA Pool_BGColorTable, X ; Where ZS saves the array of palettes
                    STA.l $7EC300 : STA.l $7EC500 : STA.l $7EC540 : STA.l $7EC340

                    SEP #$30 ; Set A, X, and Y in 8bit mode.

                    INC $15 ; trigger the buffer into the CGRAM.
                
                .dontUpdateBGColor1

                LDA.b #$09 ; Replaced code.

                PLB
                    
                JML Overworld_FinishTransGfx_firstHalf

    .mosaic

    ; Check to see if we need to update the animated tiles by checking what was previously loaded.
    LDX.b $8A
    LDA.w Pool_AnimatedTable, X : CMP.w AnimatedTileGFXSet : BEQ .dontUpdateAnimated2
        STA.w AnimatedTileGFXSet : DEC : TAY

        JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.

    .dontUpdateAnimated2

    ; Check to see if we need to update the main palette by checking
    ; what was previously loaded.
    LDX.b $8A
    LDA.w Pool_MainPaletteTable, X : CMP.w $0AB3 : BEQ .dontUpdateMain2
        STA.w $0AB3

        ; Run the vanilla routine that only loads the buffer.
        JSL Palette_OverworldBgMain

    .dontUpdateMain2

    REP #$30 ; Set A, X, and Y in 16bit mode.

    LDA.b $8A : ASL : TAX ; Get area code and times it by 2

    LDA Pool_BGColorTable, X ; Where ZS saves the array of palettes
    STA.l $7EC300 : STA.l $7EC340 ;set transparent color ; only set the buffer so it fades in right during mosaic transition.

    SEP #$30 ; Set A, X, and Y in 8bit mode.

    INC.b $15 ; trigger the buffer into the CGRAM

    LDA.b #$09 ; Replaced code.

    ; PLACE CUSTOM GFX LOAD HERE!
    ;JML CheckForChangeGraphicsTransitionLoadCastle

    CheckForChangeGraphicsTransitionLoadRetrun:

    PLB
        
    JML Overworld_FinishTransGfx_firstHalf

    SkipOverworld_FinishTransGfx_firstHalf:

    PLB

    JML $02ABC3 ;skips Overworld_FinishTransGfx_firstHalf
}

; The following 2 functions are copied from the palettes.asm but they only copied colors
; into the buffer so these copy colors into the normal ram as well.
Palette_OverworldBgMain2:
{
    REP #$21
        
    LDA $0AB3 : ASL A : TAX
        
    LDA $1BEC3B, X : ADC.w #$E6C8 : STA $00
        
    REP #$10
        
    ; Target BP2 through BP6 (first halves)
    ; each palette has 7 colors
    ; Load 5 palettes
    LDA.w #$0042
    LDX.w #$0006
    LDY.w #$0004
        
    JSR Palette_MultiLoad2
        
    SEP #$30
        
    RTL
}

Palette_MultiLoad2:
{
    ; Description: Generally used to load multiple palettes for BGs.
    ; Upon close inspection, one sees that this algorithm is almost the same as the
    ; last subroutine.
    ; Name = Palette_MultiLoad(A, X, Y)
        
    ; Parameters: X = (number of colors in the palette - 1)
    ;             A = offset to add to $7EC300, in other words, where to write in palette
    ;             memory
    ;             Y = (number of palettes to load - 1)
    ; 
        
    STA $04 ; Save the values for future reference.
    STX $06
    STY $08
        
    LDA.w #$001B    ; The absolute address at $00 was planted in the calling function. This value 
                    ; is the bank #$1B ( => D in Rom) The address is found from $0AB6
    STA $02         ; And of course, store it at $02
    
    .nextPalette
        ; $0AA8 + A parameter will be the X value.
        LDA $0AA8 : CLC : ADC $04 : TAX
        
        LDY $06 ; Tell me how long the palette is.
    
        .copyColors
            ; We're loading A from the address set up in the calling function.
            LDA [$00] : STA $7EC300, X : STA $7EC500, X 
            
            ; Increment the absolute portion of the address by two, and decrease the color count by one
            INC $00 : INC $00
            
            INX #2
        
        ; So basically loop (Y+1) times, taking (Y * 2 bytes) to $7EC300, X        
        DEY : BPL .copyColors
        
        ; This technique bumps us up to the next 4bpp (16 color) palette.
        LDA $04 : CLC : ADC.w #$0020 : STA $04
        
        ; Decrease the number of palettes we have to load.
        DEC $08
        
    BPL .nextPalette
        
    ; We're done loading palettes.
        
    RTS
}

pushpc

; ==============================================================================

if !Func0ABC5A = 1

org $0ABC5A ; $053C5A
    JSL CheckForChangeGraphicsNormalLoad

warnpc $0ABC5E

endif

; Loads the animated tiles after the overworld map is closed.
pullpc
CheckForChangeGraphicsNormalLoad:
{
    PHB : PHK : PLB

    JSL InitTilesets ; Replaced code.

    LDX.b $8A
    LDA.w Pool_AnimatedTable, X : STA.w AnimatedTileGFXSet : DEC : TAY

    ; TODO: this whole function may not be needed.
    ; This forces the game to update the animated tiles when going from one area to another.
    ;JSL DecompOwAnimatedTiles 

    ; PLACE CUSTOM GFX LOAD HERE!
    ;JSL CheckForChangeGraphicsNormalLoadCastle
        
    PLB

    RTL
}
pushpc

; ==============================================================================

if !Func0AB8F5 = 1

; Loads different animated tiles when returning from bird travel.
org $0AB8F5 ; $0538F5
{
    ; Get the animated tiles value for this overworld area.
    LDX.b $8A
    LDA.l Pool_AnimatedTable, X 

    ; The decompression function increases it by 1 so subtract 1 here.
    DEC : TAY
    
    ; From this point on it is the vanilla function.
    JSL DecompOwAnimatedTiles ; $5394 IN ROM
    JSL $0BFE70 ; $05FE70 IN ROM
        
    STZ $0AA9
    STZ $0AB2
        
    JSL InitTilesets
        
    INC $0200
        
    STZ $B2
        
    JSL $02B1F4 ; $0131F4 IN ROM
        
    ; Play sound effect indicating we're coming out of map mode
    LDA.b #$10 : STA.w $012F
        
    ; reset the ambient sound effect to what it was
    LDX.b $8A : LDA.l $7F5B00, X : LSR #4 : STA.w $012D
        
    ; if it's a different music track than was playing where we came from,
    ; simply change to it (as opposed to setting volume back to full)
    LDA.l $7F5B00, X : AND.b #$0F : TAX : CPX.w $0130 : BNE .different_music
        ; otherwise, just set the volume back to full.
        LDX.b #$F3
    
    .different_music
    
    STX.w $012C

    ; PLACE CUSTOM GFX LOAD HERE!
    ;JSL CheckForChangeGraphicsNormalLoadCastle
        
    RTL
}
warnpc $0AB948

endif

; ==============================================================================

if !Func0BFEC6 = 1

; Loads different special transparent colors and overlay speeds based on the overlay during transition and under other certain cases. Exact cases need to be investigated. When leaving dungeon.
org $0BFEC6 ; $05FEC6
Overworld_LoadBGColorAndSubscreenOverlay:
{
    JSL ReplaceBGColor

    ; set fixed color to neutral
    LDA.w #$4020 : STA.b $9C
    LDA.w #$8040 : STA.b $9D
    
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X

    ; Check for misery mire.
    CMP.w #$009F : BNE .notMire
        JMP .subscreenOnAndReturn
    
    .notMire
    
    ; Check for lost woods?, skull woods, and pyramid area.
    CMP.w #$009D : BEQ .noCustomFixedColor
    CMP.w #$0096 : BEQ .noCustomFixedColor
        LDX.w #$4C26
        LDY.w #$8C4C
        
        ; Check for LW Death mountain.
        CMP.w #$0095 : BEQ .setCustomFixedColor
            LDX.w #$4A26
            LDY.w #$874A
            
            ; Check for DW Death mountain. (not turtle rock?)
            CMP.w #$009C : BEQ .setCustomFixedColor

            SEP #$30 ; Set A, X, and Y in 8bit mode.
            
            ; Update CGRAM this frame
            INC $15
            
            RTL
        
        .setCustomFixedColor
        
        STX.b $9C
        STY.b $9D ; Set the fixed color addition color values
    
    .noCustomFixedColor
    
    LDA.b $11 : AND.w #$00FF : CMP.w #$0004 : BEQ .BRANCH_11
        ; Make sure BG2 and BG1 Y scroll values are synchronized. Same for X scroll
        LDA.b $E8 : STA.b $E6
        LDA.b $E2 : STA.b $E0
            
        LDA.b $8A : ASL : TAX
        LDA.l Pool_OverlayTable, X
            
        ; Are we at Hyrule Castle or Pyramid of Power?
        CMP.w #$0096 : BNE .subscreenOnAndReturn
            LDA.b $E2 : SEC : SBC.w #$0778 : LSR A : TAY : AND.w #$4000 : BEQ .BRANCH_7
                TYA : ORA.w #$8000 : TAY
            
            .BRANCH_7
            
            STY.b $00
                
            LDA.b $E2 : SEC : SBC $00 : STA.b $E0
                
            LDA.b $E6 : CMP.w #$06C0 : BCC .BRANCH_9
                SEC : SBC.w #$0600 : AND.w #$03FF : CMP.w #$0180 : BCS .BRANCH_8
                    LSR A : ORA.w #$0600
                
                    BRA .BRANCH_10
            
                .BRANCH_8
            
                LDA.w #$06C0
                
                BRA .BRANCH_10
            
            .BRANCH_9

            LDA.b $E6 : AND.w #$00FF : LSR A : ORA.w #$0600
            
            .BRANCH_10
            
            ; Set BG1 vertical scroll
            STA.b $E6
                
            BRA .subscreenOnAndReturn
    
    .BRANCH_11
    
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : CMP.w #$0096 : BNE .subscreenOnAndReturn
        ; Synchronize Y scrolls on BG0 and BG1. Same for X scrolls
        LDA.b $E8 : STA.b $E6
        LDA.b $E2 : STA.b $E0
            
        LDA.b $0410 : AND.w #$00FF : CMP.w #$0008 : BEQ .BRANCH_12
            ; Handles scroll for special areas maybe?
            LDA.w #$0838 : STA.b $E0
        
        .BRANCH_12
        
        LDA.w #$06C0 : STA.b $E6
    
    .subscreenOnAndReturn
    
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    ; Put BG0 on the subscreen
    LDA.b #$01 : STA.b $1D
        
    ; Update palette
    INC $15
        
    RTL
}
warnpc $0BFFA8

endif

pullpc
ReplaceBGColor:
{
    PHB : PHK : PLB

    ; TODO: This may need to check if we are in a warp and then if so load the custom color.
    ; If not, then chceck if its enabled or not.
    ;SEP #$20 ; Set A in 8bit mode

    ;LDA.w Pool_EnableBGColor : BNE .custom
        ;REP #$20 ; Set A in 16bit mode

        ;PLB

        ;RTL

    ;.custom

    ;REP #$20 ; Set A in 16bit mode

    LDA.b $8A : ASL : TAX ; Get area code and times it by 2
    LDA.w Pool_BGColorTable, X ; Get the color.

    STA.l $7EC300 : STA.l $7EC500 ; Set the BG color 
    STA.l $7EC540 : STA.l $7EC340

    PLB

    RTL
}
pushpc

; ==============================================================================

; Fixes an old hook.
org $0ED627
    LDA $8A : CMP.w #$0080

if !Func0ED627 = 1

; Loads the transparent color under some load conditions such as the mirror warp.
; TODO: Investigate the other conditions. Exiting dungeons.
org $0ED627 ; $075627
    JML IntColorLoad2
    NOP

warnpc $0ED62C

endif

pullpc
IntColorLoad2:
{
    PHB : PHK : PLB

    ; I don't think this is needed. Since this is just for warp we should always load the color i think.
    ;SEP #$20 ; Set A in 8bit mode

    ;LDA.w Pool_EnableBGColor : BNE .custom ; pc 140140 is where ZS saves whether to use the asm or not
        ;REP #$20 ; Set A in 16bit mode

        ;LDA.b $8A : CMP.w #$0080 : BCC .notSpecialArea
            ;PLB
            ;JML $0ED62E

        .notSpecialArea

        ;PLB
        ;JML $0ED644

    .custom

    ;REP #$20 ; Set A in 16bit mode

    LDA.b $8A : ASL : TAX ; Get area code and times it by 2
    LDA.w Pool_BGColorTable, X ; Get the color.
    TAX

    STA.l $7EC300 : STA.l $7EC340 ;set transparent color
    STA.l $7EC500 : STA.l $7EC540

    INC $15

    PLB

    JML $0ED651
}
; pushpc

; ==============================================================================

if !Func0ED8AE = 1

; Resets the area special color after the screen flashes.
org $0ED8AE ; $0758AE
{
    LDA.b $1B : BNE .noSpecialColor
        REP #$30 ; Set A, X, and Y in 16bit mode.

        LDX.w #$4020 : STX.b $9C
        LDX.w #$8040 : STX.b $9D
        
        LDX.w #$4F33
        LDY.w #$894F
        
        ; Lost woods and skull woods.
        LDA.b $8A : ASL : TAX
        LDA.l Pool_OverlayTable, X : CMP.w #$009D : BEQ .noSpecialColor
            CMP.w #$0040 : BEQ .noSpecialColor
                ; Pyramid area.
                CMP.w #$0096 : BEQ .specialColor
                    LDX.w #$4C26
                    LDY.w #$8C4C
                    
                    ; LW death mountain.
                    CMP.w #$0095 : BEQ .specialColor
                        LDX.w #$4A26
                        LDY.w #$874A
                        
                        ; DW death mountain.
                        CMP.w #$009C : BEQ .specialColor
                
                .specialColor

                STX.b $9C
                STY.b $9D
        
        .noSpecialColor
    
    SEP #$30 ; Set A, X, and Y in 8bit mode.
        
    RTL
}
warnpc $0ED8FB

endif

; ==============================================================================