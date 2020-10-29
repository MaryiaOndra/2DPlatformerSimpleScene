using UnityEngine;

public class MummyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _yDestroyPos = -5;

    private void Start()
    {
        SetEulerAngle();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (transform.position.y < _yDestroyPos)
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
