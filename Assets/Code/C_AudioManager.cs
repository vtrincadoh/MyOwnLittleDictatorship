using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AudioManager : MonoBehaviour
{
    AudioSource m_ASource;

    private void Start()
    {
        m_ASource = GetComponent<AudioSource>();
        m_ASource.Stop();
        Invoke("playMusic", 0.5f);
    }

    void playMusic()
    {
        m_ASource.Play();
    }
}
