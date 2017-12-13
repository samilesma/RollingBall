using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerDown : MonoBehaviour {
    private PlayerController playerScript;
    public enum Powers {SlowMotion, Speeder, SunShine, Darkness, Jumper, YouDead};
    public Powers power= Powers.SlowMotion;
    public Text powerDown;
    private Renderer rend;
    private Light light;

    public AudioSource sound; //set in inspector    


    void Start () {
        rend = GetComponent<Renderer>();
        light = GameObject.Find("Directional Light").GetComponent<Light>();
        
        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-100, transform.position.z);
            rend.enabled = false;
            if (power==Powers.SlowMotion)
            {
                powerDown.text = "Slowmotion";
                playerScript.speed = 1;
                StartCoroutine(Delay(4));
            }
            else if(power==Powers.Speeder)
            {
                powerDown.text = "Speedster";
                playerScript.speed = 30;
                StartCoroutine(Delay(4));
            }
            else if (power == Powers.SunShine)
            {
                powerDown.text = "Sunshine";
                light.intensity = 10;
                StartCoroutine(Delay(4));
            }
            else if (power == Powers.Darkness)
            {
                powerDown.text = "Darkness";
                light.intensity = 0.1f;
                StartCoroutine(Delay(4));
                sound.Play(); //play the coin sound
            }
            else if (power == Powers.Jumper)
            {
                powerDown.text = "Jumper";
                playerScript.jumper = true;
                StartCoroutine(Delay(4));
            }
            else if (power == Powers.YouDead) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Delay(int delay)
    {
        Debug.Log("1");
        yield return new WaitForSeconds(delay);
        Debug.Log("2");
        powerDown.text = "";
        if (power == Powers.SlowMotion) playerScript.speed = 11;
        else if (power == Powers.Speeder) playerScript.speed = 11;
        else if (power == Powers.SunShine) light.intensity = 1;
        else if (power == Powers.Darkness) light.intensity = 1;
        else if (power == Powers.Jumper) playerScript.jumper = false;
    }
}
