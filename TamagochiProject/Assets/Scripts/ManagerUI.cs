using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ManagerUI : MonoBehaviour
{   
    public Estudiante estudiante;
    public GameManager gameManager;
    public ObjetivosManager objetivosManager;
    public PlayerController playerController;

    public GameObject MensajeInteractuar;
    public GameObject MensajeReprobaste;
    public GameObject MensajeAprobaste;
    public GameObject PanelContinuar;
    public GameObject PanelResultado;
    public GameObject PanelIrUniversidad;
    public GameObject PanelNoIrUniversidad;
    public GameObject PanelFadeOut;

    public Image zonaVerde;
    public Slider sliderMecanicaBarra;
    public Slider sliderBarraEstudiante;

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
    public void actualizarBarraEstudio()
    {
        sliderBarraEstudiante.value = objetivosManager.barraEstudio;
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
        MensajeInteractuar.SetActive(false);
    }
    public void activarMensajeReprobaste()
    {
        PanelResultado.SetActive(true);
        MensajeReprobaste.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OcultarPanel(PanelResultado));
    }
    public void activarMensajeAprobaste()
    {
        PanelResultado.gameObject.SetActive(true);
        MensajeAprobaste.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OcultarPanel(PanelResultado));
    }
    public void desactivarMensajeAprobaste()
    {
        PanelResultado.gameObject.SetActive(false);
    }
    public void activarPanelContinuar()
    {
        PanelContinuar.gameObject.SetActive(true);
    }
    public void desactivarPanelContinuar()
    {
        PanelContinuar.gameObject.SetActive(false);
    }
    public void activarPanelIrUniversidad()
    {
        PanelIrUniversidad.gameObject.SetActive(true);
    }
    public void desactivarPanelIrUniversidad()
    {
        PanelIrUniversidad.gameObject.SetActive(false);
    }
    public void activarPanelNoIrUniversidad()
    {
        PanelNoIrUniversidad.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OcultarPanel(PanelNoIrUniversidad.gameObject));
    }
    public void desactivarNoPanelIrUniversidad()
    {
        PanelNoIrUniversidad.gameObject.SetActive(false);
    }
    public void activarPanelFadeOut()
    {
        PanelFadeOut.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OcultarPanel(PanelFadeOut));
    }
    public void desactivarPanelFadeOut()
    {
        PanelFadeOut.gameObject.SetActive(false);
    }
    private System.Collections.IEnumerator OcultarPanel(GameObject panel)
    {
        yield return new WaitForSeconds(3); // Espera el tiempo deseado
        panel.SetActive(false);                     // Oculta el panel
    }
}
