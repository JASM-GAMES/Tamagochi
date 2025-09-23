using UnityEngine;
using System;

/// <summary>
/// Script para objetos interactuables que lanzan minijuegos de barra (MecanicaJuego)
/// y afectan las necesidades del estudiante. Compatible con ScriptableObjects
/// para valores base de las necesidades y velocidad de tiempo.
/// </summary>
public class Interactuable : MonoBehaviour
{
    [Header("Refs")]
    public MecanicaJuego mecanicaJuego;      
    public Estudiante estudiante;
    public GameManager gM;

    [Header("Modificar Velocidad Tiempo")]
    public float modificarVelocidadTiempo;

    [Header("Cambios en necesidades por éxito")]
    public int cambiarHambreExito;
    public int cambiarSuenoExito;
    public int cambiarDiversionExito;
    public int cambiarEstresExito;
    public int cambiarSocialExito;

    [Header("Cambios en necesidades por fracaso")]
    public int cambiarHambreFracaso;
    public int cambiarSuenoFracaso;
    public int cambiarDiversionFracaso;
    public int cambiarEstresFracaso;
    public int cambiarSocialFracaso;

    [Header("Cambios en necesidades pasivos durante la interacción")]
    public float cambiarHambrePasivo;
    public float cambiarSuenoPasivo;
    public float cambiarDiversionPasivo;
    public float cambiarEstresPasivo;
    public float cambiarSocialPasivo;

    // flags internos
    private bool suscrito = false;

    // Guardar valores previos para restaurar
    private float prevSegundosXMinutos;
    private float prevHambre, prevSueno, prevDiversion, prevEstres, prevSocial;

    // Autoasignar GameManager si es null


    private void Awake()
    {
        // Intentar encontrar el GameManager en la escena
        if (gM == null)
            gM = GameManager.Instance ?? FindFirstObjectByType<GameManager>();
    }

    /// <summary>
    /// Llamado por el Player cuando presiona E frente al objeto.
    /// Inicia la mecánica y suscribe eventos.
    /// </summary>
    public void Interactuar()
    {
        if (mecanicaJuego == null)
        {
            Debug.LogWarning("Interactuable: falta referencia a MecanicaJuego en " + name);
            return;
        }

        mecanicaJuego.interactuable = this;

        // Suscribirse solo si no está suscrito
        if (!suscrito)
        {
            mecanicaJuego.OnEstadoJuego += EstadoMinijuego;
            mecanicaJuego.OnResultado += CambiarAtributos;
            suscrito = true;
        }

        // Activar la mecánica (OnEnable -> IniciarMinijuego)
        mecanicaJuego.gameObject.SetActive(true);
    }

    /// <summary>
    /// Método que se ejecuta cuando la barra da resultado de éxito o fracaso.
    /// Modifica las necesidades del estudiante según el resultado.
    /// </summary>
    /// <param name="exito">True si la barra fue exitosa, False si falló.</param>
    public void CambiarAtributos(bool exito)
    {
        if (estudiante == null)
        {
            Debug.LogWarning("Interactuable: falta referencia a Estudiante en " + name);
            return;
        }

        if (exito)
        {
            estudiante.Hambre += cambiarHambreExito;
            estudiante.Sueno += cambiarSuenoExito;
            estudiante.Diversion += cambiarDiversionExito;
            estudiante.Estres += cambiarEstresExito;
            estudiante.Social += cambiarSocialExito;
        }
        else
        {
            estudiante.Hambre -= cambiarHambreFracaso;
            estudiante.Sueno -= cambiarSuenoFracaso;
            estudiante.Diversion -= cambiarDiversionFracaso;
            estudiante.Estres -= cambiarEstresFracaso;
            estudiante.Social -= cambiarSocialFracaso;
        }
    }

    private void EstadoMinijuego(bool jugando)
    {
        if (gM == null)
        {
            gM = GameManager.Instance ?? FindFirstObjectByType<GameManager>();
            if (gM == null)
            {
                Debug.LogWarning("Interactuable: no hay GameManager en la escena.");
                return;
            }
        }

        if (jugando)
        {
            // Guardar valores previos antes de modificar
            prevSegundosXMinutos = gM.segundosXMinutos;
            prevHambre = gM.tiempoXHambre;
            prevSueno = gM.tiempoXSueno;
            prevDiversion = gM.tiempoXDiversion;
            prevEstres = gM.tiempoXEstres;
            prevSocial = gM.tiempoXSocial;

            // Aplica valores pasivos usando presetBase
            gM.segundosXMinutos = modificarVelocidadTiempo;
            gM.tiempoXHambre = cambiarHambrePasivo;
            gM.tiempoXDiversion = cambiarDiversionPasivo;
            gM.tiempoXSueno = cambiarSuenoPasivo;
            gM.tiempoXEstres = cambiarEstresPasivo;
            gM.tiempoXSocial = cambiarSocialPasivo;
        }
        else
        {
            // Restaurar valores previos
            gM.segundosXMinutos = prevSegundosXMinutos;
            gM.tiempoXHambre = prevHambre;
            gM.tiempoXSueno = prevSueno;
            gM.tiempoXDiversion = prevDiversion;
            gM.tiempoXEstres = prevEstres;
            gM.tiempoXSocial = prevSocial;

            // Desuscribirse para evitar eventos huérfanos
            if (suscrito && mecanicaJuego != null)
            {
                mecanicaJuego.OnEstadoJuego -= EstadoMinijuego;
                mecanicaJuego.OnResultado -= CambiarAtributos;
                suscrito = false;
            }
        }
    }

    /// <summary>
    /// Llamar para cancelar la interacción y cerrar la barra.
    /// </summary>
    public void NoInteractuar()
    {
        if (mecanicaJuego != null)
            mecanicaJuego.gameObject.SetActive(false);

        EstadoMinijuego(false);
    }

    /// <summary>
    /// Asegura desuscripción al destruir el objeto para evitar errores.
    /// </summary>
    private void OnDestroy()
    {
        if (mecanicaJuego != null)
        {
            mecanicaJuego.OnEstadoJuego -= EstadoMinijuego;
            mecanicaJuego.OnResultado -= CambiarAtributos;
        }
    }
}
