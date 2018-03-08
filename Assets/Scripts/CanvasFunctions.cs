using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CanvasFunctions : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartScene(){
		Scene loadedLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (loadedLevel.buildIndex);

	}

	public void pauseGame(){
		Time.timeScale = 0;
	}

	public void resumeGame(){
		Time.timeScale = 1;
	}

	public void StartGame(){
		SceneManager.LoadScene ("First");
	}

	public void resetHealths(){
		DamageTaken.currentHealth = DamageTaken.maxHealth;
		DamageTwoTaken.currentHealth = DamageTaken.maxHealth;

	}
}
