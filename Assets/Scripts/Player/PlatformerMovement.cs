using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float jumpTime = 16f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private float horizontal;
    private bool isFacingRight = true;
    private bool isJumping = false;
    private float jumpingTimeCounter;

    private void OnEnable() {
        rb.gravityScale = 4.5f;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if ( horizontal != 0 && IsGrounded()) {
            SoundManager.current.PlayerWalk();
        }

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            SoundManager.current.PlayerJump();
            isJumping = true;
            jumpingTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if( Input.GetButton("Jump") && isJumping ) {
            if ( jumpingTimeCounter > 0 ) {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            } else {
                isJumping = false;
            }
            jumpingTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
        }

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
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
