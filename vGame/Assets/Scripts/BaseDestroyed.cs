using UnityEngine;
using System.Collections;

public enum DamageLevel
{
	Full,
	ThreeQuarter,
	Half,
	Quarter
}

public class BaseDestroyed : MonoBehaviour
{

	private Health health;
	private playerScore score;
	public GameObject skynetExplosion;
	public GameObject Fire;
	public GameObject[] ThreeQuarterDamage;
	public GameObject[] HalfDamage;
	public GameObject[] QuarterDamage;
	
	private DamageLevel level = DamageLevel.Full;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1F;
		health = transform.root.GetComponentInChildren<Health> ();
		score = GameObject.Find ("HUD_Canvas").GetComponent<playerScore> ();
		health.onDeathEvent += DestroyBase;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float currentHP = health.currentHP;
		float maxHP = health.maxHP;
		
		if (currentHP / maxHP <= 0.25f) {
			if (level != DamageLevel.Quarter) {
				level = DamageLevel.Quarter;
				SpawnFires (QuarterDamage);
			}
		} else if (currentHP / maxHP <= 0.5f) {
			if (level != DamageLevel.Half) {
				level = DamageLevel.Half;
				SpawnFires (HalfDamage);
			}
		} else if (currentHP / maxHP <= 0.755f) {
			if (level != DamageLevel.ThreeQuarter) {
				level = DamageLevel.ThreeQuarter;
				SpawnFires (ThreeQuarterDamage);
			}
		}
		
	}
	
	private void SpawnFires (GameObject[] locations)
	{
		foreach (GameObject location in locations) {
			GameObject fire = (GameObject)Instantiate (Fire, location.transform.position, Fire.transform.rotation);
			fire.transform.parent = location.transform;
		}
	}

	private void DestroyBase ()
	{
		Time.timeScale = 0.5F;
		score.gameOver = true;
		Invoke ("EndGame", 5f);
		Instantiate(skynetExplosion, transform.position, skynetExplosion.transform.rotation);
		gameObject.SetActive (false);
		// Destroy(gameObject);
	}

	private void EndGame ()
	{
		GameOverScore.gameScore = score.points;
		Application.LoadLevel ("GameOver");
	}

	public void ReturnToNormalTime() {
		Time.timeScale = 1f;
	}
}
