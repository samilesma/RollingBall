using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public float x1 = 0;
    public float y1 = 0;
    public float z1 = 0;
    public float x2 = 0;
    public float y2 = 0;
    public float z2 = 0;
    public float seconds = 1f;
    public bool repeat = true;
    public bool reverse = true;
    private bool reversing = false;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(x1, y1, z1);
    }
	
	// Update is called once per frame
	void Update () {
        if (((transform.position.x < x2 && x2 > x1) || (transform.position.x > x2 && x2 < x1)) && !reversing)
        {
            transform.Translate(
                -(y2 - y1) / seconds * Time.deltaTime,
                -(x2 - x1) / seconds * Time.deltaTime,
                -(z2 - z1) / seconds * Time.deltaTime
            );
        }
        else if (((transform.position.x > x1 && x2 > x1) || (transform.position.x < x1 && x2 < x1)) && reversing)
        {
            transform.Translate(
                (y2 - y1) / seconds * Time.deltaTime,
                (x2 - x1) / seconds * Time.deltaTime,
                (z2 - z1) / seconds * Time.deltaTime
            );
        }
        else
        {
            if (reverse) reversing = !reversing;
            else if (repeat) transform.position = new Vector3(x1, y1, z1);
        }
	}
}
