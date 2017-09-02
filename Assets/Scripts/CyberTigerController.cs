using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CyberTigerController : MonoBehaviour {

    public float upForce = 200f;
    public int energy = 100;
    public Slider energyBar;
    public Text currentEnergy;
    public float shotSpeed = 500f;
    public GameObject currentShot;
    public int currentEnergyCost = 6;
    public GameObject[] weapon;
    public Transform firePoint;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private int lastSpeedup = 1;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        energyBar.maxValue = energy;
        currentShot = weapon[0];
        
    }
	
	// Update is called once per frame
	void Update () {
        currentEnergy.text = energy.ToString();
        if (GameController.instance.score % 3 == 0 && lastSpeedup != GameController.instance.score) {
            lastSpeedup = GameController.instance.score;
            GameController.instance.scrollSpeed *= 1.5f;
        }

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
            other.gameObject.transform.position = objectPoolPosition;
        }
        if (other.gameObject.tag == "Enemy Shot") {
            energy -= 5;
            other.gameObject.transform.position = objectPoolPosition;
        }
        if (other.gameObject.tag == "Obstacle") {
            energy -= 20;
            other.gameObject.transform.position = objectPoolPosition;
        }
        if (other.gameObject.tag == "Pickup") {
            if (GameController.instance.pickupType == 0) {

                switch (GameController.instance.pickupNumber) {
                    case 0:
                        energy += 10;
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 1:
                        energy += 25;
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 2:
                        energy += 50;
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                }
            }
            else if (GameController.instance.pickupType == 1) {

                switch (GameController.instance.pickupNumber) {
                    case 0:
                        currentEnergyCost = 6;
                        currentShot = weapon[0];
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 1:
                        currentEnergyCost = 8;
                        currentShot = weapon[1];
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 2:
                        currentEnergyCost = 8;
                        currentShot = weapon[2];
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 3:
                        currentEnergyCost = 20;
                        currentShot = weapon[3];
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                    case 4:
                        currentEnergyCost = 8;
                        currentShot = weapon[4];
                        other.gameObject.transform.position = objectPoolPosition;
                        break;
                }
            }
        }
    }
}
