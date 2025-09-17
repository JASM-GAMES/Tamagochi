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
        hambre = 30;
        diversion = 0;
        estres = 80;
        social = 20;

        // no es necesario llamar a los metodos en el start, solo es para probarlos
        //jugar();
        //comer();
        //dormir();
        //estudiar();
        //hacerTrabajo();
        //irUniversidad();
        //chatear();

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
    //asdjkaosnfoqwf
    public void jugar()
    {
        Debug.Log("esta jugando");
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
        // Valida los limites de los atributos en cada accion
        validarAtrinutos();

        Debug.Log("Esta durmiendo...");
        Debug.Log("Sueño actual: " + sueno);
        Debug.Log("Hambre actual: " + hambre);
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
