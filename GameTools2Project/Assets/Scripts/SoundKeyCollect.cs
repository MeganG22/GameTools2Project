using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKeyCollect : MonoBehaviour {

    [SerializeField] AudioClip m_audioClip;
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void MakeSound()
    {
        PlaySound();
    }

    private void PlaySound()
    {

        //if (m_audioSource != null)
        //{
            Debug.Log("Sound");
            m_audioSource.PlayOneShot(m_audioClip);
        //}
    }
}
