using System;
using UnityEngine;

[Serializable]
public class Boundary
{
    public float XMin, XMax, ZMin, ZMax;
}

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundary Boundary;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float ForwardSpeed;
    public float FireRate = 0.5f;

    private float _nextFire;
    private Rigidbody _rigidBody;

    void Start()
    {
        _nextFire = 0.0f;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = new Vector3(0.0f, 0.0f, ForwardSpeed);
    }
    
    void Update()
    {
        if (!Input.GetButton("Fire1") || !(Time.time > _nextFire)) return;

        _nextFire = Time.time + FireRate;

        GetComponent<AudioSource>().Play();
        Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        _rigidBody.velocity = movement * Speed;
        _rigidBody.rotation = Quaternion.Euler(movement * -Tilt);
        /*
        _rigidBody.position = new Vector3
        (
            Mathf.Clamp(_rigidBody.position.x, Boundary.XMin, Boundary.XMax),
            0.0f,
            Mathf.Clamp(_rigidBody.position.z, Boundary.ZMin, Boundary.ZMax)
        );
        */
    }
}
