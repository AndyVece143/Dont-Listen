using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestination : MonoBehaviour
{
    // what items this interacts with
    public List<string> itemKeys = new List<string>();

    // is the corresponding item colliding
    public List<bool> itemColliding = new List<bool>();

    // if this has been activated
    public bool activator = false;

    // used in triggers
    private int index = 0;

    void Start()
    {
        int length = itemColliding.Count;
        for (int i = 0; i < length; i++)
        {
            itemColliding[i] = false;
        }
    }

    void Update()
    {
        // if all items are on itemDestination, activate 
        foreach(bool b in itemColliding)
        {
            if (b)
            {
                activator = true;
            }
            else
            {
                activator = false;
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if in range of an interactable
        if (other.tag == "interactable")
        {
            index = 0;

            foreach (string s in itemKeys)
            {
                // if the item key matches the item
                if (s == other.name)
                {
                    itemColliding[index] = true;
                }

                index++;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if in range of an interactable
        if (other.tag == "interactable")
        {
            index = 0;

            foreach (string s in itemKeys)
            {
                // if the item key matches the item
                if (s == other.name)
                {
                    itemColliding[index] = false;
                }

                index++;
            }
        }
    }
}
