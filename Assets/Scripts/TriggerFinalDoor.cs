﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject Door2;
    public bool Triggered;
    public AudioSource sfx;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame


    public void OnTriggerEnter(Collider other)
    {
        if (Triggered == false && other.gameObject.tag == "Player" && open == true)
        {
            Triggered = true;
            Door.GetComponent<Animator>().SetTrigger("OpenDoor1"); // What I used for a one-off 
            Door2.GetComponent<Animator>().SetTrigger("OpenDoor2");
            sfx.PlayOneShot(doorOpen);
        }
        if (Triggered == false && other.gameObject.tag == "Player" && open == false)
        {
            sfx.PlayOneShot(doorClose);
        }
    }
}