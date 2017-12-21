using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    private TypingPizza typingPizza;
    private string pizza = "";

	// Use this for initialization
	void Start () {
        pizza = "HWI";
        typingPizza = gameObject.AddComponent<TypingPizza>();
        typingPizza.SetPizza(pizza);
    }
	
	// Update is called once per frame
	void Update () {

        typingPizza.TypeUpdate();

        if (typingPizza.isTypingFinish())
        {
            typingPizza.SetPizza(pizza);
        }

	}
}
