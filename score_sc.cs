using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_sc : MonoBehaviour {
    Text sc_text;
    public static int score;
    public float time_score;
    public GameObject goal;
    public int final_time_score;
    public float Ffinal_time_score;

    // Use this for initialization
    void Start () {
        sc_text = GameObject.Find("score").GetComponent<Text>();
        time_score = 0;
        goal = GameObject.Find("win_spot");
	}
	
	// Update is called once per frame
	void Update () {
        sc_text.text = "Score:" + score;
        time_score += Time.deltaTime;
  
        if (goal.GetComponent<goal>().IsWin == true)
        {
            Ffinal_time_score = time_score;
            Ffinal_time_score = (1 / Ffinal_time_score) *1000000;
            final_time_score = Mathf.RoundToInt(Ffinal_time_score);
            score += final_time_score;
     
        }
        
	}
}
