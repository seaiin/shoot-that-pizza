using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHouse : MonoBehaviour {
    public GameObject housePrefab;

	// Use this for initialization
	void Start () {
        //for (int i = 0; i < 20; i++) {
        Invoke("houseMove", 4);
        Invoke("houseMove", 2);
        Invoke("houseMove", 1);
        //}
    }
	
	void houseMove () {
        GameObject house = ObjectPooling.SharedInstance.GetPooledObject();

        if (house != null) {
            house.SetActive(true);
        }
    }
}
