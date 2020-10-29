using UnityEngine;

[RequireComponent(typeof (Light))]
public class LightIntensity : MonoBehaviour
{    
    private float _lowIntensity = 0.5f;
    private float _hightIntensity = 5.0f;
    private float _fadeSpeed = 2.0f;
    private float _changeMargin = 0.2f;
    private float _targetIntensity;

    private Light _light;

    private void Start()
    {
        _light = gameObject.GetComponent<Light>();
        _light.intensity = 0f;
        _targetIntensity = _hightIntensity;
    }

    private void Update() 
    {
        Debug.Log(gameObject.activeSelf);

        if (gameObject.activeSelf)
        {
            _light.intensity = Mathf.Lerp(_light.intensity, _targetIntensity, Time.deltaTime * _fadeSpeed);
            CheckTargetIntensity();
        }
        else
        {
            _light.intensity = Mathf.Lerp(_light.intensity, 0f, Time.deltaTime * _fadeSpeed);
        }
    }

    private void CheckTargetIntensity() 
    {
        if (Mathf.Abs(_targetIntensity - _light.intensity) < _changeMargin)
        {
            if (_targetIntensity == _hightIntensity)
            {
                _targetIntensity = _lowIntensity;
            }
            else 
            {
                _targetIntensity = _hightIntensity;
            }
        }
    }
}
