using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDisable : MonoBehaviour {

    //public GameObject WallToDestroy;
    //public GameObject TheObject;
    //public GameObject Player;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
        if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exiting");
        if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.SetActive(true);
        }
    }
}
