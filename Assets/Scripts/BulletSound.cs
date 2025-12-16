using UnityEngine;
using UnityEngine.Audio;

public class BulletSound : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(clip);
    }
}
