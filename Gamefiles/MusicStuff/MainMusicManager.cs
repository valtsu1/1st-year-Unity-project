using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicManager : MonoBehaviour
{
    public static MainMusicManager instance;

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