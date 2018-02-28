using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class random_switch : MonoBehaviour {
    public GameObject[] _switch;
    private int i;
    private int random;
	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
            foreach(GameObject sw in _switch)
            {
                if(i < 5)
                {
                    random = Random.Range(0, 2);
                    if (random == 0)
                    {
                        if (sw != null)
                        {
                            Destroy(sw);
                            i++;
                        }
                    }   
                }   
            }
	}
}
