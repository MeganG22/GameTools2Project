using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOrbThrow : MonoBehaviour {

    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void MakeSoundTwo()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        Debug.Log("Sound");
        m_audioSource.PlayOneShot(m_audioClip);
    }
}
