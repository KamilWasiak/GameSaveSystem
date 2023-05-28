using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, int> playerHealth;
    public SerializableDictionary<string, Vector3> playerPosition;

    public GameData()
    {
        playerHealth = new SerializableDictionary<string, int>();
        playerHealth["PlayerHealth"] = 100;

        playerPosition = new SerializableDictionary<string, Vector3>();
        playerPosition["PlayerPosition"] = new Vector3(0, 1, 0);
        //playerPosition["PlayerPosition"] = new float[3];
        //playerPosition["PlayerPosition"][0] = 0;
        //playerPosition["PlayerPosition"][1] = 1;
        //playerPosition["PlayerPosition"][2] = 0;
    }
}
