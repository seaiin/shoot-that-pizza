using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOrder : MonoBehaviour {
    private SpriteRenderer sr;
    private Sprite[] sp;
    private static Dictionary<string, int> pizzaIndex = new Dictionary<string, int>();
    private string pizzaCode;
    private int index;

    void Awake () {
        //initIndex();
        //pizzaIndex.Add("AAA", 0);
        sp = Resources.LoadAll<Sprite>("pizza/complete");
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start () {
        pizzaCode = transform.parent.gameObject.GetComponent<HouseMovement>().getPizza();
        index = getIndex(pizzaCode);
        sr.sprite = sp[index];
	}
	
	void Update () {
		if (!transform.parent.gameObject.activeSelf) {
            gameObject.SetActive(false);
            pizzaIndex.Clear();
        }
	}

    private void initIndex () {
        pizzaIndex.Add("HWI", 0);
        pizzaIndex.Add("MBL", 1);
        pizzaIndex.Add("PEP", 2);
        pizzaIndex.Add("SEA", 3);
        pizzaIndex.Add("SPN", 4);
    }

    private int getIndex (string pizzaCode) {
        if (pizzaCode == "HWI") {
            return 0;
        } else if (pizzaCode == "MBL") {
            return 1;
        } else if (pizzaCode == "PEP") {
            return 2;
        } else if (pizzaCode == "SEA") {
            return 3;
        } else if (pizzaCode == "SPN") {
            return 4;
        } else {
            return -1;
        }
    }
}
