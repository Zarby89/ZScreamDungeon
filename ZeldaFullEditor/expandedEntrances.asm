; ==============================================================================
; ZScream Expanded Entrances
; Written by Zarby89
; ==============================================================================

; ==============================================================================
; Non-Expanded Space
; ==============================================================================

pushpc

org $02D99F ; DataBank change hook1
    JSL NewEntrancesCodeChangeBank1

org $02DACE ; DataBank change hook2
    JSL NewEntrancesCodeChangeBank2

; No need to use expanded region for it!
org $02DA64 ; Check if entrance is going down on the .Extra databyte
FacingEntrance:
{
    LDA.w EntranceData_entranceExtra, X : AND.b #$01 : BEQ .face_up
        LDA.b #$02
        BRA .setFacing
    .face_up

    LDA.b #$00

    .setFacing

    STA.b $2F
    NOP
}

org $0299B0
    JSL NewFaceDownCheck
    BRA .skipuseless

org $0299BA
    .skipuseless

org $02D9A3
    LDA.w EntranceData_room_id, X

org $02D9AB
    LDA.w EntranceData_vertical_scroll, X

org $02D9B8
    LDA.w EntranceData_horizontal_scroll, X

org $02D9CB
    LDA.w EntranceData_y_coordinate, X

org $02D9D0
    LDA.w EntranceData_x_coordinate, X

org $02D9D5
    LDA.w EntranceData_camera_trigger_y, X

org $02D9E0
    LDA.w EntranceData_camera_trigger_x, X

org $02D9F0
    LDA.w EntranceData_overworld_door_tilemap, X

org $02DA1A
    LDA.w EntranceData_camera_scroll_boundaries+0, Y
    STA.w $0601

    LDA.w EntranceData_camera_scroll_boundaries+1, Y
    STA.w $0603

    LDA.w EntranceData_camera_scroll_boundaries+2, Y
    STA.w $0605

    LDA.w EntranceData_camera_scroll_boundaries+3, Y
    STA.w $0607

    LDA.w EntranceData_camera_scroll_boundaries+4, Y
    STA.w $0609

    LDA.w EntranceData_camera_scroll_boundaries+5, Y
    STA.w $060B

    LDA.w EntranceData_camera_scroll_boundaries+6, Y
    STA.w $060D

    LDA.w EntranceData_camera_scroll_boundaries+7, Y
    STA.w $060F

org $02DA74
    LDA.w EntranceData_main_GFX, X

org $02DA77
    STA.w $0AA1

org $02DA7A
    LDA.w EntranceData_song, X

org $02DA7D
    STA.w $0132

org $02DA91
    LDA.w EntranceData_floor, X

org $02DA94
    STA.b $A4

org $02DA96
    LDA.w EntranceData_dungeon_id, X

org $02DA99
    STA.w $040C

org $02DA9C
    LDA.w EntranceData_in_door, X

org $02DA9F
    STA.b $6C

org $02DAA1
    LDA.w EntranceData_layer, X

org $02DAAA
    LDA.w EntranceData_layer, X

org $02DAB2
    LDA.w EntranceData_camera_scroll_controller, X

org $02DABB
    LDA.w EntranceData_camera_scroll_controller, X

org $02DAC2
    LDA.w EntranceData_quadrant, X

org $02DACB
    LDA.w EntranceData_quadrant, X


; Long no need to change DataBank
org $0299E5
    LDA.l EntranceData_song, X

org $029B04
    LDA.l EntranceData_song, X


; UNUSED old Tile16 space
org $0F8000
EntranceData:
{
    ; Space for 0xFF entrances dungeon data.
    .room_id
    skip $200 ; words values

    .camera_scroll_boundaries
    skip $800 ; 8 bytes values

    .horizontal_scroll
    skip $200 ; words values

    .vertical_scroll
    skip $200 ; words values

    .y_coordinate
    skip $200 ; words values

    .x_coordinate
    skip $200 ; words values

    .camera_trigger_y
    skip $200 ; words values

    .camera_trigger_x
    skip $200 ; words values

    .main_GFX
    skip $100 ; byte values

    .floor
    skip $100 ; byte values

    .dungeon_id
    skip $100 ; byte values

    .in_door
    skip $100 ; byte values

    .layer
    skip $100 ; byte values

    .camera_scroll_controller
    skip $100 ; byte values

    .quadrant
    skip $100 ; byte values

    .overworld_door_tilemap
    skip $200 ; words values

    .song
    skip $100 ; byte values

    .entranceExtra
    skip $100 ; byte values
    ; Bit0 = is facing down? (set = true)
}

org $0FA100 ; After the Entrance Data

warnpc $0FF000

; These 8 bytes are to know if the rom has been expanded or not already
; Using 2 bytes for validation just to be sure since these can be different in any roms
; if first byte is $00 and 2nd byte is $01 rom is probably expanded
org $0FF000 ; Reserved for expansion code
    db $00 ; Expansion is a thing
    db $01 ; Entrances are expanded

org $0FF008
NewEntrancesCodeChangeBank1:
{
    TAX : ASL : ASL : TAY ; Overwritten code

    SEP #$20 ; set A in 8bit
    LDA.b #EntranceData>>16 ; Get the new entrance bank
    PHA ; Set new Databank to that
    PLB
    REP #$20

    RTL
}

NewEntrancesCodeChangeBank2:
{
    AND.b #$0F : STA.b $AA ; Overwritten code

    LDA.b #$02 ; Get the new entrance bank
    PHA ; Go back to databank 02
    PLB

    RTL
}

NewFaceDownCheck:
{
    LDX.w $010E
    LDA.l EntranceData_entranceExtra, X : AND.b #$01 : BEQ .faceup
        LDX.b #$01
        RTL

    .faceup

    LDX.b #$00
    RTL
}
warnpc $0FF540

; ==============================================================================

pullpc