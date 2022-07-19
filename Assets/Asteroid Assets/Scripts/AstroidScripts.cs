using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AstroidScripts : MonoBehaviour
{
    public float speed;
    private Rigidbody asteroidRb;
    public GameObject ship;
    public float asteroidHealth=4;
    private ShieldManager shieldManager;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        ship = GameObject.Find("Main Wing");
        shieldManager = GameObject.Find("ShieldManager").GetComponent<ShieldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (ship.transform.position - transform.position).normalized;

        asteroidRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Laser"))
        {
            asteroidHealth -= 1;
            Destroy(col.gameObject);
            if(asteroidHealth == 0)
            {
                Destroy(gameObject);
            }
        }
        if (col.CompareTag("Ship"))
        {
            shieldManager.ShieldHit();
            Destroy(gameObject);
        }
    }

}