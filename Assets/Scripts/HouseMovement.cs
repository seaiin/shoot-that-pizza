using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour {
    public Pizza pizza;
    public float speed = 1f;
    public float mul = 1.1f;
    public GameManage gameManage;

    private bool hasOrder = true;
    private string pizzaType;
    private float padding = 1f;
    private float startPoint;
    private Vector3 leftmost;
    private Vector3 rightmost;

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        startPoint = rightmost.x + padding;
        transform.position = new Vector3(startPoint, transform.position.y, transform.position.z);
 
        setPizza();

        gameManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>();
        speed = gameManage.GetSpeed();
	}

    void Update () {
        if(gameManage.gameRunning)
        {
            speed = gameManage.GetSpeed();
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= leftmost.x)
            {
                transform.position = new Vector3(startPoint, transform.position.y, transform.position.z);
                gameObject.SetActive(false);
            }
        }
    }

    private void setPizza () {
        pizzaType = pizza.getTypeOfPizza();
    }

    public void showType () {
        Debug.Log(pizzaType);
        //Debug.Log("Hello");
    }

    public string getPizza () {
        return pizzaType;
    }

    public GameObject getHouse () {
        return gameObject;
    }

    public void ReceiveOrder()
    {
        hasOrder = false;
    }

    public bool HasOrder ()
    {
        return hasOrder;
    }
}
