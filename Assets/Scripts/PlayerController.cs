using System;
using UnityEngine;

[System.Serializable]
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

    public float FireRate = 0.5f;

    private float _nextFire;
    private Rigidbody _rigidBody;
    private readonly Vector3 _yRot = new Vector3(0.0f, 1.0f, 0.0f);

    private enum FireType
    {
        Raw, Spray
    }

    private FireType _fireType;

    void Start()
    {
        _fireType = FireType.Spray;
        _nextFire = 0.0f;
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _fireType = _fireType == FireType.Spray ? FireType.Raw : FireType.Spray;
        }

        if (!Input.GetButton("Fire1") || !(Time.time > _nextFire)) return;

        _nextFire = Time.time + FireRate;
		GetComponent<AudioSource>().Play ();
        
		if (_fireType == FireType.Spray)
        {
            Instantiate(Shot, ShotSpawn.position, Quaternion.AngleAxis(10.0f, _yRot));
            Instantiate(Shot, ShotSpawn.position, Quaternion.AngleAxis(5.0f, _yRot));

            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);

            Instantiate(Shot, ShotSpawn.position, Quaternion.AngleAxis(-5.0f, _yRot));
            Instantiate(Shot, ShotSpawn.position, Quaternion.AngleAxis(-10.0f, _yRot));
        }
        else
        {
            const float offset = 0.2f;

            var pos = ShotSpawn.position;
            pos.x -= offset * 2;

            for (var i = 0; i < 5; i++)
            {
                Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
                pos.x += offset;
            }
        }
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidBody.velocity = movement * Speed;
        _rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidBody.velocity.x * -Tilt);
        _rigidBody.position = new Vector3
        (
            Mathf.Clamp(_rigidBody.position.x, Boundary.XMin, Boundary.XMax),
            0.0f,
            Mathf.Clamp(_rigidBody.position.z, Boundary.ZMin, Boundary.ZMax)
        );
    }
}
