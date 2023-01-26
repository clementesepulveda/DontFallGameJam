using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckpointManager checkpointManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.CompareTag("Player") ) {
            checkpointManager.SaveCheckPoint(transform.position);
        }
    }
}
