using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGamePaused;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Example of handling pause functionality
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    public void StartGame()
    {
        // Load the main game scene
        //SceneManager.LoadScene("MainGameScene");
    }

    public void EndGame()
    {
        // Handle end game logic
        Debug.Log("Game Over");
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : 1;
        Debug.Log("Game " + (isGamePaused ? "Paused" : "Resumed"));
    }
}
