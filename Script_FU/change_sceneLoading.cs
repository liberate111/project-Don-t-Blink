using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_sceneLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("change_scene", 6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void change_scene()
    {
        SceneManager.LoadScene("Wc");
    }
}
