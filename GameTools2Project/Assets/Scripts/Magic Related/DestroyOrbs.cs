using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOrbs : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "orb")
        {
            //If orb hits this gameobject; orb will be destroyed
            Destroy(collision.collider.gameObject);
        }
    }
}
