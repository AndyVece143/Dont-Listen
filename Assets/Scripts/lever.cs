using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class lever : MonoBehaviour
{
    public bool currentState = false;
    private Animation anim;
    //private Animator anim;

    //Audio stuff
    private AudioSource custAudioSource;

    [SerializeField]
    private AudioClip leverOn;

    [SerializeField]
    private AudioClip leverOff;

    public void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        custAudioSource = GetComponent<AudioSource>();
    }


    public void pulled()
    {
        if (!currentState)
        {
            currentState = true;

            // animate lever turning on
            anim.Play("Pull1");
            custAudioSource.PlayOneShot(leverOn);
        }
        else 
        {
            currentState = false;

            // animate lever turning off
            anim.Play("Pull2");
            custAudioSource.PlayOneShot(leverOff);
        }
    }
}
