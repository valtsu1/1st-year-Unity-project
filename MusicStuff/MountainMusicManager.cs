using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMusicManager : MonoBehaviour
{
    public static MountainMusicManager instance;

    void Start()
    {
        instance = this;
        instance.GetComponentInParent<AudioSource>().Play();
        DontDestroyOnLoad(instance);
    }

    public static void On()
    {
        instance.GetComponentInParent<AudioSource>().mute = false;
    }

    public static void Off()
    {
        instance.GetComponentInParent<AudioSource>().mute = true;
    }
}