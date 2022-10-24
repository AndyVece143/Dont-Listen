using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class lever : MonoBehaviour
{
    public bool currentState = false;
    private Animation anim;
    //private Animator anim;

    public void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }


    public void pulled()
    {
        if (!currentState)
        {
            currentState = true;

            // animate lever turning on
            anim.Play("Pull1");

        }
        else 
        {
            currentState = false;

            // animate lever turning of
            anim.Play("Pull2");
        }
    }
}
