using UnityEngine;

public class MummyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private int yDestroyPos = -5;

    private void Start()
    {
        SetEulerAngle();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.y < yDestroyPos)
        {
            Destroy(gameObject);
        }
    }

    private void SetEulerAngle() 
    {
        Vector3 euler = transform.eulerAngles;
        euler.y = Random.Range(0.0f, 360.0f);
        transform.eulerAngles = euler;
    }
}
