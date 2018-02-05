using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bulletui : MonoBehaviour {
    [SerializeField]
    private gun gun;
    private Text te;
	// Use this for initialization
	void Start () {
        gun = GameObject.Find("Gun").GetComponentInChildren<gun>();
        te = GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        te.text = "" + gun.o + "/8";
	}
}
