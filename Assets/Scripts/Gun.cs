using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float Speed = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot()
    {
        var bulletInstance = Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
    }

}
