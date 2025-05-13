using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private Vector3 respawnPosition = new Vector3(33.63f, 4.61f, 5.99f); // Respawn position
    private float invincibleTime = 1.0f; // 1 second of invincibility
    private float lastHitTime = -999f; // Tracks the time of the last damage

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the player touches an object with the "PurpleBranches" tag
        if (hit.gameObject.CompareTag("PurpleBranches"))
        {
            if (Time.time - lastHitTime < invincibleTime) return; // Still invincible

            lastHitTime = Time.time; // Set the time when the player gets hit

            Debug.Log("Player touched PurpleBranches!");

            // Get reference to HealthManager and call TakeDamage method
            HealthManager healthManager = FindObjectOfType<HealthManager>();

            if (healthManager != null)
            {
                healthManager.TakeDamage(); // Call TakeDamage to decrease health
            }

            // If health is greater than 0, respawn the player
            if (healthManager != null && healthManager.health > 0)
            {
                transform.position = respawnPosition; // Move player to respawn position
            }
        }
    }
}
