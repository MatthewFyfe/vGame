using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

	public GameObject[] GunPowerUps;
	public GameObject[] SpecialPowerUps;
	public float spawnInterval = 10;
	public float spawnRadius = 6;

	private float nextSpawn;
	private GameObject Skynet;
	// Use this for initialization
	void Start () {
		nextSpawn = Time.time + spawnInterval;
		Skynet = GameObject.FindGameObjectWithTag ("Skynet");
	}
	
	// Update is called once per frame
	void Update () {
		if (nextSpawn < Time.time) {
			nextSpawn = Time.time + spawnInterval;

			GameObject PowerUp = null;
			if (Random.Range(0, 101) < 50) {
				if (GunPowerUps.Length > 0) {
					PowerUp = GunPowerUps[Random.Range (0, GunPowerUps.Length)];
			    }
			} else if (SpecialPowerUps.Length > 0) {
				PowerUp = SpecialPowerUps[Random.Range (0, SpecialPowerUps.Length)];
			}

			if (PowerUp != null) {
				Vector3 spawn = Skynet.transform.position + new Vector3(
					Random.Range(-spawnRadius, spawnRadius + 1) + 3,
					Random.Range(-spawnRadius, spawnRadius + 1) + 3,
					0);
				
				Instantiate(PowerUp, spawn, PowerUp.transform.rotation);
			}
		}
	}
}
