using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {
    private bool isWalled = false;
    private bool spacedown = false;
    public int jump = 8;
    public bool jumper = false;
    public enum Force {X,Z};
    public Force direction = Force.X;
    public bool negativeDirection = false;
    private PlayerController playerScript;

    void Start () {
        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        int x=direction==Force.X?negativeDirection?-jump: jump : 0, y=jump, z= direction == Force.Z ? negativeDirection ? -jump : jump : 0;
        if ((spacedown || jumper) && isWalled) playerScript.rb.AddForce(x,y,z, ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) spacedown = true;
        else if (Input.GetKeyUp(KeyCode.Space)) spacedown = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") isWalled = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") isWalled = false;
    }


}
