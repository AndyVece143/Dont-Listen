using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1Puzzle1 : MonoBehaviour
{
    public GameObject lever;
    public GameObject leverOther1;
    public GameObject leverOther2;

    public bool active = false;
    public bool preActive = false;

    //Audio
    private AudioSource doorAudio;

    [SerializeField]
    private AudioClip doorSound;

    // is this door the left door of the two
    public bool isLeftDoor;
    public float xChange = 0.002f;
    public float yChange;
    public float zChange;

    public int i = 0;

    Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.GetComponent<lever>().currentState)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (active && i < 600)
        {
            if (isLeftDoor)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - xChange, gameObject.transform.position.y - zChange, gameObject.transform.position.z - zChange);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + xChange, gameObject.transform.position.y + yChange, gameObject.transform.position.z + zChange);
            }

            if (!doorAudio.isPlaying)
            {
                doorAudio.PlayOneShot(doorSound);
            }

            i++;
        }

        if (!active && 0 < i)
        {
            i--;

            if (isLeftDoor)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + xChange, gameObject.transform.position.y + zChange, gameObject.transform.position.z + zChange);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - xChange, gameObject.transform.position.y - yChange, gameObject.transform.position.z - zChange);
            }

            if (!doorAudio.isPlaying)
            {
                doorAudio.PlayOneShot(doorSound);
            }
        }

        preActive = active;

        previousPos = gameObject.transform.position;
    }
}
