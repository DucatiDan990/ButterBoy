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
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
    void Update()

        // Jumping !!
    {
        if (Input.GetKey(Jump) && MaxJump > CurrentJumpTime)
        {
            RB.velocity = new Vector2(RB.velocity.x, 10);
            IsGrounded = false;

            CurrentJumpTime += Time.deltaTime;
        }

        if (IsGrounded == true)
        {
            CurrentJumpTime = 0;
        }

        // Movement !!

        var horizontal = (Input.GetAxisRaw("Horizontal") * Speed);

        RB.velocity = new Vector2(horizontal, RB.velocity.y);

    }
}
