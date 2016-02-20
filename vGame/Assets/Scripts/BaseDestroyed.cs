using UnityEngine;
using System.Collections;

public class BaseDestroyed : MonoBehaviour {

	private Health health;

	// Use this for initialization
	void Start () {
		health = transform.root.GetComponentInChildren<Health>();
		health.onDeathEvent += DestroyBase;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void DestroyBase()
	{
		Destroy(gameObject);
		// SceneManager.LoadScene ("Base");
	}
}
