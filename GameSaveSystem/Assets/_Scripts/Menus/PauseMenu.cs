using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPauseMenuActive = false;

    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseMenuActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        playerController.enabled = false;
        isPauseMenuActive = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPauseMenuActive = false;
    }

    public void OnResumeGameClicked()
    {
        ResumeGame();
    }

    public void GoToMainMenu()
    {
       //SaveManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void OnSaveAndQuitClicked()
    {
        SaveManager.instance.SaveGame();
        Application.Quit();
    }

}
            
