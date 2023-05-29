using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySaveHandler
{
    private string saveDirPath = "";
    private string saveFileName = "";

    public BinarySaveHandler(string saveDirPath, string saveFileName)
    {
        this.saveDirPath = saveDirPath;
        this.saveFileName = saveFileName;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(saveDirPath, saveFileName);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(fullPath, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public GameData Load()
    {
        GameData loadedData = null;
        string fullPath = Path.Combine(saveDirPath, saveFileName);
        if (File.Exists(fullPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fullPath, FileMode.Open);

            loadedData = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return loadedData;
        }

        else
        {
            Debug.Log("Save not found.");
            return null;
        }
    }

}
