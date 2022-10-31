using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLever : MonoBehaviour
{
    public List<GameObject> levers = new List<GameObject>();

    public bool allLeversActive = false;

    //Audio
    private AudioSource doorAudio;

    [SerializeField]
    private AudioClip doorSound;

    // is this door the left door of the two
    public bool isLeftDoor;
    public float xChange;
    public float yChange;
    public float zChange;

    int i = 0;

    public void Start()
    {
        doorAudio = GetComponent<AudioSource>();
    }

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
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.002f, gameObject.transform.position.y - zChange, gameObject.transform.position.z - zChange);  
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + xChange, gameObject.transform.position.y+yChange, gameObject.transform.position.z+zChange);
            }

            if (!doorAudio.isPlaying && i == 0)
            {
                doorAudio.PlayOneShot(doorSound);
            }

            if (i == 1299)
            {
                doorAudio.Stop();
            }

            i++;
        }
    }
}
