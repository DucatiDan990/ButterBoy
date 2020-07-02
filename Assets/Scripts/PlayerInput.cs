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
            RB.velocity = new Vector2(0, 10);
            IsGrounded = false;

            CurrentJumpTime += Time.deltaTime;
        }

        if (IsGrounded == true)
        {
            CurrentJumpTime = 0;
        }

        // Movement !!

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        movement = new Vector3(moveHorizontal, 0f, 0f);

        movement = movement * Speed * Time.deltaTime;

        transform.position += movement;

    }
}
