using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class basic_zombie : MonoBehaviour {
    public UnityEngine.AI.NavMeshAgent nav;
    int oldMask ;
    [SerializeField]
    private GameObject player;
    private int hp;
    private RaycastHit Ray;
    [SerializeField]
    private Animator ani;
    public GameObject blood;
    public Transform t_other;
    public GameObject boxeye;
    public bool founded;
    public bool warp;
    private int Eclick;
    public Transform[] warp_spot;
    public GameObject par_group;
    public bool lighting;
    private bool hitting;
    private Transform red_sc;
    private float ti;
    private float ti_changepath;
    public GameObject[] switching;
    private bool startrun;
    [SerializeField]
    private GameObject burn_zom_sound;
    public Transform eye1;
    public Transform eye2;
    [SerializeField]
    private Transform going_spot;
    private bool player_founded;
    private GameObject hit_sound;
    public bool s;
    private bool ss;
    private bool sound_scarejump;
    private GameObject E_img;
    public bool blinking;
	// Use this for initialization
	void Start () {
        oldMask = Camera.main.cullingMask;
        Eclick = 0;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        red_sc = GameObject.Find("red_hurt").transform;
        ani = GetComponent<Animator>();
        hp = 5;
        ti = 0;
        Invoke("swii",5);
        E_img = GameObject.Find("Eimage");
        hit_sound = GameObject.Find("Hitted");
    }
	
	// Update is called once per frame
	void Update () {
        if (s)
        {
            Camera.main.cullingMask = (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("monster"));
            Camera.main.transform.parent = this.transform;
            Camera.main.transform.localPosition = eye1.localPosition;
            E_img.SetActive(true);
            //  Camera.main.transform.localRotation = Quaternion.Euler(Vector3.zero
            GetComponent<Animator>().speed=0.08f;
            StartCoroutine(stopAni());
            Camera.main.transform.LookAt(eye2.localPosition-Camera.main.transform.localPosition); 
            player.GetComponent<FirstPersonController>().enabled = false;
            if (hit_sound.GetComponent<AudioSource>().isPlaying == false && sound_scarejump == false)
            {
                hit_sound.GetComponent<AudioSource>().Play();
                sound_scarejump = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Eclick++;
                if (Eclick == 15)
                {
                    Camera.main.transform.parent = player.transform;
                    s = false;
                    StartCoroutine(Warp());
                    Eclick = 0;
                    score_sc.score += 100;
                    player.GetComponent<Eye>().after_release();
                }
              
            }
        }
        else
        {
            sound_scarejump = false;
            Camera.main.cullingMask = oldMask;
            E_img.SetActive(false);
            Camera.main.transform.parent = player.transform;
            player.GetComponent<FirstPersonController>().enabled = true;
            GetComponent<Animator>().speed = 1f;
        }
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
            if(s==false)
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
        if (ani.GetBool("atk") == true || hitting)
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
                    nav.speed = 8;
                    player_founded = true;
                    if (s == false)
                    {
                        ani.SetBool("run", true);

                    }
                    else
                    {

                    }
                }
                else
                {
                    player_founded = false;
                    if (blinking == false)
                    {
                        nav.speed = 5;
                    }
                    ani.SetBool("run", false);
                }
                if (Vector3.Distance(transform.position, player.transform.position) < 2)
                {
                    ani.SetBool("atk", true);    
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
        player.GetComponent<Eye>().hitpoint -= level_game.atk;
        s = true;
        ani.SetBool("atk", true);
        red_sc.GetComponent<Animator>().Play("red_active");
        yield return new WaitForSeconds(0.5f);
        hitting = false;
    }
    IEnumerator stopAni()
    {
       
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animator>().speed = 0.05f;
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
