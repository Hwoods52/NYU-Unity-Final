using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HyperdriveManager : Interactable
{
    public Slider slider;
    public float speed;
    public bool isInteracting = false;
    public GameObject player;
    public GameObject cam;
    public Transform cameraPosition;
    public AsteroidSpawnManager asteroidSpawnManager;
    public OxygenSystem oxygenSystem;
    public ParticleSystem hyperdriveParticles;
    public Material normal;
    public Material hyperdrive;
    public GameManager gameManager;

    protected override void Interact()
    {
        if (isInteracting)
        {
            isInteracting = false;
            slider.value = 0;
            player.GetComponent<PlayerMovementTutorial>().enabled = true;
          // player.GetComponentInChildren<MeshRenderer>().enabled = true;
            cam.GetComponent<MoveCamera>().enabled = true;
            cam.GetComponent<Camera>().fieldOfView = 90;
        }
        else
        {
            isInteracting = true;
            player.GetComponent<PlayerMovementTutorial>().enabled = false;
//            player.GetComponentInChildren<MeshRenderer>().enabled = false;
            cam.GetComponent<MoveCamera>().enabled = false;
            cam.transform.rotation = cameraPosition.rotation;
            cam.transform.position = cameraPosition.position;
            cam.GetComponent<Camera>().fieldOfView = 60;
        }
        
    }
    public void Start()
    {
        hyperdriveParticles.Stop();
        RenderSettings.skybox = normal;
    }
    public void Update()
    {
        if(slider.value == 1)
        {
            StartCoroutine(Hyperdrive());
            slider.value = 0;
            slider.gameObject.SetActive(false);
            Interact();

        }
        if (isInteracting)
        {
            slider.value += Time.deltaTime * speed;
        }
    }
    IEnumerator Hyperdrive()
    {
        RenderSettings.skybox = hyperdrive;
        hyperdriveParticles.Play();
        asteroidSpawnManager.StopAllCoroutines();
        oxygenSystem.isSafe = true;
        gameManager.speed = 30;
        yield return new WaitForSeconds(15);
        RenderSettings.skybox = normal;
        gameManager.speed = 10;
        StartCoroutine(asteroidSpawnManager.SpawnAsteroid());
        hyperdriveParticles.Stop();
        asteroidSpawnManager.enabled = true;
        oxygenSystem.isSafe = false;
        slider.gameObject.SetActive(true);
    }
}
