using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public TypingPizza typingPizza;
    public Score score;
    public Truck truck;
    public GameObject housePrefab;
    public HouseMovement houseMovement;

    private string pizza = "";
    private Queue<GameObject> houseQueue = new Queue<GameObject>();

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        typingPizza.TypeUpdate();

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            housePrefab = collision.gameObject;
            houseQueue.Enqueue(housePrefab);
        }
    }
}
