using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);

            Destroy(gameObject);
        }
    }
}
