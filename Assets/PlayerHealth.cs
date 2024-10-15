using UnityEngine;
using TMPro; // Aseg�rate de incluir esto para usar TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima
    private int currentHealth; // Vida actual
    public TMP_Text healthText; // Referencia al texto del HUD

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la vida actual
        UpdateHealthText(); // Actualiza el texto del HUD
    }

    // M�todo para recibir da�o
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Resta el da�o a la vida actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Aseg�rate de que no baje de 0
        UpdateHealthText(); // Actualiza el texto del HUD

        if (currentHealth <= 0)
        {
            Die(); // Llama al m�todo de muerte si la vida es 0
        }
    }

    // M�todo para curar
    public void Heal(int amount)
    {
        currentHealth += amount; // Suma la cantidad de curaci�n
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Aseg�rate de que no supere el m�ximo
        UpdateHealthText(); // Actualiza el texto del HUD
    }

    // M�todo para actualizar el texto del HUD
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Vida: " + currentHealth + "/" + maxHealth; // Actualiza el texto
        }
    }

    // M�todo para manejar la muerte
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aqu� puedes agregar l�gica para lo que sucede al morir (reiniciar, mostrar pantalla de muerte, etc.)
    }
}
