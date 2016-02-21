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
		return whatToSpawn [Random.Range (0, whatToSpawn.Length)];
	}
}
