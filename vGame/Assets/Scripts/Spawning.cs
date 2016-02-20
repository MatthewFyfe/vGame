using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	//let unity editor decide what we will spawn
	public GameObject whatToSpawn;
	private int x_position = 5, y_position = 5;
	public float spawnInterval = 1;
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
		randomNum_perimiter = Random.Range (0, 399);
		randomNum_wallPosition = Random.Range (-50, 50);

		//we defined the spawn zone as a 100x100 square. 0-99 is the north wall, 100-199 is east, 200-299 is south, 300-399 is west
		if (randomNum_perimiter < 99) {
			y_position = 50;
			x_position = randomNum_wallPosition;
		} else if (randomNum_perimiter < 199) {
			x_position = 50;
			y_position = randomNum_wallPosition;
		} else if (randomNum_perimiter < 299) {
			y_position = -50;
			x_position = randomNum_wallPosition;
		} else {
			x_position = -50;
			y_position = randomNum_wallPosition;
		}

		//actually spawn it
			Instantiate (whatToSpawn, new Vector3 (x_position, y_position, 0), new Quaternion (0, 0, 0, 0));
	}
}
