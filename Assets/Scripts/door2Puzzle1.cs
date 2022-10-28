using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2Puzzle1 : MonoBehaviour
{
    public GameObject lever;
    public GameObject door;

    public bool isLeftDoor;

    public bool active = false;
    public bool preActive = false;

    int i = 0;

    public bool startOpen = false;
    public bool startClose = false;

    // Update is called once per frame
    void Update()
    {
        if (lever.GetComponent<lever>().currentState)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (startOpen)
        {
            if (isLeftDoor)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.002f, gameObject.transform.position.y - 0, gameObject.transform.position.z - 0);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.002f, gameObject.transform.position.y + 0, gameObject.transform.position.z + 0);
            }

            i++;

            if (i == 600)
            {
                startOpen = false;

                door.GetComponent<door1Puzzle1>().i = 600;
            }
        }

        if (startClose)
        {
            if (isLeftDoor)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.002f, gameObject.transform.position.y - 0, gameObject.transform.position.z - 0);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.002f, gameObject.transform.position.y + 0, gameObject.transform.position.z + 0);
            }

            i--;

            if (i == 600)
            {
                startOpen = false;

                door.GetComponent<door1Puzzle1>().i = 0;
            }
        }

        if (door.GetComponent<door1Puzzle1>().i == 0 && active && !preActive)
        {
            startOpen = true;
        }
        else if (door.GetComponent<door1Puzzle1>().i == 600 && active && !preActive)
        {
            startClose = true;
        }

        preActive = active;
    }
}
