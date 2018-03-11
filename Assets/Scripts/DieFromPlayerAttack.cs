using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFromPlayerAttack : MonoBehaviour {


	public GameObject arrowPack;
	public GameObject healthElixir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D collider){
		if (collider.gameObject.tag == "Damage") {
			int drop = Random.Range (0, 2);
			Debug.Log (drop);


			if (drop == 0) {
				Vector3 temp = new Vector3 (transform.position.x + 3, transform.position.y, transform.position.z);
				Instantiate (arrowPack, temp, transform.rotation);
			} else if (drop == 1) {
				Instantiate (healthElixir, transform.position, transform.rotation);
			}
			Destroy (collider.gameObject);
			Destroy (gameObject);
		}
			
	}
}
