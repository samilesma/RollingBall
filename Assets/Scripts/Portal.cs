using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    public int maxPickup = 10;
    public int pickup = 0;

    private Color colorStart = Color.red;
    private Color colorEnd = Color.green;
    private float duration = 1.0F;
    private Renderer rend;
    private bool disco = false;
    private bool allowedPortal = true;

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
        if(disco)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            GameObject player = GameObject.Find("Player");
            PlayerController playerScript = player.GetComponent<PlayerController>();
            playerScript.rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);

            playerScript.movement = false;
            playerScript.transform.position = new Vector3(transform.position.x+transform.localScale.x/2, playerScript.transform.position.y, transform.position.z+transform.localScale.z/2);
            if(allowedPortal) StartCoroutine(portal());
        }
    }

    IEnumerator portal()
    {
        allowedPortal = false;

        yield return new WaitForSeconds(1);

        GameObject camera = GameObject.Find("Main Camera");
        CameraController cameraScript = camera.GetComponent<CameraController>();
        cameraScript.active = false;

        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        playerScript.rb.AddForce(0, 100, 0, ForceMode.Impulse);

        yield return new WaitForSeconds(1);

        playerScript.level++;
        SceneManager.LoadScene("Level " + playerScript.level, LoadSceneMode.Additive);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && pickup == maxPickup) disco = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player") disco = false;
    }
}
