using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator m_animator;
    private float m_dodgeX;
    private float m_walkY;

    // Use this for initialization
    void Start()
    {
        //Initialise Animator
        m_animator = GetComponent<Animator>();

    }

    public void Move(float dodgeX, float walkY)
    {
        m_animator.SetFloat("DodgeX", dodgeX);
        m_animator.SetFloat("WalkY", walkY);
    }

 }


