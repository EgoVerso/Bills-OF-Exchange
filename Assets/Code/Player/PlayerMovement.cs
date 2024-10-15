using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad base del jugador, modificable desde el Inspector
    public float speedReduction = 2f; // Cantidad de reducción de velocidad al apuntar, modificable desde el Inspector

    private float originalMoveSpeed; // Para almacenar la velocidad original

    void Start()
    {
        // Guardar la velocidad original al inicio
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        // Detectar si el botón derecho del mouse está presionado
        if (Input.GetMouseButton(1)) // 1 es el botón derecho del mouse
        {
            moveSpeed = originalMoveSpeed - speedReduction; // Reducir la velocidad
        }
        else
        {
            moveSpeed = originalMoveSpeed; // Restaurar la velocidad normal
        }

        // Obtener la entrada horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D y flechas izquierda/derecha
        float moveVertical = Input.GetAxis("Vertical"); // W/S y flechas arriba/abajo

        // Crear un vector de movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;

        // Aplicar movimiento al objeto
        transform.Translate(movement);
    }
}
