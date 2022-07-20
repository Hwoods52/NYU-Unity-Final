using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    public GameObject bucket;
    public int ballin;
    public GameObject waterSphere;
    public Vector3 offset = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        //bucket = GameObject.Find("Bucket");
        ballin = 0;
        spawner();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawner()
    {
        while(ballin < 1)
        {
            Debug.Log("ballin");
            Instantiate(waterSphere, bucket.transform.position + offset, waterSphere.transform.rotation);
            ballin++;
        }
        
    }
}
