/// <reference types = "@altv/types-client" />
import * as alt from "alt-client"

let blutColshapeState = false; 
let blutColshapeID = -1;

let huelsenColShapeState = false;
let huelsenColShapeID = -1;


alt.on('playerWeaponShoot', (weaponHash, totalAmmo, ammoInClip) => {
    const lPlayer = alt.Player.local.scriptID;
    alt.log('Player ist shooting.');
    alt.emitServer('PLAYER_SHOOT_EVENT', weaponHash, totalAmmo , ammoInClip)
});

/* Blut ColShape ubertragung */
alt.onServer('InBlutColShape', (state, indexdm) => {
    blutColshapeState = state
    blutColshapeID = indexdm
    alt.log("Blut ColShape "+ blutColshapeID +" "+ blutColshapeState + " Kansnt jetzt X drücken" )
});

/* Hulesen ColShape ubertragung */
alt.onServer('InHuelsenColShape', (state, indexdm) => {
    huelsenColShapeState = state
    huelsenColShapeID = indexdm
    alt.log("huelsen ColShape "+ huelsenColShapeID +" "+ huelsenColShapeState + " Kansnt jetzt Y drücken" )
});


alt.on('keydown', (key) =>{
    if (key == alt.KeyCode.X && blutColshapeState){
        alt.log('Player hat X gedrückt! in Blut ColShape');
    }
});

alt.on('keydown', (key) =>{
    if (key == alt.KeyCode.Y && huelsenColShapeState){
        alt.log('Player hat Y gedrückt! in huelsen ColShape');
    }
});