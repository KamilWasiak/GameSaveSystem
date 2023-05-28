using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;

    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<ISaveable> saveableObjects;

    private FileSaveHandler saveHandler;
    
  public static SaveManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Save Manager alraedy exists in the scene");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        this.saveHandler = new FileSaveHandler(Application.persistentDataPath, filename, useEncryption);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.saveableObjects = FindAllSaveableObjects();
        // LoadGame();      -Currently not working as it causes errors
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    private void Start()
    {
        
        
        LoadGame();
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
