using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour {
    public GameManage gameManage;

    void Start()
    {
        gameManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool checkTag = collision.gameObject.tag == "House1"
                        || collision.gameObject.tag == "House2"
                        || collision.gameObject.tag == "House3"
                        || collision.gameObject.tag == "House4"
                        || collision.gameObject.tag == "House5";
        if (checkTag && collision.gameObject.GetComponent<HouseMovement>().HasOrder())
        {
            Debug.Log("Game Over");
            gameManage.gameRunning = false;
        }
    }
}
