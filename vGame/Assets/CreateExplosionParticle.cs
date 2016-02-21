using UnityEngine;
using System.Collections;

public class CreateExplosionParticle : MonoBehaviour
{

	public GameObject Explosion;

	// Use this for initialization
	void Start ()
	{
		Instantiate (Explosion, transform.position, Explosion.transform.rotation);
	}
}
