using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScript : MonoBehaviour {


	public string tempTag;

	public string permTag;
	public float waitTime = 2f;
	// Use this for initialization
	void Start () {

		transform.gameObject.tag = tempTag;
		
	}
	
	// Update is called once per frame
	void Update () {

		waitTime -= Time.deltaTime;

		if (waitTime <= 0) {
			transform.gameObject.tag = permTag;
		}
		
	}
}
