using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI healthText;
    TextMeshProUGUI goldText;
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
        else if (gameObject.name == "GoldText")
        {
            UpdateGoldUI();
        }   
    }

    private void UpdateHealthUI()
    {
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
        healthText.text = ("Health: " + playerStats.playerHealth);
    }

    private void UpdateGoldUI()
    {
        goldText = gameObject.GetComponent<TextMeshProUGUI>();
        goldText.text = ("Gold: " + playerStats.playerGold);
    }
}
