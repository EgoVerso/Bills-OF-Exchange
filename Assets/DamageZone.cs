using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de da�o que se har�
    public float detectionRadius = 5f; // Radio de detecci�n para aplicar da�o
    public Transform player; // Referencia al objeto del jugador
    public float damageInterval = 2f; // Intervalo de tiempo para aplicar da�o

    private bool playerInZone = false; // Para rastrear si el jugador est� en la zona
    private float lastDamageTime; // Tiempo desde el �ltimo da�o aplicado

    private void Update()
    {
        if (player != null)
        {
            // Comprobar la distancia entre el jugador y el cubo
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= detectionRadius)
            {
                if (!playerInZone) // Marca que el jugador ha entrado en la zona
                {
                    playerInZone = true;
                    lastDamageTime = Time.time; // Reinicia el tiempo de da�o
                    ApplyDamage(); // Aplica da�o inmediato al entrar
                }
                else if (Time.time >= lastDamageTime + damageInterval) // Verifica si ha pasado el intervalo
                {
                    ApplyDamage();
                }
            }
            else
            {
                playerInZone = false; // Reinicia la verificaci�n al salir de la zona
            }
        }
    }

    private void ApplyDamage()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            lastDamageTime = Time.time; // Actualiza el tiempo del �ltimo da�o
            Debug.Log("Da�o aplicado: " + damageAmount);
        }
        else
        {
            Debug.LogWarning("El objeto del jugador no tiene el componente PlayerHealth.");
        }
    }
}
