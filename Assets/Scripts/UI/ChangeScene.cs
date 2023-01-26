using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToChangeTo;
    
    public void ChangeSceneTo() {
        SoundManager.current.ButtonPress();
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
