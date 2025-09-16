using UnityEngine;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    public Estudiante estudiante;
    public GameManager gameManager;

    public TMP_Text textoHambre;
    public TMP_Text textoSueno;
    public TMP_Text textoDiversion;
    public TMP_Text textoEstres;
    public TMP_Text textoSocial;

    public TMP_Text textoTiempo;

    private string minuto;
    private string hora;
    private string dia;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarTiempo()
    {
        minuto = gameManager.GetMinuto().ToString();
        hora = gameManager.GetHora().ToString();
        dia = gameManager.GetDia().ToString();
        textoTiempo.text = $"Día: {gameManager.GetDia()+1} - {gameManager.GetHora():00}:{gameManager.GetMinuto():00}";
    }

}
