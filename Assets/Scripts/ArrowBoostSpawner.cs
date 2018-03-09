using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBoostSpawner : MonoBehaviour {

	Vector3[] positions;
	public GameObject arrowPack;
	bool calledCreate = false;
	// Use this for initialization
	void Start () {
		positions = new Vector3[4];
		positions [1] = new Vector3 (2.57f, 0.56f, 0f);
		positions [2] = new Vector3 (-3.49f, 0.56f, 0f);
		positions [3] = new Vector3 (8.31f, 0.56f, 0f);

		float nextTime = Random.Range (7.0f, 12.0f);
		while ((nextTime -= Time.deltaTime) > 0) {
			continue;
		}
		CreateArrowBoost ();


	



	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void CreateArrowBoost(){
		Quaternion rotation = transform.rotation;
		float y = -2.0f;
		float x = Random.Range (-8.3f, 7.75f);
		positions[0] = new Vector3 (x, y, 0);
		int pos = Random.Range (0, 4);
		Instantiate (arrowPack, positions [pos], rotation);



		int nextTime = Random.Range (7, 12);

		Debug.Log ("Made at position: " + positions [pos]);

		Invoke ("CreateArrowBoost", nextTime);

	}
}
