using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPodTrigger : MonoBehaviour
{
    public HealthManager healthManager;
    public bool isHealing = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHealing = true;
            healthManager.playerHealth += Time.deltaTime * 5;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHealing = false;
        }
    }
}
