using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public TextMeshProUGUI scoreString;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    //run when player clicks the main menu button
    public void mainMenuClick() {
        SceneManager.LoadScene(0);
    }

    //run when player clicks to run again
    public void RunAgainClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
