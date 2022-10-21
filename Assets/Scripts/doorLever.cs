using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLever : MonoBehaviour
{
    public List<GameObject> levers = new List<GameObject>();

    public bool allLeversActive = false;

    // is this door the left door of the two
    public bool isLeftDoor;
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in levers)
        {
            // if the activator is, well, activated
            if (g.GetComponent<lever>().currentState)
            {
                allLeversActive = true;
            }
            else
            {
                allLeversActive = false;
                break;
            }
        }

        if (allLeversActive && i < 1300)
        {
            if (isLeftDoor)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.001f, gameObject.transform.position.y, gameObject.transform.position.z);  
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.001f, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            i++;
        }
    }
}
