using UnityEngine;
using System.Collections;

public class UIEvents : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel ("Game");
	}

	public void ResetHighScore() {
		if (PlayerPrefs.HasKey("HighScore")) {
			PlayerPrefs.DeleteKey("HighScore");
		}
		var startScreenHighScore = GameObject.Find("StartScreenHighScore").GetComponent<StartScreenHighScore>();
		startScreenHighScore.highScore = 0;
		startScreenHighScore.UpdateHighScoreText();
	}
}
