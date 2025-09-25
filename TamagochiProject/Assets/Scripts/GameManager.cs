using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Tiempo del Juego")]
    public int minutosActual;  // 0 - 59
    public int horasActual;    // 0 - 23
    public int diaActual;     // 0 en adelante

    [Header("Referencias")]
    public Estudiante estudiante;

    public float segundosXMinutos;
    public float tiempoXHambre;
    public float tiempoXSueno;
    public float tiempoXDiversion;
    public float tiempoXEstres;
    public float tiempoXSocial;

    public ManagerUI UIM;

    private float timer;

    //getter y setter

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
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
        UIM.actualizarBarraEstudio();
    }
    //Disminuye las necesidades del estudiante con el tiempo
    private void DisminuirNecesidadesEstudiante()
    {
        estudiante.Hambre = estudiante.Hambre - tiempoXHambre;
        estudiante.Sueno = estudiante.Sueno - tiempoXSueno;
        estudiante.Diversion = estudiante.Diversion - tiempoXDiversion;
        estudiante.Estres = estudiante.Estres - tiempoXEstres;
        estudiante.Social = estudiante.Social - tiempoXSocial;
    }

    //sirve como un reloj que avanza los minutos, horas y dias
    //se agrego tambien la logica que debe ocurrir cuando se avanza una hora o un dia
    private void AvanzarTiempo()
    {
        minutosActual++;
        DisminuirNecesidadesEstudiante();
        // lo que pasa cuando se llega a 60 minutos
        if (minutosActual >= 60)
        {
            minutosActual = 0;
            horasActual++;
            // lo que pasa cuando se llega a 24 horas
            if (horasActual >= 24)
            {
                horasActual = 0;
                diaActual++;
            }
        }
    }
    public void ModificarTiempo(float nuevoTiempo)
    {
        segundosXMinutos = nuevoTiempo;
    }
    public void ModificarNecesidades(float hambre,float sueno,float diversion,float estres,float social)
    {
    tiempoXHambre=hambre;
    tiempoXSueno=sueno;
    tiempoXDiversion= diversion;
    tiempoXEstres= estres;
    tiempoXSocial= social;
}
    public void GuardarNecesidadesIniciales()
    {
        float refTiempoXHambre = tiempoXHambre;
        float refTiempoXSueno = tiempoXSueno;
        float refTiempoXDiversion = tiempoXDiversion;
        float refTiempoXEstres = tiempoXEstres;
        float refTiempoXSocial = tiempoXSocial;
    }
}


