using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Player's movement speed
    public Transform cameraTransform;     // Transform of the camera
    public Animator animator;             // Reference to the Animator component
    public GameObject projectilePrefab;   // Reference to the projectile prefab
    public Transform shootPoint;          // The point from which the projectile will be fired
    public float shootForce = 700f;       // The force with which the projectile will be fired
    public float shootCooldown = 0.5f;    // Cooldown time between shots

    private float lastShootTime;

    void Update()
    {
        // ---- MOVEMENT SECTION ----
        // Capture horizontal and vertical input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera's rotation
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure movement is only on the XZ plane
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Combine input to get the movement direction
        Vector3 moveDirection = forward * moveZ + right * moveX;

        // Apply the movement to the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // If there's movement input, rotate the player to face the direction of the camera
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", moveDirection.magnitude * moveSpeed);

        // ---- SHOOTING SECTION ----
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

        // Get the Rigidbody component of the projectile and apply force to it
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);

        // Optionally, destroy the projectile after a certain time to avoid cluttering the scene
        Destroy(projectile, 2f); // Increased the lifetime of the projectile
    }
}
