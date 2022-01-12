using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioClip sonidoFuego;
    public GameObject fuego;
    public float duration;


    private AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void ActivarFuego()
    {
        CancelInvoke("DeactivateFuego");
        audios.clip = sonidoFuego;
        audios.Play();
        fuego.SetActive(true);
        Invoke("DeactivateFuego", duration);
    }
    private void DeactivateFuego()
    {
        fuego.SetActive(false);
        audios.Stop();
    }
}
