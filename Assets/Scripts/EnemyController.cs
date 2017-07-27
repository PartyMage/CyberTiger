using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool running = false;
    private Rigidbody2D rb2d;
    private Animator anim;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {
		if (running == false)
            anim.SetBool("isRunning", false);
        else if (running == true)
            anim.SetBool("isRunning", true);
    }
}
