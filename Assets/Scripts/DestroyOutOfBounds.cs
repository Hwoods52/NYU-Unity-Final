using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundary = 30f;
    private float lowerBoundary = -10;
    private float bottomBoundary = 30f;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z > topBoundary)
        {
            Destroy(gameObject);
        } else if(transform.position.z < lowerBoundary)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
