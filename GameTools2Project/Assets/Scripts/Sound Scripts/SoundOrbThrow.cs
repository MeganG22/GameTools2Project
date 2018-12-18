using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOrbThrow : MonoBehaviour {

    //Orb Throw Sound Sources
    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    private void Start()
    {
        //Initialising the Audio Source
        m_audioSource = GetComponent<AudioSource>();
    }

    private void MakeSoundTwo()
    {
        //Animation Event to Perform PlaySound Function
        PlaySound();
    }

    private void PlaySound()
    {
        //Play the Orb Throw Sound
        Debug.Log("Sound");
        m_audioSource.PlayOneShot(m_audioClip);
    }
}
