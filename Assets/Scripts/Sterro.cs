using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource source;
    public float maxDistance = 10f;

    void LateUpdate()
    {
        float xPos = transform.position.x / maxDistance;

        xPos = Mathf.Clamp(xPos, -1f, 1f);
        source.panStereo = xPos;
    }
}
