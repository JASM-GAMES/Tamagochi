using System;

/// <summary>
/// Interfaz m�nima para cualquier mec�nica reutilizable.
/// - Define los eventos que debe disparar.
/// - Define c�mo iniciarse para un Interactuable y c�mo cancelarse.
/// </summary>
public interface IMecanica
{
    /// <summary>
    /// Resultado del minijuego:
    /// true = �xito, false = fracaso
    /// </summary>
    event Action<bool> OnResultado;

    /// <summary>
    /// Estado del minijuego:
    /// true = empez�, false = termin�/cancel�
    /// </summary>
    event Action<bool> OnEstadoJuego;

    /// <summary>
    /// Inicia la mec�nica para un Interactuable espec�fico.
    /// Puedes pasar par�metros opcionales para personalizar la dificultad.
    /// </summary>
    void StartFor(Interactuable owner, float? overrideTama�oZona = null, float? overrideVelocidadBarra = null);

    /// <summary>
    /// Cancela la mec�nica de forma manual.
    /// </summary>
    void Cancelar();
}