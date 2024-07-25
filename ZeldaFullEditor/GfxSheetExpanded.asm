org $0098AB ; freespace in bank00
label:
.offset
dw $0000 ; rods
dw $0108 ; hammer
dw $00C0 ; bow
dw $0390 ; shovel
dw $03F0 ; Zzz ♪
dw $0438 ; powder dust
dw $0330 ; hookshot
dw $0048 ; net
dw $0318 ; cane
dw $0450 ; book

org $00D567
ADC.w .offset, Y




org $00CF46
GFXSheetPointers:
.background_bank
org $00CF46+115
.sprite_bank

org $00CF46+247
.background_high
org $00CF46+362
.sprite_high

org $00CF46+494
.background_low
org $00CF46+609
.sprite_low


org $00D53B
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $02
STA.b $05
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $01
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $00


org $00DA99
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $00
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $01
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $02

org $00E2D8
LDA.w GFXSheetPointers_sprite_bank
STA.b $02
LDA.w GFXSheetPointers_sprite_high
STA.b $01
LDA.w GFXSheetPointers_sprite_low
STA.b $00

org $00E462
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $02
STA.b $05
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $01
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $00

org $00E6BA
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $02
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $01
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $00

org $00E72E
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $02
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $01
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $00

org $00E772
LDA.w GFXSheetPointers_sprite_bank,Y
STA.b $CA
LDA.w GFXSheetPointers_sprite_high,Y
STA.b $C9
LDA.w GFXSheetPointers_sprite_low,Y
STA.b $C8

org $00E78F
LDA.w GFXSheetPointers_background_bank,Y
STA.b $CA
LDA.w GFXSheetPointers_background_high,Y
STA.b $C9
LDA.w GFXSheetPointers_background_low,Y
STA.b $C8