using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private int _currentPoint;
    private Transform[] _points;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _target;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {  
        _target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);       

        if (transform.position == _target.position)
        {
            _currentPoint++;
            _spriteRenderer.flipX = false;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
                _spriteRenderer.flipX = true;
            }
        }

        _animator.SetFloat("Speed", _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _animator.SetBool("Attack", true);
            _speed = 0;
        }
    }
}
