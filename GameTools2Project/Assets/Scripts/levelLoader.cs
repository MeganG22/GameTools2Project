﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour {

    public int LevelToLoad;

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
