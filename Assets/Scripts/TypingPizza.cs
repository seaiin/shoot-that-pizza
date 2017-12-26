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

    public TypingTab typingTab;
    public PizzaTab pizzaTab;

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
        isFinish = true;
        Array.Clear(pizzaCode, 0, pizzaCode.Length);
        isEmptry = true;
        pizzaCodeCount = 0;
        typingTab.SetTypingCount(pizzaCodeCount);
        typingTab.SetTypingChar(pizzaCode);
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
            }
            else
            { 
                if (input[0] == pizzaCode[0] && pizzaCodeCount == 1)
                {
                    pizzaCodeCount = 1;
                }
                else
                {
                    pizzaCodeCount = 0;
                }   
            }
            typingTab.SetTypingCount(pizzaCodeCount);
            pizzaTab.ChangedSprite(pizzaCodeCount);
        }
    }

    public void SetPizza(string pizza)
    {
        if (pizza != "")
        {
            pizzaCode = pizza.ToCharArray();
            isEmptry = false;
            typingTab.SetTypingChar(pizzaCode);
            typingTab.SetTypingCount(pizzaCodeCount);
            pizzaTab.SetPizza(pizza);
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

    public char[] GetPizza()
    {
        return pizzaCode;
    }

    public void TypeUpdate()
    {
        if (detectPressedKey() != "")
        {
            GetInput();
            CheckInput();
        }

        if (pizzaCodeCount >= pizzaCode.Length)
        {
            SetFinish();
        }
   
    }

    public Sprite getCompletePizza ()
    {
        return pizzaTab.getCompletePizza();
    }
}
