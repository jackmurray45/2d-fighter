using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour {
	public GameObject knights;
	public GameObject mages;
	private float timeUntilNextEnemy = 5.0f;
	private float decreaseDelay = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeUntilNextEnemy -= Time.deltaTime;
		if (timeUntilNextEnemy <= 0 && DamageTaken.currentHealth > 0 && DamageTwoTaken.currentHealth > 0) {
			float y = -2.0f;
			float x = Random.Range (-8.0f, 7.75f);
			//transform.position = new Vector3 (x, y, 0);
			Quaternion rotation = transform.rotation;

			int currentEnemy = Random.Range (0, 2);
			if (currentEnemy == 0) {
				Instantiate (mages, new Vector3 (x, y, 0), rotation);
			} else if (currentEnemy == 1) {
				Instantiate (knights, new Vector3 (x, y, 0), rotation);
			}

			if (decreaseDelay > .2f) {
				decreaseDelay -= .1f;
			}

			timeUntilNextEnemy = Random.Range(5.0f*decreaseDelay, 10.0f*decreaseDelay);
			Debug.Log ("NEXT ATTACK: " + timeUntilNextEnemy);

		}

	}
}
