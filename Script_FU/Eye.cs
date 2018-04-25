using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Eye : MonoBehaviour {
    private GameObject obj;
    public Animator ani;
    public GameObject bot;
    public GameObject cam;
    RaycastHit ray;
    private bool eye_close;
    public GameObject sli;
    public bool blink;
    RaycastHit ray_switch;
    private int count_switch;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    private Text ttt;
    private Text hp;
    public int hitpoint;
    private GameObject _switch;
    public Transform cam1;
    public Transform cam2;
    public Transform main_cam;
    public GameObject zom;
    // Use this for initialization
    void Start () { 
        obj = GameObject.Find("Blink");
        ani = obj.GetComponent<Animator>();
        sli = GameObject.FindGameObjectWithTag("SliderBar");
        ttt = GameObject.Find("count_time").GetComponent<Text>();
        ttt.gameObject.SetActive(false);
        hitpoint = 100;
        hp = GameObject.Find("Hp").GetComponent<Text>();
        _switch = GameObject.Find("Switch_sound");
        zom = GameObject.FindGameObjectWithTag("Enemy");
          
	}
    /*
     tri = Q
     O  = E
     [] = right click
      */

    // Update is called once per frame
    void Update() {
     
        if (hitpoint <= 0)
        {
            SceneManager.LoadScene("game_over");
            main_cam.parent = null;
            main_cam.transform.position = cam1.position;
            main_cam.LookAt(cam2);

        }
        //Debug.DrawRay(cam.transform.position, cam.transform.forward,Color.green);
        hp.text = "HP : " + hitpoint;
        if (Input.GetMouseButtonDown(1) || Input.GetAxis("[]") == 1)    //Right Click
        {
            StartCoroutine(Wait());
            ani.Play("blink");
            sli.GetComponent<Blink_Bar>().slider.value = 0;
        }
        if (blink)
        {
            StartCoroutine(Wait());
            blink = false;
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out ray))
        {
            if (ray.transform.gameObject.tag == "Enemy" && bot.GetComponent<Renderer>().isVisible == true)      //See the Enemy
            {
                if (eye_close == false && bot.GetComponentInParent<basic_zombie>().s==false)
                {
                    bot.GetComponentInParent<basic_zombie>().founded = true;
                }
                else 
                {
                    bot.GetComponentInParent<basic_zombie>().founded = false;
                }

            }
            else if (ray.transform.tag == "bat")
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("O") == 1)
                {
                    Destroy(ray.transform.gameObject);
                    GetComponentInChildren<light_beam>().value_beam += 10;
                    score_sc.score += 50;
                }
            }
            else if (ray.transform.tag == "medic")
            {
                if ((Input.GetKeyDown(KeyCode.E)||  Input.GetAxis("O") == 1) && hitpoint < 100 )
                {
                    Destroy(ray.transform.gameObject);
                    hitpoint = 100;
                    score_sc.score += 50;
                }
            }
            else
            {
                bot.GetComponentInParent<basic_zombie>().founded = false;
            }   
        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out ray_switch, 3)) {
            if(ray_switch.transform.gameObject.tag == "switch")
            {
                if (ray_switch.transform.GetComponent<look_switch>().stop == false)
                {
                    ttt.gameObject.SetActive(true);
                    ray_switch.transform.GetComponent<look_switch>().count += Time.deltaTime;
                    count_switch = Mathf.RoundToInt(ray_switch.transform.GetComponent<look_switch>().count);
                    ttt.text = "" + count_switch;
                    if (_switch.GetComponent<AudioSource>().isPlaying==false)
                    _switch.GetComponent<AudioSource>().Play();
                }
                else
                {
                    ttt.gameObject.SetActive(false);
                }
            }
            else
            {
                ttt.gameObject.SetActive(false);
                _switch.GetComponent<AudioSource>().Stop();
            }
        }

    }
    IEnumerator Wait()
    {
        //Debug.Log("Before Waiting 2 seconds");
        eye_close = true;
        zom.GetComponent<basic_zombie>().nav.speed = 20;
        zom.GetComponent<basic_zombie>().blinking = true;
        yield return new WaitForSeconds(1);
        //zom.GetComponent<basic_zombie>().nav.speed = 8;
        eye_close = false;
        zom.GetComponent<basic_zombie>().blinking = false;
        //Debug.Log("After Waiting 2 Seconds");

    }
    public void after_release()
    {
        ani.Play("blink");
    }
}
