using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button ExitButton;

    [SerializeField] private OptionsMenu OptionsMenuPrefab;

    public void OnEnable()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
        OptionsButton.onClick.AddListener(OnOptionsButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }
    private void OnDisable()
    {
        StartButton.onClick.RemoveListener(OnStartButtonClick);
        OptionsButton.onClick.RemoveListener(OnOptionsButtonClick);
        ExitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        GameManager.Instance?.StartGame();
    }
    private void OnOptionsButtonClick()
    {
        Instantiate(OptionsMenuPrefab, this.transform.parent); // Spawns the OptionsMenu prefab as a sibling to the MainMenu

    }
    private void OnExitButtonClick()
    {
        GameManager.Instance?.QuitGame();
    }
}
