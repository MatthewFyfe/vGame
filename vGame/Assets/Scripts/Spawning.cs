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
		/*Possible Improvement: define '399' as RectanglePerimeter and define the 4 IF blocks as perimiter/4, p/3, p/2, p
		 * This would allow dynamically changing the spawn rectangle size
		 */
		randomPerimeterDistance = Random.Range (0, perimeter);
		if (randomPerimeterDistance < width) {
			spawnY = height / 2;
			spawnX = randomPerimeterDistance;
		} else if ((randomPerimeterDistance - width) < height) {
			spawnX = width / 2;
			spawnY = randomPerimeterDistance - width;
		} else if ((randomPerimeterDistance - width - height) < width) {
			spawnY = -height / 2;
			spawnX = randomPerimeterDistance - width - height;
		} else {
			spawnX = -width / 2;
			spawnY = randomPerimeterDistance - width * 2 - height;
		}
		
		//actually spawn it
		Instantiate (WhatToSpawn (), new Vector3 (spawnX, spawnY, 0), new Quaternion (0, 0, 0, 0));
	}

	GameObject WhatToSpawn ()
	{
		return whatToSpawn [Random.Range (0, whatToSpawn.Length)];
	}
}
