using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreen;
    public MoveCamera moveCamera;
    public PlayerMovementTutorial playerMovement;
    public AsteroidSpawnManager spawnManager;
    public GameObject mainCanvas;
    public GameObject deathCanvas;
    public MapScreen mapScreen;
    public GameObject watch;

    public float distance;
    public float speed;
    public TextMeshProUGUI shipDistanceScreen;
    public TextMeshProUGUI deathScreenDistance;


    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "SampleScene 1" && !deathCanvas.activeSelf){
            distance += Time.deltaTime * speed;
            Mathf.Round(distance);
            shipDistanceScreen.text = "Distance: " + distance; 
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void PlayerDeath()
    {
        //deathScreen.SetActive(true);
        moveCamera.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        playerMovement.enabled = false;
        spawnManager.enabled = false;
        mapScreen.enabled = false;
        watch.SetActive(false);
        mainCanvas.SetActive(false);
        deathScreenDistance.text = "Distance: " + distance;
        deathCanvas.SetActive(true);

    }
}
