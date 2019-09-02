using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip backgroundMusic;
    public AudioSource audioSource;

    //Ao iniciar o programa a musica de fundo também é inicializada
    private void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    public void playMusic()
    {
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }
}
