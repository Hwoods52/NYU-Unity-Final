using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    public bool activated = false;
    public WeaponScript weaponScript;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player")
        {
            Debug.Log("test");
            activated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.parent.name == "Player")
        {
            activated = false;
        }
    }
}
