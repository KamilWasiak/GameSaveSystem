using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ISaveable
{

    [SerializeField]
    public int playerHealth;
    private string playerHealthKey;

    [SerializeField]
    public int playerGold;
    private string playerGoldKey;



    void Awake()
    {
        playerHealthKey = ("PlayerHealth");
        playerGoldKey = ("PlayerGold");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth -= 10;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            playerGold++;
        }
    }

    public void LoadData(GameData data)
    {
        data.playerHealth.TryGetValue(playerHealthKey, out playerHealth);
        data.playerGold.TryGetValue(playerGoldKey, out playerGold);
    }

    public void SaveData(ref GameData data)
    {
        if (data.playerHealth.ContainsKey(playerHealthKey))
        {
            data.playerHealth.Remove(playerHealthKey);
        }
        data.playerHealth.Add(playerHealthKey, playerHealth);


        if (data.playerGold.ContainsKey(playerGoldKey))
        {
            data.playerGold.Remove(playerGoldKey);
        }
        data.playerGold.Add(playerGoldKey, playerGold);
    }
}
