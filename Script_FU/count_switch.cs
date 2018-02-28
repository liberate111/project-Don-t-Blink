using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_switch : MonoBehaviour {
    public static int _count_switch;
    public GameObject door_exit_Ob;
    public GameObject _door_exit;
    private bool plus_bonus_once;
    private bool s;
    // Use this for initialization
    void Start () {
        _count_switch = 0;
        //door_exit = GameObject.Find("door_exit");
        plus_bonus_once = false;
        s = false;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = _count_switch + "/5";
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            s = true;
        }
		if(_count_switch == 5|| s==true)
        {
            if(plus_bonus_once == false)
            {
                score_sc.score += 1000;
                plus_bonus_once = true;
                _door_exit.GetComponent<door_gui>().display = true;
                Destroy(door_exit_Ob); 

            }
            
          
        }
	}
}
