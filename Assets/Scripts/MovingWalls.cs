using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;
    public int distance = 3;
	public char pos;
    // Use this for initialization
    void Start()
    {
		if (pos == 'y') {
			min = transform.position.y;
			max = transform.position.y + distance;
		} else if (pos == 'x') {
			min = transform.position.x;
			max = transform.position.x + distance;
		} else if (pos == 'z') {
			min = transform.position.z;
			max = transform.position.z + distance;
		}


    }

    // Update is called once per frame
    void Update()
    {
		if (pos == 'y') {
			transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.z);
		} 
		else if (pos == 'x') {
			transform.position = new Vector3( Mathf.PingPong(Time.time * 2, max - min) + min , transform.position.y, transform.position.z);
		} 
		else if (pos == 'z') {
			transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
		}
    }


}
