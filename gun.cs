using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {
    private Animator ani;
    private bool Reloading;
    private bool shoot;
    private AudioSource Gun_sound;
    public AudioClip[] sa;
    public GameObject bullet;
    public Transform bul_Hit;
    [SerializeField]
    public int o;
    public GameObject cartage;
    public GameObject car_spot;
    public GameObject buller_spwan;
    public Transform gaden;

    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
        Gun_sound = GetComponent<AudioSource>();
        o = 8;
	}
	
	// Update is called once per frame
	void Update () {
      
        if (Input.GetMouseButtonDown(0)&&o>0&& !this.ani.GetCurrentAnimatorStateInfo(0).IsName("reload"))
        {
            if (!this.ani.GetCurrentAnimatorStateInfo(0).IsName("shoot")&& !this.ani.GetCurrentAnimatorStateInfo(0).IsName("zero")&&Reloading==false)
            {
             
                    ani.Play("shoot");
                Gun_sound.clip = sa[Random.Range(0,2)];
                Gun_sound.Play();
                    GameObject ss = Instantiate(cartage, car_spot.transform.position, Quaternion.Euler(90,0,0)) as GameObject;
                    ss.GetComponent<Rigidbody>().AddForce((gaden.position- car_spot.transform.position ) * Random.Range(300,340));
                    o--;
                    GameObject buller= Instantiate(bullet,buller_spwan.transform.position,Quaternion.identity) as GameObject;
                buller.GetComponent<Rigidbody>().AddForce(transform.forward* 2500);
                
            }

        }
        else if( o== 0)
        {
            if(Reloading == false)
            {
                 if (!this.ani.GetCurrentAnimatorStateInfo(0).IsName("zero"))
                {
                    //Reloading = true;
                    if (Gun_sound.isPlaying == false)
                    {
                        Gun_sound.clip = sa[2];
                        Gun_sound.Play();
                        ani.SetBool("zero", true);
                        StartCoroutine(Wait());
                    }
              
                }
               
            }
           

        }
       if (Input.GetKeyDown(KeyCode.R)&&Reloading==false)
            {
            if (!this.ani.GetCurrentAnimatorStateInfo(0).IsName("shoot"))
            {
                if(o<8)
                Reloading = true;
            }
            }
     
        if (Reloading == true&&ani.GetBool("reload")==false)
        {
            // o = 0;
            if (Gun_sound.isPlaying == false)
            {
                Gun_sound.clip = sa[2];
                Gun_sound.Play();
                ani.SetBool("reload", true);
                StartCoroutine(Wait());
            }
         

        }
        else if(Reloading==false)
        {
            ani.SetBool("reload", false);
        }
        if (shoot == true)
        {
            StartCoroutine(Waittoshoot());
        }

    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.17f);
        // print("WaitAndPrint " + Time.time);
        o = 8;
        Reloading = false;
        ani.SetBool("zero", false);
    }
    private IEnumerator Waittoshoot()
    {
        yield return new WaitForSeconds(0.18f);
        // print("WaitAndPrint " + Time.time);
        shoot = false;
    }

}
