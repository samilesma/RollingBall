/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip clipOne;
    public AudioClip clipTwo;
    public AudioClip clipThree;
    public PowerDown powerDown;
    private AudioClip clipToPlay;

    void Start()
    {

        GameObject powerD = GameObject.Find("PowerDown");
        powerDown = powerD.GetComponent<PowerDown>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PowerDown")) {
            if (powerDown.power == powerDown.Powers.Darkness)
            {
                clipToPlay = clipOne;
            }
        }
        
        playSound();
    }

    private void playSound()
    {
        audioSource.PlayOneShot(clipToPlay);
    }
}
*/
using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    public AudioSource coinSound; //set in inspector    

    void OnTriggerEnter(Collider other)  // other is a reference to the other trigger collider we have touched
    {
        if (other.gameObject.tag == "Ball") //or you could do other.gameObject.name == "Player"
        {
            coinSound.Play(); //play the coin sound
        }
    }
}