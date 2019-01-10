using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    public bool returnToMap;
    public int nextSceneNumber;
    public int SceneMapTier;
    /// <summary>
    /// Loads map and unlocks next level
    /// or loads scene
    /// </summary>
    public void NextScene()
    {
        if (returnToMap == true)
        {
            MapManager.UnlockNextLevel(SceneMapTier);
            SceneManager.LoadScene(1);
        }
        
        else {
            SceneManager.LoadScene(nextSceneNumber);
        }
    }
}
