using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float Speed = 5f;
    public float ShootForce = 1000f;
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
            Shoot();

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(soundToPlay);
    }

    void Shoot()
    {
        var bulletInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(FirePoint.forward * ShootForce);
    }
}