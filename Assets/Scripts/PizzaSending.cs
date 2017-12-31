using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSending : MonoBehaviour {
    
    public GameObject house;

    private Vector3 startPoint;
    private Vector3 startScale;
    private Vector3 newScale = new Vector3(0.1f, 0.1f, 0);
    private float speedPos = 5.0f;
    private float speedScale = 0.5f;

    public void SetHouse(GameObject sendHouse)
    {
        house = sendHouse;
    }

    // Use this for initialization
    void Start () {
        startPoint = transform.position;
        startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, house.transform.position, Time.deltaTime * speedPos);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speedScale * Time.deltaTime);

        if (transform.position == house.transform.position) {
            transform.position = startPoint;
            transform.localScale = startScale;
            gameObject.SetActive(false);
        }
	}
}
