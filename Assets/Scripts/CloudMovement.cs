using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {
    public float speed = 1f;
    private Vector3 leftmost;
    private Vector3 rightmost;

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= leftmost.x - 2) {
            transform.position = new Vector3(rightmost.x + 2f, Random.Range(2f, 3.5f), transform.position.z);
            speed = Random.Range(0.4f, 1f);
        }
    }
}
