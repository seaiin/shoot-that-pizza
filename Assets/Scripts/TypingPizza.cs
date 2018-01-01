using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingPizza : MonoBehaviour {

    private char[] pizzaCode = new char[10];
    private int pizzaCodeCount;
    private string input;
    private bool isFinish = false;
    private bool isEmptry = true;
    private bool isEnd = false;
    private AudioClip[] audioClip;

    public TypingTab typingTab;
    public PizzaTab pizzaTab;
    public AudioSource audioSource;

    void Start()
    {
        audioClip = Resources.LoadAll<AudioClip>("Typing");
    }

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
                if (pizzaCodeCount < 3)
                {
                    audioSource.PlayOneShot(audioClip[1]);
                }
            }
            else
            {
                pizzaCodeCount = 0;
                audioSource.PlayOneShot(audioClip[2]);
            }
            typingTab.SetTypingCount(pizzaCodeCount);
            if (!isEnd)
            {
                pizzaTab.ChangedSprite(pizzaCodeCount);
            }
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
            if (!isEnd)
            {
               pizzaTab.SetPizza(pizza);
            }
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
            if (isEnd)
            {
                SceneManager.LoadScene("Start");
            }
            else
            {
                SetFinish();
                audioSource.PlayOneShot(audioClip[0]);
            }
        }
   
    }

    public Sprite getCompletePizza ()
    {
        return pizzaTab.getCompletePizza();
    }

    public void SetEnd()
    {
        isEnd = true;
        SetPizza("AGN");
    }
}
