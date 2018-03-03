﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrowTwo : MonoBehaviour {
	public float timeLeftToShoot = 0f;
	public float arrowPower = 0.0f;
	private const float ARROW_MAX = 10.0f;
	public GameObject arrow;
	public DamageTwoTaken dt;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeLeftToShoot -= Time.deltaTime;
		if (Input.GetKey ("[0]")) {
			if(arrowPower < ARROW_MAX)
				arrowPower += .1f;
			if (arrowPower > ARROW_MAX)
				arrowPower = ARROW_MAX;
		}
		if (Input.GetKeyUp ("[0]") && dt.currentHealth > 0 && timeLeftToShoot <= 0) {
			arrowPower = 0.0f;
			float rot = transform.rotation.y;
			if (rot == 0)
				rot = 1.5f;
			else
				rot = -1.5f;



			Vector3 arrowPos = new Vector3 (transform.position.x + rot, transform.position.y, transform.position.z);
			Instantiate (arrow, arrowPos, transform.rotation);
			timeLeftToShoot = 2.0f;

		}



	}
}