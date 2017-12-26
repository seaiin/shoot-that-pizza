using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPizzaCode : MonoBehaviour {
    public GameManage gameManage;

    void OnTriggerEnter2D (Collider2D collision) {
        bool checkTag = collision.gameObject.tag == "House1"
                        || collision.gameObject.tag == "House2"
                        || collision.gameObject.tag == "House3"
                        || collision.gameObject.tag == "House4"
                        || collision.gameObject.tag == "House5";
        if (checkTag) {
            gameManage.enqueueHouse(collision.gameObject); // Send data pass by method in GameManage
        }
    }
}
