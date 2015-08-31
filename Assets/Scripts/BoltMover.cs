using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;

    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();

        rigidBody.velocity = transform.forward * MoveSpeed;
        rigidBody.angularVelocity = new Vector3(0.0f, 0.0f, RotationSpeed);
    }
}