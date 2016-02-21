using UnityEngine;
using System.Collections;

public enum EnemyBehaviour
{
	MoveToPlayer,
	MoveToBase,
	MoveToClosest
}

public class EnemyAI : MonoBehaviour
{

	public EnemyBehaviour behaviour = EnemyBehaviour.MoveToClosest;
	public int preferredDistance = 10;
	public int shootingDistance = 15;
	public bool runsFromPlayer = false;
	public float speed = 2.5f;
	public int pointValue = 1;

	private GameObject Player;
	private GameObject Skynet;
	private Health health;
	private Gun gun;
	private GameObject target;

	private playerScore score;
	private Animator humanAnimator;
	public AudioClip[] deathSound;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		Skynet = GameObject.FindGameObjectWithTag ("Skynet");
		gun = transform.root.GetComponentInChildren<Gun> ();
		health = transform.root.GetComponentInChildren<Health> ();
		humanAnimator = transform.root.GetComponentInChildren<Animator> ();
		health.onDeathEvent += OnDeath;
		score = GameObject.Find ("HUD_Canvas").GetComponent<playerScore> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		switch (behaviour) {
		case EnemyBehaviour.MoveToPlayer:
			target = Player;
			if (Player == null) {
				target = Skynet;
			}
			break;
		case EnemyBehaviour.MoveToBase:
			target = Skynet;
			break;
		case EnemyBehaviour.MoveToClosest:
			target = DetermineClosestUnit ();
			break;
		}

		if (target != null) {
			MoveToUnit ();
			
			float distanceFromTarget = Vector3.Distance (transform.position, target.transform.position);
			if (gun != null) {
				gun.isShooting = distanceFromTarget <= shootingDistance;
			}
		}
	}

	void MoveToUnit ()
	{
		// Set the rotation
		float rotation = Mathf.Atan2 (target.transform.position.y - transform.position.y,
		                             target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, rotation);

		float distance = Time.deltaTime * speed;
		float distanceFromTarget = Vector3.Distance (transform.position, target.transform.position);
		if (distanceFromTarget >= preferredDistance) {
			if (humanAnimator != null) {
				humanAnimator.SetBool ("isMoving", true);
			}
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, distance);
		} else if (runsFromPlayer) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, -distance);
		} else {
			if (humanAnimator != null) {
				humanAnimator.SetBool ("isMoving", false);
			}
		}
	}

	GameObject DetermineClosestUnit ()
	{
		Vector3 playerPosition, skynetPostion;
		float playerDistance = 0, skynetDistance = 0;
		if (Player != null) {
			playerPosition = Player.transform.position;
			playerDistance = Vector3.Distance (transform.position, playerPosition);
		}
		if (Skynet != null) {
			skynetPostion = Skynet.transform.position;
			skynetDistance = Vector3.Distance (transform.position, skynetPostion);
		}

		if (playerDistance > skynetDistance) {
			return Skynet;
		} else {
			if (Player != null) {
				return Player;
			} else {
				return Skynet;
			}
		}
	}

	void OnDeath ()
	{
		if (deathSound != null && Player != null) {
			Player.transform.root.GetComponentInChildren<AudioSource> ().PlayOneShot (
				deathSound[Random.Range (0, deathSound.Length)]
			);
		}
		//give the player who killed this enemy a point, and remove the enemy
		score.points += pointValue;
		Destroy (gameObject);
	}
}
