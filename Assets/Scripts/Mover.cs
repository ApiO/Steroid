using UnityEngine;

public class Mover : MonoBehaviour 
{
	public float speed;
	private Rigidbody _rigidBody;
	
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody> ();
		_rigidBody.velocity = (new Vector3(Random.Range(-1, 1), 
		                                  Random.Range(-1, 1),
		                                  Random.Range(-1, 1))).Normalize() * speed;
	}
}
