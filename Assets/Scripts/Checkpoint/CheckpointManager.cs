using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;

    // Start is called before the first frame update
    void Start() {
        lastCheckpointPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("r")) {
            GameObject player =  GameObject.FindWithTag("Player");
            if ( player.GetComponent<MovementController>().hasDied ) {
                player.transform.position = lastCheckpointPosition;
                player.GetComponent<MovementController>().UnkillPlayer();
            }
        }
    }

    public void SaveCheckPoint(Vector3 newPosition) {
        lastCheckpointPosition = newPosition;
    }
}
