using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandDoor : MonoBehaviour {

    private Animator m_animator;

    void Start()
    {
        //Initialise Animator
        m_animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Door Hit");
        if (collision.gameObject.tag == "Player")
        {
            m_animator.SetTrigger("open");
        }
    }
}
