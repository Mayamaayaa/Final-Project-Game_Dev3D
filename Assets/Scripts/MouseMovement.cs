using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 300f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    // Starting position and rotation (Modify this to set your desired starting values)
    public Vector3 startingPosition = new Vector3(0f, 1.5f, 0f); // Example: height 1.5
    public Vector3 startingRotation = new Vector3(0f, 0f, 0f);  // Default: 0,0,0

    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set the starting position and rotation when the game starts
        transform.position = startingPosition;
        transform.rotation = Quaternion.Euler(startingRotation);

        // Initialize the rotation values with the starting rotation
        xRotation = startingRotation.x;
        yRotation = startingRotation.y;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply mouse movement rotation around the x and y axis
        xRotation -= mouseY;
        yRotation += mouseX;

        // Clamp the xRotation between the top and bottom limits
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Apply the new rotations to the transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
