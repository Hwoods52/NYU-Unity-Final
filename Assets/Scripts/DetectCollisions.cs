using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
            Destroy(gameObject);
            Destroy(col.gameObject);
    }
}
