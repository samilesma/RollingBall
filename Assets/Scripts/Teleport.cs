using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject tpObject;
    
    void OnTriggerEnter(Collider collider)
    {
            tpObject.transform.position = spawnPoint.position;
    }
}
