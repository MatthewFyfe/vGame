﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {

	public static int gameScore;

	public bool isHighScore = false;

	// Use this for initialization
	void Start () {
		var scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		scoreText.text = "Score: " + gameScore;

		int currentHighScore = -1;
		if (PlayerPrefs.HasKey("HighScore")) {
			currentHighScore = PlayerPrefs.GetInt("HighScore");
		}

		if (gameScore > currentHighScore) {
			isHighScore = true;
			PlayerPrefs.SetInt("HighScore", gameScore);
			PlayerPrefs.Save();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
