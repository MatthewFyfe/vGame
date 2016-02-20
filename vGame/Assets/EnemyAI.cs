using UnityEngine;
using System.Collections;

public enum EnemyBehaviour {
	MoveToPlayer,
	MoveToBase,
	MoveToClosest
}

public class EnemyAI : MonoBehaviour {

	public EnemyBehaviour behaviour = EnemyBehaviour.MoveToClosest;

	private GameObject Player;
	private GameObject Skynet;
	private float speed = 2.5f;
	private Health health;

	public int pointValue = 1;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Skynet = GameObject.FindGameObjectWithTag("Skynet");
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += OnDeath;
	}
	
	// Update is called once per frame
	void Update () {
		switch (behaviour) {
		case EnemyBehaviour.MoveToPlayer:
			MoveToPlayer ();
			break;
		case EnemyBehaviour.MoveToBase:
			MoveToBase ();
			break;
		case EnemyBehaviour.MoveToClosest:
			MoveToClosest ();
			break;
		}

	}

	void MoveToPlayer(){
		// Set the rotation
		float rotation = Mathf.Atan2( Player.transform.position.y - transform.position.y,
		                             Player.transform.position.x - transform.position.x ) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3( 0, 0, rotation );

		float distance = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, distance);
	}

	void MoveToBase(){
		// Set the rotation
		float rotation = Mathf.Atan2( Skynet.transform.position.y - transform.position.y,
		                             Skynet.transform.position.x - transform.position.x ) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3( 0, 0, rotation );
		
		float distance = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, Skynet.transform.position, distance);
	}

	void MoveToClosest(){
		var playerDistance = Vector3.Distance (transform.position, Player.transform.position);
		var skynetDistance = Vector3.Distance (transform.position, Skynet.transform.position);

		if (playerDistance > skynetDistance) {
			MoveToBase ();
		} else {
			MoveToPlayer();
		}
	}

	void OnDeath()
	{
		//give the player who killed this enemy a point, and remove the enemy
		playerScore.points += pointValue;
		Destroy(gameObject);
	}
}
