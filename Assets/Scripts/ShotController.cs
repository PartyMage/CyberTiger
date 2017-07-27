using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float speed;
    public bool concussive = false;

	// Use this for initialization
	void Start () {
        speed = 20f;
        if (GameController.instance.shotTypeNumber == 4)
            concussive = true;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "Obstacle")
        {
            if (concussive == true)
                Destroy(other.gameObject);
            Destroy(gameObject);

        }

    }
}
