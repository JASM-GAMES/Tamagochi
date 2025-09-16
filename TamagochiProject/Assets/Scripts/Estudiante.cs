using System.Reflection;
using UnityEngine;

public class Estudiante : MonoBehaviour
{
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
        hambre = 30;

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
        // Presiona la tecla D para que el estudiante duerma y ver los cambios en el hambre y el sueño
        if (Input.GetKeyDown(KeyCode.D))
        {
            dormir();
        }
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

    //Mecanica para dormir tomada por eduardo
    public void dormir()
    {
        int cantidadDormida = 40; // Cantidad que recupera al dormir
        int hambreAumentada = 15; // Dormir da hambre

        // Disminuir el sueño y aumentar el hambre
        sueno -= cantidadDormida;
        hambre += hambreAumentada;

        // Limitar los valores entre 0 y 100
        if (sueno > 100) sueno = 100;
        if (hambre > 100) hambre = 100;
        // limitar los valores para que no sean negativos
        if (sueno < 0) sueno = 0;
        if (hambre < 0) hambre = 0;

        Debug.Log("Esta durmiendo...");
        Debug.Log("\n");
        Debug.Log("Sueño actual: " + sueno);
        Debug.Log("Hambre actual: " + hambre);
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
