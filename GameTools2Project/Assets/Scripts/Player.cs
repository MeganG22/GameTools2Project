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
            timer = 0.5f;
        }
    }

    void UpdatePosition()
    {
        wayPoint.transform.position = transform.position;
    }

    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 400;

        // If the object we hit is the enemy
        if (c.gameObject.tag == "enemy")
            Debug.Log("hitting");
        {
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
            Debug.Log("Force");
        }
    }
}


