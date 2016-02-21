using UnityEngine;
using System.Collections;

public class moveVBot : MonoBehaviour
{
	public float moveSpeed = 5.0f; //VBots moveSpeed coefficient
	public bool isBeingHacked = false;
	
	// Update is called once per frame
	void Update ()
	{
		
		float translationX = 0;
		float translationY = 0;
		float distance = Time.deltaTime * moveSpeed;

		var direction = (isBeingHacked ? -1 : 1);

		if (Input.GetKey (KeyCode.W)) {
			translationY += direction;
		}

		if (Input.GetKey (KeyCode.A)) {
			translationX -= direction;
		}

		if (Input.GetKey (KeyCode.S)) {
			translationY -= direction;
		}

		if (Input.GetKey (KeyCode.D)) {
			translationX += direction;
		}
		 
		Vector3 translationVector = new Vector3 (transform.position.x + translationX, 
		                                         transform.position.y + translationY, transform.position.z);

		transform.position = Vector3.MoveTowards (transform.position, translationVector, distance);
	}
}
