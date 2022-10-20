//Deegan Melchiondo
//10/18/22
//Class that houses all info sound will need

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    public string name;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [Range(-100f, 100f)]
    public float pan;

    public bool loop;
}
