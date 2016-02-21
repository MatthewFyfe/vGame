using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {

	public static int gameScore;

	// Use this for initialization
	void Start () {
		var highScoreObject = GameObject.Find ("HighScoreText");
		highScoreObject.SetActive(false);

		var scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		scoreText.text = "Score: " + gameScore;

		int currentHighScore = -1;
		if (PlayerPrefs.HasKey("HighScore")) {
			currentHighScore = PlayerPrefs.GetInt("HighScore");
		}

		if (gameScore > currentHighScore) {
			PlayerPrefs.SetInt("HighScore", gameScore);
			PlayerPrefs.Save();
			highScoreObject.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
