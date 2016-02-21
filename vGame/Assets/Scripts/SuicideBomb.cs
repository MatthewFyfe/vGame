using UnityEngine;
using System.Collections;

public class SuicideBomb : MonoBehaviour {

	private float suicideDistance = 2.5f;
	private GameObject player;
	private GameObject skynet;
	private bool playerInRange;
	private bool skynetInRange;
	private Health health;

	public GameObject bomb;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		skynet = GameObject.FindGameObjectWithTag("Skynet");
		health = transform.root.GetComponentInChildren<Health> ();
		health.onDeathEvent += Death;
	}
	
	// Update is called once per frame
	void Update () {
		playerInRange = false;
		if (player != null) {
			playerInRange = Vector3.Distance (transform.position, player.transform.position) <= suicideDistance;
		}
		skynetInRange = false;
		if (skynet != null) {
			skynetInRange = Vector3.Distance (transform.position, skynet.transform.position) <= suicideDistance;
		}
		if (playerInRange || skynetInRange) {
			health.SendMessage("takeDamage", health.currentHP);
		}
	}

	void Death(){
		Instantiate (bomb, transform.position, transform.rotation);
		Time.timeScale = 0.5f;
		BaseDestroyed baseDestroyed = skynet.GetComponent<BaseDestroyed>();

		baseDestroyed.Invoke("ReturnToNormalTime", 0.2f);
		
	}
}
