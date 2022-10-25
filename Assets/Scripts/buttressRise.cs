using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buttressRise : MonoBehaviour
{
    public GameObject pedestal1;
    public GameObject pedestal2;

    // Update is called once per frame
    void Update()
    {
        if (pedestal1.GetComponent<itemDestination>().activator && pedestal2.GetComponent<itemDestination>().activator && this.gameObject.transform.position.y < 20.0f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.02f, this.gameObject.transform.position.z);
        }
    }
}
