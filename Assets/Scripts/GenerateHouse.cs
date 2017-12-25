using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHouse : MonoBehaviour {
    public GameObject housePrefab;
    public float minTime = 1f;
    public float maxTime = 3f;

    private float time;
    private float spawnTime;
    private static Dictionary<int, string> tagHouse = new Dictionary<int, string>();
    private string tagString = "House1";

    void Start () {
        setRandomTime();
        time = minTime;
        tagHouse.Add(0, "House1");
        tagHouse.Add(1, "House2");
        tagHouse.Add(2, "House3");
        tagHouse.Add(3, "House4");
        tagHouse.Add(4, "House5");
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
        int tagNum = (int)(Random.Range(0, 5));
        tagString = tagHouse[tagNum];

        GameObject house = ObjectPooling.SharedInstance.GetPooledObject(tagString);
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
