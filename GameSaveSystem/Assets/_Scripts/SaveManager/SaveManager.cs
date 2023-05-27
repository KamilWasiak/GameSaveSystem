using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;

    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<ISaveable> saveableObjects;

    private FileSaveHandler saveHandler;
    
  public static SaveManager instance { get; private set; }

    private void Start()
    {
        this.saveHandler = new FileSaveHandler(Application.persistentDataPath, filename, useEncryption);
        this.saveableObjects = FindAllSaveableObjects();
        LoadGame();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Save Manager alraedy exists in the scene");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (ISaveable saveableObj in saveableObjects)
        {
            saveableObj.SaveData(ref gameData);
        }

        saveHandler.Save(gameData);
    }

    public void LoadGame()
    {
        this.gameData = saveHandler.Load();

        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (ISaveable saveableObj in saveableObjects)
        {
            saveableObj.LoadData(gameData);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame(); 
    }

    private List<ISaveable> FindAllSaveableObjects()
    {
        IEnumerable<ISaveable> saveableObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<ISaveable>();

        return new List<ISaveable>(saveableObjects);
    }
}
