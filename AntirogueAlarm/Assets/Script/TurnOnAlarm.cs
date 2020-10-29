using UnityEngine;

public class TurnOnAlarm : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {            
            _alarm.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _alarm.gameObject.SetActive(false);
        }
    }
}
