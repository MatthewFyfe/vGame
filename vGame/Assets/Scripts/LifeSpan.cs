using UnityEngine;
using System.Collections;

public class LifeSpan : MonoBehaviour
{
	public float seconds = 5;
	private float timeOfDeath;

	void Start ()
	{
		timeOfDeath = Time.time + seconds;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > timeOfDeath) {
			Destroy (gameObject);
		}
	}
}
