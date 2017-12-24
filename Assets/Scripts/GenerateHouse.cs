using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHouse : MonoBehaviour {
    public GameObject housePrefab;
    public float minTime = 1f;
    public float maxTime = 3f;

    private float time;
    private float spawnTime;

	void Start () {
        setRandomTime();
        time = minTime;
    }

    void FixedUpdate () {
        time += Time.deltaTime;
        //Debug.Log("time: " + time);
        //ebug.Log("spawn time: " + spawnTime);

        if (time >= spawnTime) {
            houseSpawn();
            setRandomTime();
        }
    }

    void houseSpawn () {
        time = 0;

        GameObject house = ObjectPooling.SharedInstance.GetPooledObject();
        //HouseMovement houseObject = house.GetComponent<HouseMovement>();
        //houseObject.showType();

        if (house != null) {
            house.SetActive(true);
        }
    }

    void setRandomTime () {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
