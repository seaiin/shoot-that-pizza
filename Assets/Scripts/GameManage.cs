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

    private Queue<string> pizzaCodeQueue = new Queue<string>();

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
