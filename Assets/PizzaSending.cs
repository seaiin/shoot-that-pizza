using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSending : MonoBehaviour {
    public float speed = 1f;

    private Vector3 startPoint;
	// Use this for initialization
	void Start () {
        startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= 5f) {
            transform.position = startPoint;
            gameObject.SetActive(false);
        }
	}
}
