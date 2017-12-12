using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public int maxPickup = 10;
    public int pickup = 0;

    private Color colorStart = Color.red;
    private Color colorEnd = Color.green;
    private float duration = 1.0F;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if(pickup==maxPickup)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name=="EndSpot" && pickup==maxPickup)
        {
            Debug.Log("ON PORTAL");
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            GameObject player = GameObject.Find("Player");
            PlayerController playerScript = player.GetComponent<PlayerController>();
            playerScript.rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
    }
}
