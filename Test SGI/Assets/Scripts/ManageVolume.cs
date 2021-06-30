using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageVolume : MonoBehaviour
{
    public AudioSource audioSource; // Se coloca de forma externa(desde Unity)

    public float volumeStep = 0.1f;
    public float maxVolume = 0.5f;
    public float minVolume = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.volumeStep = 0.1f;
        this.maxVolume  = 0.5f;
        this.minVolume  = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /**
     * Se ejecuta cuando se hace click sobre la componente
     * Aumenta el volumen
     */
    public void onGazeClick_increaseVolume()
    {
        if ((this.audioSource.volume + this.volumeStep) > this.maxVolume) this.audioSource.volume = this.maxVolume;
        else this.audioSource.volume += this.volumeStep;
        Debug.Log("Button clicked !");
    }

    /**
     * Se ejecuta cuando se hace click sobre la componente
     * Disminuye el volumen
     */
    public void onGazeClick_decreaseVolume()
    {
        if ((this.audioSource.volume - this.volumeStep) < this.minVolume) this.audioSource.volume = this.minVolume;
        else this.audioSource.volume -= this.volumeStep;
        Debug.Log("Button clicked !");
    }
}
