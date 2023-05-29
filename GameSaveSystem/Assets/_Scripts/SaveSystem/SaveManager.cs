using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using CloudSaveSample;

public class SaveManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;

    [SerializeField] private bool useEncryption;

    
    private GameData gameData;

    private List<ISaveable> saveableObjects;

    private FileSaveHandler saveHandler;
    private BinarySaveHandler binarySaveHandler;
    private CloudSaveSample.CloudSaveSample cloudsaveHandler;
    enum SaveMethod
    {
        LocalSave,
        CloudSave
    }
    [SerializeField] SaveMethod saveMethod;

    enum SaveType
    {
        Json,
        Binary
    }
    [Header("(Local Save Only)")]
        [SerializeField] SaveType saveType;

    public static SaveManager instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance != null)
        {
            Debug.LogWarning("Save Manager alraedy exists in the scene, deleting new instance.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        this.saveHandler = new FileSaveHandler(Application.persistentDataPath, filename, useEncryption);
        this.binarySaveHandler = new BinarySaveHandler(Application.persistentDataPath, filename);
        this.cloudsaveHandler = new CloudSaveSample.CloudSaveSample();
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
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {

        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data found. Start a new game before trying to save.");
            return;
        }

        foreach (ISaveable saveableObj in saveableObjects)
        {
            saveableObj.SaveData(ref gameData);
        }

        if (saveMethod == SaveMethod.LocalSave && saveType == SaveType.Json)
        {
            saveHandler.Save(gameData);
        }
        else if (saveMethod == SaveMethod.LocalSave && saveType == SaveType.Binary)
        {
            binarySaveHandler.Save(gameData);
        }
        else if (saveMethod == SaveMethod.CloudSave)
        {
            cloudsaveHandler.Save(gameData);
        }
    }

    public void LoadGame()
    {
        if (saveMethod == SaveMethod.LocalSave && saveType == SaveType.Json)
        {
            this.gameData = saveHandler.Load();
            
        }
        else if (saveMethod == SaveMethod.LocalSave && saveType == SaveType.Binary)
        {
            //this.gameData = binarySaveHandler.Load();
            //Loading binary files currently not working - fix required
        }
        else if (saveMethod == SaveMethod.CloudSave)
        {
            //this.gameData = cloudsaveHandler.Load();
            //cloud save loading currently not working - fix required
        }

        if (this.gameData == null)
        {
            Debug.Log("No save file found. Start a new game before trying to load.");
            return;
        }

        foreach (ISaveable saveableObj in saveableObjects)
        {
            saveableObj.LoadData(gameData);
        }
    }

    public bool hasSaveFile()
    {
        return gameData != null;
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