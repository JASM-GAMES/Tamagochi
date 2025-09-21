using UnityEngine;
using UnityEngine.Events;
public class Interactuable : MonoBehaviour
{
    public MecanicaJuego mecanicaJuego;
    public Estudiante estudiante;

    // Cambios en las necesidades al interactuar (éxito)
    public int cambiarHambreExito;
    public int cambiarSuenoExito;
    public int cambiarDiversionExito;
    public int cambiarEstresExito;
    public int cambiarSocialExito;
    // Cambios en las necesidades al interactuar (fracaso)
    public int cambiarHambreFracaso;
    public int cambiarSuenoFracaso;
    public int cambiarDiversionFracaso;
    public int cambiarEstresFracaso;
    public int cambiarSocialFracaso;

    public string mensaje = "|E|";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Estudiante"))
        {
            Debug.Log(mensaje);
            // Aquí podrías mostrar un UI prompt en pantalla
        }
    }

    public void cambiarAtributos()
    {
        if (mecanicaJuego.getExito())
        {
            estudiante.setHambre(estudiante.getHambre() + cambiarHambreExito);
            estudiante.setSueno(estudiante.getSueno() + cambiarSuenoExito);
            estudiante.setDiversion(estudiante.getDiversion() + cambiarDiversionExito);
            estudiante.setEstres(estudiante.getEstres() + cambiarEstresExito);
            estudiante.setSocial(estudiante.getSocial() + cambiarSocialExito);
        }
        else
        {
            estudiante.setHambre(estudiante.getHambre() - cambiarHambreFracaso);
            estudiante.setSueno(estudiante.getSueno() - cambiarSuenoFracaso);
            estudiante.setDiversion(estudiante.getDiversion() - cambiarDiversionFracaso);
            estudiante.setEstres(estudiante.getEstres() - cambiarEstresFracaso);
            estudiante.setSocial(estudiante.getSocial() - cambiarSocialFracaso);
        }
    }

    public void Interactuar()
    {
        mecanicaJuego.interactuable = this; // <- le decimos quién es el objeto actual
        mecanicaJuego.gameObject.SetActive(true);
    }
}