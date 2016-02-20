using UnityEngine;
using System.Collections;

public class bulletAI : MonoBehaviour
{

	public float bulletSpeed = 0.5f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, bulletSpeed * Time.deltaTime, 0);
	}
}
