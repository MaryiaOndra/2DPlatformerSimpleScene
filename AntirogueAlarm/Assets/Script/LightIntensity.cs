using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    internal bool alarmOn;

    private float lowIntensity = 0.5f;
    private float hightIntensity = 5.0f;
    private float fadeSpeed = 2.0f;
    private float changeMargin = 0.2f;
    private float targetIntensity;
    private Light light;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
        light.intensity = 0f;
        targetIntensity = hightIntensity;
    }

    private void Update() 
    {
        if (alarmOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, Time.deltaTime * fadeSpeed);
            CheckTargetIntensity();
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0f, Time.deltaTime * fadeSpeed);
        }
    }

    private void CheckTargetIntensity() 
    {
        if (Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
        {
            if (targetIntensity == hightIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else 
            {
                targetIntensity = hightIntensity;
            }
        }
    }
}
