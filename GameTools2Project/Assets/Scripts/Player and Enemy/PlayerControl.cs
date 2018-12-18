using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Player Control Variables
    public Animator m_animator;
    private float m_dodgeX;
    private float m_walkY;
    private float m_back;
    private bool m_magic;
    private bool m_collect;

    //Player Reference
    private Player m_player;

    private void Start()
    {
        //Getting Player & Animator
        m_player = GetComponent<Player>();
        m_animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        //Getting the Inputs
        m_dodgeX = Input.GetAxis("Horizontal");
        m_walkY = Input.GetAxis("Vertical");
        m_magic = Input.GetButtonDown("Jump");
        m_back = Input.GetAxis("Vertical");
        m_collect = Input.GetButtonDown("Collect");

        //Setting Player Movement
        m_player.Move(m_dodgeX, m_walkY, m_back, m_magic, m_collect);
    }

    private void OnTriggerStay(Collider other)
    {
        var pickable = other.GetComponent<Pickable>();

        //if key selected & object has pickable script & not picked already; move to Player's hand & set Pick Trigger Animation
        if (m_collect && pickable != null && !pickable.picked)
        {
            Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
            pickable.BePicked(rightHand);

            m_animator.SetTrigger("Pick");
        }
    }
}

