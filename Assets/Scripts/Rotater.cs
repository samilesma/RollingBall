using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {
    public int x = 0;
    public int y = 0;
    public int z = 0;
    public int speed = 1;
    public bool Negate = false;

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime * speed * (Negate ? -1 : 1));
	}
}
