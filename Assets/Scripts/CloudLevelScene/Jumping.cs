using UnityEngine;

public class Jumping : MonoBehaviour
{
    public CharacterController controller;
    public float jumpHeight = 2f;  // Height of the jump
    public float gravity = -9.81f;  // Gravity force
    private float velocityY = 0f;  // Vertical velocity
    private bool isGrounded;

    public Walking walkingScript;  // Reference to the walking script

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // If grounded and falling, reset the vertical velocity to stay grounded
        if (isGrounded && velocityY < 0)
        {
            velocityY = -2f; // Small downward force to stay grounded
        }

        // Jump input (works as soon as spacebar is pressed)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump velocity
        }

        // Apply gravity to the vertical velocity
        velocityY += gravity * Time.deltaTime;

        // Move the player: horizontal movement + vertical movement (jump/gravity)
        Vector3 horizontal = walkingScript.GetMovementDirection() * walkingScript.moveSpeed;
        Vector3 vertical = new Vector3(0, velocityY, 0);

        // Combine horizontal and vertical movement
        Vector3 move = horizontal + vertical;
        controller.Move(move * Time.deltaTime);
    }
}
