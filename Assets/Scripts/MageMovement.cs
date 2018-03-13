using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMovement : MonoBehaviour {

	public DamageTaken dt;
	public DamageTwoTaken DTt;
	Animator anim;
	private Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator> ();
		if (DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			if (FireBall.currentArcher == 1) {
				target = GameObject.Find ("archer1").transform;
			} else {
				target = GameObject.Find ("archer2").transform;
			}
		}





		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("dying")  && DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			float step = 5 * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), step);
		}
	}
}
