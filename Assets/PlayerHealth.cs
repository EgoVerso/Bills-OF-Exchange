using UnityEngine;
using TMPro; // Asegúrate de incluir esto para usar TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima
    private int currentHealth; // Vida actual
    public TMP_Text healthText; // Referencia al texto del HUD

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida actual
        UpdateHealthText(); // Actualiza el texto del HUD
    }

    // Método para recibir daño
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Resta el daño a la vida actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegúrate de que no baje de 0
        UpdateHealthText(); // Actualiza el texto del HUD

        if (currentHealth <= 0)
        {
            Die(); // Llama al método de muerte si la vida es 0
        }
    }

    // Método para curar
    public void Heal(int amount)
    {
        currentHealth += amount; // Suma la cantidad de curación
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegúrate de que no supere el máximo
        UpdateHealthText(); // Actualiza el texto del HUD
    }

    // Método para actualizar el texto del HUD
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Vida: " + currentHealth + "/" + maxHealth; // Actualiza el texto
        }
    }

    // Método para manejar la muerte
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aquí puedes agregar lógica para lo que sucede al morir (reiniciar, mostrar pantalla de muerte, etc.)
    }
}
