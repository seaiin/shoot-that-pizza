using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingPizza : MonoBehaviour {

    char[] pizzaCode = new char[10];
    int pizzaCodeCount = 0;
    string input = "";

    public string detectPressedKey()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                return kcode.ToString();
            }
        }

        return "";
    }

    // Use this for initialization
    void Start () {
        pizzaCode = "HWI".ToCharArray();
        pizzaCodeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        input = detectPressedKey();

        if(pizzaCodeCount >= pizzaCode.Length)
        {
            Debug.Log("Finish!");
            pizzaCodeCount = 0;
        }

        if(Regex.IsMatch(input, @"^[A-Z]+$"))
        {
            if(input[0] == pizzaCode[pizzaCodeCount])
            {
                pizzaCodeCount++;
                Debug.Log("Correct!");
            }
            else
            {
                pizzaCodeCount = 0;
                Debug.Log("Incorrect!");
            }
        }
	}

}
