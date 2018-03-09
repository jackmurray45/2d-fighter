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

    private AudioSource playerSound;
    private bool isDead = false;
    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
        playerSound = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();

	}

    IEnumerator DamageFlash()
    {
        Color currentColor = renderer.material.color;
        currentColor.a -= .7f;
        renderer.material.color = currentColor;
        yield return new WaitForSeconds(.2f);
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

	}

	void OnTriggerEnter2D (Collider2D collider){
		
		if (collider.gameObject.tag == "Damage") {
			currentHealth -= 25;
			if (currentHealth < 0)
				currentHealth = 0;
            healthDisplay.text = "" + currentHealth;
			Destroy (collider.gameObject);
            StartCoroutine(DamageFlash());
            playerSound.Play();
		}
		if (collider.gameObject.tag == "FireBall") {
			currentHealth -= 10;
			healthDisplay.text = "" + currentHealth;
			Destroy (collider.gameObject);
			//StartCoroutine(DamageFlash());
			playerSound.Play();


		}
	}
}


