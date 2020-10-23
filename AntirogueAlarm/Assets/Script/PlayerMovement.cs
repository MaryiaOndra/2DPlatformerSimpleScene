using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnSpeed = 40;
    private float speed = 2;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(verticalInput);

        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

        if (verticalInput > 0)
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
           gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
     
        animator.SetFloat("Speed", Math.Abs(verticalInput));
    }

    
}
