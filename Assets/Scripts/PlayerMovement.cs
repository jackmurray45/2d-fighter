using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerMovement : PhysicsObject {
	public DamageTaken dt;
	public float maxSpeed = 10;
	public float jumpTakeOffSpeed = 13;
	Animator anim;
	public TMP_Text t;
	public Button b;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	protected override void ComputeVelocity(){
		Vector2 move = Vector2.zero;

		if (dt.currentHealth <= 0) {
			b.gameObject.SetActive (true);
			t.gameObject.SetActive (true);
			t.SetText ("Player 2 Wins!");
		}

		if (Input.GetKeyDown ("w") && grounded) {
			anim.SetTrigger ("isJumping");
			
			velocity.y = jumpTakeOffSpeed;
		}


		if (Input.GetKey("d") && dt.currentHealth > 0) {
			anim.SetBool ("isRunning", true);
			move.x = 1;
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		else if (Input.GetKey ("a") && dt.currentHealth > 0) {
			anim.SetBool ("isRunning", true);
			move.x = -1;
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}

		else {
			anim.SetBool ("isRunning", false);
		}
		if (!grounded) {
			anim.SetBool ("isRunning", false);
		}

		targetedVelocity = move * maxSpeed;


	}
}
