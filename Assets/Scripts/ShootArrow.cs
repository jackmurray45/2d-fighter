﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour {

	public float timeLeftToShoot = 0f;
	public float arrowPower = 0.0f;
	private const float ARROW_MAX = 10.0f;
	public GameObject arrow;
	public DamageTaken dt;
    public AudioClip shootSound;

    private AudioSource playerAudio;

	// Use this for initialization
	void Start () {
        playerAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeftToShoot -= Time.deltaTime;
		if (Input.GetKey ("space")) {
			if(arrowPower < ARROW_MAX)
				arrowPower += .1f;
			if (arrowPower > ARROW_MAX)
				arrowPower = ARROW_MAX;
		}
		if (Input.GetKeyUp ("space") && dt.currentHealth > 0 && timeLeftToShoot <= 0) {
            arrowPower = 0.0f;

            float rot = transform.rotation.y;
            if (rot == 0)
                rot = 1.25f;
            else
                rot = -1.25f;

            Vector3 arrowPos = new Vector3(transform.position.x + rot, transform.position.y, transform.position.z);
            int right = 30;
            if (rot < 0)
                right = 150;

            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            Instantiate (arrow, arrowPos, Quaternion.Euler(transform.rotation.x, transform.rotation.y, right));
            
            timeLeftToShoot = .5f;

		}
		

		
	}
}
