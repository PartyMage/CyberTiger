using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //instructions for spawn
    public float timeSinceLastSpawn;
    public float spawnRate = 4f;
    public int SpawneeType;
    //spawn types
    public GameObject[] Enemies;
    public GameObject[] Obstacles;
    public GameObject[] platforms;
    public GameObject pickup;
    public GameObject[] fullObjectPool;
    //
    public int enemiesPoolSize = 5;
    public int obstaclesPoolSize = 5;
    public int pickupsPoolSize = 5;
    public int fullObjectPoolPoolSize;
    public int fullPoolPosition = 0;
    //is there a second floor yet?
    public bool secondFloorActive = true;
    public int platformTimeCount = 0;

    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private Vector2 secondFloorPosition = new Vector2(-15f, 25f);
    private System.Random rng = new System.Random();

    // Use this for initialization
    void Start () {
        InstantiationPool();
        Shuffle();
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        platformTimeCount++;
        if (timeSinceLastSpawn >= spawnRate) {
            timeSinceLastSpawn = 0;
            fullObjectPool[fullPoolPosition].transform.position = gameObject.transform.position;
            fullPoolPosition++;
            if (fullPoolPosition >= fullObjectPoolPoolSize)
                fullPoolPosition = 0;
        }
        if (platformTimeCount == 10)
            SecondFloor();
	}
    //creating the pools of objects to send at cyber tiger
    void InstantiationPool() {
        fullObjectPoolPoolSize = (enemiesPoolSize + obstaclesPoolSize + pickupsPoolSize);
        fullObjectPool = new GameObject[fullObjectPoolPoolSize];
        SpawneeType = 0;
        for (int i = 0; i < enemiesPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee();
            fullPoolPosition++;
        }
        SpawneeType = 1;
        for (int i = 0; i < obstaclesPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee();
            fullPoolPosition++;
        }
        SpawneeType = 2;
        for (int i = 0; i < pickupsPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee();
            fullPoolPosition++;
        }
        fullPoolPosition = 0;
    }
    //spawn second floor platforms when needed
    public void SecondFloor()
    {
        GameObject floorTile = null;
        if (secondFloorActive == false)
            return;
        else
            foreach (GameObject floor in platforms)
                floorTile = Instantiate(floor, secondFloorPosition, Quaternion.identity);

    }

    public void Shuffle() {
        GameObject holdObject = null;
        int k;
        for (int i = 0; i < fullObjectPoolPoolSize; i++)
        {
            k = rng.Next(i, fullObjectPoolPoolSize);
            holdObject = fullObjectPool[i];
            fullObjectPool[i] = fullObjectPool[k];
            fullObjectPool[k] = holdObject;
        }

    }
    //pick what will spawn between the different types of enemies
    GameObject ChooseSpawnee ()
    {
        GameObject holdSpawn = null;
        switch (SpawneeType) {
            case 0:
                holdSpawn = Instantiate(Enemies[Random.Range(0, Enemies.Length)], objectPoolPosition, Quaternion.identity);
                break;
            case 1:
                holdSpawn = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], objectPoolPosition, Quaternion.identity);
                break;
            case 2:
                holdSpawn = Instantiate(pickup, objectPoolPosition, Quaternion.identity);
                break;
        }
            return holdSpawn;

    }
}
