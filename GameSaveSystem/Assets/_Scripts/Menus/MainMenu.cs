using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button loadGameButton;
    
    private void Start()
    {
        if (!SaveManager.instance.hasSaveFile())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
    }


    public void ContinueGameClicked()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
  