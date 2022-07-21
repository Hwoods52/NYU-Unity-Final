using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldManager : MonoBehaviour
{
    public float shieldHealth = 10;
    public bool shieldsOn = true;
    public TankStation tankStation;
    [SerializeField]
    private TextMeshProUGUI shieldText;
    public HealthManager healthManager;
    void Start()
    {
        shieldText.text = "Shield Health = " + shieldHealth;
    }
    public void ShieldHit()
    {
        shieldHealth -= 1;
        shieldText.text = "Shield Health = " + shieldHealth;
        if(shieldHealth <= 0)
        {
            shieldsOn = false;
            shieldText.text = "Shields Down";
            tankStation.shieldsEmpty = true;
            healthManager.shipHealth -= 1;
        }
    }
    public void TankUsed()
    {
        shieldHealth = 10;
        shieldText.text = "Shield Health = " + shieldHealth;
    }
}