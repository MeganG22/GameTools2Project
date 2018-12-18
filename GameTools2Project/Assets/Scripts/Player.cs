using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //IK Enumerator
    private float deltaX;
    private Quaternion spineRotation;
    private bool m_enableIK;
    private float m_weightIK;
    private Vector3 m_positionIK;
    private bool m_collect;

    //Animator
    private Animator m_animator;
    private float m_dodgeX;
    private float m_walkY;
    private float m_back;

    private float timer = 0.5f;
    float interval = 1.90f;
    float lastSpell = 0;

    //public GameObject c;

    public UnityEvent OnShoot;

    //private bool m_magic;

    // Use this for initialization
    void Start()
    {
        //Initialise Animator
        m_animator = GetComponent<Animator>();
    }

    public void Move(float dodgeX, float walkY, float back, bool magic, bool collect)
    {
        m_animator.SetFloat("DodgeX", dodgeX);
        m_animator.SetFloat("WalkY", walkY);

        m_collect = collect;

        if (magic)
        {
            lastSpell = Time.time;
            m_animator.SetTrigger("Magic");

            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }
        }

    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = 0f;
        }

        //check input if true and Time.time-lastSpell > interval then cast spell
        if (Input.GetButtonDown("Jump") && Time.time - lastSpell > interval)
        {
            //Setting the shooting orb event
            m_animator.SetTrigger("Magic");

            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }
        }
    }

    void Spell()
    {
        lastSpell = Time.time;
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "key")
        {
            var pickable = other.GetComponent<Pickable>();

            if (m_collect && pickable != null && !pickable.picked)
            {
                // do something
                Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
                pickable.BePicked(rightHand);

                m_animator.SetTrigger("Pick");
                StartCoroutine(UpdateIK(other));// Start corroutine to update position and weight
            }
        }
    }

    private IEnumerator UpdateIK(Collider other)
    {
        m_enableIK = true;

        while (m_enableIK)
        {
            m_positionIK = other.transform.position;
            m_weightIK = m_animator.GetFloat("IK");
            yield return null;
        }
    }

    public void DisableIK()
    {
        m_enableIK = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (m_enableIK)
        {
            m_animator.SetIKPosition(AvatarIKGoal.RightHand, m_positionIK);
            m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, m_weightIK);
        }
    }
}


