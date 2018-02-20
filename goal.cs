using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goal : MonoBehaviour {
    public bool IsWin;
	// Use this for initialization
	void Start () {
        IsWin = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            IsWin = true;
            score_sc.score += 4000;
            SceneManager.LoadScene("win"); 
        }
    }
}
