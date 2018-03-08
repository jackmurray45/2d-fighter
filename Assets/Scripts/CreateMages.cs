using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMages : MonoBehaviour {

	public GameObject mages;
	public float timeUntilNextMage = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeUntilNextMage -= Time.deltaTime;
		if (timeUntilNextMage <= 0 && DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			float y = -2.0f;
			float x = Random.Range (-8.3f, 7.75f);
			//transform.position = new Vector3 (x, y, 0);
			Quaternion rotation = transform.rotation;
			Debug.Log (transform.position);
			Instantiate (mages, new Vector3 (x, y, 0), rotation);
			timeUntilNextMage = 15.0f;

		}
		
	}
}
