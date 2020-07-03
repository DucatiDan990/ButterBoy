using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public KeyCode Jump;
    private Rigidbody2D RB;

    public bool IsGrounded;
    public float MaxJump;

    public float Speed;
    Vector3 movement;

    private float CurrentJumpTime;


    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && RB.velocity.y <= 0)
        {
            IsGrounded = true;
        }
    }


    void Update()

        // Jumping !!
    {
        var animator = GetComponentInChildren<Animator>();

        if (Input.GetKey(Jump) && MaxJump > CurrentJumpTime)
        {
            RB.velocity = new Vector2(RB.velocity.x, 10);
            IsGrounded = false;

            CurrentJumpTime += Time.deltaTime;

            if (animator != null)
            {
                animator.SetTrigger("jump");
            }
        }

        if (IsGrounded == true)
        {
            CurrentJumpTime = 0;
        }

        // Movement !!

        var horizontal = (Input.GetAxisRaw("Horizontal") * Speed);

        RB.velocity = new Vector2(horizontal, RB.velocity.y);

        if (IsGrounded)
        {

            if (horizontal > 0)
            {
                animator.SetTrigger("right");
            }

            if (horizontal < 0)
            {
                animator.SetTrigger("left");
            }

            if (horizontal == 0)
            {
                animator.SetTrigger("idle");
            }
        }


    }
}
