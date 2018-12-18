using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //IK Enumerator Variables
    private float deltaX;
    private Quaternion spineRotation;
    private bool m_enableIK;
    private float m_weightIK;
    private Vector3 m_positionIK;
    private bool m_collect;

    //Animator Variables
    private Animator m_animator;
    private float m_dodgeX;
    private float m_walkY;
    private float m_back;

    //Timer Variables
    float interval = 1.90f;
    float lastSpell = 0;

    //Shoot Event
    public UnityEvent OnShoot;

    void Start()
    {
        //Initialising Player's Animator
        m_animator = GetComponent<Animator>();
    }

    public void Move(float dodgeX, float walkY, float back, bool magic, bool collect)
    {
        //Setting Player's Movement
        m_animator.SetFloat("DodgeX", dodgeX);
        m_animator.SetFloat("WalkY", walkY);

        //Setting Players Picking Animation Reference
        m_collect = collect;

        if (magic)
        {
            //If Magic Animation Triggered; Shoot Event is Invoked
            lastSpell = Time.time;  //Used for Timer
            m_animator.SetTrigger("Magic");

            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }
        }

    }

    void Update()
    {
        Spell();

        //Checking if Space Bar hit and if the animation has finished playing before playing again
        if (Input.GetButtonDown("Jump") && Time.time - lastSpell > interval)
        {
            //Setting the Magic Trigger / Event
            m_animator.SetTrigger("Magic");

            if (OnShoot != null)
            {
                OnShoot.Invoke();
            }
        }
    }

    void Spell()
    {
        //If current Magic Animation playing in current time
        lastSpell = Time.time;
    }

    private void OnTriggerStay(Collider other)
    {
        //If Player collide with a Key Object; the item picked will be moved to Players hand & Pick Animation Trigger set
        if (gameObject.tag == "key")
        {
            var pickable = other.GetComponent<Pickable>();

            if (m_collect && pickable != null && !pickable.picked)
            {
                Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
                pickable.BePicked(rightHand);

                m_animator.SetTrigger("Pick");
                StartCoroutine(UpdateIK(other)); //Starting corroutine to update position and weight
            }
        }
    }

    private IEnumerator UpdateIK(Collider other)
    {
        //Updating corroutine position and weight
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
        //Finishing the IK Animation when Picking Animation Done
        m_enableIK = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //Checking Player Animation's position & weight IK
        if (m_enableIK)
        {
            m_animator.SetIKPosition(AvatarIKGoal.RightHand, m_positionIK);
            m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, m_weightIK);
        }
    }
}


