using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        SoundManager.current.FinishGame();
        SceneManager.LoadScene("Thanks");
    }
}
