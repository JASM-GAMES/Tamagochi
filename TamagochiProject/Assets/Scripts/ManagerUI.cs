using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{   
    public Estudiante estudiante;
    public GameManager gameManager;

    public Image zonaVerde;
    public Slider sliderMecanicaBarra;

    public Slider sliderHambre;
    public Slider sliderSueno;
    public Slider sliderDiversion;
    public Slider sliderEstres;
    public Slider sliderSocial;

    public TMP_Text textoTiempo;

    private string minuto;
    private string hora;
    private string dia;

    public void actualizarTiempo()
    {
        minuto = gameManager.GetMinuto().ToString();
        hora = gameManager.GetHora().ToString();
        dia = gameManager.GetDia().ToString();
        textoTiempo.text = $"Día: {gameManager.GetDia()+1} - {gameManager.GetHora():00}:{gameManager.GetMinuto():00}";
    }

    public void actualizarNecesidades()
    {
        sliderHambre.value = estudiante.getHambre();
        sliderSueno.value = estudiante.getSueno();
        sliderDiversion.value = estudiante.getDiversion();
        sliderEstres.value = estudiante.getEstres();
        sliderSocial.value = estudiante.getSocial();
    }

    public void activarMecanicaBarra()
    {
        sliderMecanicaBarra.gameObject.SetActive(true);
    }

    public void desactivarMecanicaBarra()
    {
        sliderMecanicaBarra.gameObject.SetActive(false);
    }

}
