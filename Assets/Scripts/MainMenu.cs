using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //click to start the game
    void TigerRun() {
        SceneManager.LoadScene(1);

    }

    //click to view credits
    void CreditsClick() {

    }
}
