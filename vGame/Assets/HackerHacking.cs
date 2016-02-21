using UnityEngine;
using System.Collections;

public class HackerHacking : MonoBehaviour {

	public float hackingDistance = 15;
	
	private GameObject Player;
	private GameObject Skynet;
	private Health hackerHealth;

	public AudioClip hackingSound;
	
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
				moveVBot move = Player.transform.root.GetComponent<moveVBot>();
				if (move.isBeingHacked == false) {
					move.isBeingHacked = true;
					if (hackingSound != null) {
						Camera.main.transform.root.GetComponentInChildren<AudioSource>().PlayOneShot(hackingSound);
					}
				}
			}
		}
	}

	void StopHacking() {
		if (Player != null) {
			Player.GetComponent<moveVBot> ().isBeingHacked = false;
		}
	}
}
