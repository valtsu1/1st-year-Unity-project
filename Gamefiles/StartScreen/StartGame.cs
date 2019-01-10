using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    private NextSceneManager nextSceneManager;

    void Start()
    {
        nextSceneManager = GameObject.Find("NextSceneManager").GetComponent<NextSceneManager>();
    }
    void OnMouseUp()
    {
        nextSceneManager.NextScene();
    }
}
