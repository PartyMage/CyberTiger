using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Image startScreen;
    public Image creditsPage;
    public int count;
    public bool ableToClick;
	// Use this for initialization
	void Start () {
        ableToClick = false;
        startScreen.gameObject.SetActive(true);
        creditsPage.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        count++;
		if (ableToClick == true) {
            if (Input.GetMouseButtonDown(0)) {
                startScreen.gameObject.SetActive(false);
                BackToMenu();
            }


        } else if (ableToClick == false){
            if (count > 50) {
                ableToClick = true;
                
            }
        }
	}

    //click to start the game
    public void TigerRun() {
        SceneManager.LoadScene(1);
    }

    //click to view credits
    public void CreditsClick() {
        creditsPage.gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0)) {
            BackToMenu();
        }
    }

    public void BackToMenu() {
        creditsPage.gameObject.SetActive(false);
    }
}
