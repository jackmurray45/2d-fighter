using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBoostSpawner : MonoBehaviour {

	Vector3[] positions;
	public GameObject arrow;
	public GameObject healthElixir;
	public GameObject arrowPack;
	bool calledCreate = false;
	// Use this for initialization
	void Start () {

		Invoke ("CreateArrowBoost", 15.0f);


	



	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void CreateArrowBoost(){

		float arrowOrBoost = Random.Range (0.0f, 1.0f);


		Quaternion rotation = transform.rotation;
		float y = 6.5f;
		float x = Random.Range (-8.3f, 7.75f);
		Vector3 positions= new Vector3 (x, y, 0);

		if (arrowOrBoost > .15f) {
			
			Instantiate (arrow, positions, rotation);
		} else if (arrowOrBoost < .15f && arrowOrBoost > .075f) {
			positions = new Vector3 (positions.x + 3, positions.y, positions.z);
			Instantiate (arrowPack, positions, rotation);
		} else {
			Instantiate (healthElixir, positions, rotation);
		}



		int nextTime = Random.Range (7, 12);

		Debug.Log ("Made at position: " + positions);

		Invoke ("CreateArrowBoost", nextTime);

	}
}
