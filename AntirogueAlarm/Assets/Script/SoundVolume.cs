using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    private float minVolume = 0.3f;
    private float maxVolume = 1f;
    private float targetVolume;
    private float changeMargin = 0.2f;

    private AudioSource audioSource;

    internal bool soundOn;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (soundOn)
        {            
            audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime);
            CheckSoundVolume();
        }
        else
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime);
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
