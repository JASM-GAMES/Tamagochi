using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Interactuable interactuableActual;

    public float velocidadMovimiento = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;        // No gravedad en 2D top-down
        rb.freezeRotation = true;   // Que no rote al chocar
    }

    void Update()
    {
        // Interacción
        if (Input.GetKeyDown(KeyCode.E) && interactuableActual != null)
        {
            interactuableActual.Interactuar();
        }
        // Lee input con WASD / flechas
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
    }

    void FixedUpdate()
    {
        // Movimiento físico
        rb.MovePosition(rb.position + input * velocidadMovimiento * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //mensaje de debug para ver con que estoy interactuando
        Debug.Log("estoy interactuando: "+collision);
        if (collision.TryGetComponent(out Interactuable interactuable))
        {
            interactuableActual = interactuable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //mensaje de debug para ver con que ya no estoy interactuando
        Debug.Log(" no estoy interactuando: " + collision);
        if (collision.TryGetComponent(out Interactuable interactuable) && interactuable == interactuableActual)
        {
            interactuableActual = null;
        }
    }

}