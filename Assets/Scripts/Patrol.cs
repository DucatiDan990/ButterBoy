using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public GameObject ToastDead;
    public bool changePosition = true;

    public bool movingRight = true;

    public Transform groundDetection;

    public float toastDistanceToGround;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //PatrolTest();
        RayCastPatrol();
    }

    public void PatrolTest()
    {
        if (changePosition == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT");
            collision.gameObject.GetComponent<PlayerLife>().LoseLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().Toast--;
            collision.gameObject.GetComponent<PlayerLife>().wingame();
            Destroy(gameObject);
            Instantiate(ToastDead, transform.position -= new Vector3(0, toastDistanceToGround, 0), Quaternion.identity);
        }
    }

    public void RayCastPatrol()
    {

        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == null)
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }
}