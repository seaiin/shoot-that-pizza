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

        if (transform.position.x <= leftmost.x) {
            transform.position = new Vector3(rightmost.x + 2f, 0, 0);
            gameObject.SetActive(false);
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

}
