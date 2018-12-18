using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHolder : MonoBehaviour {

    [SerializeField] GameObject m_magicOrb;
    [SerializeField] Transform m_magicReference;
    [SerializeField] Player m_player;
    private Animator m_animator;

    //bool input = false;

    //private float _timer;
    //[SerializeField] private float _waitTime;

    //float interval = 1.90f;
    //float lastSpell = 0;

    private void OnEnable()
    {
        m_player.OnShoot.AddListener(Magic);
    }

    private void OnDisable()
    {
        m_player.OnShoot.RemoveListener(Magic);
    }

    private void Magic()
    {
        m_animator = GetComponent<Animator>();
        bool input = Input.GetButtonDown("Jump");
        //lastSpell = Time.time;
        //_timer += Time.deltaTime;

        if(input)
        {
        //If magic aninmation is triggered and waitTime achieved instansiate the orb
        Instantiate(m_magicOrb, m_magicReference.position, m_magicReference.rotation);
            //_timer = 0f;

        }
    }
    
}
