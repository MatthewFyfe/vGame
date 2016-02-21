using UnityEngine;
using System.Collections;

public class HackerHacking : MonoBehaviour {

	public float hackingDistance = 15;
	
	private GameObject Player;
	private GameObject Skynet;
	private Health hackerHealth;
	
	void Start ()
	{
		hackerHealth = transform.root.GetComponentInChildren<Health> ();
		hackerHealth.onDeathEvent += StopHacking;
		Player = GameObject.FindGameObjectWithTag ("Player");
		Skynet = GameObject.FindGameObjectWithTag ("Skynet");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Skynet != null  && Player != null) {
			if (Vector3.Distance (transform.position, Skynet.transform.position) <= hackingDistance) {
				Player.GetComponent<moveVBot>().isBeingHacked = true;
			}
		}
	}

	void StopHacking() {
		Player.GetComponent<moveVBot>().isBeingHacked = false;
	}
}
