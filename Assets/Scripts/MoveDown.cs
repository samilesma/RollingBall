using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {
    private bool onit = false;
    public enum Directions {X,Y,Z};
    public Directions Direction = Directions.X;
    public bool Negate = false;
    public GameObject Object;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (onit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            Object.transform.position = new Vector3(
                Object.transform.position.x + (Direction == Directions.X ? 0.1f : 0),
                Object.transform.position.y + (Direction == Directions.Y ? 0.1f : 0),
                Object.transform.position.z + (Direction == Directions.Z ? 0.1f : 0)
            );
        }
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
