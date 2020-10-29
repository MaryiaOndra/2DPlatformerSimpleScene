using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Light))]

public class Alarm : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
