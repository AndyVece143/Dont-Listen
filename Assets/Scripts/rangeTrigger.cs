using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class rangeTrigger : MonoBehaviour
{
    public GameObject Player;

    // is the player clicking right this frame
    public bool clickedL;

    // is the player clicking right this frame
    public bool clickedR;

    // is the player in reach of an item
    public bool isInReach = false;

    // is the player in reach of a lever
    public bool leverIsInReach = false;

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
            clickedL = true;
        }

        // right click check
        if (Input.GetMouseButtonDown(1))
        {
            clickedR = true;
        }

        // position held was in
        if (whatsHeld)
        {
            pastPosition = whatsHeld.transform.position;
        }

        // drop item
        if (isHolding && clickedL)
        {
            isHolding = false;
            whatsHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
            whatsHeld.GetComponent<Rigidbody>().freezeRotation = false;
            whatsHeld = null;
            dropping = true;
        }

        // drop item
        if (isHolding && clickedR)
        {
            isHolding = false;
            whatsHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
            whatsHeld.GetComponent<Rigidbody>().freezeRotation = false;
            whatsHeld.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 7.0f, 3.0f);
            whatsHeld = null;
            dropping = true;
        }

        // if the player is in reach of something and clicks
        if (isInReach && clickedL && !dropping)
        {
            isHolding = true;
            whatsHeld = whatsInReach;
            whatsHeld.GetComponent<Rigidbody>().freezeRotation = true;
        }

        // if the player is in reach of something and clicks
        if (leverIsInReach && clickedL)
        {
            whatsInReach.GetComponent<lever>().pulled();
        }

        // move object with player
        if (isHolding)
        {
            {
                whatsHeld.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z);
            }
        }

        // reset drop
        dropping = false;

        // reset click
        clickedL = false;
        // reset click
        clickedR = false;
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

        // if in range of a lever
        if (other.tag == "lever")
        {
            Debug.Log("lever entering collision");

            leverIsInReach = true;

            whatsInReach = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if leaving range of an interactable
        if (other.tag == "interactable")
        {
            Debug.Log("cube leaving collision");

            isInReach = false;

            whatsInReach = null;
        }

        // if leaving range of a lever
        if (other.tag == "lever")
        {
            Debug.Log("lever leaving collision");

            leverIsInReach = false;

            whatsInReach = null;
        }
    }
}
