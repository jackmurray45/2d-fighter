using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
