using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject currentCheckpoint;
    List<GameObject> checkpoints = new List<GameObject>();

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

        // Finds all checkpoints in checkpoint holder and adds them to the list
        foreach (Transform child in GameObject.Find("CheckpointHolder").transform)
        {
            checkpoints.Add(child.gameObject);
        }
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

        GameObject pauseMenu = GameObject.Find("PauseMenu"); // RL: Consider caching this reference
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isGamePaused);
        }

        Time.timeScale = isGamePaused ? 0 : 1;
        Debug.Log("Game " + (isGamePaused ? "Paused" : "Resumed"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetPlayer(GameObject player)
    {
        player.transform.position = (Vector2)currentCheckpoint.transform.position + new Vector2(0, 2);
    }

    public void NewCheckpoint(GameObject checkpoint)
    {
        if (currentCheckpoint == null)
        {
            currentCheckpoint = checkpoint;
            return;
        }

        // Makes sure both checkpoints are in the list
        if (checkpoints.Contains(checkpoint) && checkpoints.Contains(currentCheckpoint))
        {
            currentCheckpoint = checkpoints.IndexOf(checkpoint) > checkpoints.IndexOf(currentCheckpoint) ? checkpoint : currentCheckpoint;
        }
        else Debug.Log("Checkpoint not in list");
    }
}
