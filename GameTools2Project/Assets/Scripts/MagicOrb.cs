using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    [SerializeField] float m_power;
    [SerializeField] private float _lifetime;

    public static int numberOfOrbs;

    void Start()
    {
        //Limiting orbs to shoot once at a time
        numberOfOrbs = 1;
        Destroy(gameObject, _lifetime);
    }

    private void OnEnable()
    {
        //Adding force to the orb
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.AddForce(transform.forward * m_power * Time.deltaTime);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        //If orb hits the Portal it destroys
        if (collision.gameObject.tag == "portal")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}

