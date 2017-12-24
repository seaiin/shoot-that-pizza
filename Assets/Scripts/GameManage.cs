using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public TypingPizza typingPizza;
    public Score score;
    public Truck truck;

    private Queue<string> pizzaCodeQueue = new Queue<string>();

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        typingPizza.TypeUpdate();
        
        if (typingPizza.isTypingFinish())
        {
            score.SetScore(100);
            typingPizza.SetNotFinish();
        }

        if (typingPizza.isTypingEmp())
        {
            if (pizzaCodeQueue.Count > 0)
            {
                typingPizza.SetPizza(pizzaCodeQueue.Dequeue());
            }
        }
        

	}

    public void showPizza(string pizzaCode)
    {
        pizzaCodeQueue.Enqueue(pizzaCode);
    }

}
