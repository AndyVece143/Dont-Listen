using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // the item destination that triggers this object
    public List<GameObject> activivatorObjects;

    public bool puzzleComplete = false;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in activivatorObjects)
        {
            // if the activator is, well, activated
            if (g.GetComponent<itemDestination>().activator)
            {
                puzzleComplete = true;
            }
            else
            {
                puzzleComplete = false;
                break;
            }
        }

        if (puzzleComplete)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
        }
    }
}
