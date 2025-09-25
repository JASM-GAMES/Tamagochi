using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;
    public float sensibilidadMouse = 2f;

    [Header("Interacción")]
    public float distanciaInteraccion = 3f; // hasta dónde puede interactuar
    public Interactuable interactuableActual;

    [Header("Opciones")]
    public bool bloquearCursor = true;

    private float rotacionX = 0f;
    private Rigidbody rb;
    private Camera cam;
    public ManagerUI mui;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // evita que la física gire el jugador
        cam = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        if (bloquearCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        RotarCamara();
        DetectarInteractuable();

        // Si hay algo interactuable en la mira y presionamos E
        if (Input.GetKeyDown(KeyCode.E) && interactuableActual != null)
        {
            interactuableActual.Interactuar();
        }
    }

    void FixedUpdate()
    {
        MoverJugador();
    }

    private void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void MoverJugador()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direccion = (transform.right * x + transform.forward * z).normalized;
        Vector3 nuevaPosicion = rb.position + direccion * velocidadMovimiento * Time.fixedDeltaTime;

        rb.MovePosition(nuevaPosicion);
    }

    private void DetectarInteractuable()
    {
        Interactuable nuevoInteractuable = null;
        RaycastHit hit;

        // Opcional: usa una LayerMask para solo raycastear interactuables
        // if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanciaInteraccion, capaInteractuables))
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanciaInteraccion))
        {
            hit.collider.TryGetComponent(out nuevoInteractuable);
        }

        // Si cambió el objeto en la mira
        if (nuevoInteractuable != interactuableActual)
        {
            if (interactuableActual != null)
            {
                interactuableActual.CancelarInteraccion(); // opcional: cancelar lógica en la mecánica
                mui.desactivarMensajeInteractuar();
            }

            interactuableActual = nuevoInteractuable;

            if (interactuableActual != null)
            {
                Debug.Log("Mirando interactuable: " + interactuableActual.name);
                mui.activarMensajeInteractuar();
            }
        }

        // Opcional: asegurar que si no hay ninguno, el mensaje esté oculto
        if (nuevoInteractuable == null && interactuableActual == null)
        {
            mui.desactivarMensajeInteractuar();
        }
    }
}