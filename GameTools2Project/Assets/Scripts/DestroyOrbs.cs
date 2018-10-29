using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOrbs : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "orb")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
