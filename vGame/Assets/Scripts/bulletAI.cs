using UnityEngine;
using System.Collections;

public enum BulletType {
	Friendly,
	Hostile,
	Neutral
}

public class bulletAI : MonoBehaviour
{
	public BulletType bulletType = BulletType.Friendly;
	public float bulletSpeed = 0.5f;
	public int bulletDamage = 1;
	public bool piercing = false;
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, bulletSpeed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{	
		if (coll.gameObject.tag == "Bullet") { 

		} else if (coll.gameObject.tag == "Obstacle") {
			collide (coll);
		} else if (bulletType == BulletType.Friendly) {
			if (coll.gameObject.tag == "Enemy") {
				collide (coll);
			}
		} else if (bulletType == BulletType.Hostile) {
			if (coll.gameObject.tag != "Enemy") {
				collide (coll);
			}
		} else {
			collide (coll);
		}
	}

	void collide(Collider2D other) {
		//apply damage to the objects via health (check the bullets damage, apply to enemies health)
		if(other.GetComponent<Health>())
		{
			other.SendMessage("takeDamage", bulletDamage);
		}
		//erase bullet
		if (!piercing) {
			Destroy(gameObject);
		}
	}
}
