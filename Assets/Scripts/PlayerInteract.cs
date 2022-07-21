using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    public bool isHoldingTank = false;
    public GameObject heldObject;
    

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && !isHoldingTank)
            {
                hitInfo.collider.GetComponent<Interactable>().BaseInteract();
            }
            else if (isHoldingTank && hitInfo.collider.CompareTag("TankStation") && Input.GetKeyDown(KeyCode.Mouse0) && heldObject.GetComponent<Grabable>().hasBeenUsed == false && hitInfo.collider.gameObject.GetComponent<TankStation>().shieldsEmpty == true)
            {
                hitInfo.collider.GetComponent<Interactable>().BaseInteract();
            }
        }else if (isHoldingTank && Input.GetKeyDown(KeyCode.Mouse0))
        {
            heldObject.GetComponent<Grabable>().Drop();
        }

    }
}
