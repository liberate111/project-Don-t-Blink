using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartbeat : MonoBehaviour {
    private AudioSource au;
    private GameObject enemy;
    private GameObject closing_enemy;
	// Use this for initialization
	void Start () {
        au = GetComponent<AudioSource>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        closing_enemy = GameObject.Find("Close_sound");
        au.volume = 0f;
        au.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, enemy.transform.position) < 35){
            if (Vector3.Distance(transform.position, enemy.transform.position) < 10)
            {
                au.volume = 1f;
            }
            else if (Vector3.Distance(transform.position, enemy.transform.position) < 15)
            {

                au.volume = 0.8f;
            }
            else if (Vector3.Distance(transform.position, enemy.transform.position) < 20)
            {
                au.volume = 0.6f;
             
            }
            else if (Vector3.Distance(transform.position, enemy.transform.position) < 28)
            {
                au.volume = 0.4f;
               
            }
            if (au.isPlaying == false)
            {
             
                au.volume = 0.2f;
                au.Play();          
            }
            
        }
        else if(Vector3.Distance(transform.position, enemy.transform.position) >= 35)
        {
            au.volume = 0f;
            au.Stop();
        }
        if (Vector3.Distance(transform.position, enemy.transform.position) >= 6)
        {
            closing_enemy.GetComponent<AudioSource>().Stop();
            closing_enemy.GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            if (closing_enemy.GetComponent<AudioSource>().isPlaying == false)
            {
                closing_enemy.GetComponent<AudioSource>().Play();
                closing_enemy.GetComponent<AudioSource>().volume = 0.1f;
            }
        }
        
    }
}
