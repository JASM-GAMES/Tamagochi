using UnityEngine;
using UnityEngine.Events;
public class Interactuable : MonoBehaviour
{
    public string mensaje = "|E|";
    public UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //mensaje de debug para ver con que estoy interactuando
        Debug.Log("Interactuable detectó algo: " + other.name);
        if (other.CompareTag("Estudiante"))
        {
            // mensaje de debug para ver que es el estudiante
            Debug.Log("Interactuable: es el estudiante");
            Debug.Log(mensaje);
            // Aquí podrías mostrar un UI prompt en pantalla
        }
    }

    public void Interactuar()
    {
        onInteract?.Invoke();
    }
}