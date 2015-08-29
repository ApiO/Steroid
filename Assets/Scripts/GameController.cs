using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool _gameOver;
    private bool _restart;
    private int _score;

	void Start()
    {
        _gameOver = false;
        _restart = false;
        restartText.text = string.Empty;
        gameOverText.text = string.Empty;

        _score = 0;
	    UpdateScore();

		StartCoroutine (SpawnWaves());
	}

    void Update()
    {
        if (_restart && Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while (true) 
		{
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate(hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);

		    if (_gameOver)
		    {
		        restartText.text = "Press 'Enter' to restart";
		        _restart = true;
		        break;
		    }
		}
	}

    public void AddScore(int value)
    {
        _score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        _gameOver = true;
    }
}