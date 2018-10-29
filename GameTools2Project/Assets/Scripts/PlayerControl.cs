using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Animator m_animator;

    private float m_dodgeX;
    private float m_walkY;
    private float m_back;
    private bool m_magic;
    private bool m_collect;

    private Player m_player;

    private void Start()
    {
        m_player = GetComponent<Player>();
        m_animator = GetComponent<Animator>();
    }
    void FixedUpdate() //physics seconds
    {
        //Get Inputs
        m_dodgeX = Input.GetAxis("Horizontal");
        m_walkY = Input.GetAxis("Vertical");
        m_magic = Input.GetButtonDown("Jump");
        m_back = Input.GetAxis("Vertical");
        m_collect = Input.GetButtonDown("Collect");

        m_player.Move(m_dodgeX, m_walkY, m_back, m_magic);
    }

    private void OnTriggerStay(Collider other)
    {
        var pickable = other.GetComponent<Pickable>();

        //Debug.Log("PickingTrigger");
        //Debug.Log(m_picked);

        if (m_collect && pickable != null && !pickable.picked) //if key selected & object has pickable script & not picked already
        {
            Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
            pickable.BePicked(rightHand);

            m_animator.SetTrigger("Magic");
            //StartCoroutine(UpdateIK(other));
        }
    }
}

