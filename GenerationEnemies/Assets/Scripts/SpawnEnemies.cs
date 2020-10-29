using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _enemy;

    private Transform[] _points;
    private float _startDelay = 2;
    private float _spawnInterval = 2;
    private int _randomPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        InvokeRepeating("SpawnInRandomPlace", _startDelay, _spawnInterval);
    }

    private void SpawnInRandomPlace() 
    {
        _randomPoint = Random.Range(0, _path.childCount);

        Vector3 spawnPos = _points[_randomPoint].position;

        Instantiate(_enemy, spawnPos, _enemy.transform.rotation);        
    }
}
