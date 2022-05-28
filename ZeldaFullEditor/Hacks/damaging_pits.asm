org PitDamageHook
	%InsertZSMarker()

	LDA.b $A0
	ASL
	TAX
	CMP.l RoomPitDamage,X
	BNE .damage
	NOP
	NOP