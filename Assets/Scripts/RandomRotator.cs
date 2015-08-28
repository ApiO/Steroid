using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;

	private Rigidbody _rigidBody;
	
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		_rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
