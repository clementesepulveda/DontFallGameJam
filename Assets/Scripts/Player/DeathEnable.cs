using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnable : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float angleDirection = 30;
    
    private void OnEnable() {
        float angleDegrees = Random.Range(-angleDirection, angleDirection) + 90;
        float angleRads = angleDegrees * Mathf.Deg2Rad;
        rb.freezeRotation = false;
        rb.AddTorque(rotationSpeed);
        rb.velocity = new Vector3(Mathf.Cos(angleRads)*jumpSpeed, Mathf.Sin(angleRads)*jumpSpeed, 0);
    }

    
    private void OnDisable() {
        rb.freezeRotation = true;
        rb.rotation = 0;
    }
}
