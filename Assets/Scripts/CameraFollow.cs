using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 targetCamPos = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
