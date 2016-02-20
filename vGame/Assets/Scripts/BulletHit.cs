using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) 
	{	
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Bullet") {
			Destroy(coll.gameObject);
			Destroy(gameObject);
		}
	}
}