﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float maxSpeed = 10;
	public float jumpTakeOffSpeed = 13;


	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		float currentRotation = transform.rotation.y;
		Debug.Log (currentRotation);
		if (currentRotation == 0) {
			rb.velocity = new Vector2 (15, 10);
		} else if (currentRotation == -1) {
			rb.velocity = new Vector2 (-15, 10);
		}

	}

	void OnTriggerEnter2D (Collider2D collider){

		Destroy (gameObject);
	}
		

}
