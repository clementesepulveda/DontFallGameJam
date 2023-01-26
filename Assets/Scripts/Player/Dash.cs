using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;
    [SerializeField] 
    private float dashSpeed = 8f;
    private float dashInput;
    [SerializeField] 
    private bool isDashing = false;
    
    void Update() {
        if ( Input.GetKeyDown(KeyCode.LeftShift) && !isDashing) {
            Debug.Log("Dashing!");
            isDashing = true;
            rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
        }
    }

    private void FixedUpdate() {
        
    }
}
