using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingPizza : MonoBehaviour {

    private char[] pizzaCode = new char[10];
    private int pizzaCodeCount;
    private string input;
    private bool isFinish = false;
    private bool isEmptry = true;

    private string detectPressedKey()
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

    private void GetInput()
    {
        input = detectPressedKey();
    }

    private void SetFinish()
    {
        if (pizzaCodeCount >= pizzaCode.Length)
        {
            isFinish = true;
            Array.Clear(pizzaCode, 0, pizzaCode.Length);
            isEmptry = true;
            pizzaCodeCount = 0;
            Debug.Log("Finish!");
        }
    }
    
    public void SetNotFinish()
    {
        isFinish = false;
    }

    private void CheckInput()
    {
        if (Regex.IsMatch(input, @"^[A-Z]+$"))
        {
            if (input[0] == pizzaCode[pizzaCodeCount])
            {
                pizzaCodeCount++;
                Debug.Log("Correct! - " + pizzaCodeCount);
            }
            else
            { 
                if (input[0] == pizzaCode[0] && pizzaCodeCount == 1)
                {
                    pizzaCodeCount = 1;
                    Debug.Log("Correct! - " + pizzaCodeCount);
                }
                else
                {
                    pizzaCodeCount = 0;
                }   
            }
        }
    }

    public void SetPizza(string pizza)
    {
        Debug.Log(pizza);
        if (pizza != "")
        {
            pizzaCode = pizza.ToCharArray();
            isEmptry = false;
        }
    }

    public bool isTypingFinish()
    {
        return isFinish;
    }

    public bool isTypingEmp()
    {
        return isEmptry;
    }

    public void TypeUpdate()
    {
        GetInput();
        CheckInput();
        SetFinish();
    }


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

}
