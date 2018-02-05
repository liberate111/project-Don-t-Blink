using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Open_door : MonoBehaviour {
    public Animator animator;
    public bool check_door;
    public AudioClip[] sound_door;
    private AudioSource _sound_door;
    public NavMeshObstacle obs;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        _sound_door = GetComponent<AudioSource>();
        obs = GetComponent<NavMeshObstacle>();
    }
	
	// Update is called once per frame
	void Update () {       
        if (check_door)
        {
            if (!_sound_door.isPlaying)
            {
                if (animator.GetBool("open") == false)
                {
                    animator.SetBool("open", true);
                    _sound_door.clip = sound_door[0];
                    _sound_door.Play();
                    
                }
                else
                {
                    animator.SetBool("open", false);
                    _sound_door.clip = sound_door[1];
                    _sound_door.Play();
                }    
                check_door = false;
            }                   
        }
        if (animator.GetBool("open") == false)
            obs.enabled = true;
        else
            obs.enabled = false;
    }   
}
