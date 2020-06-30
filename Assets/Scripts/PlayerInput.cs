using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public KeyCode Jump;
    private Rigidbody2D RB;


    public bool IsGrounded;
    public float MaxJump;
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
    }
}