using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {
    private bool onit = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (onit) transform.position = new Vector3(transform.position.x, transform.position.y-0.01f, transform.position.z);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") onit = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") onit = false;
    }
}
