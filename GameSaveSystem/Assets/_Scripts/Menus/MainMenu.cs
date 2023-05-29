using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        if (!SaveManager.instance.hasSaveFile())
        {
            loadGameButton.interactable = false;
        }

    }
    public void OnNewGameClicked()
    {
        
        SaveManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Game");
    }

    public void OnLoadGameClicked()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
  