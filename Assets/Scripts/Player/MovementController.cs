using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    private bool hasSwimmingAbility = false;
    private List<string> abilities;
    public bool hasDied = false;

    public void CharacterSwim() {
        if ( hasDied ) {return;}

        SoundManager.current.GoInWater();
        if ( hasSwimmingAbility ) {
            transform.Find("Swim").gameObject.SetActive(true);
            transform.Find("Platformer").gameObject.SetActive(false);
        } else {
            KillPlayer();
        }
    }
    
    public void CharacterPlatformer() {
        if ( hasDied ) {return;}

        transform.Find("Swim").gameObject.SetActive(false);
        transform.Find("Platformer").gameObject.SetActive(true);
    }

    public void EnableSwimming() {
        hasSwimmingAbility = true;
    }

    public void PausePlayer() {
        if ( hasDied ) {return;}

        transform.Find("Paused").gameObject.SetActive(true);
        transform.Find("Platformer").gameObject.SetActive(false);
    }

    public void UnpausePlayer() {
        if ( hasDied ) {return;}

        transform.Find("Paused").gameObject.SetActive(false);
        transform.Find("Platformer").gameObject.SetActive(true);
    }

    public void KillPlayer() {
        SoundManager.current.DeathSound();
        DisableAllChildren();
        transform.Find("Death").gameObject.SetActive(true);
        hasDied = true;
    }

    public void UnkillPlayer() {
        if ( !hasDied ) { return; }

        DisableAllChildren();
        transform.Find("Platformer").gameObject.SetActive(true);
        hasDied = false;
    }

    private void DisableAllChildren() {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }
}
