; ==============================================================================
; Area Specific BG color
; Written by Jared_Brian_
; 08-04-2022
; ==============================================================================

; ==============================================================================
; Modified Functions
; ==============================================================================

; Loads the transparent color under some load conditions
org $0BFEB6
    JML IntColorLoad1

; Loads the transparent color under some load conditions
org $0ED627
    JML IntColorLoad2
    NOP

; Main Palette loading routine. 
org $0ED5E7
    JSL CheckForChangePaletteLONG

; After leaving special areas like Zora's and the Master Sword area.
org $02E94A
    JSL CheckForChangePalette2LONG

; ==============================================================================

org $288150 ;reserved ZS space

IntColorLoad1:
{
    PHB : PHK : PLB

    STA $00

    SEP #$20 ; Set A in 8bit mode

    LDA $8140 : BNE .custom ; pc 140140 is where ZS saves whether to use the asm or not
        REP #$20 ; Set A in 16bit mode

        LDA $00
        STA $7EC300
        STA $7EC500 ;replaced code

        PLB

        JML $0BFEBA

    .custom

    LDA.b #$00 : XBA ; used to flush out the other byte in A

    LDA $8A : ASL : TAX ; Get area code and times it by 2
    
    REP #$20 ; Set A in 16bit mode

    LDA $8000, X ; pc 140000 is where ZS saves the array of palettes
    TAX

    STA $7EC300 : STA $7EC500 ;replaced code

    PLB

    JML $0BFEBA
}

; ==============================================================================

IntColorLoad2:
{
    PHB : PHK : PLB

    SEP #$20 ; Set A in 8bit mode

    LDA $8140 : BNE .custom ; pc 140140 is where ZS saves whether to use the asm or not
        REP #$20 ; Set A in 16bit mode

        LDA $8A : CMP.w #$0080 : BCC .notSpecialArea
            PLB
            JML $0ED62E

        .notSpecialArea

        PLB
        JML $0ED644

    .custom

    LDA.b #$00 : XBA ; used to flush out the other byte in A

    REP #$20 ; Set A in 16bit mode

    LDA $8A : ASL : TAX ; Get area code and times it by 2

    LDA $8000, X ; pc 140000 is where ZS saves the array of palettes
    TAX

    STA $7EC300 ;set transparent color

    PLB

    JML $0ED651
}

; ==============================================================================

CheckForChangePaletteLONG:
{
    PHB : PHK : PLB

    JSL $1BEEA8 ;Palette_OverworldBgAux3 replaced from where inserted

    JSR CheckForChangePalette

    PLB
    
    RTL
}

; ==============================================================================

CheckForChangePalette2LONG:
{
    PHB : PHK : PLB

    JSL $0ED5A8 ; Overworld_LoadPalettes replaced by jump

    JSR CheckForChangePalette

    PLB
    
    RTL
}

; ==============================================================================

CheckForChangePalette:
{
    LDA $8140 : BEQ .return ; pc 140140 is where ZS saves whether to use the asm or not
        PHX

        LDA $8A : ASL : TAX ; Get area code and times it by 2
        
        REP #$20 ; Set A in 16bit mode

        LDA $8000, X ; pc 140000 is where ZS saves the array of palettes
        STA $7EC300 ;set transparent color ; only set the buffer so it fades in right during mosaic transition

        SEP #$20 ; Set A in 8bit mode

        INC $15 ; trigger the buffer into the CGRAM

        PLX
    
    .return

    RTS
}

; ==============================================================================

; Make sure we don't hit the mosaic ASM.
print "End Area BG Color ASM ", pc
warnpc $288200