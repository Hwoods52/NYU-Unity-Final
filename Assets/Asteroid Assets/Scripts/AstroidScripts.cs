using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AstroidScripts : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float speed;
    private Rigidbody asteroidRb;
    public GameObject ship;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        ship = GameObject.Find("Main Wing");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (ship.transform.position - transform.position).normalized;

        asteroidRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject)
        {
            Debug.Log("collision");
            UpdateScore(2);
            Destroy(gameObject);
        }

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "amogus:" + score;
    }
}