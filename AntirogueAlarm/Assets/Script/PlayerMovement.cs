using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private float _turnSpeed = 50;
    private float _speed = 2;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * _turnSpeed);

        if (verticalInput > 0)
        {
            gameObject.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
           gameObject.transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
     
        _animator.SetFloat("Speed", Math.Abs(verticalInput));
    }    
}
