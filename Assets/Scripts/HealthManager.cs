using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public Transform heartContainer;
    public GameObject gameOverText;

    private bool isGameOver = false;

    void Start()
    {
        health = heartContainer.childCount;
        gameOverText.SetActive(false);
        UpdateHearts();
        Time.timeScale = 1f; // Ensure normal speed at game start
    }

    public void TakeDamage()
    {
        if (health <= 0) return;

        health--;
        UpdateHearts();

        if (health <= 0)
        {
            gameOverText.SetActive(true);
            isGameOver = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f; // Freeze game
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartScene();
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                LoadMainMenu();
            }
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartContainer.childCount; i++)
        {
            heartContainer.GetChild(i).gameObject.SetActive(i < health);
        }
    }

    public void RestartScene()
    {
        Time.timeScale = 1f; // Unfreeze
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Unfreeze
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}
