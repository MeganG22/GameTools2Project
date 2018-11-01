using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour {

    public UnityEvent EndGame;
    public string Tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            //if player hits endLight the current scene loads again
            EndGame.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
