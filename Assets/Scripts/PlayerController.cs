using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public int forceConst = 5;
    public float speed=11;
	public int jump = 5;
    public Text countText;
    public Text winText;
    public float maxSpeed=50;
    public int count;
    public Renderer rend;
    public Rigidbody rb;
    public int level = 0;
    private bool spacedown=false;
    private bool isGrounded = true;
    public string scene;
    public bool movement = true;
    private Spawn Spawn;
    public bool jumper = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";

        GameObject portal = GameObject.Find("EndSpot");
        Spawn = portal.GetComponent<Spawn>();
    }

    private void FixedUpdate()
    {
        if (movement)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            if (rb.velocity.magnitude > maxSpeed) rb.velocity = rb.velocity.normalized * maxSpeed;
            rb.AddForce(movement * speed);
        }

        if (GameObject.Find("Player").transform.position.y<-1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if((spacedown || jumper) && isGrounded) rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")) 
        {
            other.gameObject.SetActive(false);
            Spawn.pickup++;
            count++;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) spacedown = true;
        else if(Input.GetKeyUp(KeyCode.Space)) spacedown = false;

        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void reset()
    {
        Spawn.pickup = 0;
        count = 0;
    }
}
