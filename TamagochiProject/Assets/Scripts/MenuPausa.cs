using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa; // Arrastra el Canvas Pausa aquí
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
        menuPausa.SetActive(true);  // Mostrar menú
        Time.timeScale = 0f;        // Detener el tiempo del juego
        juegoPausado = true;
    }

    void Reanudar()
    {
        menuPausa.SetActive(false); // Ocultar menú
        Time.timeScale = 1f;        // Reanudar el tiempo
        juegoPausado = false;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f; // Asegurar que el tiempo vuelve a la normalidad
        SceneManager.LoadScene("Menu"); // Nombre exacto de tu escena del menú principal
    }

    public void AbrirOpciones()
    {
        Debug.Log("Aquí puedes abrir un panel de opciones");
        // Si quieres, más adelante puedes activar otro panel con configuraciones
    }
}
