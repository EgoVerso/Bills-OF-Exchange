using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject bulletPrefab; // Asigna aqu� el prefab de la bala
    public Transform shootPoint; // El punto desde donde se disparar� la bala
    public float bulletSpeed = 20f;

    void Update()
    {
        // Detectar si el bot�n izquierdo del rat�n es presionado
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en la posici�n del "shootPoint"
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // A�adir fuerza a la bala en la direcci�n del "shootPoint"
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = shootPoint.forward * bulletSpeed;
    }
}
