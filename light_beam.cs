using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class light_beam : MonoBehaviour {
    Light l;
    private bool k;
    public GameObject bot;
    public float value_beam;
    private int _value_beam;
    private GameObject lightbeam;
	// Use this for initialization
	void Start () {
        value_beam = 10;
        l = GetComponent<Light>();
        bot = GameObject.FindGameObjectWithTag("Enemy");
        lightbeam = GameObject.Find("lightbeam_bar");
	}
	
	// Update is called once per frame
	void Update () {
        if(value_beam <= 0)
        {
            k = false;
        }
        _value_beam = Mathf.RoundToInt(value_beam);
        lightbeam.GetComponent<Text>().text = "BATTERY  " + _value_beam;

        if (k)
        {
            value_beam -= Time.deltaTime;
            l.intensity = Mathf.Lerp(l.intensity, 7,1f* Time.deltaTime);
            l.spotAngle = Mathf.Lerp(l.spotAngle, 25, 1f * Time.deltaTime);
        }
        else
        {
            bot.GetComponent<basic_zombie>().lighting = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            k = true;
        //    l.intensity = Mathf.Clamp( Time.deltaTime,1, 7); ;
           // l.spotAngle = 30;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            k = false;
            l.intensity = 1;
            l.spotAngle = 60;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (k)
        {
            if (other.transform.tag == "Enemy")
            {
                other.transform.GetComponent<basic_zombie>().lighting = true;
            }
        
        }
   
    }
    private void OnTriggerExit(Collider other)
    {
      
            if (other.transform.tag == "Enemy")
            {
                other.transform.GetComponent<basic_zombie>().lighting = false;
            }

        

    }
}
