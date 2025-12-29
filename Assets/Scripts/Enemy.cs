using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public string TargetTag = "Player";      
    public float DetectionRadius = 10f;    
    public float MoveSpeed = 3f;              
    public LayerMask detectionLayer;
    public AudioClip deathSound;
    private AudioSource audioSource;

    private Transform target;                 
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FindNearestPlayer();
        FollowTarget();
    }

    void FindNearestPlayer()
    {
        Collider[] playersInRange = Physics.OverlapSphere(transform.position, DetectionRadius, detectionLayer);

        foreach (var collider in playersInRange)
        {
            if (collider.CompareTag(TargetTag))
            {
                target = collider.transform;
                return;
            }
        }
        target = null;
    }

    void FollowTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            rigidbody.MovePosition(transform.position + direction.normalized * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
                Invoke("DelayedDestroy", deathSound.length); 
            }
            else
                Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
