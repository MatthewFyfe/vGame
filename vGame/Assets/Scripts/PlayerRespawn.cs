using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	private float respawnDelay = 3;
	private float TimeTillRespawn;

	public GameObject respawnObject;
	public GameObject spawnEffects;
	public AudioClip respawnSound;

	// Use this for initialization
	void Start () {
		Instantiate(spawnEffects, transform.position, spawnEffects.transform.rotation);
		TimeTillRespawn = Time.time + respawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeTillRespawn < Time.time) {
			GameObject player = (GameObject)Instantiate(respawnObject, transform.position, transform.rotation);
			player.transform.root.GetComponentInChildren<Health>().currentHP = 150;

			if (respawnSound != null) {
				player.transform.root.GetComponentInChildren<AudioSource> ().PlayOneShot (respawnSound);
			}

			Destroy (gameObject);
		}
	}
}
