using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float maxSpeed = 10;
	public float jumpTakeOffSpeed = 13;
	public float rotateChange = 0.05f;


	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		float currentRotation = transform.rotation.y;

		if (currentRotation == 0) {
			rb.velocity = new Vector2 (15, 10);
		} else {
			rb.velocity = new Vector2 (-15, 10);
		}



	}

	void Update(){
		

		if (rb.velocity.x < 0) {
			transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, transform.eulerAngles.z+rotateChange);
		} else {
			transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, transform.eulerAngles.z -rotateChange);

		}
	}

	void OnTriggerEnter2D (Collider2D collider){

		Destroy (gameObject);
	}
		

}
