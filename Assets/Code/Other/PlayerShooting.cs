using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // Reference to the projectile prefab
    public Transform shootPoint;         // The point from which the projectile will be fired
    public float shootForce = 700f;      // The force with which the projectile will be fired
    public Animator animator;            // Reference to the Animator component
    public float shootCooldown = 0.5f;   // Cooldown time between shots

    private bool isShooting = false;
    private float lastShootTime;

    void Update()
    {
        // Check if the player presses the spacebar and if the cooldown has passed
        if (Input.GetKey(KeyCode.Space) && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
        }
        else
        {
            // Set IsShooting to false if the player isn't holding the shoot button
            animator.SetBool("IsShooting", false);
        }
    }

    void Shoot()
    {
        // Set IsShooting to true to play the animation
        animator.SetBool("IsShooting", true);

        // Update the last shoot time to the current time
        lastShootTime = Time.time;

        // Instantiate the projectile at the shoot point's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectile.gameObject.SetActive(true);

        // Get the Rigidbody component of the projectile and apply force to it
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);

        // Optionally, destroy the projectile after a certain time to avoid cluttering the scene
        Destroy(projectile, 2f); // Increased the lifetime of the projectile
    }
}