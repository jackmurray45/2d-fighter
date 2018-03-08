using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateFireBalls : MonoBehaviour {
	public float timeLeftToShoot = 0f;
	public float timeLeftToChangeArcher = 5f;
	public GameObject fireBall;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeftToShoot -= Time.deltaTime;
		timeLeftToChangeArcher -= Time.deltaTime;
		if (Time.timeScale != 0 && timeLeftToShoot <= 0 && DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			float rot = transform.rotation.y;
			if (rot == 0)
				rot = 1.25f;
			else
				rot = -1.25f;

			Vector3 firePos = new Vector3(transform.position.x + rot, transform.position.y, transform.position.z);

			Instantiate (fireBall, firePos, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.position.z));
			timeLeftToShoot = 1f;


		}

		if (timeLeftToChangeArcher <= 0) {
			if (FireBall.currentArcher == 1) {
				FireBall.currentArcher = 2;
			} else {
				FireBall.currentArcher = 1;
			}
			timeLeftToChangeArcher = 5f;
		}



		
	}
}
