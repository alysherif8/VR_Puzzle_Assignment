using UnityEngine;

public class OriginalPosition : MonoBehaviour
{
    public Vector3 startPosition;
    public Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
}
