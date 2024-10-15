using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bulletPrefab; // Asigna aquí el prefab de la bala
    public Transform shootPoint; // El punto desde donde se disparará la bala
    public float bulletSpeed = 20f;
    public GameObject reloadObject; // Referencia al objeto de recarga

    void Update()
    {
        // Solo permite disparar si el objeto de recarga no está activo
        if (reloadObject != null && !reloadObject.activeInHierarchy)
        {
            // Detectar si el botón izquierdo del ratón es presionado
            if (Input.GetMouseButtonDown(0))
            {
                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        // Instanciar la bala en la posición del "shootPoint"
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Añadir fuerza a la bala en la dirección del "shootPoint"
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
        }
    }
}
