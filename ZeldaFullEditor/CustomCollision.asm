;Custom dungeon collision code
;mostly written by kan
;put together by Jared_Brian_
;meant to be used with the ZScream collision editor
;12-18-2021

; Format:
; dw <offset> : db width, height
; dw <tile data>, ...
;
; if <offset> == $F0F0, start doing single tiles
; format:
; dw <offset> : db <data>
;
; if <offset> == $FFFF, stop

RoomPointer = $258090

org $01B95B ; restored code from previous version overwritten
db $A5, $B4, $C9, $00, $20, $D0, $03, $EE, $00, $02

org $01B986
	JSL CustomRoomCollision
	NOP #$01
org $258000
CustomRoomCollision_easyout:
{
	PLP
	LDA.w #$3030 : STA $00
	RTL
}

CustomRoomCollision:
{
	PHP
	LDA $B4 : CMP.w #$2000 : BNE .notEndOfTable
        
        INC $0200
    
    .notEndOfTable

	REP #$30
	LDA.b $A0
	ASL
	ADC.b $A0
	TAX
	LDA.l RoomPointer, X
	BEQ .easyout

	STA.b $08

	LDA.l RoomPointer+1, X
	STA.b $09

	PHB

	PEA.w $7F7F
	PLB
	PLB

	LDY.w #$0000

.read_next
	LDA.b [$08],Y
	INY
	INY
	CMP.w #$F0F0
	BCC .new_rectangle

.single_tiles
	CMP.w #$FFFF
	BEQ .done

	TAX

	SEP #$20
	LDA.b [$08],Y
	STA.w $2000,X
	REP #$20
	INY
	LDA.b [$08],Y
	INY
	INY
	BRA .single_tiles

.done
	PLB
	PLP
	LDA.w #$3030 : STA $00
	RTL

.new_rectangle
	STA.b $02 ; beginning of row

	LDA.b [$08],Y ; number of rows and columns
	STA.b $06

	INY
	INY

.next_row
	REP #$21
	LDA.b $02
	TAX
	ADC.w #64
	STA.b $02

	SEP #$20
	LDA.b $06 : STA $0C; save number of columns

.next_column
	LDA.b [$08],Y
	STA.w $2000,X
	INY
	INX
	DEC.b $0C
	BNE .next_column

	DEC.b $07
	BNE .next_row

	REP #$21
	JMP .read_next
}