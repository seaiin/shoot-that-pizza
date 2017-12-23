using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHouse : MonoBehaviour {
    public GameObject housePrefab;

	void Start () {
        for (int i = 1; i <= 20; i += 5) {
            Invoke("houseMove", i);
            //Invoke("houseMove", 2);
            //Invoke("houseMove", 1);
        }
    }
	
	void houseMove () {
        GameObject house = ObjectPooling.SharedInstance.GetPooledObject();

        if (house != null) {
            house.SetActive(true);
        }
    }
}
