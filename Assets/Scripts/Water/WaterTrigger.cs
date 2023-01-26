using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if ( other.CompareTag("Player") && other.GetComponent<MovementController>() != null ) {
            other.GetComponent<MovementController>().CharacterSwim();
        }
        if ( other.CompareTag("EyeLevel") ) {
            other.GetComponentInParent<WaterMovement>().SetGravity();
            other.GetComponentInParent<WaterMovement>().SetHeadOverWater(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if ( other.CompareTag("Player") && other.GetComponent<MovementController>() != null ) {
            other.GetComponent<MovementController>().CharacterPlatformer();
        }

        if ( other.CompareTag("EyeLevel") && other.GetComponentInParent<WaterMovement>() != null ) {
            other.GetComponentInParent<WaterMovement>().SetHeadOverWater(true);
        }
    }
}
