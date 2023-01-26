using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject dialogueAnchor;

    [SerializeField] 
    private GameObject dialogueBubble;

    [SerializeField] 
    private GameObject textBox;

    [SerializeField] 
    [TextArea]
    private string[] sentences;
    [SerializeField] 
    private float textSpeed;

    [SerializeField] 
    private bool pausesCharacter;

    [SerializeField] 
    private float delayDestroySeconds;
	private Queue<string> sentencesQueue;


    private Transform transformToFollow;
    private bool hasVisited = false;
    private MovementController playerMovementController;

    private void Start() {
        sentencesQueue = new Queue<string>();
    }

    private void Update() {
        if ( transformToFollow != null ){
            Vector3 follow = transformToFollow.position;
            follow = new Vector3( follow.x*16, follow.y*16, follow.z);
            follow = new Vector3( Mathf.Round(follow.x), Mathf.Round(follow.y), follow.z);
            follow = new Vector3( follow.x/16, follow.y/16, follow.z);
            dialogueAnchor.transform.position = follow;

        
            if ( Input.GetButtonDown("Jump") && pausesCharacter) {
                DisplayNextSentence();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if ( hasVisited ) { return; }
        if ( !other.gameObject.CompareTag("Player") ) { return; }

        hasVisited = true;

        transformToFollow = other.gameObject.transform;
        dialogueAnchor.SetActive(true);
        
        if ( pausesCharacter ) {
            playerMovementController = other.gameObject.GetComponent<MovementController>();
            playerMovementController.PausePlayer();
            StartDialogue();
        } else {
            SetBubble(sentences[0]);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentences[0]));
            
            StartCoroutine(DelayDestroy());
        }
    }

    public void StartDialogue() {
		foreach (string sentence in sentences) {
			sentencesQueue.Enqueue(sentence);
		}

        StopAllCoroutines();
		DisplayNextSentence();
    }

	public void DisplayNextSentence () {
		if (sentencesQueue.Count == 0) {
            playerMovementController.UnpausePlayer();
            Destroy(gameObject);
            return;
		}

		string sentence = sentencesQueue.Dequeue();
        SetBubble(sentence);
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

    private void SetBubble(string text) {
        textBox.GetComponent<TMP_Text>().text = text;
        Canvas.ForceUpdateCanvases();

        // Adjust dialogue box
        dialogueBubble.GetComponent<SpriteRenderer>().size = new Vector2(
            dialogueBubble.GetComponent<SpriteRenderer>().size.x,
            1+(textBox.GetComponent<TMP_Text>().textInfo.lineCount-1)*1f
        );

        if ( textBox.GetComponent<TMP_Text>().textInfo.lineCount == 5) {
            // Adjust text to dialogue box
            textBox.GetComponent<RectTransform>().localPosition = new Vector3(
                textBox.GetComponent<RectTransform>().localPosition.x,
                2,
                0
            );
        } else {
            // Adjust text to dialogue box
            textBox.GetComponent<RectTransform>().localPosition = new Vector3(
                textBox.GetComponent<RectTransform>().localPosition.x,
                0.5f + 0.5f*(textBox.GetComponent<TMP_Text>().textInfo.lineCount-1),
                0
            );
        }
    }

	IEnumerator TypeSentence (string sentence) {
		textBox.GetComponent<TMP_Text>().text = "";
        var i = 0;
		foreach (char letter in sentence.ToCharArray()) {
            if ( i%2 == 0) {
                SoundManager.current.TextWrite();
            }
            i++;
			textBox.GetComponent<TMP_Text>().text += letter;
			yield return new WaitForSeconds(textSpeed/60f);
		}
	}

    IEnumerator DelayDestroy() {
        yield return new WaitForSeconds(delayDestroySeconds);
        Destroy(gameObject);
    }
}
