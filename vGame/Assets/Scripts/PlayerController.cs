using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Health health;

	public GameObject RespawnMarker;
	
	// Use this for initialization
	void Start () {
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += Death;
	}

	void Death() {
		Transform playerTransform = transform;
		Instantiate(RespawnMarker, playerTransform.position, playerTransform.rotation);
		Destroy (gameObject);
	}
}
