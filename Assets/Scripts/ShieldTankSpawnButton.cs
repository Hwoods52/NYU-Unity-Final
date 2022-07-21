using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShieldTankSpawnButton : Interactable
{
    public Slider slider;
    public GameObject shieldTankPrefab;
    public Transform spawnPoint;
    public bool isReady = true;
    public TextMeshProUGUI shieldFabricatorText;
    protected override void Interact()
    {
        if (isReady)
        {
            slider.gameObject.SetActive(true);
            Instantiate(shieldTankPrefab, spawnPoint.position, shieldTankPrefab.transform.rotation);
            isReady = false;
            StartCoroutine(Printing());
            slider.value = 0;
        }
    }

    private void Update()
    {
        if (isReady)
        {
            slider.gameObject.SetActive(false);
            shieldFabricatorText.text = "Shield Tank Fabricator Ready";
            slider.value = 1;
        }
        else
        {
            
            shieldFabricatorText.text = "Shield Tank Fabricating";
            slider.value += Time.deltaTime * .2f;
        }
    }


    IEnumerator Printing()
    {
        yield return new WaitForSeconds(5);
        isReady = true;
    }
}
