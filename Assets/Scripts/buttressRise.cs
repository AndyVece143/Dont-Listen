using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buttressRise : MonoBehaviour
{
    public GameObject pedestal;

    // Update is called once per frame
    void Update()
    {
        if (pedestal.GetComponent<itemDestination>().activator && this.gameObject.transform.position.y < 20.0f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.02f, this.gameObject.transform.position.z);
        }
    }
}
