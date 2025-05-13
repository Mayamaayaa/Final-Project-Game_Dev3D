using UnityEngine;
using UnityEngine.UI;

public class InstructionOverlay : MonoBehaviour
{
    public GameObject instructionsImage; // Drag your "instructions" image here
    public float fadeDuration = 1f;

    private CanvasGroup canvasGroup;
    private bool waitingForInput = true;

    void Start()
    {
        // Get the CanvasGroup component attached to the instructions image
        canvasGroup = instructionsImage.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not found on instructionsImage.");
            return;
        }

        // Ensure the image is fully visible at the start
        canvasGroup.alpha = 1f;

        // Freeze the game at the start by disabling mouse movement
        if (TryGetComponent(out MouseMovement mouse))
        {
            mouse.enabled = false;
        }
    }

    void Update()
    {
        // Wait for spacebar press
        if (waitingForInput && Input.GetKeyDown(KeyCode.Space))
        {
            waitingForInput = false;

            // Re-enable mouse movement after spacebar is pressed
            if (TryGetComponent(out MouseMovement mouse))
            {
                mouse.enabled = true;
            }

            // Start the fade-out process
            StartCoroutine(FadeOutInstructions());
        }
    }

    System.Collections.IEnumerator FadeOutInstructions()
    {
        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        // Fade out the image by reducing alpha over time
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / fadeDuration);
            yield return null;
        }

        // Ensure the image is fully invisible after fading out
        canvasGroup.alpha = 0f;
        instructionsImage.SetActive(false); // Optionally deactivate the image
    }
}
