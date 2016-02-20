using UnityEngine;
using System.Collections;

public class followUnit : MonoBehaviour
{
	public GameObject unitToFollow;
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (unitToFollow != null) {
			transform.position = new Vector3 (unitToFollow.transform.position.x, unitToFollow.transform.position.y, transform.position.z);
		}	
	}
}
