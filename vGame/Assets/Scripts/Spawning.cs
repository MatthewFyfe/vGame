using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

	//let unity editor decide what we will spawn
	public GameObject[] whatToSpawn;
	private int spawnX, spawnY;
	public float spawnInterval = 1;
	public bool isSpawning = true;

	public int height;
	public int width;
	private int perimeter;
	private int randomPerimeterDistance;
	private float gameTime;
	private ArrayList spawnWeights = new ArrayList ();
	private float randomFloat; 

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("spawnAThing", 0, spawnInterval);
		perimeter = 2 * width + 2 * height;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//check if isSpawning has been turned off (or on)
	}

	void spawnAThing ()
	{
		/*
		 * Generates a random number that represents a point on the perimeter
		 * Selects the side of the spawn perimeter based on how far along on the perimeter that point is
		 * Fixes the X or Y value to that wall's value
		 * Calculates the other dimension by finding the distance along that wall and offsetting it
		 */
		randomPerimeterDistance = Random.Range (0, perimeter);
		if (randomPerimeterDistance < width) {
			spawnY = height / 2;
			spawnX = (randomPerimeterDistance) - width/2;
		} else if ((randomPerimeterDistance - width) < height) {
			spawnX = width / 2;
			spawnY = (randomPerimeterDistance - width) - height/2;
		} else if ((randomPerimeterDistance - width - height) < width) {
			spawnY = -height / 2;
			spawnX = (randomPerimeterDistance - width - height) - width/2;
		} else {
			spawnX = -width / 2;
			spawnY = (randomPerimeterDistance - width * 2 - height) - height/2;
		}
		
		//actually spawn it
		Instantiate (WhatToSpawn (), new Vector3 (spawnX, spawnY, 0), new Quaternion (0, 0, 0, 0));
	}

	GameObject WhatToSpawn ()
	{
		// Get time
		gameTime = Time.timeSinceLevelLoad;

		// Get weighted spawn table based on time/score
		// Restrict spawn pool based on time
		// Increase weighting towards more difficult types based on time
		if (gameTime < 10) {
			spawnInterval = 0.3f;
			spawnWeights = new ArrayList{1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 20) {
			spawnInterval = 0.5f;
			spawnWeights = new ArrayList{0.8f, 0.2f, 0.0f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 30) {
			spawnInterval = 0.8f;
			spawnWeights = new ArrayList{0.6f, 0.2f, 0.2f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 50) {
			spawnInterval = 1f;
			spawnWeights = new ArrayList{0.4f, 0.2f, 0.2f, 0.2f, 0.0f, 0.01f};
		} else if (gameTime < 90) {
			spawnInterval = 1f;
			spawnWeights = new ArrayList{0.2f, 0.2f, 0.2f, 0.2f, 0.18f, 0.02f};
		} else if (gameTime < 120) {
			spawnInterval = 1f;
			spawnWeights = new ArrayList{0.2f, 0.2f, 0.2f, 0.2f, 0.15f, 0.05f};
		}

		randomFloat = Random.Range (0.0f, 1.0f);
		int i;
		for (i = 0; i <= spawnWeights.Count; i++) {
			if (randomFloat < (float)spawnWeights[i]) {
				break;
			} else {
				randomFloat -= (float)spawnWeights[i];
			}
		}


		// Return random spawn from that table
		return whatToSpawn [i];
	}
}
