using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    private float maxSpeed = 5f;
    private float xValue;
    private float groundRadius = 0.02f;
    private bool isDead;

    ///TODO: make bounds around scene
    //private float leftBound = -6.171f;
    //private float rightBound = 6.249f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //make player jump
        if (isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("OnGround", false);
            playerRb.AddForce(Vector2.up * jumpForce);
        }
    }

    void FixedUpdate()
    {
        //check if player touch the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);        
        animator.SetBool("OnGround", isGrounded);
        animator.SetFloat("vSpeed", playerRb.velocity.y);

        if (!isDead)
        {
            //check if player press arrows or A, D
            xValue = Input.GetAxis("Horizontal");

            //change Speed component in Animator for x position value
            animator.SetFloat("Speed", Mathf.Abs(xValue));

            //changing the direction of movement of the Player and mirror its image
            FlipPlayerSprite();

            //make player move with max speed
            playerRb.velocity = new Vector2(xValue * maxSpeed, playerRb.velocity.y);
        }
    }

    private void FlipPlayerSprite() 
    {
        if (xValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (xValue > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyMovement>(out EnemyMovement movement))
        {
            animator.SetBool("IsDead", true);
            isDead = true;
        }
    }
}
