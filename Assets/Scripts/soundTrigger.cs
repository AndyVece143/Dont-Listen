using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour
{
    bool triggered;
    float soundCooldown = 0f;
    float soundRate = 15f;

    [SerializeField]
    AudioClip clip;

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider == 
        //triggered = true;
    }

    // Update is called once per frame
    void Update()
    {
        int rng = (int)Random.Range(0, 100);

        if (triggered == true && rng == 50 && Time.time > soundCooldown)
        {
            FindObjectOfType<AudioManager>().Play(clip.name);
            soundCooldown = Time.time + soundRate;
        }
    }
}
