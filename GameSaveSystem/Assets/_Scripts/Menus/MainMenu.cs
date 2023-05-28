using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
  