
org $099A09

;old code use 0x55 bytes (new code use 0x43)
NewGraves:
    AND.w #$FFF0 : STA $00
    
    LDY.w #$001C ;check every entries...

.y_coord_next

    LDA.w $00 : SEC : SBC #$0010 : CMP $9968, Y : BNE .y_coord_doesnt_match ;are we colliding a Y Position Tile?
        LDA.w $9986, Y : CMP.w $22 : BCS .xCoordNonMatch ;does it match the X Position at the same position in the array?
        CLC : ADC.w #$000F : CMP.w $22 : BCC .xCoordNonMatch
            BRA CheckDashable
        .xCoordNonMatch
    .y_coord_doesnt_match
    
    DEY #2 : BPL .y_coord_next ;Check the next Y
    
    BRA terminate_object ;25
    
    CheckDashable:
    CPY.w #$001A : BNE .nondashable_grave    
        LDA $0372 : AND.w #$00FF : BEQ terminate_object ;are we dashing?
        BRA success ;55
    
    .nondashable_grave
    
        ; self terminate if we tried to dash a nondashable grave stone
        LDA $0372 : AND.w #$00FF : BNE terminate_object
        BRA success

    
    BRA terminate_object ;67

NOP #13

org $099A5E
terminate_object:

org $099A66
success:
