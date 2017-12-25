using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingTab : MonoBehaviour {

    public TextMeshProUGUI typingText;

    private string typingChar;
    private int typingCount;

    public void SetTypingChar(char[] typing)
    {
        typingChar = new string(typing);
        typingText.SetText(typingChar + " : " + typingCount);
    }

    public void SetTypingCount(int count)
    {
        typingCount = count;
        typingText.SetText(typingChar + " : " + typingCount);
    }

	// Use this for initialization
	void Start () {
        typingText = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
