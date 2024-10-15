using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo que la bala existirá antes de ser destruida
    private AudioSource audioSource; // Referencia al AudioSource
    public AudioClip bulletSound; // Sonido de disparo

    void Start()
    {
        // Encuentra el AudioSource en el objeto actual
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && bulletSound != null)
        {
            audioSource.PlayOneShot(bulletSound); // Reproduce el sonido de disparo
        }
        else
        {
            Debug.LogError("AudioSource o bulletSound no asignado en el prefab de la bala.");
        }

        // Destruye la bala después del tiempo especificado
        Invoke("DestroyObject", lifeTime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destruir la bala al colisionar con cualquier objeto
        DestroyObject();
    }

    void DestroyObject()
    {
        // Destruye el objeto
        Destroy(gameObject);
    }
}
