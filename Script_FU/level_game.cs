using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_game : MonoBehaviour {
    public static int atk;
    private GameObject _easy;
    private GameObject _medium;
    private GameObject _hard;

    // Use this for initialization
    void Start () {
        _easy = GameObject.Find("Checkmark_Easy");
        _medium = GameObject.Find("Checkmark_Medium");
        _hard = GameObject.Find("Checkmark_Hard");
        atk = 5;
    }
	
	// Update is called once per frame
	void Update () {
        //print(atk);
           
	}
    public void easy()
    {
        atk = 5;

        _easy.GetComponent<Image>().enabled = true;
        _medium.GetComponent<Image>().enabled = false;
        _hard.GetComponent<Image>().enabled = false;
    }
    public void medium()
    {
        atk = 10;

        _easy.GetComponent<Image>().enabled = false;
        _medium.GetComponent<Image>().enabled = true;
        _hard.GetComponent<Image>().enabled = false;
    }
    public void hard()
    {
        atk = 15;

        _easy.GetComponent<Image>().enabled = false;
        _medium.GetComponent<Image>().enabled = false;
        _hard.GetComponent<Image>().enabled = true;
    }
}
