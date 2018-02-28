using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_door : MonoBehaviour {
    //Ray ray;
    RaycastHit ray;
    bool loc;
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
                if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("O") == 1)
                {
                    if (loc == false)
                    {
                        ray.transform.GetComponentInParent<Open_door>().check_door = true;
                        loc = true;
                        StartCoroutine(Wait());
                    }
                 
                }            
            }
        }
        
    }
    IEnumerator Wait()
    {
        //Debug.Log("Before Waiting 2 seconds");
       
        yield return new WaitForSeconds(3);
        loc = false;
        //Debug.Log("After Waiting 2 Seconds");

    }
}
