using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Bridge_00 : MonoBehaviour
{
    public PlayableDirector movement;
    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("YO");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        movement.Play();
    }
}
