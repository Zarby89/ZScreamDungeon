; ==============================================================================
; Area Specific BG color
; Written by Jared_Brian_
; 08-04-2022
; ==============================================================================

; ==============================================================================
; Modified Functions
; ==============================================================================

org $0BFEB6             ;loads the transparent color under some load conditions
    JML IntColorLoad1

org $0ED644             ;loads the transparent color under some load conditions
    JML IntColorLoad2
    NOP

org $0ED5E7 ;Main Palette loading routine. 
    JSL CheckForChangePalette

; ==============================================================================

org $268150 ;reserved ZS space

IntColorLoad1:
{
    PHB : PHK : PLB

    STA $00

    SEP #$20 ; Set A in 8bit mode

    LDA $8140 : BNE .custom ; pc 130140 is where ZS saves whether to use the asm or not

    REP #$20 ; Set A in 16bit mode

    LDA $00
    STA $7EC500 ;replaced code

    PLB

    JML $0BFEBA

    .custom

    LDA.b #$00 : XBA ; used to flush out the other byte in A

    LDA $8A : ASL : TAX ; Get area code and times it by 2
    
    REP #$20 ; Set A in 16bit mode

    LDA $8000, X ; pc 130000 is where ZS saves the array of palettes
    TAX

    STA $7EC500 ;replaced code

    PLB

    JML $0BFEBA
}

; ==============================================================================

IntColorLoad2:
{
    PHB : PHK : PLB

    SEP #$30 ; Set A in 8bit mode

    LDA $8140 : BEQ .custom ; pc 130140 is where ZS saves whether to use the asm or not

    REP #$30 ; Set A in 16bit mode

    PLB

    JML $0ED651

    .custom

    LDA.b #$00 : XBA ; used to flush out the other byte in A

    LDA $8A : ASL : TAX ; Get area code and times it by 2

    REP #$30 ; Set A in 16bit mode

    LDA $8000, X ; pc 130000 is where ZS saves the array of palettes
    TAX

    PLB

    JML $0ED651
}

; ==============================================================================

CheckForChangePalette:
{
    PHB : PHK : PLB

    JSL $1BEEA8 ;Palette_OverworldBgAux3 replaced from where inserted

    LDA $8140 : BEQ .return ; pc 130140 is where ZS saves whether to use the asm or not

    PHX

    LDA $8A : ASL : TAX ; Get area code and times it by 2
    
    REP #$20 ; Set A in 16bit mode

    LDA $8000, X ; pc 130000 is where ZS saves the array of palettes
    STA $7EC300 : STA $7EC500 ;set transparent colors

    SEP #$20 ; Set A in 8bit mode

    INC $15 ; trigger the buffer into the CGRAM

    PLX
    
    .return 

    PLB
    
    RTL
}

; ==============================================================================