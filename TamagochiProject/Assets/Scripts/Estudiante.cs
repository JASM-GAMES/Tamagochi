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
        jugar();
        comer();
        dormir();
        estudiar();
        hacerTrabajo();
        irUniversidad();
        chatear();
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
    public void setSueno(int sueño)
    {
        this.sueno = sueño;
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
    //------------------------------------------------------
    //======================================================
    //METODOS DEL ESTUDIANTE
    //======================================================
    //------------------------------------------------------
    public void jugar()
    {
        Debug.Log("esta jugando");
    }
    public void comer()
    {
        Debug.Log("esta comiendo");
    }
    public void dormir()
    {
        Debug.Log("esta durmiendo");
    }
    public void estudiar()
    {
        Debug.Log("esta estudiando");
    }
    public void hacerTrabajo()
    {
        Debug.Log("esta haciendo el trabajo");
    }
    public void irUniversidad()
    {
        Debug.Log("se fue a la universidad");
    }
    public void chatear()
    {
        Debug.Log("esta chateando");
    }
    //------------------------------------------------------
}
