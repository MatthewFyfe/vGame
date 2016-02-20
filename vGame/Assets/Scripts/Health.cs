using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int currentHP, maxHP;
	private float HP_DepleteTime = 1;
	private bool isDraining = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//if currentHP is zero (or lower) kill the gameObject
		if (currentHP <= 0) {
			//play a death animation?

			//poof it's gone
			Destroy(gameObject);
		}

		//if currentHP is > maxHP, deplete HP down to max
		if (currentHP > maxHP && !isDraining) {
			//runs the DepleteHP function once per second, starting immediately
			InvokeRepeating ("DepleteHP", 0, HP_DepleteTime);
			isDraining = true;
		} 

		//if currentHP is <= maxHP, stop draining (if it is)
		if (currentHP <= maxHP && isDraining) {
			//stop all invoke instances of DepleteHP
			CancelInvoke("DepleteHP");
			isDraining = false;
		}
	}
	
	void takeDamage()
	{
		currentHP -= 1;
	}

	void takeDamage(int x)
	{
		currentHP -= x;
	}
}
