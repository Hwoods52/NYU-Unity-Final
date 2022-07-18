using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 10f;

    public float horizontalInput;
    public float verticalInput;
    public int movementType;
    void Start()
    {
        movementType = 0;
    }

    void Update()
    {
        if(movementType == 0) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }



        //move the vehicle forward
        if (movementType == 1)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
    }
}