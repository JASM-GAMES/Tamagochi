using UnityEngine;

public class SoundActivate : MonoBehaviour
{
    public AudioSource audioSource; // se usa para reproducir el sonido
    public AudioClip sonidoDormir;
    public AudioClip sonidoComer;
    public AudioClip sonidoDivertirse;
    public AudioClip sonidoSocial;
    public AudioClip sonidoPuerta;
    public AudioClip sonidoEstudiar;

    private bool sonando = false;
  

    public void EncenderSonidoDormir()
    {

            audioSource.clip = sonidoDormir;
            audioSource.Play();
            sonando = true;
        
    }

    public void EncenderSonidoComer()
    {
            audioSource.clip = sonidoComer;
            audioSource.Play();
            sonando = true; 
    }

    public void EncenderSonidoDivertirse()
    {
        
            audioSource.clip = sonidoDivertirse;
            audioSource.Play();
            sonando = true;
        
    }

    public void EncenderSonidoSocial()
    {
        
            audioSource.clip = sonidoSocial;
            audioSource.Play();
            sonando = true;
        
    }

    public void EncenderSonidoPuerta()
    {

        audioSource.clip = sonidoPuerta;
        audioSource.Play();
        sonando = true;

    }

    public void EncenderSonidoEstudiar()
    {

        audioSource.clip = sonidoEstudiar;
        audioSource.Play();
        sonando = true;

    }

    public void ApagarSonidoGeneral()
    {

            audioSource.Stop();
            sonando = false;
        
    }



}


