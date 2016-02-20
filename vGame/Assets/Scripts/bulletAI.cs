using UnityEngine;
using System.Collections;

public class bulletAI : MonoBehaviour
{

	public float bulletSpeed = 0.5f;
	public int bulletDamage = 1;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, bulletSpeed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{	
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Bullet" && 
		    coll.gameObject.tag != "Obstacle" && coll.gameObject.tag != "Skynet") {
			
			//Destroy(coll.gameObject);
			
			//apply damage to the objects via health (check the bullets damage, apply to enemies health)
			if(coll.GetComponent<Health>())
			{
				coll.SendMessage("takeDamage", bulletDamage);
			}
			//erase bullet
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Skynet") {
			Destroy(gameObject);
		}
	}
}
