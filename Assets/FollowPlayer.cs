using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float followDistance = 2f; // Distancia a la que el objeto debe mantenerse
    public float followSpeed = 2f; // Velocidad a la que el objeto se mueve hacia el jugador

    void Update()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;

        // Obtener la distancia actual al jugador
        float distance = direction.magnitude;

        // Verificar si el objeto está más cerca de la distancia deseada
        if (distance > followDistance)
        {
            // Normalizar la dirección y mover el objeto hacia el jugador
            direction.Normalize();
            Vector3 targetPosition = player.position - direction * followDistance;

            // Mover el objeto hacia la posición objetivo
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
