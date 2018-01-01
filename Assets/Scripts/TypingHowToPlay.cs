using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypingHowToPlay : MonoBehaviour {
    public AudioSource audioSource;
    public TypingTab typingTab;

    private char[] pizzaCode = new char[10];
    private int pizzaCodeCount;
    private string input;
    private AudioClip[] audioClip;

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
        SceneManager.LoadScene("HowToPlay");
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
                audioSource.PlayOneShot(audioClip[2]);
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
        }
    }


    void Update()
    {
        if (detectPressedKey() != "")
        {
            GetInput();
            CheckInput();
        }

        if (pizzaCodeCount >= pizzaCode.Length)
        {
            audioSource.PlayOneShot(audioClip[0]);
            SetFinish();
        }
    }

    void Awake()
    {
        pizzaCode = "HTP".ToCharArray();
        typingTab.SetTypingChar(pizzaCode);
        typingTab.SetTypingCount(0);
    }
}
