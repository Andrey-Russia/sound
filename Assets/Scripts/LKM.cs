using UnityEngine;

public class LKM : MonoBehaviour
{
    public AudioClip soundToPlay;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (soundToPlay != null)
            audioSource.clip = soundToPlay;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(soundToPlay);
    }
}
