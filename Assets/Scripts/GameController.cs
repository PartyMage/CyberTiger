using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject deathMenu;
    public float scrollSpeed = -1.5f;
    public bool gameOver = false;
    public int shotTypeNumber = 0;
    public int pickupType = 0;
    public int pickupNumber = 0;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
