using UnityEngine;

public class BulletSound : MonoBehaviour
{
    public AudioClip clip;

    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
            Debug.Log($"Collision detected with {collision.gameObject.name}");
            Destroy(gameObject);
        }
    }
}