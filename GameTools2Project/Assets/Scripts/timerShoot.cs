using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerShoot : MonoBehaviour {

        float interval = 0.5f;
        float lastSpell = 0;

        private Animator m_animator;

    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        //check input if true and Time.time-lastSpell > interval then cast spell
        if (Input.GetButtonDown("Jump") && Time.time - lastSpell > interval)
        {
            m_animator.SetTrigger("Magic");
        }
    
        }

        void Spell()
        {
            lastSpell = Time.time;
        }
    }

