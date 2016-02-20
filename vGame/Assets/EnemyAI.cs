using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject Player;
	private float speed = 2.5f;
	private Health health;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += OnDeath;
	}
	
	// Update is called once per frame
	void Update () {
		MoveToPlayer ();
	}

	void MoveToPlayer(){
		// Set the rotation
		float rotation = Mathf.Atan2( Player.transform.position.y - transform.position.y,
		                             Player.transform.position.x - transform.position.x ) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3( 0, 0, rotation );

		float distance = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, distance);
	}

	void OnDeath()
	{
		Destroy(gameObject);
	}
}
