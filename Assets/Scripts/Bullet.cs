using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public AudioClip hitSound;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hitSound != null && GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().PlayOneShot(hitSound);
    }
}
