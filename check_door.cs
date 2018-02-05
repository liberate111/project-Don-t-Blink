using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_door : MonoBehaviour {
    //Ray ray;
    RaycastHit ray;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	   if(Physics.Raycast(transform.position,transform.forward,out ray,5))
        {
           // print("test ray"+ ray.collider.name);
            if(ray.collider.gameObject.tag == "door")
            {  
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ray.transform.GetComponentInParent<Open_door>().check_door = true;
                }            
            }
        }
        
    }
}
