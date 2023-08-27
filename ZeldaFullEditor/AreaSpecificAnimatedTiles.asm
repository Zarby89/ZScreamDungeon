; ==============================================================================

AnimatedTileGFXSet = $0FC0

org $00D394
    DecompOwAnimatedTiles:

org $02ABBE
    Overworld_FinishTransGfx_firstHalf:

org $02ABB8 ;after most of the transition gfx changes take place
    JML CheckForChangeGraphicsTransitionLoad

org $0AB917 ;after most of the area loading after calling the bird takes place
    JSL CheckForChangeGraphicsNormalLoad

org $0ABC5A ;after the overworld map is closed
    JSL CheckForChangeGraphicsNormalLoad

org $028492 ;after leaving a dungeon
    JSL CheckForChangeGraphicsNormalLoad

; ==============================================================================

org $288300 ; Reserved ZS space
Pool:
{
    .animatedTable
    ;LW
    ;db $01, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;DW
    ;db $01, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;SP
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
    ;db $00, $00, $00, $00, $00, $00, $00, $00
}

; ==============================================================================

org $2883A0
CheckForChangeGraphicsTransitionLoad:
{
    PHB : PHK : PLB
    
    ; Check to see if we need to update the animated tiles by checking what was previously loaded.
    LDX $8A
    LDA Pool_animatedTable, X : CMP AnimatedTileGFXSet : BEQ .dontUpdate
        STA AnimatedTileGFXSet : DEC : TAY

        JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.

    .dontUpdate

    LDA.b #$09 ; Replaced code.

    PLB
        
    JML Overworld_FinishTransGfx_firstHalf
}

; ==============================================================================

CheckForChangeGraphicsNormalLoad:
{
    PHB : PHK : PLB

    JSL $00E19B ; Calls InitTilesets that was replaced.

    LDX $8A
    LDA Pool_animatedTable, X : STA AnimatedTileGFXSet : DEC : TAY

    JSL DecompOwAnimatedTiles ; This forces the game to update the animated tiles when going from one area to another.
        
    PLB

    RTL
}

; ==============================================================================