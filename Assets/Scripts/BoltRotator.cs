using UnityEngine;
using System.Collections;

public class BoltRotator : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.angularVelocity = new Vector3(0.0f, 0.0f, speed);
    }
}
