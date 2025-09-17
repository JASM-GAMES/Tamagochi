using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
}