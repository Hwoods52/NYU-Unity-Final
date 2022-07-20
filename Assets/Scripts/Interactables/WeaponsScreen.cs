using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScreen : Interactable
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private Transform weaponsCameraPosition;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public bool isBeingUsed = false;
    public Transform defaultCameraPosition;
    public Transform defaultOrientation;

    public Camera mainCamera;
    public Camera gunCamera;
    public Camera fakeGunCamera;
    public Transform mainCameraPosition;

    protected override void Interact()
    {
        if (isBeingUsed == true)
        {

            isBeingUsed = false;
            player.GetComponent<PlayerMovementTutorial>().enabled = true;
            player.GetComponentInChildren<MeshRenderer>().enabled = true;
            MoveCamera moveCamera = cam.GetComponent<MoveCamera>();
            moveCamera.cameraPosition = defaultCameraPosition;
            moveCamera.orientation = defaultOrientation;
            cam.GetComponent<Camera>().fieldOfView = 90;
            moveCamera.xMin = -90;
            moveCamera.xMax = 90;
            moveCamera.yMin = -360;
            moveCamera.yMax = 360;
            
            
        }
         else if (isBeingUsed == false)
        {
            isBeingUsed = true;
            player.GetComponent<PlayerMovementTutorial>().enabled = false;
            player.GetComponentInChildren<MeshRenderer>().enabled = false;
            MoveCamera moveCamera = cam.GetComponent<MoveCamera>();
            moveCamera.cameraPosition = weaponsCameraPosition;
            cam.transform.rotation = weaponsCameraPosition.rotation;
            moveCamera.orientation = weaponsCameraPosition;
            cam.GetComponent<Camera>().fieldOfView = 60;
            moveCamera.xMin = xMin;
            moveCamera.xMax = xMax;
            moveCamera.yMin = yMin;
            moveCamera.yMax = yMax;
            mainCamera.depth = -1;
            mainCamera.gameObject.GetComponent<MoveCamera>().enabled = false;
            gunCamera.gameObject.GetComponent<MoveCamera>().enabled = true;
            mainCamera.transform.position = mainCameraPosition.position;
            mainCamera.transform.rotation = mainCameraPosition.rotation;
            gunCamera.transform.rotation = fakeGunCamera.transform.rotation;
        }
        
        
        
    }
}
