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
    }
	
	// Update is called once per frame
	void Update () {
        //print(atk);
           
	}
    public void easy()
    {
        atk = 1;

        _easy.GetComponent<Image>().enabled = true;
        _medium.GetComponent<Image>().enabled = false;
        _hard.GetComponent<Image>().enabled = false;
    }
    public void medium()
    {
        atk = 2;

        _easy.GetComponent<Image>().enabled = false;
        _medium.GetComponent<Image>().enabled = true;
        _hard.GetComponent<Image>().enabled = false;
    }
    public void hard()
    {
        atk = 3;

        _easy.GetComponent<Image>().enabled = false;
        _medium.GetComponent<Image>().enabled = false;
        _hard.GetComponent<Image>().enabled = true;
    }
}
