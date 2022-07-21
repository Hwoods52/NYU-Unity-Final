using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTest : Interactable
{
    public GameObject Obs;
    public PlayerInteract playerInteract;
    public bool hasBeenUsed = false;
    void OnMouseDown()
    {
        transform.position = Obs.transform.position;
        transform.parent = Obs.transform.parent;
        transform.rotation = new Quaternion(0, 0, 0, 1);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        playerInteract.isHoldingTank = true;
        playerInteract.heldObject = gameObject;

    }

     void Drop()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
       
    }



}
