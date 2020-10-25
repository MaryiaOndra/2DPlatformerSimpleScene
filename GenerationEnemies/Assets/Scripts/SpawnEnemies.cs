using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] GameObject enemy;
    private Transform[] points;
    private float startDelay = 2;
    private float spawnInterval = 2;
    private int randomPoint;

    // Start is called before the first frame update
    void Start()
    {
        points = new Transform[path.childCount];

        for (int i = 0; i < path.childCount; i++)
        {
            points[i] = path.GetChild(i);
        }

        InvokeRepeating("SpawnInRandomPlace", startDelay, spawnInterval);
    }

    private void SpawnInRandomPlace() 
    {
        randomPoint = Random.Range(0, path.childCount);

        Vector3 spawnPos = points[randomPoint].position;

        Instantiate(enemy, spawnPos, enemy.transform.rotation);        
    }
}
