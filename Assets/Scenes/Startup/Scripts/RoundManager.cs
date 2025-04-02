using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{

    public int bestScore = 0;
    public int score = 0;
    public int lives = 3;
    public bool didCompleteTask = false;
    public float timeRemaining = 0;
    public float defaultTimeRemaining = 5;
    public bool isReducingTime = false;

    public GameObject lifePrefab;

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

    void RefreshLives() {

        GameObject lifeParent = GameObject.FindGameObjectWithTag("Lives");

        foreach (Transform child in lifeParent.transform) {

            Destroy(child.gameObject);

        }

        for (int i = 0; lives > i; i++) {

            GameObject lifeImage = Instantiate(lifePrefab);
            lifeImage.transform.SetParent(lifeParent.transform);

        }

    }

    IEnumerator ReduceTime() {

        while (timeRemaining > 0) {

            isReducingTime = true;

            yield return new WaitForSeconds(0.1f);
            RefreshLives();

            timeRemaining -= 0.1f;

            int minute = (int) Math.Floor((defaultTimeRemaining - timeRemaining) / defaultTimeRemaining * 59);
            GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text = "11:" + (minute < 10 ? "0" + minute : minute) + " PM";

        }

        RefreshLives();

        isReducingTime = false;
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>().text = "12:00 AM";

    }
}
