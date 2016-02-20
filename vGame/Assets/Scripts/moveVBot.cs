using UnityEngine;
using System.Collections;

public class moveVBot : MonoBehaviour
{
	Vector3 VBot_position = new Vector3 ();
	public float moveSpeed = 5.0f; //VBots moveSpeed coefficient
	
	// Update is called once per frame
	void Update ()
	{
		//check for controls and shit
		VBot_position = new Vector3 ();
		
		float translationX = 0;
		float translationY = 0;
		float distance = Time.deltaTime * moveSpeed;

		if (Input.GetKey (KeyCode.W)) {
			translationY += 1;
		}

		if (Input.GetKey (KeyCode.A)) {
			translationX -= 1;
		}

		if (Input.GetKey (KeyCode.S)) {
			translationY -= 1;
		}

		if (Input.GetKey (KeyCode.D)) {
			translationX += 1;
		}
		 
		Vector3 translationVector = new Vector3 (transform.position.x + translationX, 
		                                         transform.position.y + translationY, 0);

		transform.position = Vector3.MoveTowards (transform.position, translationVector, distance);
	}
}
