using UnityEngine;

public class TurnOnAlarm : MonoBehaviour
{
    [SerializeField] private GameObject alarm;

    private LightIntensity lightIntensity;
    private SoundVolume soundVolume;

    void Start()
    {
        lightIntensity = alarm.GetComponent<LightIntensity>();
        soundVolume = alarm.GetComponent<SoundVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            lightIntensity.alarmOn = true;
            soundVolume.soundOn = true;
            soundVolume.audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            lightIntensity.alarmOn = false;
            soundVolume.soundOn = false;
            soundVolume.audioSource.Stop();
        }
    }
}
