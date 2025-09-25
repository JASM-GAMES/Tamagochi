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
    public ObjetivosManager objetivosManager;

    public float segundosXMinutos;
    public float tiempoXHambre;
    public float tiempoXSueno;
    public float tiempoXDiversion;
    public float tiempoXEstres;
    public float tiempoXSocial;

    private float refTiempoXHambre;
    private float refTiempoXSueno;
    private float refTiempoXDiversion;
    private float refTiempoXEstres;
    private float refTiempoXSocial;

    public ManagerUI UIM;

    private float timer;
    public bool universidadActivo=false;

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
        GuardarNecesidadesIniciales();
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
        estudiante.LimiteNecesidades();
        if (horasActual >= 15 && horasActual <= 16)
        {
            UIM.activarPanelIrUniversidad();
            universidadActivo = true;
        }
        else
        {
            UIM.desactivarPanelIrUniversidad();
            universidadActivo = false;
        }
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
                objetivosManager.Examen();
                objetivosManager.barraEstudio = 0;
            }
        }
    }
    public void ModificarTiempo(float nuevoTiempo){segundosXMinutos = nuevoTiempo;}
    public void ModificarHambre(float hambre){tiempoXHambre=hambre;}
    public void modificarSueno(float sueno){tiempoXSueno = sueno;}
    public void modificarDiversion(float diversion){tiempoXDiversion = diversion;}
    public void modificarEstres(float estres){tiempoXEstres = estres;}
    public void modificarSocial(float social){tiempoXSocial = social;}
    public void GuardarNecesidadesIniciales()
    {
        refTiempoXHambre = tiempoXHambre;
        refTiempoXSueno = tiempoXSueno;
        refTiempoXDiversion = tiempoXDiversion;
        refTiempoXEstres = tiempoXEstres;
        refTiempoXSocial = tiempoXSocial;
    }
    public void CargarNecesidadesIniciales()
    {
        tiempoXHambre = refTiempoXHambre;
        tiempoXSueno = refTiempoXSueno;
        tiempoXDiversion = refTiempoXDiversion;
        tiempoXEstres = refTiempoXEstres;
        tiempoXSocial = refTiempoXSocial;
    }
}