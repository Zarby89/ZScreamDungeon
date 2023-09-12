; ==============================================================================
; Hooks
; ==============================================================================

AnimatedTileGFXSet = $0FC0

org $008913
    Sound_LoadLightWorldSongBank:

org $00D394
    DecompOwAnimatedTiles:

org $00D51B
    GetAnimatedSpriteTile:

org $00D52D
    GetAnimatedSpriteTile_variable:

org $00DF4F
    Do3To4High16Bit:

org $00E19B
    InitTilesets:

org $00E556
    CopyFontToVram:


org $02ABBE
    Overworld_FinishTransGfx_firstHalf:

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
    ; $01 - Enabled

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

; Start of expanded space.
org $288480 ; $140480
pushpc

; Debug addresses
; 00D8D5 ; W6 Animated tiles on warp
!Func00D8D5 = $01
; 00DA63 ; W7 Enable/Disable subscreen
!Func00DA63 = $01
; 00EEBC
!Func00EEBC = $01
; 00FF7C ; W8 BG scrolling for HC and the pyramid area.
!Func00FF7C = $01
; 028027
!Func028027 = $01
; 029C0C
!Func029C0C = $01
; 029D1E
!Func029D1E = $01
; 029F82
!Func029F82 = $01
; 0283EE
!Func0283EE = $01
; 028632
!Func028632 = $01
; 029AA6
!Func029AA6 = $01
; 02AF58 ; W2 Main subscreen loading function
!Func02AF58 = $01
; 02B2D4 ; W1 turns on subscreen for pyramid
!Func02B2D4 = $01
; 0284DA ; Activate subscreen durring pyramid warp
!Func0284DA = $01
; 02BC44
!Func02BC44 = $01
; 02C02D ; T4 pyramid bg scroll
!Func02C02D = $01
; 02C692 ; W3 Main palette loading routine
!Func02C692 = $01
; 02AADB ; T1 Mosaic
!Func02AADB = $01
; 02ABB8 ; T2 transition animated and main palette
!Func02ABB8 = $01
; 0ABC5A
!Func0ABC5A = $01
; 0AB8F5
!Func0AB8F5 = $01
; 0BFEC6 ; W5 T3 Load overlay and default color
!Func0BFEC6 = $01
; 0ED627 ; W4 Transparent color durring warp
!Func0ED627 = $01
; 0ED8AE
!Func0ED8AE = $01

; ==============================================================================

if !Func00D8D5 = 1

; Replaces a function that decompresses animated tiles in certain mirror warp conditions.
org $00D8D5 ; $0058D5
{
    PHX ; TODO: I'm pretty sure this is necessary but make sure.

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
    STZ $1D

    PHX

    REP #$20
    ; Get the overlay value for this overworld area
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : CMP.w #$00FF : BEQ .normal
        ; If not $FF, assume we want an overlay.
        SEP #$20

        ; Turn on BG1.
        LDA.b #$01 : STA.b $1D

    .normal

    SEP #$20

    PLX

    ; From this point on it is the vanilla function.
    PHB : PHK : PLB
        
    LDA.l $00D8F4, X : TAY
        
    LDA.w $D1B1, Y : STA.b $00
    LDA.w $D0D2, Y : STA.b $01
    LDA.w $CFF3, Y : STA.b $02
    STA.b $05
        
    PLB
        
    REP #$31
        
    ; source address is determined above, number of tiles is 0x0040, base target address is $7F0000
    LDX.w #$0000
    LDY.w #$0040
        
    LDA.b $00
        
    JSR Do3To4High16Bit
    
    SEP #$30
        
    RTL
}
warnpc $00DABB

endif

; ==============================================================================

if !Func00EEBC = 1

; Zeros out the BG color when mirror warping to the pyramid area.
org $00EEBC ; $006EBC
{
    ; Check if we are warping to an area with the pyramid BG.
    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : CMP.w #$0096 : BNE .notHyruleCastle
        ; This is annoying but I just needed a little bit of extra space.
        JSL EraseBGColors

    .notHyruleCastle

    SEP #$20
        
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
        SEP #$20
        
        STZ.b $9B
        
        INC $B0
        
        JSL $0BFE70 ; $5FE70 IN ROM

        ; Check if we are warping to an area with the pyramid BG.
        LDA.b $8A : ASL : TAX
        LDA.l Pool_OverlayTable, X : CMP.w #$0096 : BEQ .dont_align_bgs
            REP #$20
            
            LDA.b $E2 : STA.b $E0 : STA.w $0120 : STA.w $011E
            LDA.b $E8 : STA.b $E6 : STA.w $0122 : STA.w $0124
        
        .dont_align_bgs
    .BRANCH_DELTA
    
    SEP #$30
        
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

; Dungeon_LoadSongBankIfNeeded:
org $029C0C
    JMP PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

; Mirror_LoadMusic:
org $029D1E
    JSR PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

; GanonEmerges_LOadPyramidArea:
org $029F82
    JSR PreOverworld_LoadProperties_LoadMain_LoadMusicIfNeeded

; Changes the function that loads overworld properties when exiting a dungeon.
; Includes removing asm that plays music in certain areas and changing how animated tiles are loaded.
; TODO: May need to add other funtionality here as well.
org $0283EE ; $0103EE
PreOverworld_LoadProperties_LoadMain:
{
    ; If the volume was set to half, set it back to full.
    LDA.w $0132 : CMP.b #$F2 : BEQ .setSong
        ; Does Link have a moon pearl?
        LDA.l $7EF357 : BNE .setSong
            ; If not, play that stupid music that plays when you're a bunny in the Dark World.
            LDX.b #$04
    
    .setSong
    
    ; The value written here will take effect during NMI.
    STX.w $0132
    
    ; Load the animated tiles the area needs.
    LDX.b $8A
    LDA.l Pool_AnimatedTable, X : DEC : TAY

    JSL DecompOwAnimatedTiles       ; $5394 IN ROM
    JSL InitTilesets                ; $619B IN ROM; Decompress all other graphics
    JSR Overworld_LoadAreaPalettes  ; $14692 IN ROM; Load palettes for overworld
        
    LDX.b $8A
        
    LDA.l $7EFD40, X : STA.b $00
        
    LDA.l $00FD1C, X
        
    JSL Overworld_LoadPalettes      ; $755A8 IN ROM; Load some other palettes
    JSL Palette_SetOwBgColor_Long   ; $75618 IN ROM; Sets the background color (changes depending on area)
        
    LDA.b $10 : CMP.b #$08 : BNE .specialArea2
        ; $1465F IN ROM; Copies $7EC300[0x200] to $7EC500[0x200]
        JSR $C65F
        
        BRA .normalArea2
    
    .specialArea2
    
    ; apparently special overworld handles palettes a bit differently?
    JSR $C6EB ; $146EB IN ROM
    
    .normalArea2
    
    JSL $0BFE70 ; $5FE70 IN ROM; Sets fixed colors and scroll values
        
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
        JSL Sprite_ReinitWarpVortex ; $4AF89 IN ROM
    
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
    JSR $8B0C ; $10B0C IN ROM
        
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
    JSR Overworld_LoadAreaPalettes  ; $14692 IN ROM ; Load Palettes
        
    PLA : STA.b $00
        
    LDX.b $8A
        
    LDA.l $00FD1C, X
        
    JSL Overworld_LoadPalettes ; $755A8 IN ROM
        
    LDA.b #$01 : STA.w $0AB2
        
    JSL Palette_Hud ; $DEE52 IN ROM
        
    LDA.l $11 : BNE .BRANCH_4
        JSL CopyFontToVram  ; $6556 IN ROM
    
    .BRANCH_4
    
    JSR $C65F   ; $1465F IN ROM
    JSL $0BFE70 ; $5FE70 IN ROM
        
    LDA.l $8A : CMP.b #$80 : BCC .BRANCH_5
        JSL Palette_SetOwBgColor_Long ; $75618 IN ROM
    
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
    
    SEP #$30
        
    RTS
}
warnpc $029AD3

endif

; ==============================================================================

if !Func02AF58 = 1

; TODO: If something is broken, its probably here, this function is scuffed.
; Main subscreen overlay loading function. Changed so that they will load from a table.
; This does not change the event overlays like the lost woods changing to the tree canopy or the misery mire rain.
; This also does not change the overlay for under the bridge because it shares an area with the master sword.
org $02AF58 ; $012F58
{
    ; $0182 is the exit room number used for getting to Zora's Domain.
    LDA.b $A0 : CMP.w #$0182 : BNE .notZoraFalls   
        SEP #$20

        ; Play rain (waterfall) sound.
        LDA.b #$01 : STA.w $012D

        REP #$20

    .notZoraFalls

    ; TODO: Because of the 16 bit LDA $8A, the high byte of A should stay 00 which helps later when loading from the table but double check this by stepping through.

    ; Check to see if we are in a SW overworld area.
    LDA.b $8A : CMP.w #$0080 : BCC .notExtendedArea
        ; Check for exit rooms (the faked way of getting from one overworld area to another).
        ; $0180 is the exit room number used for getting into the mastersword area.
        LDA.b $A0 : CMP.w #$0180 : BNE .notMasterSwordArea
            ; If the Master sword is retrieved, don't do the mist overlay.
            LDA.l $7EF300, X : AND.w #$0040 : BNE .noSubscreenOverlay ; TODO: Write a patch to change what overlay is loaded here?
                .loadOverlayShortcut

                LDA.b $8A : ASL : TAX
                LDA.l Pool_OverlayTable, X : TAX

                JMP .loadSubScreenOverlay
    
        .notMasterSwordArea
    
        ; $0189 is the exit room number used for getting to the Triforce room? TODO: Confirm this.
        CMP.w #$0189 : BEQ .loadOverlayShortcut
            ; The second mastersword/under the bridge area.
            LDX.w #$0094

            ; $0181 is the exit room number used for getting into the under the bridge area.
            LDA.b $A0 : CMP.w #$0181 : BEQ .loadOverlayShortcut
                .noSubscreenOverlay
                    
                SEP #$30
                    
                STZ $1D
                        
                INC $11
                        
                RTS
    
    .notExtendedArea

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X : TAX
    
    LDA.b $8A : BNE .notForest
        ; Check if we have the master sword.
        LDA.l $7EF300 : AND.w #$0040 : BEQ .loadSubScreenOverlay
            ; TODO: Write a patch to change this?
            ; The forest canopy overlay
            LDX.w #$009E
            
            BRA .loadSubScreenOverlay
    
    .notForest

    ; Check if we need to disable the rain in the misery mire
    LDA.b $8A : CMP.w #$0070 : BNE .notMire
        ; Has Misery Mire been triggered yet?
        LDA.l $7EF2F0 : AND.w #$0020 : BEQ .notMire
            ; The pyramid background
            LDX.w #$0096
        
    .notMire

    ; If the value is 0xFF that means we didn't set any overlay so load the pyramid one by default.
    CPX.w #$00FF : BNE .notFF
        ; The pyramid background
        LDX.w #$0096

    .notFF
    
    ; Check if we are in the beginning phase, if not, no rain.
    ; If $7EF3C5 >= 0x02
    LDA.l $7EF3C5 : AND.w #$00FF : CMP.w #$0002 : BCS .loadSubScreenOverlay
        .makeItRain
    
        ; The rain overlay
        LDX.w #$009F
    
    ; *$1300B ALTERNATE ENTRY POINT ; TODO: Verify this. If it is an alternate entry I can't find where it is reference anywhere.
    .loadSubScreenOverlay
    STY.b $84
        
    STX.b $8A : STX $8C
        
    LDA.b $84 : SEC : SBC.w #$0400 : AND.w #$0F80 : ASL A : XBA : STA.b $88
        
    LDA.b $84 : SEC : SBC.w #$0010 : AND.w #$003E : LSR A : STA.b $86
        
    STZ $0418 : STZ $0410 : STZ $0416
        
    SEP #$30
        
    ; Color +/- buffered register.
    LDA.b #$82 : STA.b $99
        
    ; Puts OBJ, BG2, and BG3 on the main screen
    LDA.b #$16 : STA.b $1C
        
    ; Puts BG1 on the subscreen
    LDA.b #$01 : STA.b $1D
        
    ; Save X for uno momento.
    PHX
        
    ; Set the ambient sound effect
    LDX.b $8A : LDA.l $7F5B00, X : LSR #4 : STA.w $012D
        
    PLX 
        
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
        
        CPX.b #$95 : BEQ .loadOverlay
        CPX.b #$9C : BEQ .loadOverlay
            LDA.l $7EC213 : TAX
        
            LDA.b #$20
        
            CPX.b #$5B : BEQ .loadOverlay
            CPX.b #$1B : BNE .disableSubscreen
                LDX.b $11
        
                CPX.b #$23 : BEQ .loadOverlay
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
    
    REP #$20
        
    ; We were pretending to be in a different area to load the subscreen
    ; overlay, so we're restoring all those settings.
    LDA.l $7EC213 : STA.b $8A
    LDA.l $7EC215 : STA.b $84
    LDA.l $7EC217 : STA.b $88
    LDA.l $7EC219 : STA.b $86
        
    LDA.l $7EC21B : STA.w $0418
    LDA.l $7EC21D : STA.w $0410
    LDA.l $7EC21F : STA.w $0416
        
    SEP #$20
        
    RTS
}
warnpc $02B0D2

endif

; ==============================================================================

if !Func02B2D4 = 1

; Turns on the subscreen if the pyramid is loaded.
org $02B2D4 ; $132D4
{
    JSR $AF19 ; $012F19 IN ROM

    ; Just because we are a few bytes short.
    JSL EnableSubScreenCheck

    RTL
}
warnpc $02B2E6

endif

pullpc
EnableSubScreenCheck:
{
    REP #$20

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
        
    CMP.w #$0096 : BNE .notPyramidOrCastle
        SEP #$20
        LDA.b #$01 : STA.b $1D
    
    .notPyramidOrCastle

    SEP #$20

    RTL
}
pushpc

; ==============================================================================

if !Func0284DA = 1

; Handles activating the subscreen and special BG color when warping to an area with the pyramid BG.
org $0284DA ; $0104DA
{
    ; Oh look at that we can just use this same function lucky us.
    JSL EnableSubScreenCheck
    
    REP #$20
        
    LDX.b #$00
        
    LDA.w #$7FFF
    
    .setBgPalettesToWhite
        STA.l $7EC540, X : STA.l $7EC560, X : STA.l $7EC580, X
        STA.l $7EC5A0, X : STA.l $7EC5C0, X : STA.l $7EC5E0, X
        
    INX #2 : CPX.b #$20 : BNE .setBgPalettesToWhite
        
    ; Also set the background color to white
    STA.l $7EC500

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
        
    CMP.w #$0096 : BNE .notPyramidOfPower
        LDA.w #$0000 : STA.l $7EC500 : STA.l $7EC540
    
    .notPyramidOfPower
    
    SEP #$20
        
    JSL Sprite_ResetAll
    JSL Sprite_OverworldReloadAll
    JSL $07B107 ; $3B107 IN ROM
    JSR $8B0C   ; $10B0C IN ROM
        
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
        LDA.w #$0600 : CMP.b $E6 : BCC .BRANCH_NU
            STA.b $E6
    
        .BRANCH_NU
    
        LDA.w #$06C0 : CMP.b $E6 : BCS .BRANCH_IOTA
            STA.b $E6
    
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

ReadOverlayArray2:
{
    REP #$10

    LDA.b $8A : ASL : TAX
    LDA.l Pool_OverlayTable, X
    TAY

    SEP #$10

    RTL
}
pushpc

; ==============================================================================

if !Func02C02D = 1

; Changes how the pyramid BG scrolls.
org $02C02D ; $01402D
{
    PHA
    JSL ReadOverlayArray2
    PLA
    
    ; TODO: figure out this garbage, in vanilla its a BEQ but BEQ doesn't work here for some reason.
    CPY.b #$96 : BNE .dontMoveBg1  
        STA.b $E0, X
    
    .dontMoveBg1
}
warnpc $02C039

endif

; ==============================================================================

if !Func02C692 = 1

; Replaces a call to a shared function. Normally this is goes to .lightworld to change the main color palette manually but we change it here so that it just uses the same table as everything else.
org $02A07A ; $01207A
    JSR Overworld_LoadAreaPalettes

; The main overworld palette loading routine un-hardcoded to load the custom main palette.
org $02C692 ; $14692
Overworld_LoadAreaPalettes:
{
    LDX.b $8A
    LDA.l Pool_MainPaletteTable, X 
    
    ; $0AB3 = 0 - LW 1 - DW, 2 - LW death mountain, 3 - DW death mountain, 4 - triforce room
    STA.w $0AB3
        
    STZ $0AA9
        
    JSL Palette_MainSpr         ; $DEC9E IN ROM; load SP1 through SP4
    JSL Palette_MiscSpr         ; $DED6E IN ROM; load SP0 (2nd half) and SP6 (2nd half)
    JSL Palette_SpriteAux1      ; $DECC5 IN ROM; load SP5 (1st half)
    JSL Palette_SpriteAux2      ; $DECE4 IN ROM; load SP6 (1st half)
    JSL Palette_Sword           ; $DED03 IN ROM; load SP5 (2nd half, 1st 3 colors), which is the sword palette
    JSL Palette_Shield          ; $DED29 IN ROM; load SP5 (2nd half, next 4 colors), which is the shield
    JSL Palette_ArmorAndGloves  ; $DEDF9 IN ROM; load SP7 (full) Link's whole palette, including Armor
        
    LDX.b #$01
        
    ; Changes the Palette_SpriteAux3 load depending on if we are in the LW or not. Will probably need it own custom table? not sure.
    LDA.l $7EF3CA : AND.b #$40 : BEQ .lightWorld2
        LDX.b #$03
    
    .lightWorld2
    
    STX.w $0AAC
        
    JSL Palette_SpriteAux3      ; $DEC77 IN ROM; load SP0 (first half) (or SP7 (first half))
    JSL Palette_Hud             ; $DEE52 IN ROM; load BP0 and BP1 (first halves)
    JSL Palette_OverworldBgMain ; $DEEC7 IN ROM; load BP2 through BP5 (first halves)
        
    RTS
}
warnpc $02C6EB

endif

; ==============================================================================

if !Func02AADB = 1

; Main Mosaic Hook. Changes it to use a table instead of hardcoded to the woods areas.
org $02AADB ; $012ADB
    JML MosaicAreaCheck

endif

pullpc
MosaicAreaCheck:
{
    PHB : PHK : PLB

    TAX
    LDA.w Pool_MosaicTable, X

    BEQ .noMosaic1
        PLB
        JML $02AAE5

    .noMosaic1

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

endif

; Loads the animated tiles after most of the transition gfx changes take place
pullpc
CheckForChangeGraphicsTransitionLoad:
{
    PHB : PHK : PLB
    
    LDA.w Pool_EnableAnimated : BEQ .dontUpdate
        ; Check to see if we need to update the animated tiles by checking what was previously loaded.
        LDX.b $8A
        LDA.w Pool_AnimatedTable, X : CMP.w AnimatedTileGFXSet : BEQ .dontUpdate
            STA.w AnimatedTileGFXSet : DEC : TAY

            JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.

    .dontUpdate

    LDA.w Pool_EnableMainPalette  : BEQ .dontUpdate2
        ; Check to see if we need to update the main palette by checking what was previously loaded.
        LDX.b $8A
        LDA.w Pool_MainPaletteTable, X : CMP.w $0AB3 : BEQ .dontUpdate2
            STA.w $0AB3

            JSL Palette_OverworldBgMain

    .dontUpdate2

    LDA.b #$09 ; Replaced code.

    PLB
        
    JML Overworld_FinishTransGfx_firstHalf
}
pushpc

; ==============================================================================

if !Func0ABC5A = 1

org $0ABC5A ; $053C5A
    JSL CheckForChangeGraphicsNormalLoad

endif

; Loads the animated tiles after the overworld map is closed.
pullpc
CheckForChangeGraphicsNormalLoad:
{
    PHB : PHK : PLB

    JSL InitTilesets ; Replaced code.

    LDA.w Pool_EnableAnimated : BEQ .dontUpdate
        LDX.b $8A
        LDA.w Pool_AnimatedTable, X : STA.w AnimatedTileGFXSet : DEC : TAY

        JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.

    .dontUpdate
        
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
    JSL $0BFE70 ; $5FE70 IN ROM
        
    STZ $0AA9
    STZ $0AB2
        
    JSL InitTilesets
        
    INC $0200
        
    STZ $B2
        
    JSL $02B1F4 ; $131F4 IN ROM
        
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
        
    RTL
}
warnpc $0AB948

endif

; ==============================================================================

if !Func0BFEC6 = 1

; Loads different special transparent colors and overlay speeds based on the overlay during transition and under other certain cases. Exact cases need to be investigated.
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

            SEP #$30
            
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
    
    ; TODO: Check for HC or pyramid.
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
    
    SEP #$20
        
    ; Put BG0 on the subscreen
    LDA.b #$01 : STA.b $1D
        
    SEP #$30
        
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

    SEP #$20 ; Set A in 8bit mode

    LDA.w Pool_EnableBGColor : BNE .custom
        REP #$20 ; Set A in 16bit mode

        PLB

        RTL

    .custom

    REP #$20 ; Set A in 16bit mode

    LDA.b $8A : ASL : TAX ; Get area code and times it by 2
    LDA.w Pool_BGColorTable, X ; Get the color.

    STA.l $7EC300 : STA.l $7EC500 ; Set the BG color 
    STA.l $7EC540 : STA.l $7EC340

    PLB

    RTL
}
pushpc

; ==============================================================================

if !Func0ED627 = 1

; Loads the transparent color under some load conditions such as the mirror warp.
; TODO: Investigate the other conditions.
org $0ED627 ; $075627
    JML IntColorLoad2
    NOP

endif

pullpc
IntColorLoad2:
{
    PHB : PHK : PLB

    SEP #$20 ; Set A in 8bit mode

    LDA.w Pool_EnableBGColor : BNE .custom ; pc 140140 is where ZS saves whether to use the asm or not
        REP #$20 ; Set A in 16bit mode

        LDA.b $8A : CMP.w #$0080 : BCC .notSpecialArea
            PLB
            JML $0ED62E

        .notSpecialArea

        PLB
        JML $0ED644

    .custom

    REP #$20 ; Set A in 16bit mode

    LDA.b $8A : ASL : TAX ; Get area code and times it by 2
    LDA.w Pool_BGColorTable, X ; Get the color.
    TAX

    STA.l $7EC300 ;set transparent color

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
        REP #$30

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
    
    SEP #$30
        
    RTL
}
warnpc $0ED8FB

endif

; ==============================================================================

;A9 00 00 8F 00 C3 7E 8F 40 C3 7E 8F 00 C5 7E 8F 40 C5 7E 6B C2 20 A5 8A 0A AA BF 40 83 28 C9 96 00 D0 06 E2 20 A9 01 85 1D E2 20 6B A5 8A 0A AA BF 40 83 28 6B C2 10 A5 8A 0A AA BF 40 83 28 A8 E2 10 6B 8B 4B AB AA BD 00 82 F0 05 AB 5C E5 AA 02 A6 8A BD 00 82 F0 05 AB 5C E5 AA 02 AB 5C F4 AA 02 8B 4B AB AD 43 81 F0 13

;A6 8A BD A0 82 CD C0
;0F F0 09 8D C0 0F

;3A A8 22 94 D3 00 AD 41 81 F0 11 A6 8A BD 60 81 CD B3 0A F0 07 8D B3 0A 22 C7 EE 1B A9 09 AB 5C BE AB 02 8B 4B AB 22 9B E1 00 AD 43 81 F0 0E

;A6 8A BD A0 82 8D

;C0 0F

;3A A8 22 94 D3 00 AB 6B 8B 4B AB E2 20 AD 40 81 D0 04 C2 20 AB 6B C2 20 A5 8A 0A AA BD 00 80 8F 00 C3 7E 8F 00 C5 7E 8F 40 C5 7E 8F 40 C3 7E AB 6B 8B 4B AB E2 20 AD 40 81 D0 13 C2 20 A5 8A C9 80 00 90 05 AB 5C 2E D6 0E AB 5C 44 D6 0E C2 20 A5 8A 0A AA BD 00 80 AA 8F 00 C3 7E AB 5C 51 D6 0E




;A9 00 00 8F 00 C3 7E 8F 40 C3 7E 8F 00 C5 7E 8F 40 C5 7E 6B C2 20 A5 8A 0A AA BF 40 83 28 C9 96 00 D0 06 E2 20 A9 01 85 1D E2 20 6B A5 8A 0A AA BF 40 83 28 6B C2 10 A5 8A 0A AA BF 40 83 28 A8 E2 10 6B 8B 4B AB AA BD 00 82 F0 05 AB 5C E5 AA 02 A6 8A BD 00 82 F0 05 AB 5C E5 AA 02 AB 5C F4 AA 02 8B 4B AB AD 43 81 F0 15

;A6 8A BD A0 82 CF C0
;0F 00 F0 0A 8F C0 0F 00

;3A A8 22 94 D3 00 AD 41 81 F0 11 A6 8A BD 60 81 CD B3 0A F0 07 8D B3 0A 22 C7 EE 1B A9 09 AB 5C BE AB 02 8B 4B AB 22 9B E1 00 AD 43 81 F0 0F

;A6 8A BD A0 82 8F

;C0 0F 00

;3A A8 22 94 D3 00 AB 6B 8B 4B AB E2 20 AD 40 81 D0 04 C2 20 AB 6B C2 20 A5 8A 0A AA BD 00 80 8F 00 C3 7E 8F 00 C5 7E 8F 40 C5 7E 8F 40 C3 7E AB 6B 8B 4B AB E2 20 AD 40 81 D0 13 C2 20 A5 8A C9 80 00 90 05 AB 5C 2E D6 0E AB 5C 44 D6 0E C2 20 A5 8A 0A AA BD 00 80 AA 8F 00 C3 7E AB 5C 51 D6 0E