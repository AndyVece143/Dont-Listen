using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool currentState = false;
    
    public void pulled()
    {
        if (!currentState)
        {
            currentState = true;

            // animate lever turning on
        }
        else 
        {
            currentState = false;

            // animate lever turning off
        }
    }
}
