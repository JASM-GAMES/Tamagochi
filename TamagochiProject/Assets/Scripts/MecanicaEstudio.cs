using System;
using UnityEngine;

public class MecanicaEstudio : MonoBehaviour
{
    public ManagerUI UIM; // Reference to the ManagerUI script
    public InteractuableEstudio interactuableE; // Reference to the Interactuable script

    public float inicioZona = 0.4f; // Duration of the mechanic in seconds
    public float tamañoZona = 0.2f;
    public float velocidadBarra = 0.5f; // Speed of the moving zone
    public int direccionBarra = 1;

    private bool exito;

    private float valorActual;
    private bool jugando;

    // EVENTOS 🚀
    public event Action<bool> OnResultado; // true = éxito, false = fracaso
    public event Action<bool> OnEstadoJuego; // true = empezó, false = terminó

    public bool Jugando => jugando; // 👈 Propiedad para saber si está en juego desde fuera

    public bool getExito()
    {
        return exito;
    }

    public void setExito(bool valor)
    {
        exito = valor;
    }

    void OnEnable()
    {
        IniciarMinijuego(); // 👈 cada vez que el objeto se activa, reinicia todo
    }

    void OnDisable()
    {
        jugando = false;
        OnEstadoJuego?.Invoke(false); // 👈 avisa que terminó
    }
    void Update()
    {
        if (!jugando) return;

        // Movimiento ping-pong del cursor
        valorActual += direccionBarra * velocidadBarra * Time.deltaTime;

        // Si llega a los extremos, cambia dirección
        if (valorActual >= 1f)
        {
            valorActual = 1f;
            direccionBarra = -1;
        }
        else if (valorActual <= 0f)
        {
            valorActual = 0f;
            direccionBarra = 1;
        }

        UIM.sliderMecanicaBarra.value = valorActual;

        // Tecla de interacción
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChequearResultado();
            Debug.Log(exito ? "¡Éxito!" : "Fallaste");
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            CancelarMinijuego();
    }

    public void IniciarMinijuego()
    {
        valorActual = 0f;
        direccionBarra = 1;
        jugando = true;
        ActualizarZonaVerde();
        OnEstadoJuego?.Invoke(true); // Aviso: empezó el minijuego
    }

    private void ActualizarZonaVerde()
    {
        inicioZona = UnityEngine.Random.Range(0f, 1f - tamañoZona);

        if (UIM.zonaVerde != null)
        {
            RectTransform rt = UIM.zonaVerde.rectTransform;

            float parentWidth = rt.parent.GetComponent<RectTransform>().rect.width;
            float width = parentWidth * tamañoZona;
            float posX = parentWidth * inicioZona;

            rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
            rt.anchoredPosition = new Vector2(posX, rt.anchoredPosition.y);
            Debug.Log($"Zona verde movida: inicio={inicioZona:F2}, posX={rt.anchoredPosition.x}, width={rt.sizeDelta.x}");
        }

    }

    private void ChequearResultado()
    {
        bool exitoActual = valorActual >= inicioZona && valorActual <= inicioZona + tamañoZona;
        exito = exitoActual;

        Debug.Log(exito ? "¡Éxito!" : "Fallaste");
        ActualizarZonaVerde();

        // 🚀 Disparamos el evento con el resultado
        OnResultado?.Invoke(exito);
    }
    public void CancelarMinijuego()
    {
        gameObject.SetActive(false); // 👈 desactiva el objeto → llama OnDisable()
    }
    private void TerminarMinijuego(bool exito)
    {
        jugando = false;
        Debug.Log(exito ? "Minijuego completado" : "Minijuego fallido");
        // Aquí podrías avisar al GameManager del resultado
        gameObject.SetActive(false);
    }
}