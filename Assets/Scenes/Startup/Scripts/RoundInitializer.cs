using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundInitializer : MonoBehaviour
{

    RoundManager round;
    bool didGameStart = false;

    public string[] microgameNames = {"RightOnTimeGame"};

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false); 
        round = GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeRound() {

        if (didGameStart) {

            return;

        }

        didGameStart = true;

        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsReady", true);

        // Remove the play button.
        GameObject button = transform.Find("Button").gameObject;
        button.GetComponent<AudioSource>().Play();

        // Play the music.
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();

        StartCoroutine(StartGame());

    }

    IEnumerator StartGame() {

        while (round.lives > 0) {

            GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<TextMeshProUGUI>().text = "Your score: " + round.score;

            GameObject.FindGameObjectWithTag("Background").GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            string microgameName = microgameNames.OrderBy(s => Guid.NewGuid()).First();
            SceneManager.LoadScene(microgameName, LoadSceneMode.Single);
            round.timeRemaining = round.defaultTimeRemaining;

            yield return new WaitForSeconds(round.timeRemaining);

            if (round.didCompleteTask) {

                round.score++;
                round.didCompleteTask = false;

            } else {

                GameObject.FindGameObjectWithTag("LoseSoundEffect").GetComponent<AudioSource>().Play();
                round.lives -= 1;

            }

            if (round.lives > 0) {

                yield return new WaitForSeconds(1);

            }

        }

        GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<TextMeshPro>().text = "Your best score: " + round.bestScore;

        GameObject.FindGameObjectWithTag("Background").GetComponent<Image>().color = new Color32(0, 0, 0, 100);
        didGameStart = false;

    }
}
