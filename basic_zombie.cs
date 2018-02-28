using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_zombie : MonoBehaviour {
    public UnityEngine.AI.NavMeshAgent nav;
    [SerializeField]
    private GameObject player;
    private int hp;
    private RaycastHit Ray;
    private Animator ani;
    public GameObject blood;
    public Transform t_other;
    public GameObject boxeye;
    public bool founded;
    public bool warp;
    public Transform[] warp_spot;
    public GameObject par_group;
    public bool lighting;
    private bool hitting;
    private Transform red_sc;
    private float ti;
    private float ti_changepath;
    public GameObject[] switching;
    private bool startrun;
    private GameObject burn_zom_sound;
    
    [SerializeField]
    private Transform going_spot;
    private bool player_founded;
    private GameObject hit_sound;
	// Use this for initialization
	void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        red_sc = GameObject.Find("red_hurt").transform;
        ani = GetComponent<Animator>();
        hp = 5;
        ti = 0;
        Invoke("swii",5);
        burn_zom_sound = GameObject.Find("burn_zomebie_sound");
        hit_sound = GameObject.Find("Hitted");
    }
	
	// Update is called once per frame
	void Update () {
        if (lighting)
        {if (burn_zom_sound.GetComponent<AudioSource>().isPlaying==false)
            burn_zom_sound.GetComponent<AudioSource>().Play();
            ti = ti + Time.deltaTime;
            if (ti > 5)
            {
                player_founded = false;
                StartCoroutine(Warp());
                ti = 0;
                score_sc.score += 200;
            }
            par_group.SetActive(true);
        }
        else
        {
            burn_zom_sound.GetComponent<AudioSource>().Stop();
            ti = 0;
            par_group.SetActive(false);
        }
        if (warp)
        {
            warp = false;
        }
        if (founded == true)
        {
            nav.speed = 0;
            ani.speed = 0;
        }
        else
        {
            ani.speed = 1;
        }
        if (hp <= 0)
        {
            ani.SetBool("dead",true);
            nav.enabled = false;
            // Destroy(this.gameObject);
        }
        else
        {
            if (nav.enabled == true && startrun && player_founded == false )
            {
                ti_changepath += Time.deltaTime;
                if (ti_changepath > 9)
                {
                    
                    going_spot = switching[Random.Range(0, 5)].transform;
                    ti_changepath = 0;
                    if (startrun && going_spot != null)
                        nav.SetDestination(going_spot.transform.position);
                }
                else
                {
                    if (going_spot != null)
                    {
                        if (Vector3.Distance(going_spot.position, transform.position) < 4)
                        {
                            going_spot = switching[Random.Range(0, 5)].transform;
                        }
                    }
               
                }
               
            }
            else if (player_founded && nav.enabled == true )
            {
                nav.SetDestination(player.transform.position);
            }
        
        }
        if (ani.GetBool("atk") ==true||hitting)
        {
            ani.SetBool("run", false);
        }
            Debug.DrawRay(boxeye.transform.position,player.transform.position - boxeye.transform.position );

        if (Physics.Raycast(boxeye.transform.position, player.transform.position-boxeye.transform.position, out Ray))
        {
            if (founded == false)
            {
                if (Ray.transform.tag == "Player")
                {
                    nav.speed = 7;
                    player_founded = true;
                    ani.SetBool("run", true);
                }
                else
                {
                    //player_founded = false;
                    nav.speed = 5;
                    ani.SetBool("run", false);
                }
                if (Vector3.Distance(transform.position, player.transform.position) < 2)
                {
                    ani.SetBool("atk", true);
                    if(hit_sound.GetComponent<AudioSource>().isPlaying == false)
                    {
                        hit_sound.GetComponent<AudioSource>().Play();
                    }
                    
                    if (hitting == false)
                    {
                        StartCoroutine(Hit());
                        hitting = true;
                    }
                  
                }
                else
                {
                    ani.SetBool("atk", false);
                }
            }
        }
    }
    /*void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "bullet")
        {   
            hp--;
            Destroy(col.gameObject);
            print(hp);
            Instantiate(blood, col.transform.position, Quaternion.identity);
        }
    }*/
    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "ColliderDoor")
        {
            if(other.GetComponentInParent<Open_door>().animator.GetBool("open") == false)
            {
                t_other = other.transform;
                StartCoroutine(Wait(t_other));   
            }
        }
        if (other.transform.tag == "Player")
        {
          //  print("twawe");
            //ping = true;
        }
    }
    IEnumerator Wait(Transform t)
    {
        //Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(5);
        //Debug.Log("After Waiting 2 Seconds");
        t_other.GetComponentInParent<Open_door>().animator.SetBool("open",true);
    }
    IEnumerator Warp()
    {
        //Debug.Log("Before Waiting 2 seconds");
        nav.enabled = false;
        int a = Random.Range(0, 10);
        transform.position = warp_spot[a].position;

        yield return new WaitForSeconds(3);
        //Debug.Log("After Waiting 2 Seconds");
        player_founded = false;
        nav.enabled = true;
      //  t_other.GetComponentInParent<Open_door>().animator.SetBool("open", true);
    }
    IEnumerator Hit()
    {
        player.GetComponent<Eye>().hitpoint -= 10;
        ani.SetBool("atk", true);
        red_sc.GetComponent<Animator>().Play("red_active");
        yield return new WaitForSeconds(3);
        hitting = false;
    }
    private void OnTriggerEnter(Collider other)
    {
   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //ping = false;
            player_founded = false;
       
        }
    }
    void swii()
    {
        startrun = true;
        switching = GameObject.FindGameObjectsWithTag("switch");
    }
}
