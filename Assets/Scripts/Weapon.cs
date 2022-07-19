using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform playerCamera;
    float yRotation;
    float xRotation;
    public MoveCamera moveCamera;
    public float xOffset;
    public float yOffset;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 200;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 200;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, moveCamera.xMin, moveCamera.xMax) ;
        yRotation = Mathf.Clamp(yRotation, moveCamera.yMin, moveCamera.yMax);
        transform.rotation = Quaternion.Euler(-xRotation+xOffset, yRotation+yOffset, 0);

    }
}
