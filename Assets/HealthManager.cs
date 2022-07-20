using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public float playerHealth = 100;
    public float shipHealth = 25;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI shipHealthText;
    public OxygenSystem oxygenSystem;
    public ShieldManager shieldManager;
    void Update()
    {
        playerHealthText.text = "Player Health: " + playerHealth;
        shipHealthText.text = "Ship Health: " + shipHealth;


        if(playerHealth == 0 || shipHealth == 0)
        {
            Debug.Log("You Died");
        }
    }
}
