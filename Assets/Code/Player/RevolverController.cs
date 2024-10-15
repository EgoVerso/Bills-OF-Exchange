using UnityEngine;
using TMPro; // Asegúrate de incluir esto para usar TextMeshPro

public class RevolverController : MonoBehaviour
{
    public GameObject revolver; // Objeto del revólver
    public GameObject mira; // Objeto de la mira
    public GameObject reloadObject; // Objeto de recarga
    public int maxBullets = 6; // Número máximo de balas
    private int currentBullets; // Balas actuales
    public float reloadTime = 2f; // Tiempo de recarga

    public AudioClip reloadSound; // Clip de sonido para la recarga
    private AudioSource audioSource; // Componente de AudioSource

    public TMP_Text bulletText; // Referencia al TextMeshPro del HUD

    void Start()
    {
        currentBullets = maxBullets; // Inicializa las balas
        reloadObject.SetActive(false); // Asegúrate de que el objeto de recarga esté desactivado al inicio
        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource del objeto
        ActivateRevolver(); // Inicialmente activa el revólver, desactiva la mira
        UpdateBulletText(); // Inicializa el texto del HUD
    }

    void Update()
    {
        // Disparar si se presiona el botón de disparo y hay balas disponibles
        if (Input.GetButtonDown("Fire1") && currentBullets > 0)
        {
            Shoot();
        }

        // Si no hay balas, inicia el proceso de recarga
        if (currentBullets == 0 && !reloadObject.activeInHierarchy)
        {
            StartReload();
        }
    }

    void Shoot()
    {
        currentBullets--; // Reduce la cantidad de balas
        Debug.Log("Disparado! Balas restantes: " + currentBullets);
        UpdateBulletText(); // Actualiza el texto del HUD

        // Aquí puedes añadir la lógica para disparar (raycast, efectos, etc.)

        if (currentBullets == 0)
        {
            Debug.Log("Sin balas!");
        }
    }

    void StartReload()
    {
        DeactivateAll(); // Desactiva tanto el revólver como la mira
        reloadObject.SetActive(true); // Activa el objeto de recarga
        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound); // Reproduce el sonido de recarga
        }
        Invoke("FinishReload", reloadTime); // Inicia la recarga
    }

    void FinishReload()
    {
        reloadObject.SetActive(false); // Desactiva el objeto de recarga
        currentBullets = maxBullets; // Restaura las balas
        UpdateBulletText(); // Actualiza el texto del HUD
        ActivateRevolver(); // Vuelve a activar el revólver después de recargar
        Debug.Log("Recarga completa! Balas disponibles: " + currentBullets);
    }

    void ActivateRevolver()
    {
        // Solo activa el revólver si no está activo el objeto de recarga
        if (!reloadObject.activeInHierarchy)
        {
            revolver.SetActive(true); // Activa el revólver
            mira.SetActive(false); // Desactiva la mira
        }
    }

    void DeactivateAll()
    {
        revolver.SetActive(false); // Desactiva el revólver
        mira.SetActive(false); // Desactiva la mira
    }

    void UpdateBulletText()
    {
        // Actualiza el texto en el HUD con las balas restantes
        if (bulletText != null)
        {
            bulletText.text = "Balas: " + currentBullets + "/" + maxBullets;
        }
    }
}
