using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource playerJump;
    public AudioSource textWrite;
    public AudioSource playerWalk;
    public AudioSource explosion;
    public AudioSource deathSound;
    public AudioSource goInWater;
    public AudioSource finishGame;
    public AudioSource buttonPress;


    public static SoundManager current { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (current != null && current != this) { 
            Destroy(this.gameObject); 
        } else { 
            current = this; 
            DontDestroyOnLoad(this.gameObject);
        } 
    }
    
    public void PlayerJump() {
        playerJump.Play();
    }

    public void TextWrite() {
        textWrite.Play();
    }

    public void PlayerWalk() {
        if ( !playerWalk.isPlaying) {
            playerWalk.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            playerWalk.Play();
        }
    }

    public void Explosion() {
        explosion.Play();
    }

    public void DeathSound() {
        deathSound.Play();
    }

    public void GoInWater() {
        goInWater.Play();
    }

    public void FinishGame() {
        finishGame.Play();
    }

    public void ButtonPress() {
        buttonPress.Play();
    }
}