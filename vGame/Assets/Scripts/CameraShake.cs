using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	
	// How long the object should shake for.
	public float shakeTime = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.5f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;

	void Start()
	{
		originalPos = transform.position;
	}
	
	void Update()
	{
		if (shakeTime > 0)
		{
			transform.position = originalPos + Random.insideUnitSphere * shakeAmount * Random.Range(0.2f, 0.8f);
			
			shakeTime -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeTime = 0f;
			transform.position = originalPos;
		}
	}
}