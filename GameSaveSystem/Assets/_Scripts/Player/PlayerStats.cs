using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ISaveable
{

    [SerializeField]
    public int playerHealth;
    private string playerHealthKey;

    void Awake()
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
        data.playerHealth.TryGetValue(playerHealthKey, out playerHealth);
    }

    public void SaveData(ref GameData data)
    {
        if (data.playerHealth.ContainsKey(playerHealthKey))
        {
            data.playerHealth.Remove(playerHealthKey);
        }
        data.playerHealth.Add(playerHealthKey, playerHealth);
    }
}
