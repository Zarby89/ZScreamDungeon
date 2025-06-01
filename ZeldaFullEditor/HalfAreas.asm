; ==============================================================================
; ZScream Half Overworld areas
; Written by Jared_Brian_
; ==============================================================================
; Debug addresses:
; ==============================================================================

pushpc

; If 1, all of the default vanilla pool values will be applied. 00 by default.
!UseVanillaPool = $00

; $02A62C
!Func02A62C = $01

; $02AB64
!Func02AB64 = $01

; $02C0C3
!Func02C0C3 = $01

; $02E598
!Func02E598 = $01

; $09C4C7
!Func09C4C7 = $01

; $02AC40
!Func02AC40 = $01

; Use this var to disable all of the debug vars above.
!AllOff = $00

if !AllOff == 1
!Func02A62C = $00
!Func02AB64 = $00
!Func02C0C3 = $00
!Func02E598 = $00
!Func09C4C7 = $00
!Func02AC40 = $00
endif

; NOTE: This is fitting into the same bank as the ZS OW ASM and may need to be
; moved later if the ZS OW ASM changes.
org $28A000 ; $142000

pushpc

; This tells the game what each area's "parent" area is. For small areas this
; is it's own area number. For large areas this is the top left area in the
; 2x2 grid.
org $02A5EC ; $0125EC
Overworld_ActualScreenID:
{
    if !UseVanillaPool > 0
    db $00, $00, $02, $03, $03, $05, $05, $07
    db $00, $00, $0A, $03, $03, $05, $05, $0F
    db $10, $11, $12, $13, $14, $15, $16, $17
    db $18, $18, $1A, $1B, $1B, $1D, $1E, $1E
    db $18, $18, $22, $1B, $1B, $25, $1E, $1E
    db $28, $29, $2A, $2B, $2C, $2D, $2E, $2F
    db $30, $30, $32, $33, $34, $35, $35, $37
    db $30, $30, $3A, $3B, $3C, $35, $35, $3F
    endif
}

org $02A62C ; $01262C
OverworldScreenTileMapChange:
{
    ; These mask values are changed to fix several vanilla issues surrounding
    ; large areas. Moving from one large area to another twords the center of
    ; the side would cause a broken transition. A large area next to another
    ; but offset by the length of another would also cause a broken transition.
    ; $01262C
    .Masks
    if !Func02A62C == 1
    dw $1F80, $1F80, $007F, $007F
    else
    dw $0F80, $0F80, $003F, $003F
    endif

    ; Examples:
    ; These work in vanilla: │ These do not:
    ; ───────────────────────┼───────────────
    ; ┌──┬──┐   ┌──┬──┐      │ ┌──┬──┐   ┌──┬──┐
    ; │  │  │<->│  │  │      │ │  │  │   │  │  │
    ; ├──┼──┤   ├──┼──┤      │ ├──┼──┤<->├──┼──┤
    ; │  │  │<->│  │  │      │ │  │  │   │  │  │
    ; └──┴──┘   └──┴──┘      │ └──┴──┘   └──┴──┘
    ; ┌──┬──┐                │ ┌──┬──┐
    ; │  │  │                │ │  │  │
    ; ├──┼──┤                │ ├──┼──┤
    ; │  │  │                │ │  │  │
    ; └──┴──┘                │ └──┴──┘
    ;  ↕   ↕                 │    ↕
    ; ┌──┬──┐                │ ┌──┬──┐
    ; │  │  │                │ │  │  │
    ; ├──┼──┤                │ ├──┼──┤
    ; │  │  │                │ │  │  │
    ; └──┴──┘                │ └──┴──┘
    ; See the layout of Zelda: Interconnected Strongholds.
    ; 
    ; None of these work in vanilla:
    ; ┌──┬──┐                          ┌──┬──┐
    ; │  │  │                          │  │  │
    ; ├──┼──┤   ┌──┬──┐      ┌──┬──┐   ├──┼──┤
    ; │  │  │<->│  │  │      │  │  │<->│  │  │
    ; └──┴──┘   ├──┼──┤      ├──┼──┤   └──┴──┘
    ;           │  │  │      │  │  │
    ;           └──┴──┘      └──┴──┘
    ; ┌──┬──┐                    ┌──┬──┐
    ; │  │  │                    │  │  │
    ; ├──┼──┤                    ├──┼──┤
    ; │  │  │                    │  │  │
    ; └──┴──┘                    └──┴──┘
    ;      ↕                      ↕
    ;    ┌──┬──┐             ┌──┬──┐
    ;    │  │  │             │  │  │
    ;    ├──┼──┤             ├──┼──┤
    ;    │  │  │             │  │  │
    ;    └──┴──┘             └──┴──┘
    ; As of 05/13/25 there arn't any released hacks that use this kind of layout.

    ; These values or for the area you are going to, not the one coming from.

    .ByScreen1 ; $012634 Transitioning right
    if !UseVanillaPool > 0
    dw $0060, $0060, $0060, $0060, $0060, $0060, $0060, $0060
    dw $0060, $0060, $F060, $1060, $1060, $0060, $1060, $F060
    dw $0060, $0060, $0060, $0060, $0060, $0060, $0060, $0060
    dw $0060, $0060, $0060, $0060, $0060, $0060, $0060, $0060
    dw $0060, $0060, $F060, $1060, $1060, $F060, $1060, $1060
    dw $0060, $0060, $0060, $0060, $0060, $0060, $0060, $0060
    dw $0060, $0060, $0060, $0060, $0060, $0060, $0060, $0060
    dw $0060, $0060, $F060, $0060, $0060, $1060, $1060, $F060
    endif

    .ByScreen2 ; $0126B4 Transitioning left
    if !UseVanillaPool > 0
    dw $0080, $0080, $0040, $0080, $0080, $0080, $0080, $0040
    dw $1080, $1080, $F040, $1080, $0080, $1080, $1080, $0040
    dw $0040, $0040, $0040, $0040, $0040, $0040, $0040, $0040
    dw $0080, $0080, $0040, $0080, $0080, $0040, $0080, $F080
    dw $1080, $1080, $F040, $1080, $1080, $F040, $1080, $1080
    dw $0040, $0040, $0040, $0040, $0040, $0040, $0040, $0040
    dw $0080, $0080, $0040, $0040, $0040, $0080, $0080, $0040
    dw $1080, $1080, $0040, $0040, $F040, $1080, $1080, $0040
    endif

    .ByScreen3 ; $012734 Transitioning down
    if !UseVanillaPool > 0
    dw $1800, $1840, $1800, $1800, $1840, $1800, $1840, $1800
    dw $1800, $1840, $1800, $1800, $1840, $1800, $1840, $1800
    dw $1800, $17C0, $1800, $1800, $17C0, $1800, $17C0, $1800
    dw $1800, $1840, $1800, $1800, $1840, $1800, $1800, $1840
    dw $1800, $1840, $1800, $1800, $1840, $1800, $1800, $1840
    dw $1800, $17C0, $1800, $1800, $17C0, $1800, $1800, $17C0
    dw $1800, $1840, $1800, $1800, $1800, $1800, $1840, $1800
    dw $1800, $1840, $1800, $1800, $1800, $1800, $1840, $1800
    endif

    .ByScreen4 ; $0127B4 Transitioning up
    if !UseVanillaPool > 0
    dw $2000, $2040, $1000, $2000, $2040, $2000, $2040, $1000
    dw $2000, $2040, $1000, $2000, $2040, $2000, $2040, $1000
    dw $1000, $0FC0, $1000, $1000, $0FC0, $1000, $1000, $0FC0
    dw $2000, $2040, $1000, $2000, $2040, $1000, $2000, $2040
    dw $2000, $2040, $1000, $2000, $2040, $1000, $2000, $2040
    dw $1000, $0FC0, $1000, $1000, $1000, $1000, $0FC0, $1000
    dw $2000, $2040, $1000, $1000, $1000, $2000, $2040, $1000
    dw $2000, $2040, $1000, $1000, $1000, $2000, $2040, $1000
    endif
}

; ==============================================================================
; Expanded Space
; ==============================================================================

if !Func02AB64 == 1

; Replaces an old $0712 check in Overworld_LoadMapProperties.
org $02AB64 ; $012B64
    JML.l AreaSizeCheck
    NOP : NOP

else

org $02AB64 ; $012B64
db $A9, $F0, $03, $AE, $12, $07

endif

org $02AB78 ; $012B78
AreaSizeCheckReturn:

pullpc

AreaSizeCheck:
{
    PHB : PHK : PLB

    LDX.b $8A
    LDA.l Pool_BufferAndBuildMap16Stripes_overworldScreenSize, X
    AND.w #$00FF : ASL : TAX

    LDA.w .YSize, X : STA.w $070A
    LDA.w .XSize, X : STA.w $070E

    PLB

    JML.l AreaSizeCheckReturn

    ;  Large, Small,  Wide,  Tall
    .YSize
    dw $01F0, $03F0, $01F0, $03F0

    .XSize
    dw $003E, $007E, $007E, $003E
}

pushpc

; ==============================================================================

; This section changes how all of the camera values get set.

; The $0712 check at $02C08E just above Overworld_SetCameraBounds is now unused.
; The $0712 check at $02E5AA is made obsolete by Overworld_SetCameraBounds

if !Func02C0C3 == $01

org $02C0C3 ; $0140C3
    JSL.l NewOverworld_SetCameraBounds
    RTS

else

org $02C0C3 ; $0140C3
db $B9, $C4, $A8, $8D, $00

endif

; Gets stored into $0708.
org $02A8C4 ; $0128C4
OverworldTransitionPositionY:
{
    ;dw $0000, $0000, $0000, $0000, $0000, $0000, $0000, $0000
    ;dw $0000, $0000, $0200, $0000, $0000, $0000, $0000, $0200
    ;dw $0400, $0400, $0400, $0400, $0400, $0400, $0400, $0400
    ;dw $0600, $0600, $0600, $0600, $0600, $0600, $0600, $0600
    ;dw $0600, $0600, $0800, $0600, $0600, $0800, $0600, $0600
    ;dw $0A00, $0A00, $0A00, $0A00, $0A00, $0A00, $0A00, $0A00
    ;dw $0C00, $0C00, $0C00, $0C00, $0C00, $0C00, $0C00, $0C00
    ;dw $0C00, $0C00, $0E00, $0E00, $0E00, $0C00, $0C00, $0E00
}

; Gets stored into $070C.
org $02A944 ; $012944
OverworldTransitionPositionX:
{
    ;dw $0000, $0000, $0400, $0600, $0600, $0A00, $0A00, $0E00
    ;dw $0000, $0000, $0400, $0600, $0600, $0A00, $0A00, $0E00
    ;dw $0000, $0200, $0400, $0600, $0800, $0A00, $0C00, $0E00
    ;dw $0000, 00000, $0400, $0600, $0600, $0A00, $0C00, $0C00
    ;dw $0000, $0000, $0400, $0600, $0600, $0A00, $0C00, $0C00
    ;dw $0000, $0200, $0400, $0600, $0600, $0A00, $0C00, $0E00 ; Value changed.
    ;dw $0000, $0000, $0400, $0600, $0800, $0A00, $0A00, $0E00
    ;dw $0000, $0000, $0400, $0600, $0800, $0A00, $0A00, $0E00
}

org $02BEE2 ; $013EE2
Pool_Overworld_SetCameraBounds:
{
    ; $013EE2
    .trans_target_north
    ;dw $FF20, $FF20, $FF20, $FF20, $FF20, $FF20, $FF20, $FF20
    ;dw $FF20, $FF20, $0120, $FF20, $FF20, $FF20, $FF20, $0120
    ;dw $0320, $0320, $0320, $0320, $0320, $0320, $0320, $0320
    ;dw $0520, $0520, $0520, $0520, $0520, $0520, $0520, $0520
    ;dw $0520, $0520, $0720, $0520, $0520, $0720, $0520, $0520
    ;dw $0920, $0920, $0920, $0920, $0920, $0920, $0920, $0920
    ;dw $0B20, $0B20, $0B20, $0B20, $0B20, $0B20, $0B20, $0B20
    ;dw $0B20, $0B20, $0D20, $0D20, $0D20, $0B20, $0B20, $0D20

    org $02BF62 ; $013F62
    .trans_target_west
    ;dw $FF00, $FF00, $0300, $0500, $0500, $0900, $0900, $0D00
    ;dw $FF00, $FF00, $0300, $0500, $0500, $0900, $0900, $0D00
    ;dw $FF00, $0100, $0300, $0500, $0700, $0900, $0B00, $0D00
    ;dw $FF00, $FF00, $0300, $0500, $0500, $0900, $0B00, $0B00
    ;dw $FF00, $FF00, $0300, $0500, $0500, $0900, $0B00, $0B00
    ;dw $FF00, $0100, $0300, $0500, $0500, $0900, $0B00, $0D00 ; Value changed.
    ;dw $FF00, $FF00, $0300, $0500, $0700, $0900, $0900, $0D00
    ;dw $FF00, $FF00, $0300, $0500, $0700, $0900, $0900, $0D00
}

pullpc

NewOverworld_SetCameraBounds:
{
    PHB : PHK : PLB

    LDX.b $8A
    LDA.l Pool_BufferAndBuildMap16Stripes_overworldScreenSize, X : ASL

    TYX : TAY

    LDA.l OverworldTransitionPositionY, X
    STA.w $0600

    CLC : ADC.w .boundary_y_size, Y
    STA.w $0602
    
    LDA.l OverworldTransitionPositionX, X
    STA.w $0604

    CLC : ADC.w .boundary_x_size, Y
    STA.w $0606

    LDA.l Pool_Overworld_SetCameraBounds_trans_target_north, X
    STA.w $0610

    CLC : ADC.w .trans_target_south_offset, Y
    STA.w $0612

    LDA.l Pool_Overworld_SetCameraBounds_trans_target_west, X
    STA.w $0614

    CLC : ADC.w .trans_target_east_offset, Y
    STA.w $0616

    TYA : TXY : TAX

    PLB

    RTL

    ;  Small, Large,  Wide,  Tall
    .boundary_y_size
    dw $011E, $031E, $011E, $031E

    .boundary_x_size
    dw $0100, $0300, $0300, $0100

    .trans_target_south_offset
    dw $02E0, $04E0, $02E0, $04E0

    .trans_target_east_offset
    dw $0300, $0500, $0500, $0300
}

pushpc

; ==============================================================================

; This changes how OverworldScreenSizeHighByte is used. Using $0718 which is
; free RAM to be the new X boundary check.

; This old purpose table no longer matters, the values themeselves don't
; reflect any actual data and its uses have been removed. Instead this space
; is unused.
org $02A844 ; $012844
OverworldScreenSizeFlag:
{
    ; 0x00 - Small map
    ; 0x20 - Large map
    ; db $20, $20, $00, $20, $20, $20, $20, $00
    ; db $20, $20, $00, $20, $20, $20, $20, $00
    ; db $00, $00, $00, $00, $00, $00, $00, $00
    ; db $20, $20, $00, $20, $20, $00, $20, $20
    ; db $20, $20, $00, $20, $20, $00, $20, $20
    ; db $00, $00, $00, $00, $00, $00, $00, $00
    ; db $20, $20, $00, $00, $00, $20, $20, $00
    ; db $20, $20, $00, $00, $00, $20, $20, $00
}

; This table is now unused for the same reason as OverworldScreenSizeFlag.
org $02A884 ; $012884
OverworldScreenSizeHighByte:
{
    ; 0x01 - Small map
    ; 0x03 - Large map
    ; db $03, $03, $01, $03, $03, $03, $03, $01
    ; db $03, $03, $01, $03, $03, $03, $03, $01
    ; db $01, $01, $01, $01, $01, $01, $01, $01
    ; db $03, $03, $01, $03, $03, $01, $03, $03
    ; db $03, $03, $01, $03, $03, $01, $03, $03
    ; db $01, $01, $01, $01, $01, $01, $01, $01
    ; db $03, $03, $01, $01, $01, $03, $03, $01
    ; db $03, $03, $01, $01, $01, $03, $03, $01
}

if !Func02E598 == $01

org $02E598 ; $016598
    JSL.l Copy0716
    NOP

org $02EADC ; $016ADC
    JSL.l Copy0716
    NOP

; Change the transition check to use the X value.
org $02A9FF ; $0129FF
    LDA.w $0718

; Change a hookshot check to use the X value.
org $08FA76 ; $047A76
    CMP.w $0718

; Change an old OverworldScreenSizeFlag use to set the X value instead.
org $02AB1B ; $012B1B
Overworld_LoadMapPropertiesInterupt:
{
    ; Code from vanilla that is still needed.
    LDA.w $0712 : STA.w $0714

    LDA.l Pool_BufferAndBuildMap16Stripes_overworldScreenSize, X : TAX
    JML.l LoadNewOverworldScreenSize

    ; These will be skipped over.
    NOP : NOP : NOP : NOP 
    NOP : NOP : NOP : NOP
    NOP

    .skip
}
warnpc $02AB33 ; $012B33

else

org $02E598 ; $016598
db $A9, $E4, $8D, $16, $07

org $02EADC ; $016ADC
db $A9, $E4, $8D, $16, $07

org $02A9FF ; $0129FF
db $AD, $16, $07

org $08FA76 ; $047A76
db $CD, $16, $07

org $02AB1B ; $012B1B
db $8A, $29, $3F, $AA, $AD, $12, $07, $8D
db $14, $07, $BF, $44, $A8, $02, $8D, $12
db $07, $BF, $84, $A8, $02, $8D, $17, $07

endif

pullpc

Copy0716:
{
    LDA.b #$E4 : STA.w $0716 : STA.w $0718

    RTL
}

LoadNewOverworldScreenSize:
{
    PHB : PHK : PLB

    LDA.w .xSize, X : STA.w $0719
    LDA.w .ySize, X : STA.w $0717

    PLB

    JML.l Overworld_LoadMapPropertiesInterupt_skip

    ; 0x01 - Small map
    ; 0x03 - Large map
    .xSize
    db $01, $03, $03, $01

    .ySize
    db $01, $03, $01, $03
}

pushpc

; ==============================================================================

; This if for controlling the boundaries used by sprites to check if they should
; be loaded. This is now unused in favor of just getting a value based on the 
; size of the area. This space can be used for expansion later.
org $09C635 ; $04C635
OverworldScreenSizeForLoading:
{
    ; LW
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02

    ; DW
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02

    ; SW
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $04, $04, $02, $04, $04, $04, $04, $02
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $04, $04, $02, $04, $04, $02, $04, $04
    ;db $02, $02, $02, $02, $02, $02, $02, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02
    ;db $04, $04, $02, $02, $02, $04, $04, $02
}

if !Func09C4C7 == $01

org $09C4C7 ; $04C4C7
LoadOverworldSpritesInterupt:
{
    LDX.w $040A
    LDA.l Pool_BufferAndBuildMap16Stripes_overworldScreenSize, X : TAY

    JML.l GetSpriteLoadingAreaSize

    ; These will be skipped over.
    NOP : NOP : NOP : NOP 
    NOP : NOP : NOP
    .skip
}
warnpc $09C4DA ; $04C4DA

else 

org $09C4C7 ; $04C4C7
db $AD, $0A, $04, $A8, $BE, $35, $C6, $8E
db $B9, $0F, $9C, $B8, $0F, $8E, $BB, $0F
db $9C, $BA, $0F

endif

pullpc

GetSpriteLoadingAreaSize:
{
    PHB : PHK : PLB

    LDX.w .xSize, Y : STX.w $0FB9 : STZ.w $0FB8 
    LDX.w .ySize, Y : STX.w $0FBB : STZ.w $0FBA

    PLB

    JML.l LoadOverworldSpritesInterupt_skip

    .xSize
    db $02, $04, $04, $02

    .ySize
    db $02, $04, $02, $04
}

pushpc

; ==============================================================================

; This is the new truth table as to what each area's size is.
org $02F88D ; $01788D
Pool_BufferAndBuildMap16Stripes_overworldScreenSize:
{
    ; The large area value and small area values were swapped.
    ; 0x00 was large before and 0x01 was small.

    ; 0x00 - Small area (1x1)
    ; 0x01 - Large area (2x2)
    ; 0x02 - Wide area (2x1)
    ; 0x03 - Tall area (1x2)

    if !UseVanillaPool > 0
    ; LW
    db $01, $01, $00, $01, $01, $01, $01, $00
    db $01, $01, $00, $01, $01, $01, $01, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $01, $01, $00, $01, $01, $00, $01, $01
    db $01, $01, $00, $01, $01, $00, $01, $01
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $01, $01, $00, $00, $00, $01, $01, $00
    db $01, $01, $00, $00, $00, $01, $01, $00

    ; DW
    db $01, $01, $00, $01, $01, $01, $01, $00
    db $01, $01, $00, $01, $01, $01, $01, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $01, $01, $00, $01, $01, $00, $01, $01
    db $01, $01, $00, $01, $01, $00, $01, $01
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $01, $01, $00, $00, $00, $01, $01, $00
    db $01, $01, $00, $00, $00, $01, $01, $00

    ; SW
    db $00, $01, $01, $00, $00, $00, $00, $00
    db $00, $01, $01, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    db $00, $00, $00, $00, $00, $00, $00, $00
    endif
}

if !Func02AC40 == $01

; Change a bunch of Pool_BufferAndBuildMap16Stripes_overworldScreenSize checks
; from a BEQ to a BNE.
org $02AC40 ; $012C40
    db $D0

org $02AC70 ; $012C70
    db $D0

org $02B2FA ; $0132FA
    db $D0

org $02B356 ; $013356
    db $D0

org $02ED39 ; $016D39
    db $D0

org $02ED6D ; $016D6D
    db $D0

; Change a bunch of Pool_BufferAndBuildMap16Stripes_overworldScreenSize checks
; from a BNE to a BEQ.

org $02F039 ; $017039
    db $F0

org $02F2EF ; $0172EF
    db $F0

org $02F323 ; $017323
    db $F0

org $02F361 ; $017361
    db $F0

org $02F39B ; $01739B
    db $F0

else

org $02AC40 ; $012C40
    db $F0

org $02AC70 ; $012C70
    db $F0

org $02B2FA ; $0132FA
    db $F0

org $02B356 ; $013356
    db $F0

org $02ED39 ; $016D39
    db $F0

org $02ED6D ; $016D6D
    db $F0

org $02F039 ; $017039
    db $D0

org $02F2EF ; $0172EF
    db $D0

org $02F323 ; $017323
    db $D0

org $02F361 ; $017361
    db $D0

org $02F39B ; $01739B
    db $D0

endif

; ==============================================================================

; TODO: Check HandleEdgeTransition_AdjustCameraBounds for possible needed changes.
; Currently I don't think anything is needed here.

; ==============================================================================

; NOTE: A second pullpc is needed here just in case someone incorperates this
; ASM into their own code base.

pullpc
pullpc
