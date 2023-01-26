using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string currentText;
    [SerializeField] 
    private GameObject dialogueAnchor;

    [SerializeField] 
    private GameObject dialogueBubble;

    [SerializeField] 
    private GameObject textBox;


    private Transform transformToFollow;
    private bool hasVisited = false;

    private void Start() {
        if ( transformToFollow != null ){
            dialogueAnchor.transform.position = transformToFollow.position;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if ( hasVisited ) { return; }
        if ( !other.gameObject.CompareTag("Player") ) { return; }

        hasVisited = true;

        transformToFollow = other.gameObject.transform;
        dialogueAnchor.SetActive(true);
        SetBubble(currentText);
            
    }

    private void SetBubble(string text) {
        textBox.GetComponent<TMP_Text>().text = text;
        Canvas.ForceUpdateCanvases();

        // Adjust dialogue box
        dialogueBubble.GetComponent<SpriteRenderer>().size = new Vector2(
            dialogueBubble.GetComponent<SpriteRenderer>().size.x,
            1+(textBox.GetComponent<TMP_Text>().textInfo.lineCount-1)*0.25f
        );
        // Adjust text to dialogue box
        Debug.Log($"{textBox.GetComponent<TMP_Text>().textInfo.lineCount} {0.5f + 0.1f*(textBox.GetComponent<TMP_Text>().textInfo.lineCount-1)}");
        textBox.GetComponent<RectTransform>().localPosition = new Vector3(
            textBox.GetComponent<RectTransform>().localPosition.x,
            0.5f + 0.1f*(textBox.GetComponent<TMP_Text>().textInfo.lineCount-1),
            0
        );
    }
}
