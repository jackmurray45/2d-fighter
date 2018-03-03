using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTwoTaken : MonoBehaviour {
	Animator anim;
	public float maxHealth = 100.0f;
	public float currentHealth = 100.0f;
	public PlayerTwoMovement playmove;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();


	}

	// Update is called once per frame
	void Update () {

		if (currentHealth == 0) {
			anim.SetTrigger ("isDead");
			playmove.maxSpeed = 0;
			playmove.jumpTakeOffSpeed = 0;

		}

	}

	void OnTriggerEnter2D (Collider2D collider){

		if (collider.gameObject.tag == "Damage") {
			Debug.Log ("DAMAGE DONE!");
			currentHealth -= 25;
			Destroy (collider.gameObject);
		}
	}
}
