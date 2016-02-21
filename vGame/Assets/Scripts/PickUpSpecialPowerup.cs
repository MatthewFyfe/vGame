﻿using UnityEngine;
using System.Collections;

public class PickUpSpecialPowerup : MonoBehaviour {
	private float pickUpDistance = 1;
	private GameObject player;

	public float RPMMultIncrease;
	public float MovementSpeedIncrease;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			if (Vector3.Distance (transform.position, player.transform.position) <= pickUpDistance) {
				Gun[] guns = player.GetComponentsInChildren<Gun> ();
				
				foreach (Gun gun in guns) {
					gun.RPMMultiplier += RPMMultIncrease;
				}

				if (MovementSpeedIncrease > 0) {
					player.transform.root.GetComponentInChildren<moveVBot>().moveSpeed += MovementSpeedIncrease;
				}
				
				Destroy (gameObject);
			}
		}
	}
}
