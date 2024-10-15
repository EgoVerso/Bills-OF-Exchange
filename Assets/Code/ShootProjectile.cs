using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bulletPrefab; // Asigna aquí el prefab de la bala
    public Transform shootPoint; // El punto desde donde se disparará la bala
    public float bulletSpeed = 20f;

    void Update()
    {
        // Detectar si el botón izquierdo del ratón es presionado
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en la posición del "shootPoint"
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Añadir fuerza a la bala en la dirección del "shootPoint"
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootPoint.forward * bulletSpeed;
    }
}
