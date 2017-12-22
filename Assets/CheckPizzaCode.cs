using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPizzaCode : MonoBehaviour {
    public GameManage gameManage;

    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "House") {
            //collision.gameObject.SendMessage("getPizza");
            HouseMovement house = collision.gameObject.GetComponent<HouseMovement>();
            string pizza = house.getPizza();
            Debug.Log("pizza: " + pizza);

            //gameManage.SendMessage("showPizza", pizza); // Send data pass by method in GameManage
        }
    }
}
