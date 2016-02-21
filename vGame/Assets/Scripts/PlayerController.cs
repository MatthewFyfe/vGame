using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Health health;

	public GameObject RespawnMarker;
	public AudioClip deathSound;
	
	// Use this for initialization
	void Start () {
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += Death;
	}

	void Death() {
		if (deathSound != null) {
			Camera.main.transform.root.GetComponentInChildren<AudioSource> ().PlayOneShot (deathSound);
		}

		Transform playerTransform = transform;
		Instantiate(RespawnMarker, playerTransform.position, playerTransform.rotation);
		Destroy (gameObject);
	}
}
