using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    void OnEnable() {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
