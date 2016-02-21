using UnityEngine;
using System.Collections;

public class BaseDestroyed : MonoBehaviour {

	private Health health;
	private playerScore score;

	// Use this for initialization
	void Start () {
		health = transform.root.GetComponentInChildren<Health>();
		score = GameObject.Find ("HUD_Canvas").GetComponent<playerScore> ();
		health.onDeathEvent += DestroyBase;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void DestroyBase()
	{
		score.gameOver = true;
		Invoke("EndGame", 3.0f);
		gameObject.SetActive(false);
		// Destroy(gameObject);
	}

	private void EndGame()
	{
		GameOverScore.gameScore = score.points;
		Application.LoadLevel ("GameOver");
	}
}
