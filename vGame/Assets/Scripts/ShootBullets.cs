using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour
{
	public KeyCode fire;

	private Gun gunScript;
	
	void Start ()
	{
		gunScript = transform.GetComponentInChildren<Gun> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		gunScript.isShooting = Input.GetKey (fire);
	}
}
