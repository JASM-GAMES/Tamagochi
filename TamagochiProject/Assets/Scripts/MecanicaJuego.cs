using System;
using UnityEngine;

public class MecanicaJuego : MonoBehaviour
{
    public ManagerUI UIM; // Reference to the ManagerUI script
    public Interactuable interactuable; // Reference to the Interactuable script

    public float inicioZona = 0.4f; // Duration of the mechanic in seconds
    public float tamañoZona = 0.2f; 
    public float velocidadBarra = 0.5f; // Speed of the moving zone
    public int direccionBarra = 1;

    private bool exito;

    private float valorActual;
    private bool jugando;

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
        IniciarMinijuego();
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
            interactuable.cambiarAtributos();
        }

        // Cancelar mecánica si el jugador se mueve
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            CancelarMinijuego();
        }
    }

    public void IniciarMinijuego()
    {
        valorActual = 0f;
        direccionBarra = 1;
        jugando = true;
        ActualizarZonaVerde();
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

    public void ChequearResultado()
    {
        if (valorActual >= inicioZona && valorActual <= inicioZona + tamañoZona)
        {
            Debug.Log("¡Éxito!");
            // Aquí puedes llamar a GameManager o sumar puntos
            ActualizarZonaVerde();
            exito = true;   
        }
        else
        {        
            Debug.Log("Fallaste");
            // Aquí penalizas al jugador
            ActualizarZonaVerde();
            exito = false;
        }
    }
    public void CancelarMinijuego()
    {
        Debug.Log("Minijuego cancelado");
        jugando = false;
        gameObject.SetActive(false); // Oculta panel si lo estás mostrando en UI
    }
    private void TerminarMinijuego(bool exito)
    {
        jugando = false;
        Debug.Log(exito ? "Minijuego completado" : "Minijuego fallido");
        // Aquí podrías avisar al GameManager del resultado
        gameObject.SetActive(false);
    }
}