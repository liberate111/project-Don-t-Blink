using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removebullet : MonoBehaviour {
    public int t=2;
	// Use this for initialization
	void Start () {
        Invoke("remove", t);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void remove()
    {
        Destroy(this.gameObject);
    }
}
