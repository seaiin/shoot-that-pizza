using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "House") {

            collision.gameObject.SetActive(false);

        }     
    }
}
