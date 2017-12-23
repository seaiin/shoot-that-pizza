using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public TypingPizza typingPizza;
    public Score score;
    public Truck truck;

    private string pizza = "";

	// Use this for initialization
	void Start () {

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
}
