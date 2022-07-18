using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    Vector3 moveVector;
    public float turnSpeed = 10f;
    public CharacterController controller;
    public float speed = 6f;
    float turnSmoothVelocity;
    public Transform playerCamera;
    public GameObject car;
    public GameObject plane;
    public Cinemachine.CinemachineFreeLook cinemachine;
    private bool hasEntered;
    public GameObject model;
    public Animator animator;

    public float turnSmoothTime = 0.1f;

    public int movementType;

    void Start()
    {
        movementType = 0;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Car Trigger" && hasEntered == false)
        {
            hasEntered = true;
            movementType = 1;
            cinemachine.Follow = car.transform;
            cinemachine.LookAt = car.transform;
            speed = 30;
            turnSpeed = 75;
            transform.parent = car.transform;
            model.SetActive(false);
            controller.enabled = false;
        }
        if (col.name == "Plane Trigger" && hasEntered == false)
        {
            hasEntered = true;
            movementType = 2;
            cinemachine.Follow = plane.transform;
            cinemachine.LookAt = plane.transform;
            speed = 10;
            turnSpeed = 100f;
            transform.parent = plane.transform;
            model.SetActive(false);
            controller.enabled = false;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Car Trigger" && hasEntered == true)
            {
                hasEntered = false;
            }
        if (col.name == "Plane Trigger" && hasEntered == true)
        {
            hasEntered = false;
        }
    }
    void Update()
    {
        moveVector = Vector3.zero;
        if (controller.isGrounded == false && movementType == 0)
        {
            moveVector += Physics.gravity;
        }
        controller.Move(moveVector * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E) && movementType == 1)
        {
            transform.parent = null;
            model.SetActive(true);
            controller.enabled = true;
            movementType = 0;
            cinemachine.Follow = transform;
            cinemachine.LookAt = transform;
            speed = 6f;
            turnSpeed = 10f;
            transform.rotation = Quaternion.Euler(0, 0, 0);


        }

        if (Input.GetKeyDown(KeyCode.E) && movementType == 2)
        {
            transform.parent = null;
            model.SetActive(true);
            controller.enabled = true;
            movementType = 0;
            cinemachine.Follow = transform;
            cinemachine.LookAt = transform;
            speed = 6f;
            turnSpeed = 10f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (movementType == 0)
        {
            turnSmoothTime = 0.1f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f && movementType == 0)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        /*if(direction.magnitude >= 0.1f && movementType == 1)
        {
           // float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
           // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
           // car.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            car.transform.Rotate(Vector3.up, turnSpeed * direction.x * Time.deltaTime);
            car.transform.Translate(Vector3.forward * Time.deltaTime * speed * direction.z);

        }*/

        if(movementType == 2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                plane.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            else
            {
                plane.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            plane.transform.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxisRaw("Jump"));
            plane.transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime * direction.z);
            plane.transform.Rotate(Vector3.up, turnSpeed * direction.x * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 movement = new Vector3(direction.x, 0f, direction.z);

        car.GetComponent<Rigidbody>().AddForce(movement.normalized * speed);
    }
}
