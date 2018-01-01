using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour {
    public float speed = 1f;
    public GameManage gameManage;

    private Vector3 leftmost;
    private Vector3 rightmost;
    private Vector3 startPoint;

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        startPoint = new Vector3(22.52f, transform.position.y, transform.position.z);
        
        gameManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>();
    }
	
	void Update () {
        if(gameManage.gameRunning)
        {
            speed = gameManage.GetSpeed();
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= -23.07)
            {
                transform.position = startPoint;
            }
        }
	}
}
