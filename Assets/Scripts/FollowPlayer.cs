using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;       // The player (your capsule)
    public Vector3 offset = new Vector3(0, 2, -3); // Position offset (above and behind)
    public float followSpeed = 5f; // Speed of movement

    void Update()
    {
        if (player != null)
        {
            // Calculate target position based on the player position and offset
            Vector3 targetPosition = player.position + player.TransformDirection(offset);

            // Smoothly move to that position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
