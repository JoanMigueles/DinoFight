using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip sonidoExplosion;
    public AudioClip sonidoBeep;
    public GameObject explosion;

    private AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void ActivarExplosion()
    {
        for (int i = 1; i <= 3; ++i)
        {
            Invoke("Beep", i);
        }
        Invoke("Boom", 4f);
    }
    private void DeactivateExplosion()
    {
        explosion.SetActive(false);
    }

    private void Beep()
    {
        audios.PlayOneShot(sonidoBeep, 0.5f);
    }

    private void Boom()
    {
        audios.PlayOneShot(sonidoExplosion, 0.5f);
        explosion.SetActive(true);
        Invoke("DeactivateExplosion", 0.65f);
    }
}
