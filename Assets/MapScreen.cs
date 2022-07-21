using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : MonoBehaviour
{
    public bool isDisplayed;
    public PlayerMovementTutorial playerMovementTutorial;
    public GameObject watch;
    public GameObject reticle;
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isDisplayed)
            {
                playerMovementTutorial.enabled = false;
                watch.SetActive(true);
                reticle.SetActive(false);
                isDisplayed = true;
            }
            else
            {
                playerMovementTutorial.enabled = true;
                watch.SetActive(false);
                reticle.SetActive(true);
                isDisplayed = false;
            }
        }
    }
}
