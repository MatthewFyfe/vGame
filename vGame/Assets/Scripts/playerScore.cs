using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerScore : MonoBehaviour {

	public int points = 0;
	public bool gameOver = false;

	float startTime, survivalTime;
	int minutes, seconds;

	public Text scoreText;
	public Text clockText;

	// Use this for initialization
	void Start () {
		//track players game time and kills
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			//track a live clock and scoreboard
			scoreText.text = "Score: " + points.ToString ();

			//get current game time in minutes:seconds
			survivalTime = Time.time - startTime;
			minutes = (int)survivalTime / 60;
			seconds = (int)survivalTime % 60;
			clockText.text = minutes.ToString ("00") + ':' + seconds.ToString ("00");
		}
	}
}
