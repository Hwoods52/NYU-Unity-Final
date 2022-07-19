using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldManager : MonoBehaviour
{
    public float shieldHealth = 10;
    public bool shieldsOn = true;
    [SerializeField]
    private TextMeshProUGUI shieldText;
    // Start is called before the first frame update
    void Start()
    {
        shieldText.text = "Shield Health = " + shieldHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShieldHit()
    {
        shieldHealth -= 1;
        shieldText.text = "Shield Health = " + shieldHealth;
    }
}
