using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int score;
	public int magnets;
	public int bombs;
	public int slows;
	public int lives;
	public float speed;
	private int spd;
	public bool gameOver;
	public GameObject hazard;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text livesText;

	public Text score2Text;
	public Text recordText;
	public GameObject panelRestart;
	public GameObject panelPause;
	public GameObject adMob1;
	private AdMobPlugin adm1;
	public Vector2 sizeScreen;
	public bool pause;
	// Use this for initialization
	void Start () {
		sizeScreen=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height));
		StartCoroutine (SpawnWaves ());
		panelRestart.SetActive(false);
		adm1 = adMob1.GetComponent<AdMobPlugin>();
		UpdateScore ();
		UpdateLives ();
		gameOver = false;
		panelPause.SetActive(false);
		Time.timeScale = 1;
		//StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			pause = !pause;
			if (pause)
			{
				panelPause.SetActive(true);
				Time.timeScale = 0;
				
			}
			else
			{
				Unpause();
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
			{
			//for (int i = 0; i < spd+1; i++)
			//{
				Vector3 spawnPosition = new Vector3 (Random.Range (-sizeScreen.x, sizeScreen.x), sizeScreen.y, 0);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				
			//}

				yield return new WaitForSeconds (spawnWait);
			}
	}

public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		speed = score/50f;

		spawnWait = 1f / ((float)speed+1);
		spd = Mathf.RoundToInt(speed);
	}

public void Unpause ()
	{
		Time.timeScale = 1;
		panelPause.SetActive(false);
		pause = false;
	}

void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

public void DecLive ()
	{

		if (lives > 0)
		{
			lives -= 1;
			UpdateLives ();

		}
		else{
			GameOver();
		}
	}

void UpdateLives ()
	{
		livesText.text = "Lives: " + lives;
	}
public void GameOver ()
	{
		gameOver = true;
		panelRestart.SetActive(true);
		StopAllCoroutines();

		score2Text.text = "Score \n" +score;
		if (PlayerPrefs.GetInt("Record") < score)
		{
			PlayerPrefs.SetInt("Record",score);
			recordText.text = "Record \n" +score;
		}
		else
		{
			recordText.text = "Record \n" +PlayerPrefs.GetInt("Record");
		}

	}
public void Restart ()
	{
		Application.LoadLevel(0);
	}
public void Exit ()
	{
		Application.Quit();
	}
}
