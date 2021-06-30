using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMusic : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip default_sound;

    public AudioClip explosion_sound;

    //public AudioClip sound;

    public float volume;

    public bool playing; // Mas adelante quiza sera elegir entre musicas, por ahora sola activar o desactivar


    // Patron Singleton (variable global a todos), accesibe desde culquier sitio
    public static InteractiveMusic musicInstance;
    public static InteractiveMusic getMusicInstance()
    {
        return musicInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        musicInstance = this;

        this.volume = 0.1f;  // Al 10%
        this.playing = true;

        audioSource.loop = true;
        audioSource.clip = default_sound;
        audioSource.volume = this.volume;
        if(this.playing) audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /**
     * Se ejecuta cuando se hace click sobre la componente
     * Pone o quita la musica.
     */
    public void onGazeClick()
    {
        this.playing = !this.playing;
        if (this.playing) audioSource.Play();
        else audioSource.Stop();
        Debug.Log("Button clicked !");
    }

    public void playExplosionSound()
    {
        audioSource.PlayOneShot(explosion_sound, 1.0f+volume*3);
    }
}
