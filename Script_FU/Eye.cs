using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {
    private GameObject obj;
    public Animator ani;
    public GameObject bot;
    public GameObject cam;
    RaycastHit ray;
    public GameObject sli;
    // Use this for initialization
    void Start () { 
        obj = GameObject.Find("Blink");
        ani = obj.GetComponent<Animator>();
        sli = GameObject.FindGameObjectWithTag("SliderBar");    
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(cam.transform.position, cam.transform.forward,Color.green);
        if (Input.GetMouseButtonDown(1))    //Right Click
        {
            ani.Play("blink");
            sli.GetComponent<Blink_Bar>().slider.value = 0;
        }
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out ray) )    
        {
            if (ray.transform.gameObject.tag == "Enemy" && bot.GetComponent<Renderer>().isVisible == true)      //See the Enemy
            {
                bot.GetComponentInParent<basic_zombie>().nav.speed = 0;          
            }
            else 
            {
                bot.GetComponentInParent<basic_zombie>().nav.speed = 3;
            }
        }       
     
    }
}
