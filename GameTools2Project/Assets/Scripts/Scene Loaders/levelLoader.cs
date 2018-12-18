using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour {

    public int LevelToLoad;

    public void LoadLevel()   //This script references the Level Ends etc.
    {
        //loads a specific scene
        SceneManager.LoadScene(LevelToLoad);
    }
}
