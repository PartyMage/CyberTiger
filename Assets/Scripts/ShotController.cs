using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float speed;
    public bool concussive = false;
    public CyberTigerController tiger;
    
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
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
            GameController.instance.score++;
            GameController.instance.scoreText.text = "Score: " + GameController.instance.score.ToString();
            other.gameObject.transform.position = objectPoolPosition;
            tiger.energy += 15;
            Destroy(gameObject);
        }
        if (other.tag == "Obstacle")
        {
            if (concussive == true) {
                GameController.instance.score++;
                GameController.instance.scoreText.text = "Score: " + GameController.instance.score.ToString();
                other.gameObject.transform.position = objectPoolPosition;
                tiger.energy += 30;
            }
            Destroy(gameObject);

        }

    }
}
