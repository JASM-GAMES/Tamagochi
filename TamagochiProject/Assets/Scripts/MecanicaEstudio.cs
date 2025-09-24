using UnityEngine;

public class MecanicaEstudio : MonoBehaviour
{
    private void Awake()
    {
        PunteroMouseVisible(true);  
    }
    // Si quieres que simplemente desaparezca el objeto:
    public void DesactivarCirculo()
    {
        // Desactiva el objeto para que desaparezca de la UI
        gameObject.SetActive(false);

        // Si quieres hacer algo más, por ejemplo sumar puntos:
        Debug.Log("¡Círculo clickeado!");
    }
    public void PunteroMouseVisible(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}