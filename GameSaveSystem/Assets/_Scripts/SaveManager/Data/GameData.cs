using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int playerHealth;
    public Vector3 playerPosition;

    public GameData()
    {
        this.playerHealth = 100;
        playerPosition = new Vector3(0, 1, 0);
    }

}
