using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{   
    public Estudiante estudiante;
    public GameManager gameManager;

    public GameObject MensajeInteractuar;

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
        minuto = gameManager.minutosActual.ToString();
        hora = gameManager.horasActual.ToString();
        dia = gameManager.diaActual.ToString();
        textoTiempo.text = $"Día: {gameManager.diaActual+1} - {gameManager.horasActual:00}:{gameManager.minutosActual:00}";
    }

    public void actualizarNecesidades()
    {
        sliderHambre.value = estudiante.Hambre;
        sliderSueno.value = estudiante.Sueno;
        sliderDiversion.value = estudiante.Diversion;
        sliderEstres.value = estudiante.Estres;
        sliderSocial.value = estudiante.Social;
    }

    public void activarMecanicaBarra()
    {
        sliderMecanicaBarra.gameObject.SetActive(true);
    }

    public void desactivarMecanicaBarra()
    {
        sliderMecanicaBarra.gameObject.SetActive(false);
    }

    public void activarMensajeInteractuar()
    {
        MensajeInteractuar.gameObject.SetActive(true);
    }
    public void desactivarMensajeInteractuar()
    {
        MensajeInteractuar.gameObject.SetActive(false);
    }
}
