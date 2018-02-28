using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_score : MonoBehaviour {
    private GameObject _score;
    private int score;
    private int highscore;
	// Use this for initialization
	void Start () {
        highscore = 0;
        _score = GameObject.Find("score");
        score = score_sc.score;
        _score.GetComponent<Text>().text = "YOUR SCORE : " + score;
        highscore = PlayerPrefs.GetInt("_highscore", highscore);

    }
	
	// Update is called once per frame
	void Update () {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("_highscore", highscore);
        }
        GetComponent<Text>().text = "HIGH SCORE : " + highscore;
	}
}
