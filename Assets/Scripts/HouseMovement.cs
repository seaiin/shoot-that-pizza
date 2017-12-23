using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour {
    public Pizza pizza;
    private string pizzaType;
    private float padding = 1f;
    private float speed = 3f;
    private Vector3 leftmost;
    private Vector3 rightmost;
    private bool readyType = false;

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        float startPoint = rightmost.x + padding;
        transform.position = new Vector3(startPoint, transform.position.y, transform.position.z);
 
        setPizza();
	}

    void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void setPizza () {
        pizzaType = pizza.getTypeOfPizza();
    }

    public void showType () {
        Debug.Log(pizzaType);
    }

    public string getPizza () {
        return pizzaType;
    }

    public void ReadyToType()
    {
        readyType = true;
    }
}
