using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isOnGround; 

    private float horizontalInput;
    //private float leftBound = -6.171f;
    //private float rightBound = 6.249f;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * Vector2.right * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
           playerRb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundOrPlatform"))
        {
            Debug.Log("I AM ON THE GROUND");
            isOnGround = true;
        }
        else 
        {
            isOnGround = false;
        }          
    }
}
