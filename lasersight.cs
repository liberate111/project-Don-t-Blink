using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasersight : MonoBehaviour {
    LineRenderer line;
    public gun guns;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        guns = GetComponentInParent<gun>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
      if  (Physics.Raycast(transform.position,transform.forward,out hit)){
            if (hit.collider)
            {
                line.SetPosition(1, new Vector3(0,0,hit.distance));
                guns.bul_Hit = hit.transform;
            }
        }else{
            line.SetPosition(1, new Vector3(0, 0, 5000));
        }
	}
}
