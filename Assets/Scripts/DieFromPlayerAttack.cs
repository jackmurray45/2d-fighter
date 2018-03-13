using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFromPlayerAttack : MonoBehaviour {
	bool alreadyShot;
	Animator anim;
	public GameObject arrowPack;
	public GameObject healthElixir;
	float timeToDie;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		alreadyShot = false;

		if (transform.gameObject.tag == "Knight") {
			timeToDie = 1.25f;
		} else {
			timeToDie = 1.5f;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (alreadyShot) {
			timeToDie -= Time.deltaTime;
		}

		if (timeToDie <= 0) {
			Destroy (gameObject);
		}
		
	}


	void OnTriggerEnter2D (Collider2D collider){
		if (collider.gameObject.tag == "Damage" && !alreadyShot) {
			int drop = Random.Range (0, 2);
			float dropRate = Random.Range (0.0f, 1.00f);
			Debug.Log (drop);

			if (dropRate <= .25f) {
				if (drop == 0) {
					Vector3 temp = new Vector3 (transform.position.x + 3, transform.position.y, transform.position.z);
					Instantiate (arrowPack, temp, transform.rotation);
				} else if (drop == 1) {
					Instantiate (healthElixir, transform.position, transform.rotation);
				}
			}


			Destroy (collider.gameObject);
			transform.gameObject.tag = "Dying";
			alreadyShot = true;


			anim.SetTrigger ("isDead");
		}
			
	}
}
