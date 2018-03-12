using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMusicManager : MonoBehaviour
{
    public static FlyingMusicManager instance;
    private static bool firstTime = true;
    void Start()
    {
        if (firstTime == true)
        {
            instance = this;
            instance.GetComponentInParent<AudioSource>().Play();
            DontDestroyOnLoad(instance);
        }
        firstTime = false;
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