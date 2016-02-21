using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

	//let unity editor decide what we will spawn
	public GameObject[] whatToSpawn;
	private int spawnX, spawnY;
	private float spawnInterval;
	public bool isSpawning = true;

	public int height;
	public int width;
	private int perimeter;
	private int randomPerimeterDistance;
	private float gameTime;
	private ArrayList spawnWeights = new ArrayList ();
	private float randomFloat; 
	private float lastSpawnTime;
	private float startingSpawnInterval = 1f;

	// Use this for initialization
	void Start ()
	{
		perimeter = 2 * width + 2 * height;
		spawnInterval = startingSpawnInterval;

		var firstHackerSpawnTime = (float) Random.Range (15, 30);  // first hacker spawns after 15-30 seconds
		var hackerSpawnInterval = 30.0f;                           // new hacker attempts to spawn every 30 seconds
		InvokeRepeating ("spawnAHacker", firstHackerSpawnTime, hackerSpawnInterval);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Get time
		gameTime = Time.timeSinceLevelLoad;
		
		// Spawn if its time
		if (gameTime - lastSpawnTime > spawnInterval) {
			spawnAThing ();
			lastSpawnTime = gameTime;
		} 
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

	void spawnAHacker() {
		GameObject existingHacker = GameObject.Find ("The Hacker");

		if (existingHacker == null) {
			randomPerimeterDistance = Random.Range (0, perimeter);
			if (randomPerimeterDistance < width) {
				spawnY = height / 2;
				spawnX = (randomPerimeterDistance) - width / 2;
			} else if ((randomPerimeterDistance - width) < height) {
				spawnX = width / 2;
				spawnY = (randomPerimeterDistance - width) - height / 2;
			} else if ((randomPerimeterDistance - width - height) < width) {
				spawnY = -height / 2;
				spawnX = (randomPerimeterDistance - width - height) - width / 2;
			} else {
				spawnX = -width / 2;
				spawnY = (randomPerimeterDistance - width * 2 - height) - height / 2;
			}

			//actually spawn it
			GameObject hacker = (GameObject)Resources.Load ("Hacker Enemy");
			hacker.name = "The Hacker";
			Instantiate (hacker, new Vector3 (spawnX, spawnY, 0), new Quaternion (0, 0, 0, 0));
		}
	}

	GameObject WhatToSpawn ()
	{
		

		// Get weighted spawn table based on time/score
		// Restrict spawn pool based on time
		// Increase weighting towards more difficult types based on time
		if (gameTime < 10) {
			spawnInterval = startingSpawnInterval;
			spawnWeights = new ArrayList{1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 20) {
			spawnInterval = 0.8f;
			spawnWeights = new ArrayList{0.8f, 0.2f, 0.0f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 30) {
			spawnInterval = 0.6f;
			spawnWeights = new ArrayList{0.6f, 0.2f, 0.2f, 0.0f, 0.0f, 0.0f};
		} else if (gameTime < 50) {
			spawnInterval = 0.5f;
			spawnWeights = new ArrayList{0.4f, 0.2f, 0.2f, 0.2f, 0.0f, 0.01f};
		} else if (gameTime < 90) {
			spawnInterval = 0.4f;
			spawnWeights = new ArrayList{0.2f, 0.2f, 0.2f, 0.2f, 0.18f, 0.02f};
		} else if (gameTime < 120) {
			spawnInterval = 0.3f;
			spawnWeights = new ArrayList{0.15f, 0.15f, 0.2f, 0.2f, 0.25f, 0.05f};
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
