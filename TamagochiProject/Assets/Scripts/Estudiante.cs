using System.Reflection;
using UnityEngine;

public class Estudiante : MonoBehaviour
{
    //COMUNICACION CON LAS REFERENCIAS DE LA ESCENA

    public ManagerUI UIM;
    public GameManager gm;

    //ATRIBUTOS
    //------------------------------------------------------
    private string nombre;
    private int edad;
    private int hambre;
    private int diversion;
    private int estres;
    private int sueno;
    private int social;

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

        // Menu para mostrar atributos inciados al ejecutar el juego
        Debug.Log("|============|" +
                  "| BIENVENIDO |" +
                  "|============|");
        Debug.Log("Hambre: " + hambre);
        Debug.Log("Sueño: " + sueno);
        Debug.Log("Diversion: " + diversion);
        Debug.Log("Estres: " + estres);
        Debug.Log("Social: " + social);
    }
    private void Update()
    {
    }

    //SETTERS Y GETTERS
    //------------------------------------------------------
    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }
    public string getNombre()
    {
        return nombre;
    }
    public void setEdad(int edad)
    {
        this.edad = edad;
    }
    public int getEdad()
    {
        return edad;
    }
    public void setHambre(int hambre)
    {
        this.hambre = hambre;
    }
    public int getHambre()
    {
        return hambre;
    }
    public void setDiversion(int diversion)
    {
        this.diversion = diversion;
    }
    public int getDiversion()
    {
        return diversion;
    }
    public void setEstres(int estres)
    {
        this.estres = estres;
    }
    public int getEstres()
    {
        return estres;
    }
    public void setSueno(int sueno)
    {
        this.sueno = sueno;
    }
    public int getSueno()
    {
        return sueno;
    }
    public void setSocial(int social)
    {
        this.social = social;
    }
    public int getSocial()
    {
        return social;
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

    //------------------------------------------------------

}
