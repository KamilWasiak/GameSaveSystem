using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ISaveable
{
    private string playerHealthKey;

    [SerializeField]
    private int playerHealth;

    void Start()
    {
        playerHealthKey = ("PlayerHealth");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth -= 10;
        }
    }

    public void LoadData(GameData data)
    {
       // this.playerHealth = data.playerHealth;

        data.playerHealth.TryGetValue(playerHealthKey, out playerHealth);
    }

    public void SaveData(ref GameData data)
    {
        // data.playerHealth = this.playerHealth;
        if (data.playerHealth.ContainsKey(playerHealthKey))
        {
            data.playerHealth.Remove(playerHealthKey);
        }
        data.playerHealth.Add(playerHealthKey, playerHealth);
    }
}
