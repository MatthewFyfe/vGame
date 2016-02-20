using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) 
	{	
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Bullet" && coll.gameObject.tag != "Obstacle") {

			//Destroy(coll.gameObject);

			//apply damage to the objects via health (check the bullets damage, apply to enemies health)


			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Obstacle") {
			Destroy(gameObject);
		}
	}
}