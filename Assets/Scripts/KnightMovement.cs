using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : PhysicsObject {
	public float timeBetweenAttacks;
	private bool archer1;
	private Transform target;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		int currentArcher = Random.Range (0, 2);
		if (currentArcher == 0) {
			archer1 = true;
		} else if (currentArcher == 1) {
			archer1 = false;
		}

		timeBetweenAttacks = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {


		
		if (DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {

			if (timeBetweenAttacks <= 0) {
				if (archer1) {
					target = GameObject.Find ("archer2").transform;
					archer1 = false;
				} else {
					target = GameObject.Find ("archer1").transform;
					archer1 = true;
				}
				timeBetweenAttacks = Random.Range (5.0f, 7.5f);
			}
		}


		float step = 5 * Time.deltaTime;
		//new Vector3 (target.position.x, transform.position.y, transform.position.z)
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("dying") && DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			if (true) {
				transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			} else {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), step);
			}
			timeBetweenAttacks -= Time.deltaTime;
		}
		
	}


	void OnTriggerEnter2D (Collider2D collider){
		Debug.Log ("CHANGE ARCHER");
		if (collider.gameObject.tag == "Player") {
			timeBetweenAttacks = 0;
		}
			
	}
}
