using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public SerializableDictionary<string, int> playerHealth;
    public Vector3 playerPosition;

    public GameData()
    {
        playerHealth = new SerializableDictionary<string, int>();
        playerHealth["PlayerHealth"] = 100;

        playerPosition = new Vector3(0, 1, 0);
    }

}
