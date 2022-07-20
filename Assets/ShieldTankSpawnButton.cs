using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTankSpawnButton : Interactable
{
    public GameObject shieldTankPrefab;
    public Transform spawnPoint;
    protected override void Interact()
    {
        Instantiate(shieldTankPrefab, spawnPoint.position, shieldTankPrefab.transform.rotation);
    }
}
