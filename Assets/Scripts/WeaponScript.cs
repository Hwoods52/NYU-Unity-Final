using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public WeaponTrigger weaponTrigger;
    public GameObject laserPrefab;
    public float fireTime = 0;
    public float fireRate = 0.2f;
    public GameObject shotPosition;
    public Camera mainCamera;
    void Update()
    {
        if(weaponTrigger.activated == true)
        {
            float x = Screen.width / 2;
            float y = Screen.height / 2;
            var ray = mainCamera.ScreenPointToRay(new Vector3(x, y, 0));
            transform.rotation = Quaternion.LookRotation(ray.direction);
            //transform.rotation = new Quaternion(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                fireTime += Time.deltaTime;
                if (fireTime >= fireRate)
                {
                    //Instantiate<GameObject>(laserPrefab, transform.position, transform.localRotation);
                    GameObject laser = Instantiate(laserPrefab, shotPosition.transform.position, shotPosition.transform.rotation);
                    laser.transform.rotation = Quaternion.LookRotation(ray.direction);
                    laser.GetComponent<Rigidbody>().velocity = ray.direction * 80;


                    fireTime = 0;
                }
            }
        }
    }
}
