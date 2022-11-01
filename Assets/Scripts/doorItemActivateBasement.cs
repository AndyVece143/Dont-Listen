using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class doorItemActivateBasement : MonoBehaviour
{
    public GameObject pedestal1;

    public float xShift;
    public float yShift;
    public float zShift;

    public int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (pedestal1.GetComponent<itemDestination>().activator && i < 60)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + xShift, this.gameObject.transform.position.y + yShift, this.gameObject.transform.position.z + zShift);
            i++;
        }
    }
}
