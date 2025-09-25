using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Interactuable: componente simple que:
/// - dispara onInteract cuando el jugador presiona E (desde PlayerController).
/// - si tiene una mecánica (implementando IMecanica), la inicia y se suscribe a sus eventos.
/// - reenvía Start/Result/End como UnityEvents para que conectes GameManager/Estudiante desde el Inspector.
/// </summary>
public class Interactuable : MonoBehaviour
{
    [Header("Mecánica (arrastrar el componente que implemente IMecanica)")]
    public MonoBehaviour mecanicaComponent; // arrastra aquí MecanicaJuego (u otra mecánica)

    [Header("Opcionales: overrides para esta interacción (pasa 0 para no override)")]
    public float overrideTamañoZona = 0f;
    public float overrideVelocidadBarra = 0f;

    [Header("Eventos (Inspector)")]
    public UnityEvent onInteract;   // se llama en cuanto el jugador interactúa (antes de iniciar)
    public UnityEvent onStart;      // cuando la mecánica avisa que arrancó
    public UnityEvent onSuccess;    // resultado éxito
    public UnityEvent onFail;       // resultado fallo
    public UnityEvent onEnd;        // cuando la mecánica termina/sea cancelada

    IMecanica mecanica; // referencia casteada a la interfaz
    bool suscrito = false;

    /// <summary>
    /// Método público que debe llamar PlayerController al apretar E.
    /// </summary>
    public void Interactuar()
    {
        onInteract?.Invoke();

        // intentar obtener la interfaz IMecanica desde el componente arrastrado
        mecanica = mecanicaComponent as IMecanica;
        if (mecanica == null && mecanicaComponent != null)
            mecanica = mecanicaComponent.GetComponent(typeof(IMecanica)) as IMecanica;

        if (mecanica == null)
        {
            // no hay mecánica; se quedan solo los UnityEvents (por ejemplo, un interruptor simple)
            Debug.Log($"[Interactuable] {name}: no hay mecánica, disparando onStart/onEnd directamente.");
            onStart?.Invoke();
            onEnd?.Invoke();
            return;
        }

        // suscribirse a eventos de la mecánica (una sola vez)
        if (!suscrito)
        {
            mecanica.OnEstadoJuego += HandleEstado;
            mecanica.OnResultado += HandleResultado;
            suscrito = true;
        }

        // construimos nullables para overrides (0 = no override)
        float? tOverride = (overrideTamañoZona > 0f) ? (float?)overrideTamañoZona : null;
        float? vOverride = (overrideVelocidadBarra > 0f) ? (float?)overrideVelocidadBarra : null;

        // iniciar la mecánica, pasando este interactuable como owner
        mecanica.StartFor(this, tOverride, vOverride);
    }

    void HandleEstado(bool jugando)
    {
        if (jugando) onStart?.Invoke();
        else
        {
            onEnd?.Invoke();
            Unsubscribe();
        }
    }

    void HandleResultado(bool exito)
    {
        if (exito) onSuccess?.Invoke();
        else onFail?.Invoke();
    }

    /// <summary>
    /// Llamar para cancelar manualmente la interacción (por ejemplo, si el jugador se mueve).
    /// </summary>
    public void CancelarInteraccion()
    {
        mecanica?.Cancelar();
        Unsubscribe();
    }

    void Unsubscribe()
    {
        if (!suscrito) return;
        if (mecanica != null)
        {
            mecanica.OnEstadoJuego -= HandleEstado;
            mecanica.OnResultado -= HandleResultado;
        }
        suscrito = false;
    }

    void OnDisable() => Unsubscribe();
    void OnDestroy() => Unsubscribe();
}