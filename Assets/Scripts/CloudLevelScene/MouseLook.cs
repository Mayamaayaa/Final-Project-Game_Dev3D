using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;  // Sensitivity of mouse movement
    public Transform playerBody;          // Reference to the player's body (for rotating)
    private float xRotation = 0f;         // Rotation on the X axis (vertical rotation)

    void Start()
    {
        // Hide the cursor and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player body on the Y axis (left/right movement)
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera (up/down movement), clamp to avoid flipping upside down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit up/down rotation

        // Apply the vertical rotation to the camera
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
