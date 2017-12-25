using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingTab : MonoBehaviour {

    public List<TextMeshProUGUI> typeCharList;

    private Color32 color;

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
            color = new Color32(221, 161, 70, 255);

            for (int i = 0; i < 3; i++)
            {
                typeCharList[i].color = color;
            }
        } else
        {
            color = new Color32(20, 152, 48, 255);

            typeCharList[count - 1].color = color;
        }

    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
