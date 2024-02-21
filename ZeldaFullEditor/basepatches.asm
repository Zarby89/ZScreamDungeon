lorom

; enable fast ROM
org $00FFD5 : db $30

org $00FFEA : dw NMIBounce
org $00FFEE : dw IRQBounce

org $808000
	SEI

	STZ.w $4200

	CLC
	XCE
	REP #$28

	JML ++

NMIBounce: JML $8080C9
IRQBounce: JML $8082D8

++	LDA.w #$0000
	TCD

	LDA.w #$01FF
	TCS

	SEP #$30

	LDA.b #$81
	STA.w $420D
	STA.w $2100

	PHK
	PLB

	NOP

; TODO move these to a new file in patches system



org $8CC2E1
TitleCardFix:
	LDA.w $2140
	BNE .exit

	LDA.b #$14
	STA.b $10

	STZ.b $11
	STZ.b $22

.exit
	RTL

; lynel fix (the code is redundant and useless)
org $9D875C
	JMP.w $9D876B

; fire spit fix
; have to rearrange this slightly so that bank isn't pulled on exit
; otherwise, it always sets the N flag
org $9E92E4
	LDA.b #$A5
	JSL $9DF65D
	BMI .no_space

	PHB
	PHK
	PLB

org $9E9360
	PLB
	PLX

.no_space
	RTL