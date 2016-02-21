﻿using UnityEngine;
using System.Collections;

public class PickUpGunPowerup : MonoBehaviour {

	private Gun powerGun;
	private float pickUpDistance = 1;
	private GameObject player;

	// Use this for initialization
	void Start () {
		powerGun = transform.root.GetComponentInChildren<Gun> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) <= pickUpDistance) {
			Gun[] guns = player.GetComponentsInChildren<Gun>();

			foreach (Gun gun in guns) {
				gun.fireMode = powerGun.fireMode;
				gun.bullet = powerGun.bullet;
				gun.coneDegree = powerGun.coneDegree;
				gun.RPM = powerGun.RPM;
				gun.NumberOfBursts = powerGun.NumberOfBursts;
				gun.TimeBetweenBursts = powerGun.TimeBetweenBursts;
				gun.NumProjectilesFire = powerGun.NumProjectilesFire;
			}

			Destroy (gameObject);
		}
	}
}
