using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    private static Dictionary<int, string> typePizza = new Dictionary<int, string>();
    private string pizzaCode;

    void Start() {
        typePizza.Add(0, "HWI");
        typePizza.Add(1, "MBL");
        typePizza.Add(2, "PEP");
        typePizza.Add(3, "SEA");
        typePizza.Add(4, "SPN");
    }

    public string getTypeOfPizza () {
        int numType = (int)(Random.Range(0, 5));
        pizzaCode = typePizza[numType];
        return pizzaCode;
    }
}
