using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public float playerHealth = 100;
    public float displayedPlayerHealth = 100;
    public float shipHealth = 25;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI shipHealthText;
    public OxygenSystem oxygenSystem;
    public ShieldManager shieldManager;
    public GameManager gameManager;
    public TextMeshProUGUI deathMessage;
    void LateUpdate()
    {
        
        shipHealthText.text = "Ship Integrity: " + shipHealth;
        if(playerHealth > 100)
        {
            playerHealth = 100;
        }
        //displayedPlayerHealth = playerHealth;
        playerHealthText.text = "Oxygen Level: " + playerHealth;


        if (playerHealth == 0)
        {
            Debug.Log("You Died");
            gameManager.PlayerDeath();
            deathMessage.text = "You Ran Out Of Oxygen";
        }else if(shipHealth == 0)
        {
            Debug.Log("You Died");
            gameManager.PlayerDeath();
            deathMessage.text = "Your Ship Exploded";
        }
    }
}
