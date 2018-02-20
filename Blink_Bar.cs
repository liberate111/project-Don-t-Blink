using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink_Bar : MonoBehaviour {
    public Slider slider;
    public GameObject _Blink;
    public int count;
    public GameObject _bot;
    private GameObject palyer;
    
	// Use this for initialization
	void Start () {
        palyer = GameObject.FindGameObjectWithTag("Player");
        slider = GetComponent<Slider>();
        slider.value = 0;
        _Blink = GameObject.Find("Blink");
        count = 0;
        _bot = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = slider.value + Time.deltaTime;
        if(slider.value == 8)   //Refresh bar value and Play Animation
        {
            palyer.GetComponent<Eye>().blink = true;
            _Blink.GetComponent<Animator>().Play("blink");
            slider.value = 0;
        }
    }
}
