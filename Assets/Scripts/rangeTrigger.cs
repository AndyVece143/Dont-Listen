using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class rangeTrigger : MonoBehaviour
{
    public GameObject Player;

    // is the player clicking this frame
    public bool clicked;

    // is the player in reach of something
    public bool isInReach = false;

    // is the player holding something
    public bool isHolding = false;

    // is the player dropping something this frame
    public bool dropping = false;

    // current object within reach
    public GameObject whatsInReach;

    // what the player is currently holding
    public GameObject whatsHeld;

    public Vector3 pastPosition;

    void Update()
    {
        // left click check
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }

        // position held was in
        if (whatsHeld)
        {
            pastPosition = whatsHeld.transform.position;
        }

        // drop item
        if (isHolding && clicked)
        {
            // my girlfriend says to keep this line of code in the final game
            // whatsHeld.GetComponent<Rigidbody>().AddForce(new Vector3(8000, 300, 8000));

            isHolding = false;
            whatsHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
            whatsHeld.GetComponent<Rigidbody>().freezeRotation = false;
            whatsHeld = null;
            dropping = true;
        }

        // if the player is in reach of something and clicks
        if (isInReach && clicked && !dropping)
        {
            isHolding = true;
            whatsHeld = whatsInReach;
            whatsHeld.GetComponent<Rigidbody>().freezeRotation = true;
        }

        // move object with player
        if (isHolding)
        {
            //if ()
            {
                whatsHeld.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z);
            }
        }

        // reset drop
        dropping = false;

        // reset click
        clicked = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // if in range of an interactable
        if (other.tag == "interactable")
        {
            Debug.Log("cube entering collision");

            isInReach = true;

            whatsInReach = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if in range of an interactable
        if (other.tag == "interactable")
        {
            Debug.Log("cube leaving collision");

            isInReach = false;

            whatsInReach = null;
        }
    }
}
