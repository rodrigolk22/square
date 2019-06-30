using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManagement : MonoBehaviour {

    public AudioClip backgroundMusic;
    public AudioSource audioSource;


    public void playMusic()
    {
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }

    }
}
