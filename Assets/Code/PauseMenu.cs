using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas
using UnityEngine.UI; // Para interactuar con los UI elements

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Asigna el Canvas del menú de pausa aquí
    public GameObject playerCanvas; // Asigna el Canvas del jugador aquí
    public string sceneToLoad; // Asigna el nombre de la escena a cargar al salir

    private bool isPaused = false;

    void Update()
    {
        // Comprobar si se presiona la tecla Escape para pausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;

        // Habilitar el control del jugador
        EnablePlayerControls(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Pausa el juego
        isPaused = true;

        // Deshabilitar el control del jugador
        EnablePlayerControls(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo se reanude
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void Quit()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo se reanude
        // Habilitar todos los componentes relevantes antes de cambiar de escena
        EnablePlayerControls(true);

        // Cambia a la escena que desees usando el nombre especificado
        SceneManager.LoadScene(sceneToLoad);
    }

    private void EnablePlayerControls(bool enable)
    {
        // Deshabilitar o habilitar los componentes relevantes en el Canvas del jugador
        foreach (Transform child in playerCanvas.transform)
        {
            // Habilita o deshabilita cada script relevante
            if (child.TryGetComponent<ShootProjectile>(out var shootProjectile))
            {
                shootProjectile.enabled = enable;
            }

            if (child.TryGetComponent<RevolverController>(out var revolverController))
            {
                revolverController.enabled = enable;
            }

            if (child.TryGetComponent<AimSystem>(out var aimSystem))
            {
                aimSystem.enabled = enable;
            }

            if (child.TryGetComponent<Bullet>(out var bullet))
            {
                bullet.enabled = enable;
            }

            if (child.TryGetComponent<PlayerMovement>(out var playerMovement))
            {
                playerMovement.enabled = enable;
            }

            // Deshabilitar o habilitar el CameraController
            if (child.TryGetComponent<CameraController>(out var cameraController))
            {
                cameraController.enabled = enable;
            }
        }
    }
}
