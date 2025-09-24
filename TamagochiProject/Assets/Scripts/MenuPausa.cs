using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa; // Arrastra el Canvas Pausa aqu�
    private bool juegoPausado = false;

    void Update()
    {
        // Detectar la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    void Pausar()
    {
        menuPausa.SetActive(true);  // Mostrar men�
        Time.timeScale = 0f;        // Detener el tiempo del juego
        juegoPausado = true;
    }

    void Reanudar()
    {
        menuPausa.SetActive(false); // Ocultar men�
        Time.timeScale = 1f;        // Reanudar el tiempo
        juegoPausado = false;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f; // Asegurar que el tiempo vuelve a la normalidad
        SceneManager.LoadScene("Menu"); // Nombre exacto de tu escena del men� principal
    }

    public void AbrirOpciones()
    {
        Debug.Log("Aqu� puedes abrir un panel de opciones");
        // Si quieres, m�s adelante puedes activar otro panel con configuraciones
    }
}
