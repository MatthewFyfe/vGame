using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	//let unity editor decide what we will spawn
	public GameObject whatToSpawn;
	private int x_position, y_position;
	public float spawnInterval = 1;
	public int spawnRadius = 100;
	public bool isSpawning = true;

	private int randomNum_perimiter, randomNum_wallPosition;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnAThing", 0, spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		//check if isSpawning has been turned off (or on)
	}

	void spawnAThing()
	{
		/*Possible Improvement: define '399' as RectanglePerimeter and define the 4 IF blocks as perimiter/4, p/3, p/2, p
		 * This would allow dynamically changing the spawn rectangle size
		 */

		//define the rectangle spawn and choose the X/Y position to spawn inb (set range in game world which is 80x80)
		randomNum_perimiter = Random.Range (0, spawnRadius);
		//randomize along the length of one side of the rectangle
		randomNum_wallPosition = Random.Range ((-1 * spawnRadius/2), spawnRadius/2);

		/*we defined the spawn zone as a square. the first quarter is the north wall(1/4), second quarter is east(2/4 or 1/2),
		third quarter is south(3/4 or 0.75), fourth quarter is west */
		if (randomNum_perimiter < spawnRadius/4) {
			y_position = spawnRadius/2;
			x_position = randomNum_wallPosition;
		} else if (randomNum_perimiter < spawnRadius/2) {
			x_position = spawnRadius/2;
			y_position = randomNum_wallPosition;
		} else if (randomNum_perimiter < spawnRadius * 0.75) {
			y_position = -1 * spawnRadius/2;
			x_position = randomNum_wallPosition;
		} else {
			x_position = -1 * spawnRadius/2;
			y_position = randomNum_wallPosition;
		}

		//actually spawn it
			Instantiate (whatToSpawn, new Vector3 (x_position, y_position, 0), new Quaternion (0, 0, 0, 0));
	}
}
