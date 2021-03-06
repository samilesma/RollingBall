﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour {
    public int[] maxPicks = new int[] {12,8,5,4,7,3};
    public int pickup = 0;

    private Color colorStart = Color.red;
    private Color colorEnd = Color.green;
    private float duration = 1.0F;
    private Renderer rend;
    private bool disco = false;
    private bool allowedPortal = true;
    private PlayerController playerScript;
    private CameraController cameraScript;
    private CountDown countdown;

    void Start()
    {
        rend = GetComponent<Renderer>();

        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        GameObject camera = GameObject.Find("Main Camera");
        cameraScript = camera.GetComponent<CameraController>();
        GameObject count = GameObject.Find("CountDown");
        countdown = count.GetComponent<CountDown>();
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        if (pickup==maxPicks[playerScript.getLevel()])
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
        if(disco)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            playerScript.rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);

            playerScript.movement = false;
            playerScript.transform.position = new Vector3(transform.position.x+transform.localScale.x/2, playerScript.transform.position.y, transform.position.z+transform.localScale.z/2);
            if(allowedPortal) StartCoroutine(portal());
        }
    }

    IEnumerator portal()
    {
        countdown.gameEnded = true;
        allowedPortal = false;
        yield return new WaitForSeconds(1);
        cameraScript.active = false;
        playerScript.rb.AddForce(0, 100, 0, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        playerScript.setLevel();
        playerScript.reset();
        SceneManager.LoadScene("Level " + playerScript.getLevel());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && pickup == maxPicks[playerScript.getLevel()]) disco = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") disco = false;
    }
}
