using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    private Dictionary<int, string> typePizza = new Dictionary<int, string>();

    void Start() {
        typePizza.Add(1, "HWI");
        typePizza.Add(2, "ITM");
        typePizza.Add(3, "PRM");
        typePizza.Add(4, "MLV");
        typePizza.Add(5, "BBQ");
    }

    public string getTypePizza () {
        int numType = (int) Random.Range(0, 6);

        return typePizza[numType];
    }
}
