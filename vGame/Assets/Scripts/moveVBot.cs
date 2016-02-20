using UnityEngine;
using System.Collections;

public class moveVBot : MonoBehaviour
{
	Vector3 VBot_position = new Vector3 ();
	public int moveSpeed = 1; //VBots moveSpeed coefficient
	
	// Update is called once per frame
	void Update ()
	{
		//check for controls and shit
		VBot_position = new Vector3 ();
		
		float translationX = 0;
		float translationY = 0;
		float distance = Time.deltaTime * moveSpeed;

		if (Input.GetKey (KeyCode.W)) {
			translationY += distance;
		}

		if (Input.GetKey (KeyCode.A)) {
			translationX -= distance;
		}

		if (Input.GetKey (KeyCode.S)) {
			translationY -= distance;
		}

		if (Input.GetKey (KeyCode.D)) {
			translationX += distance;
		}

		transform.position += new Vector3 (translationX, translationY, 0);
	}
}
