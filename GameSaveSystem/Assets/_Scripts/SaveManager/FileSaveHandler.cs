using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.NetworkInformation;

public class FileSaveHandler
{
    private string saveDirPath = "";
    private string saveFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCode = "MyEncryptionCode";

    public FileSaveHandler(string saveDirPath, string saveFileName, bool useEncryption)
    {
        this.saveDirPath = saveDirPath;
        this.saveFileName = saveFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(saveDirPath, saveFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error when trying to load " + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(saveDirPath, saveFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error when trying to save " + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string encryptedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            encryptedData += (char) (data[i] ^ encryptionCode[i % encryptionCode.Length]);
        }
        return encryptedData;
    }
}
    
