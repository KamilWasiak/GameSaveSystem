using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ISaveable
{
    [SerializeField]
    private int playerHealth;

    void Start()
    {
        
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
        this.playerHealth = data.playerHealth;
    }

    public void SaveData(ref GameData data)
    {
        data.playerHealth = this.playerHealth;
    }
}
