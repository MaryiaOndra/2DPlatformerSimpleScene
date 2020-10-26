using UnityEngine;

public class TurnOnAlarm : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    
    private bool alarmOn;

    public bool AlarmOn => alarmOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {            
            Debug.Log("ALARM");
            _alarm.gameObject.SetActive(true);
            alarmOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Debug.Log("turn OFF");
            _alarm.gameObject.SetActive(false);
            alarmOn = false;
        }
    }
}
