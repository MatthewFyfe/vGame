using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
	private float speed = 5;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles + new Vector3 (0, speed * Time.deltaTime, 0));
	}
}
