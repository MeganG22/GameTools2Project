using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    [SerializeField] float m_power;

    //bool canPower = false;
    //bool waitActive = false;

    private void OnEnable()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        //if (!waitActive)
       // {

           // if (canPower)
            //{
                m_rigidbody.AddForce(transform.forward * m_power);
        // canPower = false;
        // StartCoroutine(Wait());
        //  }
        // canPower = false;
        // }
        //}

        // IEnumerator Wait()
        // {
        //   waitActive = true;
        //   yield return new WaitForSeconds(1.0f);
        //   canPower = true;
        //    waitActive = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "portal")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}

