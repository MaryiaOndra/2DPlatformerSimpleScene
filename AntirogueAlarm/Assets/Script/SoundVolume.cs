using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    internal bool soundOn;
    internal AudioSource audioSource;

    private float minVolume = 0.1f;
    private float maxVolume = 1f;
    private float targetVolume;
    private float changeMargin = 0.1f;
    private float fadeSpeed = 0.6f;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0f;
    }

    void Update()
    {
        if (soundOn)
        {            
            audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime * fadeSpeed);
            CheckSoundVolume();
        }
        else
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime * fadeSpeed);
        }
    }

    private void CheckSoundVolume() 
    {
        if (Mathf.Abs(targetVolume - audioSource.volume) < changeMargin)
        {
            if (targetVolume == maxVolume)
            {
                targetVolume = minVolume;
            }
            else
            {
                targetVolume = maxVolume;
            }
        }
    }
}
