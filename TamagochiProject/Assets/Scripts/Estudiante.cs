using System.Reflection;
using UnityEngine;

public class Estudiante : MonoBehaviour
{
    //COMUNICACION CON LAS REFERENCIAS DE LA ESCENA

    public ManagerUI UIM;
    public GameManager gm;

    //ATRIBUTOS
    //------------------------------------------------------
    private float hambre;
    private float diversion;
    private float estres;
    private float sueno;
    private float social;

    //SETTERS Y GETTERS
    //------------------------------------------------------
    public float Hambre { get => hambre; set => hambre = value; }
    public float Diversion { get => diversion; set => diversion = value; }
    public float Estres { get => estres; set => estres = value; }
    public float Sueno { get => sueno; set => sueno = value; }
    public float Social { get => social; set => social = value; }

    //START
    //------------------------------------------------------
    void Start()
    {
        // valores iniciales para probar los metodos
        sueno = 50;
        hambre = 50;
        diversion = 50;
        estres = 50;
        social = 50;
    }
    private void Update()
    {
    }
    public void validarAtrinutos() 
    {
        // Mathf.Clamp() cumple la misma funcion que un if, pero en una sola linea de codigo, es mas efectivo para mantener valores en un establecido

        //hambre
        hambre = Mathf.Clamp(hambre, 0, 100);
        //sueño
        sueno = Mathf.Clamp(sueno, 0, 100);
        //diversion
        diversion = Mathf.Clamp(diversion, 0, 100);
        //estres
        estres = Mathf.Clamp(estres, 0, 100);
        //social
        social = Mathf.Clamp(social, 0, 100);
    }
    public void LimiteNecesidades()
    {
        if (hambre <= 0 || sueno <= 0 || diversion <= 0 || estres <= 0 || social <= 0)
        {
            // Muestra panel fade
            UIM.activarPanelFadeOut();

            // Reinicia necesidades
            hambre = 20;
            sueno = 20;
            diversion = 20;
            estres = 20;
            social = 20;

            // --- NUEVO: empujar al jugador un poco ---
            if (UIM != null && UIM.playerController != null)
            {
                var player = UIM.playerController;
                Rigidbody rb = player.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // mueve medio metro hacia atrás respecto a su forward actual
                    Vector3 empuje = -player.transform.forward * 0.5f;
                    rb.MovePosition(rb.position + empuje);
                }

                // si está interactuando con algo, cancela la interacción para que se suelte
                // (necesitas exponer interactuableActual como público en PlayerController)
                if (player.interactuableActual != null)
                {
                    player.interactuableActual.CancelarInteraccion();
                }
            }
        }
    }
    public bool PuedeEstudiar()
    {
        // devuelve true solo si todas las necesidades están por encima de 40
        return hambre > 40 && sueno > 40 && diversion > 40 && estres > 40 && social > 40;
    }
    public void SumarBarraSueno() { sueno += 10; }
    public void SumarBarraHambre() { hambre += 10; }
    public void SumarBarraDiversion() { diversion += 10; }
    public void SumarBarraEstres() { estres += 10; }
    public void SumarBarraSocial() { social += 10; }
    public void RestarBarraSueno() { sueno -= 10; }
    public void RestarBarraHambre() { hambre -= 10; }
    public void RestarBarraDiversion() { diversion -= 10; }
    public void RestarBarraEstres() { estres -= 10; }
    public void RestarBarraSocial() { social -= 10; }

}
