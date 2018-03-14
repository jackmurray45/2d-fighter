using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootArrowTwo : MonoBehaviour {
	public float timeLeftToShoot = 0f;
	public float arrowPower = 0.0f;
	private const float ARROW_MAX = 10.0f;
	public float quickShootTime = 10.0f;
	public GameObject arrow;
	public DamageTwoTaken dt;
    public AudioClip shootSound;
	public AudioClip arrowPackSound;
	private bool quickShoot;
    private AudioSource playerAudio;
	public Text boostDisplay;

	// Use this for initialization
	void Start () {
        playerAudio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

		if (playerAudio.clip == arrowPackSound) {
			Invoke ("ChangeToShoot", 1.0f);
		}

		timeLeftToShoot -= Time.deltaTime;
		if (Input.GetKey ("[0]")) {
			if(arrowPower < ARROW_MAX)
				arrowPower += .1f;
			if (arrowPower > ARROW_MAX)
				arrowPower = ARROW_MAX;
		}
		if (Input.GetKeyUp ("[0]") && DamageTwoTaken.currentHealth > 0 && timeLeftToShoot <= 0) {

			arrowPower = 0.0f;
			float rot = transform.rotation.y;
			if (rot == 0)
				rot = 1.25f;
			else
				rot = -1.25f;



			Vector3 arrowPos = new Vector3 (transform.position.x + rot, transform.position.y, transform.position.z);

			int right = 0;
			if (rot < 0)
				right = 180;

            AudioSource.PlayClipAtPoint(shootSound, transform.position);
			Instantiate (arrow, arrowPos, Quaternion.Euler(transform.rotation.x, transform.rotation.y, right));

			if (quickShoot && quickShootTime > 0) {
				
				timeLeftToShoot = 0f;

			} else {
				
				timeLeftToShoot = 0.5f;
				quickShoot = false;
				quickShootTime = 10.0f;
			}
            
           

		}

		if (quickShoot && quickShootTime > 0) {
			
			boostDisplay.text = "Arrow Boost: " + Mathf.RoundToInt(quickShootTime)+"s";
		} else {
			
			boostDisplay.text = "";
		}
		quickShootTime -= Time.deltaTime;



	}


	void ChangeToShoot(){
		playerAudio.clip = shootSound;
	}

	void OnTriggerEnter2D (Collider2D collider){
		if (collider.gameObject.tag == "ArrowBoost") {
			quickShoot = true;

			playerAudio.clip = arrowPackSound;
			playerAudio.Play ();
			Destroy (collider.gameObject);
			quickShootTime = 10.0f;
		}


	}
}
