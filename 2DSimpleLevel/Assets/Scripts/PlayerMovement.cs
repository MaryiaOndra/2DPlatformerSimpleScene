using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    private float _maxSpeed = 5f;
    private float _xValue;
    private float _groundRadius = 0.02f;
    private bool _isDead;
    private bool _isGrounded;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            _animator.SetBool("OnGround", false);
            _playerRb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _whatIsGround);        
        _animator.SetBool("OnGround", _isGrounded);
        _animator.SetFloat("vSpeed", _playerRb.velocity.y);

        if (!_isDead)
        {
            _xValue = Input.GetAxis("Horizontal");
            _animator.SetFloat("Speed", Mathf.Abs(_xValue));
            FlipPlayerSprite();
            _playerRb.velocity = new Vector2(_xValue * _maxSpeed, _playerRb.velocity.y);
        }
    }

    private void FlipPlayerSprite() 
    {
        if (_xValue < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_xValue > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyMovement>(out EnemyMovement movement))
        {
            _animator.SetTrigger("IsDead");
            _isDead = true;
        }
    }
}
