using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float ForwardSpeed;
    public float FireRate = 0.5f;
	public float speed;

	private SceneController scene;
    private float _nextFire;
    private Rigidbody _rigidBody;
	private float _sceneRadius;
	private Vector3 _orientation;

    void Start()
    {
        _nextFire = 0.0f;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = new Vector3(0.0f, 0.0f, ForwardSpeed);
		_orientation = Vector3.forward;

		SceneController sceneController = null;
		GameObject sceneControllerObject = GameObject.FindWithTag("SceneController");
		if (sceneControllerObject != null)
		{
			sceneController = sceneControllerObject.GetComponent<SceneController>();
		}
		if (sceneController == null)
		{
			Debug.Log("Cannot find 'SceneController' script");
		}
		_sceneRadius = sceneController.sceneRadius;
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
		if (moveHorizontal != 0) {
			_orientation.y += moveHorizontal;
		}

		var moveVertical = Input.GetAxis("Vertical");
		if (moveVertical != 0) {
			_orientation.x += moveVertical;
		}
				
		_rigidBody.velocity = _orientation * Time.deltaTime * speed;
		//_rigidBody.rotation = Quaternion.Euler(_orientation);

		/*
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        _rigidBody.velocity = movement * Speed;
        _rigidBody.rotation = Quaternion.Euler(movement * -Tilt);
        _rigidBody.position = new Vector3
		(
			Mathf.Clamp(_rigidBody.position.x, -_sceneRadius, _sceneRadius),
			Mathf.Clamp(_rigidBody.position.z, -_sceneRadius, _sceneRadius),
			Mathf.Clamp(_rigidBody.position.z, -_sceneRadius, _sceneRadius)
        );
		 */
    }
}
