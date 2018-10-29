using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHolder : MonoBehaviour {

    [SerializeField] GameObject m_magicOrb;
    [SerializeField] Transform m_magicReference;
    [SerializeField] Player m_player;


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
            Instantiate(m_magicOrb, m_magicReference.position, m_magicReference.rotation);
    
    }
}
