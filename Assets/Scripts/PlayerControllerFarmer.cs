using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFarmer : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 10;
    public GameObject projectilePrefab;


    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch the food
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.x < -xRange ){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    }
}
