﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameController gameControl;
    public Sprite[] batteries = new Sprite[3];
    public int pickupType;
    public int pickupNumber;

    // Use this for initialization
    void Start ()
    {
        gameControl = GameObject.Find("GameControl").GetComponent<GameController>();
        pickupType = Random.Range(0, 1);
        if (pickupType == 0) {
            pickupNumber = Random.Range(0, batteries.Length);
            GetComponent<SpriteRenderer>().sprite = batteries[pickupNumber];
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            gameControl.pickupType = pickupType;
            gameControl.pickupNumber = pickupNumber;
        }
    }
}
