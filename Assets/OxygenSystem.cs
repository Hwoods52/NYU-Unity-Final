using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OxygenSystem : Interactable
{
    public Slider slider;
    public HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            slider.value -= Time.deltaTime * .07f;
        }
        if(slider.value == 0)
        {
            healthManager.playerHealth -= Time.deltaTime * 3;
        }
    }

    protected override void Interact()
    {
        slider.value += .1f;
    }
}
