using UnityEngine;

public class Walking : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Get horizontal movement direction (to be used in Jumping.cs)
    public Vector3 GetMovementDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return transform.right * x + transform.forward * z;  // Direction of movement
    }
}
