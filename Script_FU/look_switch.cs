using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_switch : MonoBehaviour {
    public float count;
    public bool stop;
    public Light l;
    public GameObject door;
    public GameObject handler;
	// Use this for initialization
	void Start () {
        count = 0;
        l.color = Color.red;
     //   l.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(count > 10) //switch active
        {
            handler.transform.localRotation = Quaternion.Euler(90, 0, 0);
            stop = true;
            score_sc.score += 1000;
            count_switch._count_switch += 1;
            GetComponent<box_gui>().enabled = false;
            l.enabled = true;
            l.color = Color.green;
            this.enabled = false;
        }
	}
}
