using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundery : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.tag);
        gameObject.SetActive(false);
    }
}
