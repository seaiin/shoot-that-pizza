using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public TypingPizza typingPizza;
    public Score score;
    public Truck truck;
    public float houseSpeed = 1f;
    public float mul = 1.1f;
    private bool canUpSpeed = true;

    private Queue<GameObject> houseQueue = new Queue<GameObject>();
    private HouseMovement house;
    private string pizzaCode;

	void Update () {

        typingPizza.TypeUpdate();
        
        if (typingPizza.isTypingFinish())
        {
            score.SetScore(100);
            typingPizza.SetNotFinish();
        }

        SetSpeed();

        if (typingPizza.isTypingEmp())
        {
            if (houseQueue.Count > 0)
            {
                house = houseQueue.Dequeue().GetComponent<HouseMovement>();
                typingPizza.SetPizza(house.getPizza());
            }
        }
	}

    public void enqueueHouse(GameObject houseObject)
    {
        houseQueue.Enqueue(houseObject);
    }

    public void SetSpeed ()
    {
        if (score.GetScore() % 500 == 0 && canUpSpeed) {
            houseSpeed *= mul;
            canUpSpeed = false;
        } else {
            if (score.GetScore() % 500 != 0) {
                canUpSpeed = true;
            }
        }
    }

    public float GetSpeed ()
    {
        return houseSpeed;
    }
}
