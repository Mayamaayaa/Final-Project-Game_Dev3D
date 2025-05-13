using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // <-- Add this to handle scene reloading

public class HealthMa : MonoBehaviour
{
    public static HealthMa Instance;

    public Image[] hearts;
    public Image gameOverImage;
    public Transform respawnPoint;
    public float fallHeight = -10f;

    private int health = 3;
    private bool hasFallen = false;
    private bool isGameOver = false; // <-- Add flag to track Game Over state

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        // Detect fall
        if (transform.position.y < fallHeight && !hasFallen)
        {
            hasFallen = true;
            LoseLife();
        }

        // Check for spacebar to reset game
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f; // Unpause the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
        }
    }

    public void LoseLife()
    {
        if (health <= 0) return;

        health--;
        hearts[health].enabled = false;
        RespawnPlayer();

        if (health <= 0)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true; // <-- Set game over flag
        }
    }

    private void RespawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = respawnPoint.position;
            hasFallen = false;
        }
    }
}
