using System;
using UnityEngine;

/// <summary>
/// Minijuego de barra (ping-pong). Implementa IMecanica.
/// - Emite OnEstadoJuego(true/false) y OnResultado(true/false).
/// - StartFor(owner, overrides...) inicia la sesión para ese interactuable.
/// - Por defecto termina la sesión cuando el jugador presiona la tecla (terminarAlPresionar = true).
/// </summary>
public class MecanicaJuego : MonoBehaviour, IMecanica
{
    [Header("UI")]
    public ManagerUI UIM; // slider y zona verde (puede ser null para probar sin UI)

    [Header("Parámetros por defecto (0..1)")]
    public float inicioZona = 0.4f;
    public float tamañoZona = 0.2f;
    public float velocidadBarra = 0.5f; // unidades relativas por segundo
    public bool terminarAlPresionar = true; // si true, un press termina la sesión

    // eventos públicos (IMecanica)
    public event Action<bool> OnResultado;
    public event Action<bool> OnEstadoJuego;

    // info de la sesión
    public Interactuable Owner { get; private set; }
    bool jugando = false;
    float valorActual = 0f;
    int direccion = 1;

    // overrides temporales
    float prevTamaño;
    float prevVelocidad;
    bool hadOverrides = false;

    // -------- API simple --------
    // Llamar desde Interactuable: mecanica.StartFor(this, overrideTamaño, overrideVel);
    public void StartFor(Interactuable owner, float? overrideTamañoZona = null, float? overrideVelocidadBarra = null)
    {
        // si ya hay una sesión activa, cancela (evita doble uso)
        if (jugando)
            Cancelar();

        Owner = owner;

        // aplicar overrides si vienen
        if (overrideTamañoZona.HasValue || overrideVelocidadBarra.HasValue)
        {
            prevTamaño = tamañoZona;
            prevVelocidad = velocidadBarra;
            hadOverrides = true;

            if (overrideTamañoZona.HasValue) tamañoZona = Mathf.Clamp01(overrideTamañoZona.Value);
            if (overrideVelocidadBarra.HasValue) velocidadBarra = Mathf.Max(0.0001f, overrideVelocidadBarra.Value);
        }

        // activa el panel (si está desactivado)
        gameObject.SetActive(true);

        // iniciar la sesión
        IniciarMinijuego();
    }

    public void Cancelar()
    {
        // terminar sin éxito
        TerminarMinijuego(false);
    }

    // -------- lógica interna --------
    void IniciarMinijuego()
    {
        valorActual = 0f;
        direccion = 1;
        jugando = true;
        ActualizarZonaVerde();
        OnEstadoJuego?.Invoke(true); // aviso que arrancó
    }

    void Update()
    {
        if (!jugando) return;

        // mover cursor
        valorActual += direccion * velocidadBarra * Time.deltaTime;
        if (valorActual >= 1f) { valorActual = 1f; direccion = -1; }
        else if (valorActual <= 0f) { valorActual = 0f; direccion = 1; }

        if (UIM != null && UIM.sliderMecanicaBarra != null)
            UIM.sliderMecanicaBarra.value = valorActual;

        // input para chequear resultado
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool exitoActual = ChequearResultadoLocal();
            OnResultado?.Invoke(exitoActual);

            if (terminarAlPresionar)
                TerminarMinijuego(exitoActual);
            else
                ActualizarZonaVerde(); // si no termina, genera nueva zona
        }

        // ejemplo simple: cancelar si el jugador se mueve (puedes quitarlo y que el Interactuable lo maneje)
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            Cancelar();
    }

    // devuelve si es exito
    bool ChequearResultadoLocal()
    {
        return valorActual >= inicioZona && valorActual <= inicioZona + tamañoZona;
    }

    void ActualizarZonaVerde()
    {
        inicioZona = UnityEngine.Random.Range(0f, Mathf.Max(0f, 1f - tamañoZona));
        if (UIM != null && UIM.zonaVerde != null)
        {
            RectTransform rt = UIM.zonaVerde.rectTransform;
            float parentWidth = rt.parent.GetComponent<RectTransform>().rect.width;
            float width = parentWidth * tamañoZona;
            float posX = parentWidth * inicioZona;
            rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
            rt.anchoredPosition = new Vector2(posX, rt.anchoredPosition.y);
        }
    }

    public void TerminarMinijuego(bool exitoFinal)
    {
        // avisos
        OnResultado?.Invoke(exitoFinal);
        OnEstadoJuego?.Invoke(false);

        jugando = false;

        // restaurar overrides si los hubo
        if (hadOverrides)
        {
            tamañoZona = prevTamaño;
            velocidadBarra = prevVelocidad;
            hadOverrides = false;
        }

        Owner = null;

        // desactiva panel para que vuelva al estado original
        gameObject.SetActive(false);
    }
}