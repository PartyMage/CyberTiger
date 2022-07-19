using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {


	public GameController gameControl;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		gameControl = GameObject.Find("GameControl").GetComponent<GameController>();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(gameControl.scrollSpeed, 0);
        if (gameControl.gameOver == true)
            rb2d.velocity = Vector2.zero;
	}
}
