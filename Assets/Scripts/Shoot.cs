using UnityEngine;

public class Shootf: MonoBehaviour
{
    public GameObject bulletPrefab;    
    public Transform gunTransform;       
    public float moveSpeed = 5f;         
    public AudioClip shootSound;       
    public AudioClip hitSound;          
    public AudioSource audioSource;     

    void Start()
    {
        audioSource.spatialBlend = 1f;                
        audioSource.minDistance = 1f;                 
        audioSource.maxDistance = 50f;                  
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic; 
    }

    void Update()
    {
        HandleMovement();
        FireBullets();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
    }

    void FireBullets()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity); 
            PlayShootSound(); 
        }
    }

    void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }
}