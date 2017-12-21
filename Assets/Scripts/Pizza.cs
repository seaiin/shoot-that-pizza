using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    private static Dictionary<int, string> typePizza;
    private string pizzaCode;

    void Start() {
        typePizza = new Dictionary<int, string>();
        typePizza.Add(0, "HWI");
        typePizza.Add(1, "ITM");
        typePizza.Add(2, "PRM");
        typePizza.Add(3, "MLV");
        typePizza.Add(4, "BBQ");
    }

    public string getTypeOfPizza () {
        int numType = (int)(Random.Range(0, 5));
        Debug.Log(numType);
        pizzaCode = typePizza[numType];
        Debug.Log(pizzaCode);

        return pizzaCode;
    }
}
