using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private float m_dodgeX;
    private float m_walkY;

    private Player m_player;

    private void Start()
    {
        m_player = GetComponent<Player>();
    }
    void FixedUpdate() //physics seconds
    {
        //Get Inputs
        m_dodgeX = Input.GetAxis("Horizontal");
        m_walkY = Input.GetAxis("Vertical");

        m_player.Move(m_dodgeX, m_walkY);
    }
}

