using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTaken : MonoBehaviour {
	Animator anim;
	public static float maxHealth = 100.0f;
	public static float currentHealth = 100.0f;
	public PlayerMovement playmove;
    public AudioClip deathSound;
    public Text healthDisplay;
	public float invisibleTimeFrame;
    private AudioSource playerSound;
    private bool isDead = false;
    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
        playerSound = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
		invisibleTimeFrame = 0f;

	}

    IEnumerator DamageFlash()
    {
        Color currentColor = renderer.material.color;
        currentColor.a -= .7f;
        renderer.material.color = currentColor;
        yield return new WaitForSeconds(2.0f);
        currentColor.a += .7f;
        renderer.material.color = currentColor;
    }

    // Update is called once per frame
    void Update () {

		if (currentHealth == 0 && !isDead) {
			anim.SetTrigger ("isDead");
			playmove.maxSpeed = 0;
			playmove.jumpTakeOffSpeed = 0;
            playerSound.clip = deathSound;
            playerSound.Play();
            isDead = true;
		}
		if(invisibleTimeFrame >= 0)
			invisibleTimeFrame -= Time.deltaTime;

	}

	void OnTriggerEnter2D (Collider2D collider){
		if (invisibleTimeFrame <= 0) {
			if (collider.gameObject.tag == "Damage") {
				currentHealth -= 10;
				if (currentHealth < 0)
					currentHealth = 0;
				healthDisplay.text = "" + currentHealth;
				Destroy (collider.gameObject);
				StartCoroutine (DamageFlash ());
				playerSound.Play ();
			}
			if (collider.gameObject.tag == "FireBall") {
				currentHealth -= 5;
				if (currentHealth < 0)
					currentHealth = 0;
				healthDisplay.text = "" + currentHealth;
				Destroy (collider.gameObject);
				StartCoroutine(DamageFlash());
				playerSound.Play ();
			}

			if (collider.gameObject.tag == "Knight") {
				currentHealth -= 20;
				if (currentHealth < 0)
					currentHealth = 0;
				healthDisplay.text = "" + currentHealth;

				StartCoroutine (DamageFlash ());
				playerSound.Play ();
			}
			invisibleTimeFrame = 2.0f;
		}

		if (collider.tag == "Health" && currentHealth < 100) {
			currentHealth += 50;
			if (currentHealth > maxHealth) {
				currentHealth = maxHealth;
			}
			healthDisplay.text = "" + currentHealth;
			Destroy (collider.gameObject);
		}
	}
}


