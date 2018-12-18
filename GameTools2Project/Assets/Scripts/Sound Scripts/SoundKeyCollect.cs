using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKeyCollect : MonoBehaviour {

    //Key Collect Sound Sources
    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    private void Start()
    {
        //Initialising the Audio Source
        m_audioSource = GetComponent<AudioSource>();
    }

    private void MakeSound()
    {
        //Animation Event to Perform PlaySound Function
        PlaySound();
    }

    private void PlaySound()
    {
        //Play the Key Collect Sound
            Debug.Log("Sound");
            m_audioSource.PlayOneShot(m_audioClip);
    }
}
