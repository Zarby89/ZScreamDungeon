org $09C292
    ; make the sprite bank be in a consistent place for ZS to read: $09C293
    LDA.w #SpriteData>>16
    JSL GetSpritePointer
    JMP.w $09C29C ; skip over code we already took care of

; Fix pointer reads
org $09C2B2 : LDA.b [$90]
org $09C2C1 : LDA.b [$90],Y
org $09C329 : LDA.b [$90],Y
org $09C332 : LDA.b [$90],Y
org $09C350 : LDA.b [$90],Y
org $09C38C : LDA.b [$90],Y
org $09C398 : LDA.b [$90],Y
org $09C3AA : LDA.b [$90],Y
org $09C3BF : LDA.b [$90],Y
org $09C3F3 : LDA.b [$90],Y
org $09C3FB : LDA.b [$90],Y
org $09C404 : LDA.b [$90],Y
org $09C416 : LDA.b [$90],Y

org $208000 ; TEMPORARY LOCATION

GetSpritePointer:
    STA.b $92

    LDA.w $048E
    ASL
    TAX

    LDA.l SpriteData,X
    STA.b $90

    RTL

org $208100
SpriteData: