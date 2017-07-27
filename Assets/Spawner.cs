using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public int hitGoal = 500;
    public int count = 0;
    public int SpawneeType;
    public GameObject[] Enemies;
    public GameObject[] Obstacles;
    public GameObject pickup;
    // Use this for initialization
    void Start () {
        SpawneeType = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
        count += 1;
        if (count >= hitGoal) { 
            ChooseSpawnee();
            SpawneeType = Random.Range(0,3);
            hitGoal = Random.Range(200, 500);
            count = 0;
        }
	}

    void ChooseSpawnee () {
        switch (SpawneeType) {
            case 0:
                Instantiate(Enemies[Random.Range(0, Enemies.Length)],gameObject.transform.position,gameObject.transform.rotation);
                break;
            case 1:
                Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 2:
                Instantiate(pickup, gameObject.transform.position, gameObject.transform.rotation);
                break;
        }

    }
}
