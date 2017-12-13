using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject tpObject;
    private float timer = 1.0f;
    private bool justCameOut = false;
    // Use this for initialization


    
    void OnTriggerEnter(Collider collider)
    {
            tpObject.transform.position = spawnPoint.position;
    }
}
