using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPU : MonoBehaviour
{
    public float speed;
    public float range;

    public GameObject[] toActivate;
    public GameObject toDectivate;

    private Vector3 originalPosition;

    void Start() {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float newY = originalPosition.y + (2 * Mathf.PingPong(Time.time * speed, 1) - 1 )* range;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.CompareTag("Player") ) {
            SoundManager.current.Explosion();
            other.gameObject.GetComponent<MovementController>().EnableSwimming();
            
            foreach (var item in toActivate) {
                item.SetActive(true);
            }
            toDectivate.SetActive(false);
            Destroy(gameObject);
        }
    }
}
