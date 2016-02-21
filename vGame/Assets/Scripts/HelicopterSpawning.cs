using UnityEngine;
using System.Collections;

public class HelicopterSpawning : MonoBehaviour {

	public GameObject SpawnType;
	public float spawnInterval = 5f;
	public float spawnAmmount = 6;
	public float spawnDistance = 25;

	private GameObject Skynet;
	private float spawnTime = 0f;

	void Start() {
		Skynet = GameObject.FindGameObjectWithTag("Skynet");
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, Skynet.transform.position) <= spawnDistance) {
			if (spawnTime < Time.time) {
				for (int i = 0; i < spawnAmmount; i++) {
					Vector3 newPosition = new Vector3(
						transform.position.x + Random.Range (-0.5f, 0.6f), 
						transform.position.y + Random.Range (-0.5f, 0.6f), 
						0);
					Instantiate (SpawnType, newPosition, transform.rotation);
				}
				spawnTime = Time.time + spawnInterval;
			}
		}
	}
}
