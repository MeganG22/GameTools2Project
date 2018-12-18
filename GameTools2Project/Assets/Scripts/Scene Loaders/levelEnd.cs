using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour {

    //Unity Event 
    public UnityEvent EndGame;
    public string Tag;

    private void OnTriggerEnter(Collider other)
    {
        //If a GameObject(player) hits the End Goal Sphere; the end game event is set and player brought back to the beginning
        if (other.CompareTag(Tag))
        {
            //if player hits endLight the current scene loads again
            EndGame.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
