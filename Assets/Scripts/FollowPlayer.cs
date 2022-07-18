using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject capsulePlayer;
    public float damping = 1;
    public PlayerController playerController;
    private Vector3 carOffset = new Vector3(0, 5, -7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerController.movementType == 0)
        {
            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = capsulePlayer.transform.eulerAngles.y;
            
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = capsulePlayer.transform.position - (rotation * carOffset);

            transform.LookAt(capsulePlayer.transform);
        }
        if (playerController.movementType == 1)
        {
            transform.position = player.transform.position + carOffset;
        }
    }
}
