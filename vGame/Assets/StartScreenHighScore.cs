using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenHighScore : MonoBehaviour {

	public int highScore = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) {
			highScore = PlayerPrefs.GetInt("HighScore");
		}
		
		UpdateHighScoreText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHighScoreText() {
		var highScoreText = GameObject.Find ("HighScoreText").GetComponent<Text>();
		highScoreText.text = "High Score: " + highScore;
	}
}
