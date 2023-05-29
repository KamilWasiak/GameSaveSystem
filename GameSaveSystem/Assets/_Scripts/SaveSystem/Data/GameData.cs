using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public SerializableDictionary<string, int> playerHealth;
    public SerializableDictionary<string, int> playerGold;
    public SerializableDictionary<string, bool> coinsCollected;
    public SerializableDictionary<string, Vector3> playerPosition;

    public GameData()
    {
        playerHealth = new SerializableDictionary<string, int>();
        playerHealth["PlayerHealth"] = 100;

        playerGold = new SerializableDictionary<string, int>();
        playerGold["PlayerGold"] = 0;

        coinsCollected = new SerializableDictionary<string, bool>();

        playerPosition = new SerializableDictionary<string, Vector3>();
        playerPosition["PlayerPosition"] = new Vector3(0, 1, 0);
    }
}
