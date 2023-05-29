using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI healthText;
    TextMeshProUGUI coinsText;
    PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(gameObject.name == "HealthText")
        {
            UpdateHealthUI();
        }
        else if (gameObject.name == "CoinsText")
        {
            UpdateCoinUI();
        }   
    }

    private void UpdateHealthUI()
    {
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
        healthText.text = ("Health: " + playerStats.playerHealth);
    }

    private void UpdateCoinUI()
    {
        coinsText = gameObject.GetComponent<TextMeshProUGUI>();
        coinsText.text = ("Coins: " + playerStats.playerHealth);
    }
}
