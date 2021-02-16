using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text scoreText;

    void Awake()
    {
        Player.onCollect += RenderScore;
        Debug.Log(Player.score);
    }

	// Use this for initialization
	void Start () {
        RenderScore();
	}
	
	void RenderScore()
    {
        scoreText.text = "Score: " + Player.score;
    }
}
