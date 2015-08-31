using UnityEngine;

public class EngineFlameRotator : MonoBehaviour
{
    public float speed;
    
    // Use this for initialization
    void Update ()
    {
        transform.rotation *= Quaternion.Euler(0.0f, speed * Time.deltaTime, 0.0f);
    }
}
