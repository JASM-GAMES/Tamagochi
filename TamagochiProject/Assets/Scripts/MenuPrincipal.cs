using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Panel de confirmación")]
    public GameObject panelConfirmacion;

    [Header("Panel de despedida")]
    public GameObject panelDespedida;

    public void IniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PreguntarSalir()
    {
        panelConfirmacion.SetActive(true);
    }

    public void ConfirmarSalir()
    {
        // Oculta el panel de confirmación
        panelConfirmacion.SetActive(false);

        // Muestra el panel de despedida
        panelDespedida.SetActive(true);

        // Inicia la corrutina para salir después de unos segundos
        StartCoroutine(SalirConRetraso());
    }

    public void CancelarSalir()
    {
        panelConfirmacion.SetActive(false);
    }

    private IEnumerator SalirConRetraso()
    {
        yield return new WaitForSeconds(2f); // espera 2 segundos

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
