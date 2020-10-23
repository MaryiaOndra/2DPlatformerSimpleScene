using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;
    [SerializeField] private float speed;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);

        if (verticalInput > 0)
        {
            Debug.Log("FORWARD");
            playerRB.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            Debug.Log("BACK");
            playerRB.transform.Translate(Vector3.back * speed * Time.deltaTime);
          //  gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
     
       // animator.SetFloat("Speed", Math.Abs(verticalInput));
    }
}
