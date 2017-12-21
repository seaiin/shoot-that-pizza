﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour {
    public Pizza pizza;
    private string pizzaType;
    private float padding = 1f;
    private float speed = 5f;

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        float startPoint = rightmost.x + padding;
        transform.position = new Vector3(startPoint, transform.position.y, 0);

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
}
