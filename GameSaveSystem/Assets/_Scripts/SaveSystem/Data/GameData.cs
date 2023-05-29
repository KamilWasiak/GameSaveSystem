using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public SerializableDictionary<string, int> playerHealth;
    public SerializableDictionary<string, Vector3> playerPosition;

    public GameData()
    {
        playerHealth = new SerializableDictionary<string, int>();
        playerHealth["PlayerHealth"] = 100;

        playerPosition = new SerializableDictionary<string, Vector3>();
        playerPosition["PlayerPosition"] = new Vector3(0, 1, 0);
    }
}
