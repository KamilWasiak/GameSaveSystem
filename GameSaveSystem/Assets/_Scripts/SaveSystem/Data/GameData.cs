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

        //Loading data not working as Vector3's are not serializable. 
        //In order to make this work a converter class needs to be made to convert
        //the vector3 into a float array
        playerPosition = new SerializableDictionary<string, Vector3>();
        playerPosition["PlayerPosition"] = new Vector3(0, 1, 0);
    }
}
