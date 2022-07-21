using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRay : MonoBehaviour
{
    public float distance;
    public LayerMask mask;
    public GameObject laserPrefab;
    public float fireRate = 0.2f;
    public float fireTime = 0;
    public Ray ray1;
    public void Update()
    {
        ray1 = new Ray(transform.position, -transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray1, out hitInfo, distance, mask))
        {

            Debug.Log("shoot ray");
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireTime += Time.deltaTime;
            if (fireTime >= fireRate)
            {
                Instantiate<GameObject>(laserPrefab, transform.position, transform.localRotation);
                fireTime = 0;
            }
        }

    }
}
