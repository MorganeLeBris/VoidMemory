﻿using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;

	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;

	/// <summary>
	/// x offset for shots
	/// </summary>
	public float shootDecal;

	/// <summary>
	/// AudioSource for shooting sounds
	/// </summary>
	private AudioSource audio;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0.15f;
		if (audio == null) {
			audio = GetComponent<AudioSource>();
		}
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			if(audio != null)
				audio.Play ();

			// Assign position
			Vector3 temppos = transform.position;
			temppos.x += shootDecal;
			shotTransform.position = temppos;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}
		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
