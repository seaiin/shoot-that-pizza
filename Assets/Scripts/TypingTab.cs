using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingTab : MonoBehaviour {

    public List<TextMeshProUGUI> typeCharList;


    public void SetTypingChar(char[] typing)
    {
        for (int i = 0; i < 3; i++)
        {
            typeCharList[i].text = typing[i].ToString();
        }
    }

    public void SetTypingCount(int count)
    {
        if (count == 0)
        { 
            for (int i = 0; i < 3; i++)
            {
                typeCharList[i].color = Color.white;
            }
        } else
        {
            typeCharList[count - 1].color = Color.green;
        }

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
