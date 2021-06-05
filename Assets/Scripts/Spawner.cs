using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //instructions for spawn
    public float timeSinceLastSpawn;
    public float spawnRate = 4f;
    public GameObject SecondFloorLevel;
    //spawn types
    public GameObject[] Enemies;
    public GameObject[] Obstacles;
    public GameObject platform;
    public GameObject pickup;
    public GameObject[] fullObjectPool;
    public GameObject[] floorPool;
    //
    public int enemiesPoolSize = 5;
    public int obstaclesPoolSize = 5;
    public int pickupsPoolSize = 5;
    public int fullObjectPoolPoolSize;
    public int fullPoolPosition = 0;
    //is there a second floor yet?
    public bool secondFloorActive = true;
    public int platformTimeCount = 0;
    public int count = 0;
    public GameObject objectPoolPosition;

    private System.Random rng = new System.Random();

    // Use this for initialization
    void Start () {
        PopulatePool();
        Shuffle();
        floorPool = new GameObject[10];
        SecondFloor();
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        platformTimeCount++;
        if (timeSinceLastSpawn >= spawnRate) {
            timeSinceLastSpawn = 0;
            fullObjectPool[fullPoolPosition].transform.position = this.transform.position;
            fullPoolPosition++;
            if (fullPoolPosition >= fullObjectPoolPoolSize)
            {
                fullPoolPosition = 0;
                Shuffle();
            }

        }
        if(secondFloorActive == true)
        {
            if (platformTimeCount == 225)
            {
                floorPool[count].transform.position = SecondFloorLevel.transform.position;
                count++;
                platformTimeCount = 0;
                if (count == 9)
                {
                    count = 0;
                }
            }
        }

	}
    //creating the pools of objects to send at cyber tiger
    void PopulatePool() {
        fullObjectPoolPoolSize = (enemiesPoolSize + obstaclesPoolSize + pickupsPoolSize);
        fullObjectPool = new GameObject[fullObjectPoolPoolSize];
        for (int i = 0; i < enemiesPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee(0);
            fullPoolPosition++;
        }
        for (int i = 0; i < obstaclesPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee(1);
            fullPoolPosition++;
        }
        for (int i = 0; i < pickupsPoolSize; i++) {
            fullObjectPool[fullPoolPosition] = ChooseSpawnee(2);
            fullPoolPosition++;
        }
        fullPoolPosition = 0;
    }
    //spawn second floor platforms when needed
    public void SecondFloor()
    {
        if (secondFloorActive == false)
        {
            return;
        }
        else
        {
            for(int i = 0; i < 10; i++)
            {
                floorPool[i] = Instantiate(platform, objectPoolPosition.transform);
            }
        }
    }

    //shuffle the object being spawned
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
    GameObject ChooseSpawnee (int SpawneeType)
    {
        GameObject holdSpawn = null;
        switch (SpawneeType) {
            case 0:
                holdSpawn = Instantiate(Enemies[Random.Range(0, Enemies.Length)], objectPoolPosition.transform);
                break;
            case 1:
                holdSpawn = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)], objectPoolPosition.transform);
                break;
            case 2:
                holdSpawn = Instantiate(pickup, objectPoolPosition.transform);
                break;
        }
            return holdSpawn;

    }
}
