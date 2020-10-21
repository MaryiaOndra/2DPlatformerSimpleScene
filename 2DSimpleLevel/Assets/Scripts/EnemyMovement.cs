using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform path;
    [SerializeField] private float speed;

    private int currentPoint;
    private Transform[] points;
    private Animator animator;

    private void Start()
    {
        points = new Transform[path.childCount];
        animator = GetComponent<Animator>();

        for (int i = 0; i < path.childCount; i++)
        {
            points[i] = path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = points[currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
