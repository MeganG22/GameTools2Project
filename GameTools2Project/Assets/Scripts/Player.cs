using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private float m_dodgeX;
    private float m_walkY;
    private float m_back;

    public GameObject wayPoint;
    private float timer = 0.5f;

    float interval = 0.5f;
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

    public void Move(float dodgeX, float walkY, float back, bool magic)
    {
        m_animator.SetFloat("DodgeX", dodgeX);
        m_animator.SetFloat("WalkY", walkY);
        //m_animator.SetFloat("Back Jump", back);
        //m_animator.SetBool("Magic", magic);
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
            UpdatePosition();
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


    void UpdatePosition()
    {
        //Giving the player a wayPoint gameObject for the darkEnergy to follow
        wayPoint.transform.position = transform.position;
    }

    //void OnCollisionEnter(Collision c)
    //{
        //The strength of the enemie's push
        //float force = 100;

        //If the object the player hits is the enemy
        //if (c.gameObject.tag == "enemy")
            //Debug.Log("hitting");
        //{
            //Add the push
           // Vector3 dir = c.contacts[0].point - transform.position;
            //dir = -dir.normalized;
            //GetComponent<Rigidbody>().AddForce(dir * force);
            //Debug.Log("Force");
        //}
    //}
}


