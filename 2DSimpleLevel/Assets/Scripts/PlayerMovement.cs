using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

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
        if (isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("OnGround", false);
            playerRb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);        
        animator.SetBool("OnGround", isGrounded);
        animator.SetFloat("vSpeed", playerRb.velocity.y);

        if (!isDead)
        {
            xValue = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(xValue));
            FlipPlayerSprite();
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
            animator.SetTrigger("IsDead");
            isDead = true;
        }
    }
}
