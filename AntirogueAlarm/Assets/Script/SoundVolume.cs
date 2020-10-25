using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    private float minVolume = 0.2f;
    private float maxVolume = 1f;
    private float targetVolume;
    private float changeMargin = 0.1f;

    [SerializeField] private float fadeSpeed;

    private AudioSource audioSource;

    [SerializeField] internal bool soundOn;


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
            Debug.Log("soundOn");
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
