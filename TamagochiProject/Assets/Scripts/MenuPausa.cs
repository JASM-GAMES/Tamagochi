using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Header("Pausa")]
    public GameObject Pausa;

    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                Reanudar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        Pausa.SetActive(true); // Activa el Canvas
        Time.timeScale = 0f;         // Detiene el tiempo del juego
        juegoPausado = true;
    }

    public void Reanudar()
    {
        Pausa.SetActive(false); // Desactiva el Canvas
        Time.timeScale = 1f;          // Restaura el tiempo del juego
        juegoPausado = false;
    }

    public void IrAlMenuPrincipal()
    {
        
        SceneManager.LoadScene("Menu"); // ⚠️ cambia "MenuPrincipal" por el nombre real de tu escena
    }

    public void Opciones()
    {
        Debug.Log("Menú de opciones abierto (por implementar)");
    }
}
