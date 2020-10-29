using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position);

            Destroy(gameObject);
        }
    }
}
