using UnityEngine;

public class Mover : MonoBehaviour 
{
	public float speed;
	private Rigidbody _rigidBody;
	
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody> ();

		_rigidBody.velocity = transform.forward * speed;
	}
}
