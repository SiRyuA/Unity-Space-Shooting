using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public float startWait = 1;
	public float spawnWate = 0.75f;
	public float waveWate = 2;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;
	public GUIText wavelevelText;

	int Score;
	int waveSpawn;
	int waveLevel;
	bool gameover;
	bool restart;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (480, 800, false);

		Score = 0;
		waveSpawn = 0;
		waveLevel = 10;
		restartText.text = "";
		gameoverText.text = "";
		UpdateScore ();
		gameover = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
	}

	public void AddScore(int newScore){
		Score += newScore;
		UpdateScore();
	}

	void UpdateScore(){
		scoreText.text = "Score : " + Score;
		wavelevelText.text = "Wave : " + waveLevel;
	}

	public void GameOver(){
		gameoverText.text = "GAME OVER";
		gameover = true;
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(startWait);

		while (true) {

			if(gameover == true){
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

			waveSpawn += 10;
			++waveLevel;
			
			for (int i=0; i<waveSpawn; ++i) {

				if(gameover == true){
					restartText.text = "Press 'R' for Restart";
					break;
				}

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-5,5), 5, 9.5f);
				Quaternion spawnRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWate);
			}

			yield return new WaitForSeconds (waveWate);

			if(waveLevel == 11){
				gameoverText.text = "GAME CLEAR";
				restartText.text = "Press 'R' for Restart";
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (restart == true) {
			if(Input.GetKeyDown(KeyCode.R)==true){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
