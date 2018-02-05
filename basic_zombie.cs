using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_zombie : MonoBehaviour {
    public UnityEngine.AI.NavMeshAgent nav;
    private GameObject player;
    private int hp;
    private Animator ani;
    public GameObject blood;
    public Transform t_other;
	// Use this for initialization
	void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        hp = 5;
	}
	
	// Update is called once per frame
	void Update () {
     
        if (hp <= 0)
        {
            ani.SetBool("dead",true);
            nav.enabled = false;
            // Destroy(this.gameObject);
        }
        else
        {
            nav.SetDestination(player.transform.position);
        }
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "bullet")
        {   
            hp--;
            Destroy(col.gameObject);
            print(hp);
            Instantiate(blood, col.transform.position, Quaternion.identity);
        }
    }
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
    }
    IEnumerator Wait(Transform t)
    {
        //Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(5);
        //Debug.Log("After Waiting 2 Seconds");
        t_other.GetComponentInParent<Open_door>().animator.SetBool("open",true);
    }
}
