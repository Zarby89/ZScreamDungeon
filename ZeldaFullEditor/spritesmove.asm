  lorom
  
!ADD = "CLC : ADC"
!SUB = "SEC : SBC"
!BLT = "BCC"
!BGE = "BCS"

;Load Overworld Sprites hook
  org $09C4AC
    JSL LoadOverworldSpritesLong
    RTS

  org $218000
    LoadOverworldSpritesLong:
    {
        ; Loads overworld sprite information into memory ($7FDF80, X is one such array)
        PHB : PHK : PLB
        ; calculate lower bounds for X coordinates in this map
        LDA $040A : AND.b #$07 : ASL A : STZ $0FBC : STA $0FBD
        
        ; calculate lower bounds for Y coordinates in this map
        LDA $040A : AND.b #$3F : LSR #2 : AND.b #$0E : STA $0FBF : STZ $0FBE
        
        LDA $040A : TAX
        
        LDA $09C635, X : TAX : STX $0FB9 : STZ $0FB8 
        STX $0FBB    : STZ $0FBA
        
        REP #$30
        
        ; What Overworld area are we in?
        LDA $040A : ASL A : TAY
        
        SEP #$20
        
        ; load the game state variable
        LDA $7EF3C5 ;World State Variable
        
        CMP.b #$03 : BEQ .secondPart
        CMP.b #$02 : BEQ .firstPart

        ; Load the "Beginning" sprites for the Overworld. ;0 (Rain State) ;0x80 Maps LW and DW
        LDA $8100, Y : STA $00
        LDA $8101, Y

        BRA .loadData
    
    .secondPart

        ; Load the "Second part" sprites for the Overworld. ; 0x120 Maps LW and DW + Specials Areas 
        LDA $8180, Y : STA $00
        LDA $8181, Y
        
        BRA .loadData
    
    .firstPart
    
        ; Load the "First Part" sprites for the Overworld. ; 0x120 Maps LW and DW + Specials Areas 
        LDA $82A0, Y : STA $00
        LDA $82A1, Y
    
    .loadData
    
        STA $01
        
        LDY.w #$0000
    
    .nextSprite
    
        ; Read off the sprite information until we reach a #$FF byte.
        LDA ($00), Y : CMP.b #$FF : BEQ .stopLoading
        
        INY #2
        
        ; Is this a �Falling Rocks� sprite?
        LDA ($00), Y : DEY #2 : CMP.b #$F4 : BNE .notFallingRocks
        
        ; Set a "falling rocks" flag for the area and skip past this sprite
        INC $0FFD
        
        INY #3
        
        BRA .nextSprite
    
    .notFallingRocks ; Anything other than falling rocks.
    
        LDA ($00), Y : PHA : LSR #4 : ASL #2 : STA $02 : INY
        
        LDA ($00), Y : LSR #4 : !ADD $02 : STA $06
        
        PLA : ASL #4 : STA $07
        
        ; All this is to tell us where to put the sprite in the sprite map.
        LDA ($00), Y : AND.b #$0F : ORA $07 : STA $05
        
        ; The sprite / overlord index as stored as one plus it�s normal index. Don�t ask me why yet.
        INY : LDA ($00), Y : LDX $05 : INC A : STA $7FDF80, X ; Load them into what I guess you might call a sprite map.
        
        ; Move on to the next sprite / overlord.
        INY
        
        BRA .nextSprite
    
    .stopLoading
    
        SEP #$10

        PLB

        RTL
    }