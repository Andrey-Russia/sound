using UnityEngine;

public class GunAD : MonoBehaviour
{
    public float Speed = 5f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
