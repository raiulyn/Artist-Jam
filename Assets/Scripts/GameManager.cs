using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGamePaused;
    private bool isInGame;

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
            if (!isInGame) { return; } //Ensure the game is running before allowing pause
            TogglePauseGame();
        }
    }

    public void StartGame()
    {
        // Load the main game scene
        //SceneManager.LoadScene("MainGameScene");
        isInGame = true;
        SceneManagerr.Instance?.LoadScene("SampleScene");
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

        GameObject pauseMenu = GameObject.Find("PauseMenu"); // RL: Consider caching this reference
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isGamePaused);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
