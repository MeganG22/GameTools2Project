using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDisable : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        //When player collides with a wall, they are disabled
        Debug.Log("Colliding");
        if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //When player leaves collision with a wall, they are set active again
        Debug.Log("Exiting");
        if (collision.gameObject.tag == "wall")
        {
            collision.gameObject.SetActive(true);
        }
    }
}
