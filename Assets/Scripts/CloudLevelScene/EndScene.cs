using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // This is triggered when something enters the portal plane trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that touched the portal is the Player
        if (other.CompareTag("Player"))
        {
            // Load the CloudLevel scene
            SceneManager.LoadScene("FinalScene");
        }
    }
}
