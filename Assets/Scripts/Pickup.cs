using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public Sprite[] batteries = new Sprite[3];
    public Sprite[] weapons = new Sprite[5];
    public int pickupType;
    public int pickupNumber;

    // Use this for initialization
    void Start () {
        pickupType = Random.Range(0, 2);
        if (pickupType == 0) {
            pickupNumber = Random.Range(0, batteries.Length);
            GetComponent<SpriteRenderer>().sprite = batteries[pickupNumber];
        }
        else {
            pickupNumber = Random.Range(0, weapons.Length);
            GetComponent<SpriteRenderer>().sprite = weapons[pickupNumber];
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            GameController.instance.pickupType = pickupType;
            GameController.instance.pickupNumber = pickupNumber;
        }
    }
}
