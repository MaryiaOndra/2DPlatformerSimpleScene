using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform path;
    [SerializeField] private float speed;

    private int currentPoint;
    private Transform[] points;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        points = new Transform[path.childCount];

        for (int i = 0; i < path.childCount; i++)
        {
            points[i] = path.GetChild(i);
        }

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //make object move from one point to another
        Transform target = points[currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            currentPoint++;
            spriteRenderer.flipX = false;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
                spriteRenderer.flipX = true;
            }
        }

        animator.SetFloat("Speed", speed);
    }

    //private void FlipPlayerSprite()
    //{
    //    if (xValue < 0)
    //    {
    //        spriteRenderer.flipX = true;
    //    }
    //    else if (xValue > 0)
    //    {
    //        spriteRenderer.flipX = false;
    //    }
    //}
}
