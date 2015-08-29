using UnityEngine;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public int scoreValue;

    private GameController _gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (_gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Asteroid") {
			return;
		}
		
		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
            _gameController.GameOver();
		}

        _gameController.AddScore(scoreValue);
        Destroy (other.gameObject);
		Destroy (gameObject);
	}
}