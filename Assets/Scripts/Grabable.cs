using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : Interactable
{
    public GameObject playerHoldPosition;
    public PlayerInteract playerInteract;
    public bool hasBeenUsed = false;

    private void Awake()
    {
        playerHoldPosition = GameObject.Find("PlayerHoldPosition");
        playerInteract = GameObject.Find("Player").GetComponent<PlayerInteract>();
}

    protected override void Interact()
    {
        transform.position = playerHoldPosition.transform.position;
        transform.parent = playerHoldPosition.transform.parent;
        transform.rotation = new Quaternion(0, 0, 0, 1);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        playerInteract.isHoldingTank = true;
        playerInteract.heldObject = gameObject;

    }

    public void Drop()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().enabled = true;
        playerInteract.heldObject = null;
        playerInteract.isHoldingTank = false;
    }



}
