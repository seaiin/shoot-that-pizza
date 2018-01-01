using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    void Awake()
    {
        Debug.Log("Music player awake! " + GetInstanceID());

        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
        Debug.Log("Music player start " + GetInstanceID());
	}
	

	void Update () {
		
	}
}
