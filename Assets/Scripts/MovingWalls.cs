using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;
    public int distance = 3;
    // Use this for initialization
    void Start()
    {

        min = transform.position.z;
        max = transform.position.z + distance;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
    }


}
