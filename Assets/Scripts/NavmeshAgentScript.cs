using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour {

    public Transform target;
    public AudioSource audioSource;
    public AudioClip[] clip;
    NavMeshAgent agent; 

    // Use this for initialization
	void Start () 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        agent.SetDestination(target.position);
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(clip[Random.Range(0, clip.Length-1)]);
        }
	}
}
