using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class CountDown : MonoBehaviour {
    //public float timeLeft = 30.0f;
    public int timeLeft = 10;
    public Text countDownText;
    public bool gameEnded = false;
    // Use this for initialization
    void Start () {
        StartCoroutine("LoseTime");
	}

    void Update()
    {
        // timeLeft -= Time.deltaTime;

        countDownText.text = ("Time Left:" + timeLeft+ "s");
        if (timeLeft <= 5)
        {
            countDownText.color = new Color(229.0f / 255.0f, 45.0f / 255.0f, 33.0f / 255.0f);
        }
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator LoseTime()
    {
        while (!gameEnded)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
