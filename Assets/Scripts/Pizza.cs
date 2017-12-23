using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    private static Dictionary<int, string> typePizza = new Dictionary<int, string>();
    private string pizzaCode;

    void Start() {
        typePizza.Add(0, "HWI");
        typePizza.Add(1, "ITM");
        typePizza.Add(2, "PRM");
        typePizza.Add(3, "MLV");
        typePizza.Add(4, "BBQ");
    }

    public string getTypeOfPizza () {
        int numType = (int)(Random.Range(0, 5));
        pizzaCode = typePizza[numType];
        return pizzaCode;
    }
}
