using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	private float respawnDelay = 3;
	private float TimeTillRespawn;

	public GameObject respawnObject;

	// Use this for initialization
	void Start () {
		TimeTillRespawn = Time.time + respawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeTillRespawn < Time.time) {
			GameObject player = (GameObject)Instantiate(respawnObject, transform.position, transform.rotation);
			player.transform.root.GetComponentInChildren<Health>().currentHP = 150;
			Destroy (gameObject);
		}
	}
}
