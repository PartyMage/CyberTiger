using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject HUD;
    public DeathMenu deathMenu;
    public TextMeshProUGUI scoreText;
    public float scrollSpeed = -3.5f;
    public bool gameOver = false;
    public int shotTypeNumber = 0;
    public int pickupType = 0;
    public int pickupNumber = 0;
    public int totalScore = 0;
    public int lifetimeScore = 0;
    public int score = 0;
    public int energy = 100;
    int count = 0;

    // Use this for initialization
    void Awake()
    {
        gameOver = false;
        HUD = GameObject.Find("HUD");
        deathMenu = GameObject.Find("Death Menu").GetComponent<DeathMenu>();
        if (deathMenu != null)
            deathMenu.gameObject.SetActive(false);
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        count = 1;
    }
    // Update is called once per frame
    void Update () {
        if (count != 0)
        {
            if (gameOver == true)
            {
                deathMenu.gameObject.SetActive(true);
                deathMenu.scoreString.text = "Score: " + score;
                count = 0;
            }
        }
	}
}
