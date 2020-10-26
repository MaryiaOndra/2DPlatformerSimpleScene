using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class AlarmSoundVolume : MonoBehaviour
{
    private float _minVolume = 0.1f;
    private float _maxVolume = 1f;
    private float _targetVolume;
    private float _changeMargin = 0.1f;
    private float _fadeSpeed = 0.6f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {            
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, _targetVolume, Time.deltaTime * _fadeSpeed);
            _audioSource.PlayOneShot(_audioSource.clip);
            CheckSoundVolume();         
        }
        else
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0f, Time.deltaTime * _fadeSpeed);
            _audioSource.Stop();
        }
    }
    
    private void CheckSoundVolume() 
    {
        if (Mathf.Abs(_targetVolume - _audioSource.volume) < _changeMargin)
        {
            if (_targetVolume == _maxVolume)
            {
                _targetVolume = _minVolume;
            }
            else
            {
                _targetVolume = _maxVolume;
            }
        }
    }
}
