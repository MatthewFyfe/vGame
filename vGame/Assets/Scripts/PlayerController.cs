using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Health health;
	
	// Use this for initialization
	void Start () {
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += Death;
	}

	void Death() {
		Destroy (gameObject);
	}
}
