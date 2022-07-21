using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    public bool activated = false;
    public GameObject reticle;
    //public WeaponScript weaponScript;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player")
        {
            activated = true;
            reticle.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.parent.name == "Player")
        {
            activated = false;
            reticle.SetActive(true);
        }
    }
}
