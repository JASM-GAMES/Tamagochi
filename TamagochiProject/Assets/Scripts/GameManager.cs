using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tiempo del Juego")]
    public int minutosActual;  // 0 - 59
    public int horasActual;    // 0 - 23
    public int diaActual;     // 0 en adelante

    [Header("Configuración")]
    public float segundosXMinutos = 1f; // 1 seg real = 1 min juego

    public ManagerUI UIM;

    private float timer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Avanza el tiempo según el deltaTime real
        timer += Time.deltaTime;

        if (timer >= segundosXMinutos)
        {
            AvanzarMinuto();
            timer = 0f;
        }
        // Se conecta al UI
        UIM.mostrarTiempo();
    }
    //sirve para avanzar el tiempo y mostrarlo en la UI
    private void AvanzarMinuto()
    {
        minutosActual++;

        if (minutosActual >= 60)
        {
            minutosActual = 0;
            horasActual++;

            if (horasActual >= 24)
            {
                horasActual = 0;
                diaActual++;
            }
        }
    }

    // getters y setters
    public int GetHora() => horasActual;
    public int GetMinuto() => minutosActual;
    public int GetDia() => diaActual;

    public void SetHora(int hora) { 
        horasActual=hora; 
    }
    public void SetMinuto(int minuto)
    {
        minutosActual = minuto;
    }
    public void SetDia(int dia)
    {
        diaActual = dia;
    }

}