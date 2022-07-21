using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
    //public WeaponRay weaponRay;
    private void Awake()
    {
        //weaponRay = GameObject.Find("Right Weapon Shoot").GetComponent<WeaponRay>();
        //transform.LookAt(weaponRay.ray1.GetPoint(100));
    }
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
