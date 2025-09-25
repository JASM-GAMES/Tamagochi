using System;

/// <summary>
/// Interfaz mínima para cualquier mecánica reutilizable.
/// - Define los eventos que debe disparar.
/// - Define cómo iniciarse para un Interactuable y cómo cancelarse.
/// </summary>
public interface IMecanica
{
    /// <summary>
    /// Resultado del minijuego:
    /// true = éxito, false = fracaso
    /// </summary>
    event Action<bool> OnResultado;

    /// <summary>
    /// Estado del minijuego:
    /// true = empezó, false = terminó/canceló
    /// </summary>
    event Action<bool> OnEstadoJuego;

    /// <summary>
    /// Inicia la mecánica para un Interactuable específico.
    /// Puedes pasar parámetros opcionales para personalizar la dificultad.
    /// </summary>
    void StartFor(Interactuable owner, float? overrideTamañoZona = null, float? overrideVelocidadBarra = null);

    /// <summary>
    /// Cancela la mecánica de forma manual.
    /// </summary>
    void Cancelar();
}