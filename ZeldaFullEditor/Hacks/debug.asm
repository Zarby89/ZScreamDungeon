lorom


!ADD = "CLC : ADC"
!SUB = "SEC : SBC"
!BLT = "BCC"
!BGE = "BCS"

org $09BA2A ;Tile Z
db $50, $60, $70, $80, $90, $A0, $90, $80
db $70, $60, $50, $60, $70, $80, $90, $A0
db $A0, $50, $70, $80, $80, $70, $50, $50
db $50, $50, $50, $50, $60, $70, $80, $90
db $A0, $A0, $A0, $A0, $A0, $A0, $80, $90
db $70, $90, $70, $90

org $09BA21 ;Tile Speed
db #$A0

org $09BA1D ;Tile Count
db #$10

org $0EF7FE
RTS

org $02AE98
NOP #$0B


;Overlay Removed
org $02AE90
db $80
org $02AF76
db $80
org $02AFA6
db $80



;Water Caves Splashes (map 0F)
org $029995
db $80

org $098625 ;Sword Get Hook
NOP #$01 : JSL SwordGetCode

org $268000
SwordGetCode:
{
LDA #$00 : STA $7EF3CC
LDA #$02 : STA $7EF3C5
LDA #$15 : STA $7EF3C6
LDA #$01 : STA [$00]
LDA #$01 : STA $7EF359
JSL $00FC41 ;Update gfx 
RTL
}





