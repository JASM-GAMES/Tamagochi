using System;
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

    [Header("Referencias")]
    public Estudiante estudiante;

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
            AvanzarTiempo();
            timer = 0f;
        }
        

        // Se conecta al UI
        UIM.actualizarTiempo();
        UIM.actualizarNecesidades();
    }
    //Disminuye las necesidades del estudiante con el tiempo
    private void DisminuirNecesidadesEstudiante()
    {
        estudiante.setHambre(estudiante.getHambre() - 5);
        estudiante.setSueno(estudiante.getSueno() - 2);
        estudiante.setDiversion(estudiante.getDiversion() - 4);
        estudiante.setEstres(estudiante.getEstres() - 1);
        estudiante.setSocial(estudiante.getSocial() - 4);
    }

    //sirve como un reloj que avanza los minutos, horas y dias
    //se agrego tambien la logica que debe ocurrir cuando se avanza una hora o un dia
    private void AvanzarTiempo()
    {
        minutosActual++;
        // lo que pasa cuando se llega a 60 minutos
        if (minutosActual >= 60)
        {
            minutosActual = 0;
            horasActual++;
            DisminuirNecesidadesEstudiante();

            // lo que pasa cuando se llega a 24 horas
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