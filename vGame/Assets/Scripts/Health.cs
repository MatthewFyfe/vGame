using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public delegate void Delegate_OnDeath ();
	
	public event Delegate_OnDeath onDeathEvent;

	public int currentHP, maxHP;
	private float HP_DepleteTime = 1;
	private bool isDraining = false;

	public float timeToFlash = -1;

	private Color originalColor;
	private Renderer[] renderers;

	// Use this for initialization
	void Start () {
		renderers = transform.root.GetComponentsInChildren<Renderer> ();
		originalColor = renderers[0].material.color;
	}
	
	// Update is called once per frame
	void Update () {
		//if currentHP is zero (or lower) kill the gameObject
		if (currentHP <= 0) {
			//play a death animation?

			//poof it's gone
			//Destroy(gameObject);
			if (onDeathEvent != null)
				onDeathEvent ();
		}

		//if currentHP is > maxHP, deplete HP down to max
		if (currentHP > maxHP && !isDraining) {
			//runs the DepleteHP function once per second, starting immediately
			InvokeRepeating ("depleteHP", 0, HP_DepleteTime);
			isDraining = true;
		} 

		//if currentHP is <= maxHP, stop draining (if it is)
		if (currentHP <= maxHP && isDraining) {
			//stop all invoke instances of DepleteHP
			CancelInvoke("depleteHP");
			isDraining = false;
		}

		if (timeToFlash != -1) {
			if (timeToFlash < Time.time) {
				foreach (Renderer r in renderers) {
					r.material.color = originalColor;
				}
			}
		}
	}

	//TODO: make this run with takeDamage instaed, (doesnt work with invoke though)
	void depleteHP()
	{
		currentHP -= 1;
	}

	void takeDamage(int x)
	{
		currentHP -= x;

		Flasher(); 
	}

	void Flasher() 
	{
		foreach (Renderer r in renderers) {
			r.material.color = Color.red;
		}
		timeToFlash = Time.time + 0.05f;
	}
}
