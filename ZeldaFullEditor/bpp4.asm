
org $00E799
JML GfxLoad4bpp

org $00E618
JML DoLeftOrRight
NOP

org $428000
GfxLoad4bpp:
; restore code, we're still in databank 0 so LDA, Y still work
LDA.w $00D13E, Y
STA.b $C8

; Here we check if it's a 4bpp sheet
LDA.b $CA : AND.b #$40 : BEQ .decomp
; do nothing if 4bpp sheet
JML $00E7AC ; jump back on a RTS
.decomp
JML $00E79E



DoLeftOrRight:
LDY.b #$3F
LDX.w $0AA1

LDA.b $CA : AND.w #$0040 : BEQ .not4bpp
REP #$30
; Do vram transfer for 0x800 bytes
LDY.w #$0000
.loopcopy2
LDA.b [$C8], Y ; load from the ROM directly
STA.w $2118 ; store in vram
INY : INY
CPY.w #$0800 : BCC .loopcopy2

SEP #$30

JML $00E6B6 ; go back to a RTS
.not4bpp
JML $00E61D



org $00CF80+$3A ; bank
db sheet3A>>16
org $00D05F+$3A ; high
db sheet3A>>8
org $00D13E+$3A ; low
db sheet3A


org $00CF80+$3B ; bank
db sheet3B>>16
org $00D05F+$3B ; high
db sheet3B>>8
org $00D13E+$3B ; low
db sheet3B

org $00CF80+$4A ; bank
db sheet4A>>16
org $00D05F+$4A ; high
db sheet4A>>8
org $00D13E+$4A ; low
db sheet4A

org $408000
sheet3A:
incbin alttp.4bpp

sheet3B:
incbin test2.4bpp

sheet4A:
incbin test3.4bpp
