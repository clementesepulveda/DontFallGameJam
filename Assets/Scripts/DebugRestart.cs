using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DebugRestart : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown("p")) {
            SceneManager.LoadScene(0);
        }
    }
}