using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // El objeto que la cámara seguirá (el jugador)
    public Vector3 offset;     // Desplazamiento de la cámara respecto al jugador
    public float mouseSensitivity = 100f;  // Sensibilidad del movimiento del mouse
    public float distanceFromPlayer = 2f;  // Distancia de la cámara al jugador
    public float minYAngle = -30f;  // Ángulo mínimo de la cámara hacia abajo
    public float maxYAngle = 60f;   // Ángulo máximo de la cámara hacia arriba

    float currentX = 0f;
    float currentY = 0f;

    void Start()
    {
        // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Captura el movimiento del mouse
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Limita la rotación vertical de la cámara
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + rotation * direction + offset;

        // Hace que la cámara mire al jugador
        transform.LookAt(player.position + Vector3.up * 1.5f); // Ajusta la altura si es necesario
    }
}
