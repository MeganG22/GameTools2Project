using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHolder : MonoBehaviour {

    //Public Variables to Edit in Unity
    [SerializeField] GameObject m_magicOrb;
    [SerializeField] Transform m_magicReference;
    [SerializeField] Player m_player;

    private void OnEnable()
    {
        //When Called, do Magic Function
        m_player.OnShoot.AddListener(Magic);
    }

    private void OnDisable()
    {
        //When End, leave Magic Function
        m_player.OnShoot.RemoveListener(Magic);
    }

    private void Magic()
    {
        //The Magic function - This creates the orb prefab
        Instantiate(m_magicOrb, m_magicReference.position, m_magicReference.rotation);
    }
}
