using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake () {
        SharedInstance = this;
    }

    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        //1 iterate pooled objects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2 check item in list that not active currently
            if (!pooledObjects[i].activeInHierarchy)
            {
                Debug.Log("have inactive object: " + i);
                return pooledObjects[i];
            }
        }
        //3 if there are no inactive object. Exit method and return nothing
        Debug.Log("No one inactive");
        return null;
    }
}
