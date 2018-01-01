using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private int score = 0;
    private Vector3 newPos = new Vector3(0, 2, 0);
    private Vector3 newScale = new Vector3(1.5f, 1.5f, 0);
    private float speedPos = 20f;
    private float speedScale = 1f;

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

    public void EndingPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, speedPos * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speedScale * Time.deltaTime);
    }

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
    }
}
