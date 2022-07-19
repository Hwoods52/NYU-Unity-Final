using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetect : MonoBehaviour
{
    private GameObject bucket;
    private GameObject bDet;
    // Start is called before the first frame update
    void Start()
    {
        bDet = GameObject.Find("bDetect");


    }

    // Update is called once per frame
    void Update()
    {



    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("bDet"))
        {
            Debug.Log("collision");
            Destroy(gameObject);
           
        }
    }
}
