using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private int score = 0;
    public TextMeshProUGUI scoreText;

    public void SetScore(int point)
    {
        score += point;
        scoreText.SetText("SCORE : " + score);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
    }
}
