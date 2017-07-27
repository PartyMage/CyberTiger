using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CyberTigerController : MonoBehaviour {

    public float upForce = 200f;
    public int energy = 100;
    public int count = 0;
    public Slider energyBar;
    public float shotSpeed = 500f;
    public GameObject currentShot;
    public int currentEnergyCost = 6;
    public GameObject laser;
    public GameObject plasma;
    public GameObject sonic;
    public GameObject scatter;
    public GameObject concussive;
    public Transform firePoint;

    private bool isDead = false;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        energyBar.maxValue = energy;
        currentShot = laser;
        
    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if (count % 500 == 0)
            GameController.instance.scrollSpeed *= 1.5f;
        energyBar.value = energy;
        if (energyBar.value <= 0)
            isDead = true;
        if (isDead == true) {
            GameController.instance.deathMenu.SetActive (true);
            GameController.instance.gameOver = true;
        }
            
    }
    
    public void Jump () {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2 (0, upForce));
        energy -= 2;
    }

    public void Fire () {
        Instantiate(currentShot, firePoint.position, firePoint.rotation);
        energy -= currentEnergyCost;
    }

    public void PickupCollision() {

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            energy -= 20;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy Shot") {
            energy -= 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Obstacle") {
            energy -= 20;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Pickup") {
            if (GameController.instance.pickupType == 0) {

                switch (GameController.instance.pickupNumber) {
                    case 0:
                        energy += 10;
                        Destroy(other.gameObject);
                        break;
                    case 1:
                        energy += 25;
                        Destroy(other.gameObject);
                        break;
                    case 2:
                        energy += 50;
                        Destroy(other.gameObject);
                        break;
                }
            }
            else if (GameController.instance.pickupType == 1) {

                switch (GameController.instance.pickupNumber) {
                    case 0:
                        currentEnergyCost = 6;
                        currentShot = laser;
                        Destroy(other.gameObject);
                        break;
                    case 1:
                        currentEnergyCost = 8;
                        currentShot = plasma;
                        Destroy(other.gameObject);
                        break;
                    case 2:
                        currentEnergyCost = 8;
                        currentShot = sonic;
                        Destroy(other.gameObject);
                        break;
                    case 3:
                        currentEnergyCost = 20;
                        currentShot = scatter;
                        Destroy(other.gameObject);
                        break;
                    case 4:
                        currentEnergyCost = 8;
                        currentShot = concussive;
                        Destroy(other.gameObject);
                        break;
                }
            }
        }
    }
}
