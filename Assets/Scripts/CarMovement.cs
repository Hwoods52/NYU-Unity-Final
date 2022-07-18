using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private PlayerMovementTutorial playerMovement;
    private bool carMovement;
    private GameObject car;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    public Transform orientation;
    public Rigidbody rb;
    public float moveSpeed;
    public float turnSpeed;
    public Camera playerCam;
    private MoveCamera moveCamera;
    public Transform carCamPos;
    private float storedSensX;
    private float storedSensY;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovementTutorial>();
        //rb = car.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Car Entry Trigger")){
            /*storedSensX = playerCam.GetComponent<MoveCamera>().sensX;
            playerCam.GetComponent<MoveCamera>().sensX = 0;
            storedSensY = playerCam.GetComponent<MoveCamera>().sensY;
            playerCam.GetComponent<MoveCamera>().sensY = 0;
            playerCam.GetComponent<MoveCamera>().cameraPosition = carCamPos;
            playerCam.transform.rotation = carCamPos.transform.rotation;*/
            playerCam.GetComponent<MoveCamera>().enabled = false;
            playerMovement.enabled = false;
            playerCam.transform.rotation = carCamPos.transform.rotation;
            playerCam.transform.position = carCamPos.transform.position;
            carMovement = true;
            car = col.transform.parent.gameObject;
            Debug.Log(car);
        }
    }

    private void MovePlayer()
    {
        if (car != null)
        {
            moveDirection = orientation.forward * verticalInput;
            car.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            //rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            //car.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}
