using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad base del jugador, modificable desde el Inspector
    public float speedReduction = 2f; // Cantidad de reducci�n de velocidad al apuntar, modificable desde el Inspector

    private float originalMoveSpeed; // Para almacenar la velocidad original

    Vector3 moveHorizontal; // A/D y flechas izquierda/derecha
    Vector3 moveVertical; // W/S y flechas arriba/abajo
    private Rigidbody rb;

    void Start()
    {
        // Guardar la velocidad original al inicio
        originalMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Detectar si el bot�n derecho del mouse est� presionado
        if (Input.GetMouseButton(1)) // 1 es el bot�n derecho del mouse
        {
            moveSpeed = originalMoveSpeed - speedReduction; // Reducir la velocidad
        }
        else
        {
            moveSpeed = originalMoveSpeed; // Restaurar la velocidad normal
        }

        // Obtener la entrada horizontal y vertical
        moveHorizontal = Input.GetAxis("Horizontal") * transform.right; // A/D y flechas izquierda/derecha
        moveVertical = Input.GetAxis("Vertical") * transform.forward; // W/S y flechas arriba/abajo
    }

    void FixedUpdate()
    {
        // Crear un vector de movimiento
        Vector3 movement = new Vector3(moveHorizontal.x + moveVertical.x, 0f, moveHorizontal.z + moveVertical.z).normalized * moveSpeed * Time.fixedDeltaTime;
        print(movement);

        rb.MovePosition(transform.position + movement);
    }
}
