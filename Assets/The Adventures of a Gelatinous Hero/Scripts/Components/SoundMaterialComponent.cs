using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Paraphernalia.Components;
using Paraphernalia.Utils;

public class SoundMaterialComponent : MonoBehaviour {


    public bool isWood = false;
    public bool isMetal = false;
    public bool isStone = false;
    public bool isFlesh = false;
    public bool isPlayer = false;

    public string woodHitSoundName = "swordHitsWood01";
    public string fleshHitSoundName = "swordHitsFlesh01";
    public string metalHitSoundName = "swordHitsMetal01";
    public string stoneHitSoundName = "swordHitsStone01";
    public string playerHitSoundName = "playerHit";

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            if (isWood) AudioManager.PlayEffect(woodHitSoundName);
            if (isFlesh) AudioManager.PlayEffect(fleshHitSoundName);
            if (isMetal) AudioManager.PlayEffect(metalHitSoundName);
            if (isStone) AudioManager.PlayEffect(stoneHitSoundName);
            if (isPlayer) AudioManager.PlayEffect(playerHitSoundName);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Sword")
        {
            if (isWood) AudioManager.PlayEffect(woodHitSoundName);
            if (isFlesh) AudioManager.PlayEffect(fleshHitSoundName);
            if (isMetal) AudioManager.PlayEffect(metalHitSoundName);
            if (isStone) AudioManager.PlayEffect(stoneHitSoundName);
            if (isPlayer) AudioManager.PlayEffect(playerHitSoundName);
        }
    }
}
