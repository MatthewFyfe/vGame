using UnityEngine;
using System.Collections;

public class GameOverUIEvents : MonoBehaviour {

	public void RestartGame() {
		Application.LoadLevel ("Game");
	}

	public void GoToMainMenu() {
		Application.LoadLevel ("StartScreen");
	}
}
