using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{

    [SerializeField] 
    private Rigidbody2D rb;

    [SerializeField] 
    private float swimSpeed;

    [SerializeField] 
    private float jumpingPower;

    private float horizontal = 0;
    private float vertical = 0;
    private bool isFacingRight = true;

    private bool headOverWater = false;
    private bool isJumping = false;


    public void SetGravity() {
        rb.gravityScale = 3.0f;
    }

    public void SetHeadOverWater(bool isOverWater) {
        headOverWater = isOverWater;
    }

    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if ( headOverWater ) {
            // vertical = Mathf.Min(vertical, 0);
            // Debug.Log("Ready to Jump");
            if ( Input.GetButtonDown("Jump") ) {
                isJumping = true;
            }
        }

        Flip();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if ( !headOverWater ) {
            rb.velocity = new Vector2(horizontal * swimSpeed, vertical * swimSpeed);
        } else if ( isJumping ) {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                isJumping = false;
        } else {
            rb.velocity = new Vector2(horizontal * swimSpeed, Mathf.Min(vertical, 0) * swimSpeed);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
