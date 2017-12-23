using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    private TypingPizza typingPizza;
    private Score score;
    private Truck truck;
    private HouseMovement house;
    private string pizza = "";

	// Use this for initialization
	void Start () {
        typingPizza = gameObject.AddComponent<TypingPizza>();
        score = gameObject.AddComponent<Score>();
        truck = gameObject.AddComponent<Truck>();
        typingPizza.SetPizza(pizza);
    }
	
	// Update is called once per frame
	void Update () {

        typingPizza.TypeUpdate();

        if (typingPizza.isTypingFinish())
        {
            score.SetScore(100);
            typingPizza.SetPizza(pizza);
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            collision.gameObject.SendMessage("ReadyToType");
            house = collision.gameObject.GetComponent<HouseMovement>();
            pizza = house.getPizza();
            typingPizza.SetPizza(pizza);
            Debug.Log(pizza);
        }
    }
}
