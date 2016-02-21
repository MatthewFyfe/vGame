using UnityEngine;
using System.Collections;

public enum FireMode
{
	BurstFire,
	FullAuto,
	SemiAuto
}

public class Gun : ExposableMonobehaviour
{
	public delegate void Delegate_OnShoot (ref Object bullet);
	
	public event Delegate_OnShoot onShootEvent;
	
	[HideInInspector]
	[SerializeField]
	float
		_rpm = 550;
	
	[HideInInspector]
	[SerializeField]
	int
		_numberOfBursts = 1;
	
	[HideInInspector]
	[SerializeField]
	float
		_timeBetweenBursts = 0.1f;
	
	[HideInInspector]
	[SerializeField]
	int
		_numProjectilesFire = 1;
	
	[HideInInspector]
	[SerializeField]
	float
		_rpmMultiplier = 1.0f;
	
	[HideInInspector]
	[SerializeField]
	public bool
		_isBursting;
	public bool isShooting;
	public bool canShoot = true;
	public FireMode fireMode;
	public GameObject bullet;
	public GameObject spawnLocation;
	public float coneDegree = 0f;
	
	[ExposeProperty]
	public float RPM {
		set { _rpm = Mathf.Max (value, 1); }
		get { return _rpm; }
	}
	
	[ExposeProperty]
	public int NumberOfBursts {
		set { _numberOfBursts = Mathf.Max (value, 1); }
		get { return _numberOfBursts; }
	}
	
	[ExposeProperty]
	public float TimeBetweenBursts {
		set { _timeBetweenBursts = Mathf.Max (value, 0.01f); }
		get { return _timeBetweenBursts; }
	}
	
	[ExposeProperty]
	public int NumProjectilesFire {
		set { _numProjectilesFire = value; }
		get { return _numProjectilesFire; }
	}
	
	[ExposeProperty]
	public float RPMMultiplier {
		set { _rpmMultiplier = Mathf.Max (value, 0.1f); }
		get { return _rpmMultiplier; }
	}
	
	[ExposeProperty]
	public bool IsBursting {
		set { }
		get { return _isBursting; }
	}
	
	//Private vars
	private float shootTime;
	private bool semiAutoFired;
	private int burstsFired;
	private float burstFireNext;
	
	public float CalculatedRoundsPerMinute {
		get { return RPM * RPMMultiplier; }
	}
	
	// Update is called once per frame
	void Update ()
	{
		ShootController ();
	}
	
	private float RPMToMilliseconds ()
	{
		return 60 / CalculatedRoundsPerMinute;
	}
	
	public void ShootController ()
	{
		if (burstFireNext <= Time.time && IsBursting) {
			if (burstsFired < NumberOfBursts) {
				burstFireNext = Time.time + TimeBetweenBursts;
				Fire ();
			} else {
				_isBursting = false;
			}
			burstsFired++;
		}
		
		if (isShooting && canShoot) {
			if (shootTime <= Time.time) {
				shootTime = Time.time + RPMToMilliseconds ();
				
				switch (fireMode) {
				case FireMode.FullAuto:
					Fire ();
					break;
				case FireMode.SemiAuto:
					if (semiAutoFired == false) {
						Fire ();
						semiAutoFired = true;
					}
					break;
				case FireMode.BurstFire:
					if (semiAutoFired == false) {
						_isBursting = true;
						burstsFired = 1;
						Fire ();
						burstFireNext = Time.time + TimeBetweenBursts;
						shootTime += (NumberOfBursts * TimeBetweenBursts);
						semiAutoFired = true;
					}
					break;
				}
			}
		} else {
			semiAutoFired = false;
		}
	}
	
	private void Fire ()
	{
		for (int i = 0; i < NumProjectilesFire; i++) {
			
			Quaternion spawnRot = spawnLocation.transform.rotation;
			
			if (coneDegree > 0) {
				Vector3 randomRot = spawnRot.eulerAngles;
				randomRot.z += Random.Range (-(coneDegree / 2), coneDegree / 2);
				spawnRot = Quaternion.Euler (randomRot);
			}
		
			Object inst_bullet = Instantiate (bullet, spawnLocation.transform.position, spawnRot);
			
			if (onShootEvent != null)
				onShootEvent (ref inst_bullet);
		}
	}
}
