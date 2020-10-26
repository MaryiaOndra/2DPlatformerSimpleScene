using UnityEngine;


public class TurnOnAlarm : MonoBehaviour
{
    [SerializeField] private GameObject _alarm;

    private bool alarmOn;

    internal bool AlarmOn => alarmOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            alarmOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            alarmOn = false;
        }
    }
}
