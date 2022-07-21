using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStation : Interactable
{

    public PlayerInteract playerInteract;
    public Transform tankPosition;
    public GameObject usedTank;
    public ShieldManager shieldManager;
    public bool hasTank = false;
    public bool shieldsEmpty;
    protected override void Interact()
    {
        if (playerInteract.heldObject != null && hasTank == false)
        {
            playerInteract.heldObject.transform.parent = null;
            playerInteract.heldObject.transform.position = tankPosition.position;
            playerInteract.heldObject.transform.rotation = tankPosition.rotation;
            usedTank = playerInteract.heldObject;
            playerInteract.isHoldingTank = false;
            playerInteract.heldObject = null;
            hasTank = true;
            usedTank.GetComponent<Grabable>().hasBeenUsed = true;
            shieldManager.TankUsed();

        } else if (playerInteract.heldObject == null && hasTank == true)
        {
            usedTank.GetComponent<Interactable>().BaseInteract();
            hasTank = false;
            usedTank = null;
        }
    }
}
