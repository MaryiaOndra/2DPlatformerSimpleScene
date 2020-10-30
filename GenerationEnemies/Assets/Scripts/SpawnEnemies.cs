using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _enemy;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(SpawnRandomEnemies());
    }

    private IEnumerator SpawnRandomEnemies() 
    {
        var waitForTwoSec = new WaitForSecondsRealtime(2f);

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_enemy, _points[i].position, _enemy.transform.rotation);

            yield return waitForTwoSec;
        }   
    }
}
