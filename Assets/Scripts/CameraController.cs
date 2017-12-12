﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public bool active = true;
    private Vector3 offset;
    
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(active) transform.position = player.transform.position + offset;
	}
}
