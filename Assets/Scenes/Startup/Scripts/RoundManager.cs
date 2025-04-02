using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public int bestScore = 0;
    public int score = 0;
    public int lives = 3;
    public bool didCompleteTask = false;
    public float timeRemaining = 0;
    public float defaultTimeRemaining = 5;
    public bool isReducingTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isReducingTime) {

            return;

        }

        StartCoroutine(ReduceTime());
            
    }

    IEnumerator ReduceTime() {

        while (timeRemaining > 0) {

            isReducingTime = true;

            yield return new WaitForSeconds(0.1f);

            timeRemaining -= 0.1f;

            int minute = (int) Math.Floor(((defaultTimeRemaining - timeRemaining) / defaultTimeRemaining) * 59);
            GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text = "11:" + (minute < 10 ? "0" + minute : minute) + " PM";

        }

        isReducingTime = false;
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text = "12:00 AM";

    }
}
