using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject deathMenu;
    public Text scoreText;
    public float scrollSpeed = -3.5f;
    public bool gameOver = false;
    public int shotTypeNumber = 0;
    public int pickupType = 0;
    public int pickupNumber = 0;
    public int totalScore = 0;
    public int lifetimeScore = 0;
    public int score = 0;
    public int energy = 100;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
            deathMenu = GameObject.Find("Death Menu");
            scoreText = GameObject.Find("Score").GetComponent<Text>();
        }
        else if (instance != this)
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
