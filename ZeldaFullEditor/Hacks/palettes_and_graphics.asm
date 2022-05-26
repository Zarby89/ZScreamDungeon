; Create a table so every palette can have a unique palette
org $02C3F6
	BRA ++ ; skip 2 bytes

	db "ZS" ; ZScream signature to know this code is custom

++	LDX.b $8A

	LDA.l OWScreenMainPalettes,X

	TAX

	BRA $02C411
