using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource soundSource;      
    public float maxDistance = 10f;      
    public float baseVolume = 1f;        

    void LateUpdate()
    {
        Vector3 cannonPosition = transform.position;
        Vector3 sourcePosition = soundSource.transform.position;

        float dist = Vector3.Distance(cannonPosition, sourcePosition);

        float deltaX = (cannonPosition.x - sourcePosition.x) / maxDistance;
        deltaX = Mathf.Clamp(deltaX, -1f, 1f);

        float volumeFactor = 1f - dist / maxDistance;
        volumeFactor = Mathf.Clamp(volumeFactor, 0f, 1f);

        soundSource.volume = baseVolume * volumeFactor;

        soundSource.panStereo = deltaX;
    }
}
