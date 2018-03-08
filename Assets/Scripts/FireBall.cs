using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	public float destroyTime = 5f;
	private Transform target;
	public static int currentArcher;


	// Use this for initialization
	void Start () {

		if (currentArcher == 1) {
			target = GameObject.Find ("archer1").transform;
		} else {
			target = GameObject.Find ("archer2").transform;
		}

		Vector3 targetDir = target.position - transform.position;

		float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);


		

	}
	
	// Update is called once per frame
	void Update () {
		destroyTime -= Time.deltaTime;

		if (destroyTime <= 0)
			Destroy (gameObject);

		Vector3 targetDir = target.position - transform.position;
		float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);

		//transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);

		transform.Translate (Vector3.up * Time.deltaTime * 5f);
	}

	void OnTriggerEnter2D (Collider2D collider){
		if(collider.gameObject.tag == "Player")
			Destroy (gameObject);
	}
}
