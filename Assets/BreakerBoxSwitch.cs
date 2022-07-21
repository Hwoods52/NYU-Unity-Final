using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxSwitch : Interactable
{
    public bool switchOn = false;
    public GameObject switchKnobOff;
    public GameObject switchKnobOn;

    private void Start()
    {
        switchKnobOff = gameObject.transform.GetChild(0).gameObject;
        switchKnobOn = gameObject.transform.GetChild(1).gameObject;
        switchKnobOn.SetActive(false);
    }
    protected override void Interact()
    {
        if (switchOn)
        {
            switchOn = false;
            switchKnobOff.SetActive(true);
            switchKnobOn.SetActive(false);
        }
        else if (!switchOn)
        {
            switchOn = true;
            switchKnobOff.SetActive(false);
            switchKnobOn.SetActive(true);
        }
    }
}
